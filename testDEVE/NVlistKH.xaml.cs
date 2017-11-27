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
    /// Interaction logic for NVlistKH.xaml
    /// </summary>
    public partial class NVlistKH : Window
    {
        public static string stringnvid = string.Empty;
        private dtbbdsDataContext dc = new dtbbdsDataContext();
        private NhanVien nv = new NhanVien();
        private NhanVienModelView nvmd = new NhanVienModelView();
        private List<KhachHangCaNhanView> khcn = new List<KhachHangCaNhanView>();
        public NVlistKH()
        {
            InitializeComponent();
            timnv();
            Title = nv.tennv;
            lbname.Content = nv.tennv;
            lbngaysinh.Content = nv.ngaysinh.ToString();
            lbGioiTinh.Content = nv.gioitinh.Value ? "Nam" : "Nữ";
            lbsdt.Content = nv.sdt.ToString();
            lbemail.Content = nv.email;
            lbdoanhthu.Content = nv.doanhthu.ToString();
            if (nv.hinh == null) { img.Source = null; }
            else
            {
                Byte[] byteBLOBData = nv.hinh.ToArray();
                MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                img.Source = ImageHelper.CreateImageFromStream(stmBLOBData);
            }
            khcn = nvmd.getdskhcn(nv.nvid);
            gridControlkh.ItemsSource = khcn;
        }
        private void timnv()
        {
            
            foreach (NhanVien i in dc.NhanViens.Where(x => x.nvid == int.Parse(stringnvid)))
                {
                nv = i;
                }
        }
        
    }
}
