using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using CiaranONeill.NPV.Calculator;

namespace CiaranONeill.NPV.Silverlight
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            Cashflows = new Dictionary<string, double>();

            var dates = new DateRollCalculator().GetDates(RolloverType.Month).ToList();
            var data = new NpvCalculator().GetRandomData().ToList();

            for (int i = 0; i < dates.Count(); i++)
            {
                Cashflows.Add(dates[i].ToShortDateString(), data[i]);
            }

            //Cashflows.Add("Period 1", 200);
            //Cashflows.Add("Period 2", 250);
            lstCashflow.ItemsSource = Cashflows;
        }

        public Dictionary<string, double> Cashflows { get; set; }
    }
}
