using DevExpress.Xpf.Core.Native;
using DevExpress.Xpf.Editors.Helpers;
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
using System.Windows.Shapes;
using testDEVE;

namespace testDEVE
{
    /// <summary>
    /// Interaction logic for SuaBDS.xaml
    /// </summary>
    public partial class SuaBDS : Window
    {

        public int msBDS;
        dtbbdsDataContext dc = new dtbbdsDataContext();
        public SuaBDS()
        {
            InitializeComponent();
            
            
        }
        public void setBDS(int ms)
        {
            msBDS = ms;
            foreach (BatDongSan a in dc.BatDongSans.Where(x => x.bdsid == ms))
            {
                if (a != null)
                {
                    txtMsqsdd.Text = a.masoqsdd;
                    txtHh.Text = a.hoahong.ToString();
                    txtSonha.Text = a.sonha;
                    txtDuong.Text = a.tenduong;
                    txtQuan.Text = a.quan;
                    txtPhuong.Text = a.phuong;
                    txtTP.Text = a.thanhpho;
                    txtDai.Text = a.chieudai.ToString();
                    txtRong.Text = a.chieurong.ToString();
                    if (a.hinhanh.Length<=5) { img.Source = null; }
                    else
                    {
                        Byte[] byteBLOBData = a.hinhanh.ToArray();
                        MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                        img.Source = ImageHelper.CreateImageFromStream(stmBLOBData);
                    }
                    
                    foreach (KhachHang kh in dc.KhachHangs)
                    {
                        string strKH = "MS: " + kh.khid + " | Họ Tên: " + kh.hoten;
                        cboKh.Items.Add(strKH);
                        cboKh.ItemsSource = kh;
                        cboKh.Text ="MS: "+a.khid+"| Họ Tên: "+ a.KhachHang.hoten;
                    }
                    foreach(LoaiBD loai in dc.LoaiBDs)
                    {
                        cboLoai.Items.Add(loai.tenloai);
                        cboLoai.Text = a.LoaiBD.tenloai;
                    }
                }
            }
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
           
           foreach(BatDongSan bds in dc.BatDongSans.Where(x => x.bdsid == msBDS))
            {
                if (bds != null)
                {
                    bds.chieudai = double.Parse(txtDai.Text);
                    bds.chieurong = double.Parse(txtRong.Text);
                    bds.dientich = double.Parse(txtDai.Text) * double.Parse(txtRong.Text);
                    bds.hinhanh = ConvertToBytes(img.Source as BitmapImage);
                    dc.SubmitChanges();
                }
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public byte[] ConvertToBytes(BitmapImage bitmapImage)
        {
            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }
    }
}
