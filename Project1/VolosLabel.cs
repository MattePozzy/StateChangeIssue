using MauiReactor;
using System;

namespace SgatOffline2.Components
{
    public partial class VolosLabel : VStack
    {
        private readonly Label Descr = new();
        private readonly Label Value = new();

        public VolosLabel()
        {
            //Descr.Style(AppUtility.GetResources<MauiControls.Style>("LblDescr"));
            //Value.Style(AppUtility.GetResources<MauiControls.Style>("LblValore"));
            Value.LineBreakMode(LineBreakMode.WordWrap);
            Add(Descr);
            Add(Value);
        }

        public VolosLabel ValoreTextColorHex(string hexColor)
        {
            if (!string.IsNullOrWhiteSpace(hexColor))
            {
                Value.TextColor(Color.FromArgb(hexColor));
            }
            return this;
        }

        public VolosLabel ValoreFontSize(double size)
        {
            if (size > -1) Value.FontSize(size);
            return this;
        }

        public VolosLabel ValoreBold(bool bold)
        {
            if (bold) Value.FontAttributes(MauiControls.FontAttributes.Bold);
            return this;
        }

        public VolosLabel Descrizione(string text)
        {
            Descr.Text(text);
            return this;
        }

        public VolosLabel Valore(double? num)
        {
            string text = num.HasValue ? num.Value.ToString() : "-";
            Value.Text(text);
            return this;
        }

        public VolosLabel Valore(string text)
        {
            text = string.IsNullOrWhiteSpace(text) ? "-" : text;
            Value.Text(text);
            return this;
        }

        public VolosLabel Valore(Func<string> text)
        {
            string _text = text();
            _text = string.IsNullOrWhiteSpace(_text) ? "-" : _text;
            Value.Text(_text);
            return this;
        }

        public VolosLabel SetLineBreakMode(LineBreakMode type)
        {
            Descr.LineBreakMode(type);
            Value.LineBreakMode(type);
            return this;
        }

        public VolosLabel ValoreAsHtml(bool siNo)
        {
            if (siNo)
            {
                Value.TextType(TextType.Html);
                Value.FontSize(16);
                Value.FontFamily("Arial");
            }
            return this;
        }
    }
}
