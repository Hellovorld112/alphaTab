﻿using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using AlphaTab.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlphaTab.Test.Importer
{
    [TestClass]
    public class MusicXmlImporterTestSuiteTests : MusicXmlImporterTestBase
    {
        [TestMethod, AsyncTestMethod]
        public void Test_01a_Pitches_Pitches()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_01b_Pitches_Intervals()
        {
            TestReference(renderLayout: "horizontal");
        }

        [TestMethod, AsyncTestMethod]
        public void Test_01c_Pitches_NoVoiceElement()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_01d_Pitches_Microtones()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_01e_Pitches_ParenthesizedAccidentals()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_01f_Pitches_ParenthesizedMicrotoneAccidentals()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_02a_Rests_Durations()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_02b_Rests_PitchedRests()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_02c_Rests_MultiMeasureRests()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_02d_Rests_Multimeasure_TimeSignatures()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_02e_Rests_NoType()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_03a_Rhythm_Durations()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_03b_Rhythm_Backup()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_03c_Rhythm_DivisionChange()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_03d_Rhythm_DottedDurations_Factors()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_11a_TimeSignatures()
        {
            TestReference(callback: score =>
            {
                Assert.IsTrue(score.MasterBars[0].TimeSignatureCommon);
                Assert.IsTrue(score.MasterBars[1].TimeSignatureCommon);
            });
        }

        [TestMethod, AsyncTestMethod]
        public void Test_11b_TimeSignatures_NoTime()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_11c_TimeSignatures_CompoundSimple()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_11d_TimeSignatures_CompoundMultiple()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_11e_TimeSignatures_CompoundMixed()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_11f_TimeSignatures_SymbolMeaning()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_11g_TimeSignatures_SingleNumber()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_11h_TimeSignatures_SenzaMisura()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_12a_Clefs()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_12b_Clefs_NoKeyOrClef()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_13a_KeySignatures()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_13b_KeySignatures_ChurchModes()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_13c_KeySignatures_NonTraditional()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_13d_KeySignatures_Microtones()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_14a_StaffDetails_LineChanges()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_21a_Chord_Basic()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_21b_Chords_TwoNotes()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_21c_Chords_ThreeNotesDuration()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_21d_Chords_SchubertStabatMater()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_21e_Chords_PickupMeasures()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_21f_Chord_ElementInBetween()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_22a_Noteheads()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_22b_Staff_Notestyles()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_22c_Noteheads_Chords()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_22d_Parenthesized_Noteheads()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_23a_Tuplets()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_23b_Tuplets_Styles()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_23c_Tuplet_Display_NonStandard()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_23d_Tuplets_Nested()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_23e_Tuplets_Tremolo()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_23f_Tuplets_DurationButNoBracket()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_24a_GraceNotes()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_24b_ChordAsGraceNote()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_24c_GraceNote_MeasureEnd()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_24d_AfterGrace()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_24e_GraceNote_StaffChange()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_24f_GraceNote_Slur()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_31a_Directions()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_31c_MetronomeMarks()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_32a_Notations()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_32b_Articulations_Texts()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_32c_MultipleNotationChildren()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_32d_Arpeggio()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_33a_Spanners()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_33b_Spanners_Tie()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_33c_Spanners_Slurs()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_33d_Spanners_OctaveShifts()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_33e_Spanners_OctaveShifts_InvalidSize()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_33f_Trill_EndingOnGraceNote()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_33g_Slur_ChordedNotes()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_33h_Spanners_Glissando()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_33i_Ties_NotEnded()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_41a_MultiParts_Partorder()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_41b_MultiParts_MoreThan10()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_41c_StaffGroups()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_41d_StaffGroups_Nested()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_41e_StaffGroups_InstrumentNames_Linebroken()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_41f_StaffGroups_Overlapping()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_41g_PartNoId()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_41h_TooManyParts()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_41i_PartNameDisplay_Override()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_42a_MultiVoice_TwoVoicesOnStaff_Lyrics()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_42b_MultiVoice_MidMeasureClefChange()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_43a_PianoStaff()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_43b_MultiStaff_DifferentKeys()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_43c_MultiStaff_DifferentKeysAfterBackup()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_43d_MultiStaff_StaffChange()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_43e_Multistaff_ClefDynamics()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_45a_SimpleRepeat()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_45b_RepeatWithAlternatives()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_45c_RepeatMultipleTimes()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_45d_Repeats_Nested_Alternatives()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_45e_Repeats_Nested_Alternatives()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_45f_Repeats_InvalidEndings()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_45g_Repeats_NotEnded()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_46a_Barlines()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_46b_MidmeasureBarline()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_46c_Midmeasure_Clef()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_46d_PickupMeasure_ImplicitMeasures()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_46e_PickupMeasure_SecondVoiceStartsLater()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_46f_IncompleteMeasures()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_46g_PickupMeasure_Chordnames_FiguredBass()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_51b_Header_Quotes()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_51c_MultipleRights()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_51d_EmptyTitle()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_52a_PageLayout()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_52b_Breaks()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_61a_Lyrics()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_61b_MultipleLyrics()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_61c_Lyrics_Pianostaff()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_61d_Lyrics_Melisma()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_61e_Lyrics_Chords()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_61f_Lyrics_GracedNotes()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_61g_Lyrics_NameNumber()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_61h_Lyrics_BeamsMelismata()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_61i_Lyrics_Chords()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_61j_Lyrics_Elisions()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_61k_Lyrics_SpannersExtenders()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_71a_Chordnames()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_71c_ChordsFrets()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_71d_ChordsFrets_Multistaff()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_71e_TabStaves()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_71f_AllChordTypes()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_71g_MultipleChordnames()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_72a_TransposingInstruments()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_72b_TransposingInstruments_Full()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_72c_TransposingInstruments_Change()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_73a_Percussion()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_74a_FiguredBass()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_75a_AccordionRegistrations()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_99a_Sibelius5_IgnoreBeaming()
        {
            TestReference();
        }

        [TestMethod, AsyncTestMethod]
        public void Test_99b_Lyrics_BeamsMelismata_IgnoreBeams()
        {
            TestReference();
        }

        private void TestReference([CallerMemberName] string caller = null, string renderLayout = "page", Action<Score> callback = null)
        {
#if !PHASE
            var fileId = caller.Split('_')[1];
            const string path = "TestFiles/MusicXmlTestSuite";
            var file = Directory.EnumerateFiles(path, "*.xml").FirstOrDefault(f => f.Contains(fileId));
            TestReferenceFile(file, score =>
            {
                if (callback != null)
                {
                    callback(score);
                }
            }, renderLayout);
#else
            callback(null); // TODO: how to find testfile on JS
#endif
        }
    }
}
