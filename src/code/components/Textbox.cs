﻿using Raylib_cs;
using System.Numerics;

namespace RayGUI_cs
{
    public delegate void ParamEvent(string[] args, string value);

    /// <summary>Textbox component of the library</summary>
    public class Textbox : Component
    {
        private int fontSize;
        private string text;

        public ParamEvent? OnEntry;
        public string[] Args;
        public Color TextColor;

        /// <summary>Text size in pixels.</summary>
        internal Vector2 TextSize;

        /// <summary>Displayed text on the textbox.</summary>
        public string Text { get { return text; }
            set
            {
                text = value;
                TextSize = Raylib.MeasureTextEx(RayGUI.Font, text, FontSize, 1);
            }
        }

        /// <summary>Font size of the buttons's text.</summary>
        public int FontSize
        {
            get { return fontSize; }
            set
            {
                fontSize = value;
                TextSize = Raylib.MeasureTextEx(RayGUI.Font, Text, fontSize, 1);
            }
        }
        // Internal values
        internal bool _focus;
        internal double DeltaBack;
        public bool Focus { get { return _focus; } }


        /// <summary>Initializes a new instance of a <see cref="Textbox"/> object.</summary>
        /// <param name="x">X position of the textbox</param>
        /// <param name="y">Y position of the textbox</param>
        /// <param name="width">Width of the textbox</param>
        /// <param name="height"">Height of the textbox</param>
        /// <param name="text">Initial text of the textbox</param>
        public Textbox(int x, int y, int width, int height, string text) : base(x, y, width, height)
        {
            this.text = text;
            FontSize = RayGUI.DEFAULT_FONT_SIZE;
            TextColor = Color.White;
            // Interaction assignment
            _focus = false;
            DeltaBack = 0.0;
            Args = new string[2];
        }

        /// <summary>Initializes a new instance of a <see cref="Textbox"/> object.</summary>
        /// <param name="x">X position of the textbox</param>
        /// <param name="y">Y position of the textbox</param>
        /// <param name="width">Width of the textbox</param>
        /// <param name="height"">Height of the textbox</param>
        /// <param name="text">Initial text of the textbox</param>
        /// <param name="tag">Tag of the textbox</param>
        public Textbox(int x, int y, int width, int height, string text, string tag) : base(x, y, width, height, tag)
        {
            this.text = text;
            FontSize = RayGUI.DEFAULT_FONT_SIZE;
            TextColor = Color.White;
            // Interaction assignment
            _focus = false;
            DeltaBack = 0.0;
            Args = new string[2];
        }

        /// <summary>Updates a textbox after entry.</summary>
        public void EntryUpdate()
        {
            BaseColor = RayGUI.BaseColor;
            _focus = false;
            if (OnEntry is not null)
            {
                OnEntry(Args, Text);
            }
        }
    }
}