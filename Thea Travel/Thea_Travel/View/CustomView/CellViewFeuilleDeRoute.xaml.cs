using System;
using Xamarin.Forms;

namespace Thea_Travel.View.CustomView
{
    public partial class CellViewFeuilleDeRoute : ViewCell
    {
        public CellViewFeuilleDeRoute()
        {            
            InitializeComponent();
        }
         public static readonly BindableProperty TitreCellProperty =
        BindableProperty.Create("TitreCell", typeof(string), typeof(CellViewFeuilleDeRoute), "default");

        public string TitreCell
        {
            get { return (string)GetValue(TitreCellProperty); }
            set { SetValue(TitreCellProperty, value); }
        }

        public static readonly BindableProperty DebutCellProperty =
        BindableProperty.Create("DebutCell", typeof(DateTime), typeof(CellViewFeuilleDeRoute), DateTime.Today);

        public DateTime DebutCell
        {
            get { return (DateTime)GetValue(DebutCellProperty); }
            set { SetValue(DebutCellProperty, value); }
        }

        public static readonly BindableProperty FinCellProperty =
        BindableProperty.Create("FinCell", typeof(DateTime), typeof(CellViewFeuilleDeRoute), DateTime.Today);
        public DateTime FinCell
        {
            get { return (DateTime)GetValue(FinCellProperty); }
            set { SetValue(FinCellProperty, value); }
        }
    }
}
