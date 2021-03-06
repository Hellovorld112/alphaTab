﻿using AlphaTab.Collections;
using AlphaTab.Model;
using AlphaTab.Platform;
using AlphaTab.Rendering.Staves;

namespace AlphaTab.Rendering.Glyphs
{
    internal class BeatContainerGlyph : Glyph
    {
        public VoiceContainerGlyph VoiceContainer { get; set; }

        public Beat Beat { get; set; }
        public BeatGlyphBase PreNotes { get; set; }
        public BeatOnNoteGlyphBase OnNotes { get; set; }
        public FastList<Glyph> Ties { get; set; }

        public float MinWidth { get; set; }
        public float OnTimeX => OnNotes.X + OnNotes.CenterX;


        public BeatContainerGlyph(Beat beat, VoiceContainerGlyph voiceContainer)
            : base(0, 0)
        {
            Beat = beat;
            Ties = new FastList<Glyph>();
            VoiceContainer = voiceContainer;
        }

        public virtual void RegisterLayoutingInfo(BarLayoutingInfo layoutings)
        {
            var preBeatStretch = OnTimeX;
            var postBeatStretch = 0f;
            foreach (var tie in Ties)
            {
                if (tie.Width > postBeatStretch)
                {
                    postBeatStretch = tie.Width;
                }
            }

            postBeatStretch += OnNotes.X + (OnNotes.Width - OnNotes.CenterX);

            layoutings.AddBeatSpring(Beat, preBeatStretch, postBeatStretch);
            // store sizes for special renderers like the EffectBarRenderer
            layoutings.SetPreBeatSize(Beat, PreNotes.Width);
            layoutings.SetOnBeatSize(Beat, OnNotes.Width);
            layoutings.SetBeatCenterX(Beat, OnNotes.CenterX);
        }

        public virtual void ApplyLayoutingInfo(BarLayoutingInfo info)
        {
            var offset = info.GetBeatCenterX(Beat) - OnNotes.CenterX;
            PreNotes.X = offset;
            PreNotes.Width = info.GetPreBeatSize(Beat);
            OnNotes.Width = info.GetOnBeatSize(Beat);
            OnNotes.X = PreNotes.X + PreNotes.Width;
            OnNotes.UpdateBeamingHelper();
        }

        public override void DoLayout()
        {
            PreNotes.X = 0;
            PreNotes.Renderer = Renderer;
            PreNotes.Container = this;
            PreNotes.DoLayout();

            OnNotes.X = PreNotes.X + PreNotes.Width;
            OnNotes.Renderer = Renderer;
            OnNotes.Container = this;
            OnNotes.DoLayout();
            var i = Beat.Notes.Count - 1;
            while (i >= 0)
            {
                CreateTies(Beat.Notes[i--]);
            }

            UpdateWidth();
        }

        protected virtual void UpdateWidth()
        {
            MinWidth = PreNotes.Width + OnNotes.Width;
            if (!Beat.IsRest)
            {
                if (OnNotes.BeamingHelper.Beats.Count == 1)
                {
                    // make space for footer 
                    if (Beat.Duration >= Duration.Eighth)
                    {
                        MinWidth += 20 * Scale;
                    }
                }
                else
                {
                    // ensure some space for small notes
                    switch (Beat.Duration)
                    {
                        case Duration.OneHundredTwentyEighth:
                        case Duration.TwoHundredFiftySixth:
                            MinWidth += 10 * Scale;
                            break;
                    }
                }
            }

            var tieWidth = 0f;
            foreach (var tie in Ties)
            {
                if (tie.Width > tieWidth)
                {
                    tieWidth = tie.Width;
                }
            }

            MinWidth += tieWidth;


            Width = MinWidth;
        }

        public virtual void ScaleToWidth(float beatWidth)
        {
            foreach (var tie in Ties)
            {
                tie.DoLayout();
            }

            OnNotes.UpdateBeamingHelper();
            Width = beatWidth;
        }

        protected virtual void CreateTies(Note n)
        {
        }

        public static string GetGroupId(Beat beat)
        {
            return "b" + beat.Id;
        }

        public override void Paint(float cx, float cy, ICanvas canvas)
        {
            if (Beat.Voice.IsEmpty)
            {
                return;
            }

            var isEmptyGlyph = PreNotes.IsEmpty && OnNotes.IsEmpty && Ties.Count == 0;
            if (isEmptyGlyph)
            {
                return;
            }

            canvas.BeginGroup(GetGroupId(Beat));

            //var c = canvas.Color;
            //var ta = canvas.TextAlign;
            //canvas.Color = new Color(255, 0, 0);
            //canvas.TextAlign = TextAlign.Left;
            //canvas.FillText(Beat.DisplayStart.ToString(), cx + X, cy + Y - 10);
            //canvas.Color = c;
            //canvas.TextAlign = ta;

            //canvas.Color = Color.Random();
            //canvas.FillRect(cx + X, cy + Y, Width, Renderer.Height);

            //var oldColor = canvas.Color;
            //canvas.Color = new Color((byte)Platform.Platform.Random(255), (byte)Platform.Platform.Random(255), (byte)Platform.Platform.Random(255), 100);
            //canvas.FillRect(cx + X, cy + Y, Width, Renderer.Height);
            //canvas.Color = oldColor;

            //canvas.Color = new Color(200, 0, 0, 100);
            //canvas.StrokeRect(cx + X, cy + Y + 15 * Beat.Voice.Index, Width, 10);
            //canvas.Font = new Font("Arial", 10);
            //canvas.Color = new Color(0, 0, 0);
            //canvas.FillText(Beat.Voice.Index + ":" + Beat.Index, cx + X, cy + Y + 15 * Beat.Voice.Index);

            //if (Beat.Voice.Index == 0)
            //{
            //    canvas.Color = new Color(200, 0, 0, 100);
            //    canvas.StrokeRect(cx + X, cy + Y + PreNotes.Y + 30, Width, 10);
            //}

            PreNotes.Paint(cx + X, cy + Y, canvas);
            //if (Beat.Voice.Index == 0)
            //{
            //    canvas.Color = new Color(200, 0, 0, 100);
            //    canvas.StrokeRect(cx + X + PreNotes.X, cy + Y + PreNotes.Y, PreNotes.Width, 10);
            //}
            OnNotes.Paint(cx + X, cy + Y, canvas);
            //if (Beat.Voice.Index == 0)
            //{
            //    canvas.Color = new Color(0, 200, 0, 100);
            //    canvas.StrokeRect(cx + X + OnNotes.X, cy + Y + OnNotes.Y + 10, OnNotes.Width, 10);
            //}

            // paint the ties relative to the whole staff, 
            // reason: we have possibly multiple staves involved and need to calculate the correct positions.
            var staffX = cx - VoiceContainer.X - Renderer.X;
            var staffY = cy - VoiceContainer.Y - Renderer.Y;

            for (int i = 0, j = Ties.Count; i < j; i++)
            {
                var t = Ties[i];
                t.Renderer = Renderer;
                t.Paint(staffX, staffY, canvas);
            }

            canvas.EndGroup();
        }
    }
}
