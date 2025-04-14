#pragma warning disable CS8602

using Raylib_cs;
using System.Numerics;

namespace RayGUI_cs
{
    /// <summary>Represents a param delegate function.</summary>
    /// <param name="args">Arguments passed from a <see cref="Component"/>.</param>
    /// <param name="value">Value of <see cref="Component"/>.</param>
    public delegate void ParamEvent(string[] args, string value);

    /// <summary>Textbox component of the library</summary>
    public class Textbox : Component, IWritable
    {
        /// <summary>Defines a filter-type when typing into a textbox.</summary>
        public enum TextFilter
        {
            None,
            Naturals,
            Decimals,
        }

        private int fontSize;
        private string text;
        // Default-state booleans
        private bool _defaultFontSet = false;
        internal int InternalFontSize = 0;

        public TextFilter Filter;
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
                TextSize = RayGUI.MeasureComponentText(text, FontSize);
            }
        }

        /// <summary>Font size of the buttons's text.</summary>
        public int FontSize
        {
            get { return fontSize; }
            set
            {
                fontSize = value;
                TextSize = RayGUI.MeasureComponentText(text, FontSize);
                InternalFontSize = RayGUI.FindMatchingFont(fontSize);
                _defaultFontSet = true;
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
        /// <param name="placeholder">Initial text of the textbox</param>
        public Textbox(int x, int y, int width, int height, string placeholder) : base(x, y, width, height)
        {
            this.text = placeholder;

            FontSize = RayGUI.DEFAULT_FONT_SIZE;
            InternalFontSize = RayGUI.FindMatchingFont(fontSize);
            _defaultFontSet = false;

            TextColor = Color.White;
            // Interaction assignment
            _focus = false;
            DeltaBack = 0.0;
            Args = new string[2];

            Filter = TextFilter.None;
        }

        /// <summary>Updates a textbox after entry.</summary>
        internal void EntryUpdate()
        {
            _focus = false;
            BaseColor = HoverColor;
            HoverColor = BorderColor;
            if (OnEntry is not null)
            {
                OnEntry(Args, Text);
            }
        }

        /// <summary>Sets the default font size of the textbox.</summary>
        /// <param name="containerSize">Default font size to set.</param>
        void IWritable.SetDefaultFontSize(int containerSize)
        {
            if (!_defaultFontSet)
            {
                FontSize = containerSize;
                InternalFontSize = RayGUI.FindMatchingFont(fontSize);
                _defaultFontSet = false;
            }
        }
    }
}