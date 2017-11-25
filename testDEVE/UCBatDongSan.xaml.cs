using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using testDEVE.Model;

namespace testDEVE
{
    /// <summary>
    /// Interaction logic for UCBatDongSan.xaml
    /// </summary>
    public partial class UCBatDongSan : UserControl
    {
        dtbbdsDataContext dc = new dtbbdsDataContext();
        SuaBDS eBDS;
        public UCBatDongSan()
        {
            InitializeComponent();
        }

        private void grid_SelectionChanged(object sender, DevExpress.Xpf.Grid.GridSelectionChangedEventArgs e)
        {
            
        }


        private void Card_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BDSView card = grid.SelectedItem as BDSView;
            if (card == null) return;
            eBDS = new SuaBDS();
            eBDS.setBDS(card.bdsid);
            eBDS.Show();
            
        }
    }
}
