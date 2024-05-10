using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QL_KTX.Models;

namespace QL_KTX.Controllers
{
    public class SinhViensController : Controller
    {
        
        // Database
        private QLKTXEntities1 db = new QLKTXEntities1();
        // Hiển thị trang Thông tin sinh viên - index của controller sinh viên
        public ActionResult ThongTinSinhVien()
        {
            if (Session["_taiKhoan"] == null) return RedirectToAction("DangNhap", "HeThong");

            string taiKhoan = Session["_taiKhoan"].ToString();
            var a = db.SinhViens.Where(s => s.maSV == taiKhoan).First();

            return View(a);
        }



        // Hiển thị trang Cập nhật thông tin sinh viên
        public ActionResult CapNhatThongTinSinhVien()
        {
            if (Session["_taiKhoan"] == null) return RedirectToAction("DangNhap", "HeThong");

            string taiKhoan = Session["_taiKhoan"].ToString();
            var a = db.SinhViens.Find(taiKhoan);

            return View(a);
        }
        // Xủ lý lưu khi sinh viên cập nhật thông tin bản thân
        [HttpPost]
        public ActionResult CapNhatThongTinSinhVien(string maSV, string hoVaTen, string gioiTinh, string ngaySinh, string lop, string dongPhi, string anhSV_cu, string queQuan, string sdtSV, string email, string maPhong)
        {
            if (Session["_taiKhoan"] == null) return RedirectToAction("DangNhap", "HeThong");

            // Lưu dữ liệu tạm từ web sau khi nhập
            ViewBag.maSV = maSV;
            ViewBag.hoVaTen = hoVaTen;
            ViewBag.gioiTinh = gioiTinh;
            ViewBag.ngaySinh = ngaySinh;
            ViewBag.lop = lop;
            ViewBag.dongPhi = dongPhi;
            ViewBag.anhSV = anhSV_cu;
            ViewBag.queQuan = queQuan;
            ViewBag.email = email;
            ViewBag.sdtSV = sdtSV;
            ViewBag.maPhong = maPhong;

            // Kiểm tra có nhập dấu cách trong số điện thoại hay không ?
            if (!HT.KiemTraDauCach(sdtSV))
            {
                ViewBag.thongBao = "Số điện thoại không được chứa dấu cách !";
                return View();
            }

            // Kiểm tra có nhập dấu cách trong số điện thoại hay không ?
            if (!HT.KiemTraChuoiToanSoVaDuSoLuong(sdtSV, 10))
            {
                ViewBag.thongBao = "Số điện thoại không hợp lệ !";
                return View();
            }

            // Lấy ảnh cũ hoặc ảnh mới (nếu có)
            string anhSV = null;
            try
            {
                var img = Request.Files["anhSV_moi"];
                string fileImg = System.IO.Path.GetFileName(img.FileName);
                var path = Server.MapPath("/Images/" + fileImg);
                img.SaveAs(path);
                anhSV = fileImg;
            }
            catch
            {
                anhSV = anhSV_cu;
            }

            // Chuẩn hoá dữ liệu trước khi lưu vào database
            lop = lop.Trim();
            queQuan = queQuan.Trim();
            sdtSV = sdtSV.Trim();
            email = email.Trim();

            string cmd = "update SinhVien set lop = '" + lop + "', anhSV = N'" + anhSV + "', queQuan = N'" + queQuan + "', sdtSV = '" + sdtSV + "', email = '" + email + "' where maSV = '" + maSV + "'";
            db.Database.ExecuteSqlCommand(cmd);

            return RedirectToAction("ThongTinSinhVien");
        }



        // Hiển thị trang Liên hệ quản lý
        public ActionResult LienHeQuanLy()
        {
            if (Session["_taiKhoan"] == null) return RedirectToAction("DangNhap", "HeThong");

            var a = db.QuanLies.First();

            return View(a);
        }



        // Hiên thi trang Tra cứu phòng
        public ActionResult TraCuuPhong(string phongTim = "")
        {
            if (Session["_taiKhoan"] == null) return RedirectToAction("DangNhap", "HeThong");

            ViewBag.phongTim = phongTim;

            // Truy vấn theo phòng
            string cmd = null;
            if (phongTim.Length == 0)
                cmd = "select P.maPhong, (8 - count(S.maSV)) as conThieu from Phong P left join SinhVien S on P.maPhong = S.maPhong group by P.maPhong";
            else
                cmd = "select P.maPhong, (8 - count(S.maSV)) as conThieu from Phong P left join SinhVien S on P.maPhong = S.maPhong where P.maPhong = '" + phongTim + "' group by P.maPhong";

            var a = db.Database.SqlQuery<TraCuuPhongThieuNguoi>(cmd).ToList();

            return View(a);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
