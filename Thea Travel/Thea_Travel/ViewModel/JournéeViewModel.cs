using MyMVVMToolkit;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Thea_Travel.Data
{
    public class JournéeViewModel : BaseViewModel<IJournée>
    {
        public ObservableCollection<ProgrammeViewModel> LesProgrammesVM { get { return lesProgrammesVM; } }
        private ObservableCollection<ProgrammeViewModel> lesProgrammesVM = new ObservableCollection<ProgrammeViewModel>();
        private bool CanTap = true;
        public int Index { get; }

        public JournéeViewModel(int i, IJournée m)
        {
            Model = m;
            Index = i;
            foreach(var n in Model.Programmes)
            {
                lesProgrammesVM.Add(new ProgrammeViewModel(n));
            }
            ItemTappedCommand = new Command(async () => await ItemTapped() ,() => { return CanTap; });
        }

        public ICommand ItemTappedCommand { get; private set; }

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                SetProperty(ref selectedIndex, value);
                OnPropertyChanged(nameof(SelectedProgramme));
            }
        }
        private int selectedIndex = -1;

        public ProgrammeViewModel SelectedProgramme
        {
            get
            {
                return (selectedIndex != -1) ? LesProgrammesVM[SelectedIndex] : null;
            }
        }

        public  async Task ItemTapped()
        {
            CanTap = !CanTap;
            if (Model != null)
            {
                await SelectedProgramme.Model.ActionSheet();
            }
            CanTap = !CanTap;
        }

        public DateTime DateDuJour
        {
            get { return Model.DateDuJour; }
            set { SetProperty(Model.DateDuJour, value, () => Model.DateDuJour = value); }
        }
    }
}
