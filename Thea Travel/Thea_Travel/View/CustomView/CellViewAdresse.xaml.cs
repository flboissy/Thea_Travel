using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Thea_Travel.View.CustomView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CellViewAdresse : ViewCell
    {
        public CellViewAdresse()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty NomCellProperty =
        BindableProperty.Create("NomCell", typeof(string), typeof(CellViewAdresse), "");

        public string NomCell
        {
            get { return (string)GetValue(NomCellProperty); }
            set { SetValue(NomCellProperty, value); }
        }

        public static readonly BindableProperty AdresseCellProperty =
       BindableProperty.Create("AdresseCell", typeof(string), typeof(CellViewAdresse), "");

        public string AdresseCell
        {
            get { return (string)GetValue(AdresseCellProperty); }
            set { SetValue(AdresseCellProperty, value); }
        }
    }
}
