using MauiReactor;
using System;

namespace SgatOffline2.Components
{
    public partial class VolosEntry : SfTextInputLayout
    {
        private Entry _entry;
        private MauiControls.Entry _entryRef;

        public VolosEntry()
        {
            Init();
        }

        public void Init()
        {
            this.ShowHint(true);
            this.ShowHelperText(false);
            this.ReserveSpaceForAssistiveLabels(false);

            _entry = new(myRef => _entryRef = myRef);            
            Add(_entry);
        }

        public VolosEntry AggiornaValoreRef(string text)
        {
            _entryRef.Text = text;
            return this;
        }

        public VolosEntry Icona(string icon)
        {
            Label lblIcona = new Label()
               .Text(icon)
               //.FontFamily(Costanti.Font.MaterialDesignIcons.ToString())
               .FontSize(10)
               .VerticalTextAlignment(TextAlignment.Center).HorizontalTextAlignment(TextAlignment.Center)
               .TextColor(Colors.Orange);

            this.ShowLeadingView(true)
                .LeadingViewPosition(Syncfusion.Maui.Core.ViewPosition.Inside)
                .LeadingView(TemplateHost.Create(lblIcona).NativeElement as MauiControls.View);

            return this;
        }

        public VolosEntry Valore(string text)
        {
            _entry.Text(text);
            return this;
        }

        public VolosEntry Valore(Func<string> textFunc)
        {
            _entry.Text(textFunc);
            return this;
        }

        public VolosEntry Descrizione(string text)
        {
            this.Hint(text);
            return this;
        }

        public VolosEntry IsPicker()
        {
            _entry.IsEnabled(false);
            return this;
        }
    }
}