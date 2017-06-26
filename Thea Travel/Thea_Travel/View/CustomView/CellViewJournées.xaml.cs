using System;

using Xamarin.Forms;

namespace Thea_Travel.View.CustomView
{
    public partial class CellViewJournées : ViewCell
    {
        public CellViewJournées()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty DateCellProperty =
        BindableProperty.Create("DateCell", typeof(DateTime), typeof(CellViewJournées), DateTime.Today);

        public DateTime DateCell
        {
            get { return (DateTime)GetValue(DateCellProperty); }
            set { SetValue(DateCellProperty, value); }
        }
        public static readonly BindableProperty IndexCellProperty =
       BindableProperty.Create("IndexCell", typeof(int), typeof(CellViewJournées), 0);
        public int IndexCell
        {
            get { return (int)GetValue(IndexCellProperty); }
            set { SetValue(IndexCellProperty, value); }
        }
    }
}
