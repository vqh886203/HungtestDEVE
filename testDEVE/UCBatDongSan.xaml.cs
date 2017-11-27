using System.Windows.Controls;
using System.Windows.Input;
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
