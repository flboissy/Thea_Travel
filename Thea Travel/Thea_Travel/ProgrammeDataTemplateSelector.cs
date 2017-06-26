using Xamarin.Forms;
using Thea_Travel.View.CustomView; 

namespace Thea_Travel
{
    class ProgrammeDataTemplateSelector : DataTemplateSelector
    {
        private readonly DataTemplate HotelTemplate;
        private readonly DataTemplate AppartTemplate;
        private readonly DataTemplate DefautTemplate;
        
        public ProgrammeDataTemplateSelector()
        {
            HotelTemplate = new DataTemplate(typeof(CellViewProgrammeHotel));
            AppartTemplate = new DataTemplate(typeof(CellViewProgrammeAppartement));
            DefautTemplate = new DataTemplate(typeof(CellViewProgrammeDefaut));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
           var progVM = item as ProgrammeViewModel;
           if(progVM == null)
            {
                return null;
            }
            return progVM.ProgrammeType.Equals("Hôtel") ? this.HotelTemplate : progVM.ProgrammeType.Equals("Appartement") ? this.AppartTemplate : this.DefautTemplate;
        }
    }
}
