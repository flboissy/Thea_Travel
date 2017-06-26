using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Thea_Travel.View.CustomView
{
    public partial class CellViewProgrammeAppartement : ViewCell
    {
        private bool isPairRow;
        public CellViewProgrammeAppartement()
        {
            InitializeComponent();
        }

        private void root_Appearing(object sender, EventArgs e)
        {
            var viewCell = sender as ViewCell;
            isPairRow = (bool)App.Current.Properties[ListeProgrammes.IS_PAIR_KEY];
            if (isPairRow)
            {
                if (viewCell.View != null)
                {
                    viewCell.View.BackgroundColor = Color.FromHex("#c7dae0");
                }
            }
            else
            {
                if (viewCell.View != null)
                {
                    viewCell.View.BackgroundColor = Color.FromHex("#ffffff");
                }
            }
            App.Current.Properties[ListeProgrammes.IS_PAIR_KEY] = !isPairRow;
        }
    }
}
