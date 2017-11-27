using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace testDEVE.Model
{
    class NhanVienModelView
    {
        public IEnumerable<object> DSNV { get; set; }
        public IEnumerable<object> DSNVList { get; set; }

        public dtbbdsDataContext dc = new dtbbdsDataContext();
        public NhanVienModelView()
        {
            this.DSNV = getDSNVView();
            this.DSNVList = getDSNVViewList();
        }


        public IEnumerable<object> getDSNVView()
        {
            return dc.NhanViens.Select(x => new NhanVienView
            {
                nvid = x.nvid,
                tennv = x.tennv,
                diachi = x.diachi,
                gioitinh = x.gioitinh.Value ? "Nam" : "Nữ",
                email = x.email,
                sdt = x.sdt.Value,
                tuoi = DateTime.Now.Year - x.ngaysinh.Value.Year,
                hinh = x.hinh.ToString() == null ? null : x.hinh.ToArray(),

            }).ToList();
        }
        public IEnumerable<object> getdskhlist()
        {
            return dc.KhachHangs.Select(x => new KhachHangList
            {
                khid = x.khid,
                hoten = x.hoten,
                diachi = x.diachi,
                diachitt = x.diachitt,
                gioitinh = x.gioitinh.Value ? "Nam" : "Nữ",
                email = x.email,
                sdt = x.sdt.Value,
                tuoi = DateTime.Now.Year - x.ngaysinh.Value.Year,
                cmnd = x.cmnd.Value,
                loaikh = x.loaikh.Value?"Cần Mua":"Cần Bán"
            
            }).ToList();
        }
        public IEnumerable<object> getDSNVViewList()
        {
            return dc.NhanViens.Select(x => new NhanVienViewList
            {
                nvid = x.nvid,
                doanhthu=x.doanhthu.Value,
                email=x.email,
                matkhau=x.matkhau,
                gioitinh=x.gioitinh.Value?"Nam" : "Nữ",
                ngaysinh=x.ngaysinh.Value,
                hinh = x.hinh.ToString()==null?null:x.hinh.ToArray(),
                tennv = x.tennv,
                sdt = x.sdt.Value,
                diachi = x.diachi,
                taikhoan = x.taikhoan,
                quyen=x.quyen.Value
            }).ToList();
        }
        public List<KhachHangCaNhanView> getdskhcn(int a)
        {
            List<KhachHangCaNhanView> lst = new List<KhachHangCaNhanView>();
            foreach(KhachHang kh in dc.KhachHangs.Where(x=>x.nvid==a))
            {
                KhachHangCaNhanView khcn = new KhachHangCaNhanView();
                khcn.khid = kh.khid;
                khcn.hoten = kh.hoten;
                khcn.sdt = kh.sdt.Value;
                khcn.gioitinh = kh.gioitinh.Value ? "Nam" : "Nữ";
                khcn.email = kh.email;
                khcn.loaikh = kh.loaikh.Value ? "Mua" : "Bán";
                khcn.diachi = kh.diachi;
                lst.Add(khcn);
            }
            return lst;
        }
    }


    public class NhanVienViewList
    {
        public int nvid { get; set; }
        public byte[] hinh { get; set; }
        public string tennv { get; set; }
        public int sdt { get; set; }
        public string diachi { get; set; }
        public string taikhoan { get; set; }
        public string matkhau { get; set; }
        public double doanhthu { get; set; }
        public string email { get; set; }
        public DateTime ngaysinh { get; set; }
        public string gioitinh { get; set; }
        public bool quyen { get; set; }
        
    }
    public class NhanVienView
    {
        public int nvid { get; set; }
        public string tennv { get; set; }
        public int sdt { get; set; }
        public string diachi { get; set; }
        public string email { get; set; }
        public string gioitinh { get; set; }
        public int tuoi { get; set; }
        public byte[] hinh { get; set; }
        public byte[] list { get; set; }
    }
    public class KhachHangView
    {
        public int nvid { get; set; }
        public string tennv { get; set; }
        public int sdt { get; set; }
        
    }
    public class KhachHangCaNhanView
    {
        public int khid { get; set; }
        public string hoten { get; set; }
        public int sdt { get; set; }
        public string diachi { get; set; }
        public string gioitinh { get; set; }
        public string email { get; set; }
        public string loaikh { get; set; }
    }
    public class KhachHangList
    {
        public int khid { get; set; }
        public string hoten { get; set; }
        public int sdt { get; set; }
        public string diachi { get; set; }
        public string diachitt { get; set; }
        public int cmnd { get; set; }
        public string email { get; set; }
        public int tuoi { get; set; }
        public string gioitinh { get; set; }
        public string loaikh { get; set; }
    }
}

