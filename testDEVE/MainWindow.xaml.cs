using System.Windows;
using testDEVE.Model;

namespace testDEVE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UCNVList a = new UCNVList();
        UCNV b = new UCNV();
        UCBatDongSan c;
        public MainWindow()
        {
            InitializeComponent();
            usnv.Content = null;
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
            a = new UCNVList();
            usnv.Content = a;
            nbiList.IsEnabled = false;
            nbiDetail.IsEnabled = true;
        }

        private void biBDS_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            c = new UCBatDongSan();
            usnv.Content = c;
        }

        
    }
}
