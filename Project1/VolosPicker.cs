using LibMobile;
using MauiReactor;
using System;
using System.Collections.Generic;

namespace SgatOffline2.Components
{
    internal class VolosPicker : Grid
    {
        VolosEntry Campo;
        List<ComboMobile> DS;
        Syncfusion.Maui.Popup.SfPopup Modale;
        Action<string> CallbackSelect;
        bool? _IsNew = null;
        bool? _IsEnabled = null;
        string _Abil = "";
        bool _Multi = false;
        bool _ClearBtn = true;

        public VolosPicker()
        {
            Init();
        }

        private void Init()
        {
            this.IsClippedToBounds(true);
            this.BackgroundColor(Colors.Transparent);

            Campo = new VolosEntry()
                .GridRow(0).GridColumn(0)
                .IsPicker()
                .Icona("O")
                .OnTapped(() => CallbackSelect?.Invoke("xxx"));

            Add(Campo);
        }

        public VolosPicker Abilitazione(string abil)
        {
            _Abil = abil;
            CheckAbil();
            return this;
        }

        public VolosPicker IsNew(bool isNew)
        {
            _IsNew = isNew;
            CheckAbil();
            return this;
        }

        public VolosPicker IsEnabled(bool abilitato)
        {
            _IsEnabled = abilitato;
            return this;
        }

        private void CheckAbil()
        {
            //bool nonGestito = !_IsEnabled.HasValue;
            //bool gestitoAbilitato = _IsEnabled.HasValue && _IsEnabled.Value;

            //if (nonGestito || gestitoAbilitato)
            //{
            //    if (!string.IsNullOrEmpty(_Abil) && _IsNew != null)
            //    {
            //        IsEnabled(AbilitazioniAppBase.GetAbilitazione(_Abil, AbilitazioniAppBase.GetTipoAbil(_IsNew.Value)));
            //        this.IsVisible(AbilitazioniAppBase.GetAbilitazione(_Abil, AbilitazioniAppBase.TipoAbilitazione.abilitato));
            //        //Required = AbilitazioniAppBase.GetAbilitazione(_Abil, AbilitazioniAppBase.TipoAbilitazione.obbligatorio); // TODO
            //    }
            //}
            //else
            //{
            //    this.IsVisible(AbilitazioniAppBase.GetAbilitazione(_Abil, AbilitazioniAppBase.TipoAbilitazione.abilitato));
            //}
        }

        public VolosPicker Valore(string codice)
        {
            ComboMobile comboSel = DS?.Find(x => x.Codice == codice);
            Campo.Valore(() => comboSel?.Valore ?? "");
            return this;
        }

        public VolosPicker Valore(Func<string> textFunc)
        {
            ComboMobile comboSel = DS?.Find(x => x.Codice == textFunc());
            Campo.Valore(() => comboSel?.Valore ?? "");
            return this;
        }

        public VolosPicker Descrizione(string descr)
        {
            Campo.Descrizione(descr);
            return this;
        }

        public VolosPicker DataSource(List<ComboMobile> dataSource)
        {
            DS = dataSource;
            return this;
        }

        public VolosPicker DataSource(Func<List<ComboMobile>> dataSource)
        {
            DS = dataSource();
            return this;
        }

        //public VolosPicker DataSource(List<Combo> dataSourceFrmk)
        //{
        //    DS = ComboMobile.ConvertFRMKtoMobile(dataSourceFrmk);
        //    return this;
        //}

        public VolosPicker OnSelect(Action<string> func)
        {
            CallbackSelect = func;
            return this;
        }

        //public VolosPicker AggiornaValore(bool aggiorna)
        //{
        //    if (aggiorna)
        //    {
        //        // AggiornaTirValue
        //    }
        //    return this;
        //}

        public VolosPicker MultiSelezione(bool multi)
        {
            _Multi = multi;
            return this;
        }

        public VolosPicker MultiSelezione(Func<bool> multi)
        {
            _Multi = multi();
            return this;
        }

        public VolosPicker BtnPulisci(bool btnPlulisci)
        {
            _ClearBtn = btnPlulisci;
            return this;
        }

        //private void ApriPopup()
        //{
        //    if (_IsEnabled == null || (_IsEnabled.HasValue && _IsEnabled.Value))
        //    {
        //        Modale = AlertConfirm.ApriModale(new MauiControls.DataTemplate(TemplateCombo), "titolo", FooterBts());
        //    }
        //}

        //private List<VolosButton> FooterBts()
        //{
        //    List<VolosButton> btns = new();

        //    if (_Multi) btns.Add(AlertConfirm.BtnPerModale(AppUtility.GetTS().Translate("AppMobileComuni.ok"), ConfermaMultiSelezione));
        //    if (_ClearBtn) btns.Add(AlertConfirm.BtnPerModale(AppUtility.GetTS().Translate("AppMobileComuni.PulisciText"), Pulisci));
        //    btns.Add(AlertConfirm.BtnPerModale(AppUtility.GetTS().Translate("appMobileComuni.chiudi"), () => { Modale.IsOpen = false; }));

        //    return btns;
        //}

        private MauiControls.BindableObject TemplateCombo()
        {
            Grid container = new("*", "*") {
                new ListView().GridRow(0).GridColumn(0)
                    .HasUnevenRows(true).SelectionMode(MauiControls.ListViewSelectionMode.None)
                    .OnItemTapped(SelezionaElemento).ItemsSource(DS, ItemTemplate)
            };

            return TemplateHost.Create(container).NativeElement;
        }

        private void SelezionaElemento(object a, MauiControls.ItemTappedEventArgs x)
        {
            ComboMobile sel = (ComboMobile)x.Item;
            Campo.AggiornaValoreRef(sel.Valore);
            CallbackSelect?.Invoke(sel.Codice);
            Modale.IsOpen = false;
        }

        private void Pulisci()
        {
            Campo.AggiornaValoreRef("");
            CallbackSelect?.Invoke("");
            Modale.IsOpen = false;
        }

        // TODO
        private void ConfermaMultiSelezione()
        {
            Modale.IsOpen = false;
        }

        private ViewCell ItemTemplate(ComboMobile item)
        {
            VStack ele = new() {
                new Label(item.Valore).HeightRequest(40).VerticalTextAlignment(TextAlignment.Center),
                new BoxView().HeightRequest(1).Color(Colors.Green)
            };
            ele.Padding(5);
            return new ViewCell() { ele };
        }
    }
}
