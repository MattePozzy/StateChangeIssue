using LibMobile;
using MauiReactor;
using SgatOffline2.Components;
using System.Collections.Generic;

namespace Project1.Pages
{
    internal class MainPageState
    {
        public List<ComboMobile> DataSource { get; set; }
        public string Primo { get; set; }
        public string Secondo { get; set; }
    }

    internal class MainPage : Component<MainPageState>
    {
        protected override void OnMounted()
        {
            State.DataSource = new List<ComboMobile> {
                new ComboMobile() {Codice = "000", Valore = ""},
                new ComboMobile() {Codice = "001", Valore = "Uno"},
                new ComboMobile() {Codice = "002", Valore = "Due"},
            };

            State.Primo = "001";

            base.OnMounted();
        }

        private void Changed(string codSel)
        {
            if (string.IsNullOrEmpty(State.Secondo))
            {
                codSel = "002";
            }else
            {
                codSel = "";
            }

            SetState(s =>
            {
                s.Secondo = codSel;
            }, false);
        }

        public override VisualNode Render()
        {
            return new ContentPage
        {
            new ScrollView
            {
                new VerticalStackLayout
                {
                    new Label("Click on 'test picker to change the value of State.Secondo between empty and 002"),
                    new Label("the UI will be only changed for Label and VolosEntry but not for VolosLabel and 'Due picker'"),
                    new VolosPicker()
                        .Descrizione("Test picker")
                        .DataSource(State.DataSource).Valore(() => State.Primo)
                        .OnSelect(Changed),

                    new Label().Text(() => $"Label - State.Secondo: {State.Secondo}"),
                    new VolosLabel().Descrizione("VolosLabel").Valore(() => State.Secondo),
                    new VolosEntry().GridRow(10).GridColumn(0).Descrizione("VolosEntry").Valore(() => State.Secondo),

                    new VolosPicker()
                        .Descrizione("Due picker")
                        .DataSource(State.DataSource).Valore(() => State.Secondo)
                }
                .VCenter()
                .Spacing(25)
                .Padding(30, 0)
            }
        };
        }
    }
}