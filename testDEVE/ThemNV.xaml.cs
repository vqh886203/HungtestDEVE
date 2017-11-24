using DevExpress.Xpf.Core.Native;
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
using testDEVE.Model;

namespace testDEVE
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        dtbbdsDataContext dc = new dtbbdsDataContext();
        
        UCNVList ucl = new UCNVList();
        public Window1()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            NhanVien nv = new NhanVien();
            nv.taikhoan = txtTK.Text;
            nv.matkhau = "1";
            nv.tennv = txtTen.Text;
            nv.sdt = int.Parse( txtSDT.Text);
            nv.diachi = txtDiachi.Text;
            nv.ngaysinh = dtpNS.SelectedDate.Value;
            if (rdoNam.IsChecked == true)
                nv.gioitinh = true;
            else
                nv.gioitinh = false;
            nv.email = txtEmail.Text;
            nv.doanhthu = 0;
            nv.quyen = false;
            nv.hinh=ConvertToBytes(img.Source as BitmapImage);
            dc.NhanViens.InsertOnSubmit(nv);
            dc.SubmitChanges();
            MainWindow main = new MainWindow();
            UCNV uc = new UCNV();
            main.usnv.Content = uc;
            ucl.grid.ItemsSource = new NhanVienModelView().DSNVList;
            uc.gridControl.ItemsSource = new NhanVienModelView().DSNV;
            this.Close();

        }
        public  byte[] ConvertToBytes(BitmapImage bitmapImage)
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
        public BitmapImage ToImage(byte[] array)
        {
            using (var ms = new MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }
        private void txtEmail_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            txtTK.Text = txtEmail.Text;
        }
    }
}
