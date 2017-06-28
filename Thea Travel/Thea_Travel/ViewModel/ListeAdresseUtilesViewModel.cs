using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMVVMToolkit;
using Thea_Travel.Data;
using System.Collections.ObjectModel;

namespace Thea_Travel.ViewModel
{
    public class ListeAdresseUtilesViewModel : BaseViewModel<ListeAdressesUtiles>
    {
        public ObservableCollection<AdresseUtileViewModel> LesAddressesVM { get { return lesAddressesVM; } }
        private ObservableCollection<AdresseUtileViewModel> lesAddressesVM = new ObservableCollection<AdresseUtileViewModel>();

        public ListeAdresseUtilesViewModel(ListeAdressesUtiles lesAddr)
        {
            Model = lesAddr;
            foreach(var a in Model.Adresses)
            {
                lesAddressesVM.Add(new AdresseUtileViewModel(a));
            }
        }

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                SetProperty(ref selectedIndex, value);
                OnPropertyChanged(nameof(SelectedAdresse));
            }
        }
        private int selectedIndex = -1;

        public AdresseUtileViewModel SelectedAdresse
        {
            get
            {
                return (selectedIndex != -1) ? LesAddressesVM[SelectedIndex] : null;
            }
        }
    }
}
