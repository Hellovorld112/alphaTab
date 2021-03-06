﻿using System;
using AlphaTab.Haxe.Js;
using AlphaTab.Haxe.Js.Html;
using AlphaTab.Platform;

namespace AlphaTab.UI
{
    internal class HtmlElementContainer : IContainer
    {
        public float Top
        {
            get => Platform.Platform.ParseFloat(Element.Style.Top);
            set
            {
                var x = value + "px";
                Element.Style.Top = x;
            }
        }

        public float Left
        {
            get => Platform.Platform.ParseFloat(Element.Style.Top);
            set
            {
                var x = value + "px";
                Element.Style.Left = x;
            }
        }

        public float Width
        {
            get => Element.OffsetWidth;
            set
            {
                var x = value + "px";
                Element.Style.Width = x;
            }
        }

        public float ScrollLeft
        {
            get => Element.ScrollLeft;
            set => Element.ScrollTop = (int)value;
        }

        public float ScrollTop
        {
            get => Element.ScrollLeft;
            set => Element.ScrollTop = (int)value;
        }

        public float Height
        {
            get => Element.OffsetHeight;
            set
            {
                if (value >= 0)
                {
                    Element.Style.Height = value + "px";
                }
                else
                {
                    Element.Style.Height = "100%";
                }
            }
        }

        public bool IsVisible =>
            Element.OffsetWidth.IsTruthy() || Element.OffsetHeight.IsTruthy() ||
            Element.GetClientRects().Length.IsTruthy();

        public Element Element { get; }

        public HtmlElementContainer(Element element)
        {
            Element = element;
        }

        public void StopAnimation()
        {
            Element.Style.Transition = "none";
        }

        public void TransitionToX(double duration, float x)
        {
            Element.Style.Transition = "all 0s linear";
            Element.Style.TransitionDuration = duration + "ms";
            Element.Style.Left = x + "px";
        }

        public event Action<IMouseEventArgs> MouseDown
        {
            add
            {
                Element.AddEventListener("mousedown",
                    (Action<Event>)(e => { value(new BrowserMouseEventArgs((MouseEvent)e)); }),
                    true);
            }
            remove { }
        }

        public event Action<IMouseEventArgs> MouseMove
        {
            add
            {
                Element.AddEventListener("mousemove",
                    (Action<Event>)(e => { value(new BrowserMouseEventArgs((MouseEvent)e)); }),
                    true);
            }
            remove { }
        }

        public event Action<IMouseEventArgs> MouseUp
        {
            add
            {
                Element.AddEventListener("mouseup",
                    (Action<Event>)(e => { value(new BrowserMouseEventArgs((MouseEvent)e)); }),
                    true);
            }
            remove { }
        }

        public void Clear()
        {
            Element.InnerHTML = "";
        }

        public void AppendChild(IContainer child)
        {
            Element.AppendChild(((HtmlElementContainer)child).Element);
        }

        public event Action Scroll
        {
            add => Browser.Window.AddEventListener("scroll", value, true);
            remove => Browser.Window.RemoveEventListener("scroll", value, true);
        }

        public event Action Resize
        {
            add => Browser.Window.AddEventListener("resize", value, true);
            remove => Browser.Window.RemoveEventListener("resize", value, true);
        }
    }
}
