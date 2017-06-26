using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using Thea_Travel.Data;
using Thea_Travel.Services;
using Xamarin.Forms;

namespace Thea_Travel.View
{
    public partial class ListeProgrammes : ContentPage
    {
        private static readonly string CHOIX_APPELER = "Appeler";
        private static readonly string CHOIX_MAP = "Itinéraire";
        public static readonly string IS_PAIR_KEY = "PairKey";
        IJournée Journée;
        public ObservableCollection<ProgrammeViewModel> Programmes { get; set; }
        public ListeProgrammes(IJournée j)
        {
            Journée = j;
            Programmes = new ObservableCollection<ProgrammeViewModel>(Journée.Programmes.Select(elt => new ProgrammeViewModel(elt)).ToList());
            BindingContext = this;
            InitializeComponent();
            if (!App.Current.Properties.ContainsKey(IS_PAIR_KEY))
            {
                App.Current.Properties.Add(IS_PAIR_KEY, true);
            }
            else
            {
                App.Current.Properties[IS_PAIR_KEY] = true;
            }
        }

        private async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var prog = e.SelectedItem as ProgrammeViewModel;
            if (e.SelectedItem == null)
            {
                return;
            }
            string action;
            switch (prog.ProgrammeType)
            {
                case "Hôtel":
                    action = await DisplayActionSheet("Que souhaitez vous faire ?", "Retour", null, CHOIX_APPELER, CHOIX_MAP);
                    DoActionSheetResult(prog, action);
                    break;
                case "Appartement":
                    action = await DisplayActionSheet("Que souhaitez vous faire ?", "Retour", null, CHOIX_MAP);
                    DoActionSheetResult(prog, action);
                    break;
                default:
                    break;
            }
        }

        private void DoActionSheetResult(ProgrammeViewModel p, string result)
        {
            Hôtel h = null;
            Appartement a = null;
            switch (p.ProgrammeType)
            {
                case "Hôtel":
                    h = p.Model as Hôtel;
                    break;
                case "Appartement":
                    a = p.Model as Appartement;
                    break;
                default:
                    return;
            }
            if (result == null)
            {
                listViewProgrammes.SelectedItem = null;
                return;
            }
            if (result.Equals(CHOIX_APPELER))
            {
                var dialer = DependencyService.Get<IDialer>();
                if (dialer != null)
                {
                    dialer.Dial(h.Tel.Trim());
                }
            }
            else if (result.Equals(CHOIX_MAP))
            {
                switch (Device.OS)
                {
                    case TargetPlatform.iOS:
                        Device.OpenUri(new Uri(string.Format("http://maps.apple.com/?q={0}", WebUtility.UrlEncode(a != null ? a.Adresse : h.Adresse))));
                        break;
                    case TargetPlatform.Android:
                        Device.OpenUri(new Uri(string.Format("geo:0,0?q={0}", WebUtility.UrlEncode(a != null ? a.Adresse : h.Adresse))));
                        break;
                }
            }
            listViewProgrammes.SelectedItem = null;
        }
    }
}
