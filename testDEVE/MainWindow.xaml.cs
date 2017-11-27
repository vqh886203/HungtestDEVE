using System.Windows;
using testDEVE.Model;

namespace testDEVE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UCNVList a = new UCNVList();
        private UCNV b = new UCNV();
        int tt = 0;
        public MainWindow()
        {
            InitializeComponent();
            
            usnv.Content = b;
            biNV.IsEnabled = false;
            nbiList.IsEnabled = true;

        }

      

        private void biNV_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
           
            usnv.Content = b;
            
            biNV.IsEnabled = false;
            nbiList.IsEnabled = true;
            biKH.IsEnabled = true;
        }

        private void biKH_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            usnv.Content = null;
            biNV.IsEnabled = true;
            biKH.IsEnabled = false;
            nbiDetail.IsEnabled = false;
            nbiList.IsEnabled = false;
        }

        private void nbiDetail_Click(object sender, System.EventArgs e)
        {
            b = new UCNV();
            usnv.Content = b;
            biNV.IsEnabled = false;
            nbiDetail.IsEnabled = false;
            nbiList.IsEnabled = true;
        }

        private void nbiList_Click(object sender, System.EventArgs e)
        {
            tt = 1;
            UCNVList ucList = new UCNVList();
            usnv.Content = ucList;
            nbiList.IsEnabled = false;
            nbiDetail.IsEnabled = true;
            
        }


        private void biKH_ItemClick_2(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            UCKH uskh = new UCKH();
            usnv.Content = uskh;
            biNV.IsEnabled = true;
            biKH.IsEnabled = false;
            nbiList.IsEnabled = false;
            nbiDetail.IsEnabled = false;
        }
    }
}
