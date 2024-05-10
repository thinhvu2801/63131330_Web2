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
    public class QuanLiesController : Controller
    {
        // Database
        private QLKTXEntities1 db = new QLKTXEntities1();



        // Hiển thị trang Thông tin quản lý
        public ActionResult ThongTinQuanLy()
        {
            if (Session["_taiKhoan"] == null) return RedirectToAction("DangNhap", "HeThong");

            var a = db.QuanLies.First();

            return View(a);
        }



        // Hiển thị trang Cập nhật thông tin quản lý
        public ActionResult CapNhatThongTinQuanLy()
        {
            if (Session["_taiKhoan"] == null) return RedirectToAction("DangNhap", "HeThong");

            var a = db.QuanLies.First();

            return View(a);
        }
        // Xử lý khi người dùng cập nhật thông tin cho quản lý
        [HttpPost]
        public ActionResult CapNhatThongTinQuanLy(string hoQL, string tenQL, bool gioiTinh, string ngaySinh, string anhQL_cu, string sdtQL, string email)
        {
            if (Session["_taiKhoan"] == null) return RedirectToAction("DangNhap", "HeThong");

            // Lưu tạm dữ liệu
            ViewBag.hoQL = hoQL;
            ViewBag.tenQL = tenQL;
            ViewBag.gioiTinh = gioiTinh;
            ViewBag.ngaySinh = ngaySinh;
            ViewBag.anhQL = anhQL_cu;
            ViewBag.sdtQL = sdtQL;
            ViewBag.email = email;

            // Kiểm tra có nhập dấu cách trong số điện thoại hay không ?
            if (!HT.KiemTraDauCach(sdtQL))
            {
                ViewBag.thongBao = "Số điện thoại không được chứa dấu cách !";
                return View();
            }

            // Kiểm tra có nhập dấu cách trong số điện thoại hay không ?
            if (!HT.KiemTraChuoiToanSoVaDuSoLuong(sdtQL, 10))
            {
                ViewBag.thongBao = "Số điện thoại không hợp lệ !";
                return View();
            }

            // Lưu ảnh cũ hoặc ảnh mới (nếu có)
            string anhQL = null;
            try
            {
                var img = Request.Files["anhQL_moi"];
                string fileImg = System.IO.Path.GetFileName(img.FileName);
                var path = Server.MapPath("/Images/" + fileImg);
                img.SaveAs(path);
                anhQL = fileImg;
            }
            catch
            {
                anhQL = anhQL_cu;
            }

            // Kiểm tra định dạng ngày
            try
            {
                ngaySinh = DateTime.ParseExact(ngaySinh, "dd/MM/yyyy", null).ToString("yyyy-MM-dd");
            }
            catch
            {
                ViewBag.thongBao = "Dữ liệu ngày không đúng !";
                return View();
            }

            // Chuẩn hoá dữ liệu trước khi đưa vào database
            hoQL = hoQL.Trim();
            tenQL = tenQL.Trim();
            sdtQL = sdtQL.Trim();
            email = email.Trim();

            byte gioi_tinh = 1;
            if (!gioiTinh) gioi_tinh = 0;

            string cmd = "update QuanLy set hoQL = N'" + hoQL + "', tenQL = N'" + tenQL + "', gioiTinh = " + gioi_tinh + ", ngaySinh = '" + ngaySinh + "', anhQL = N'" + anhQL + "', sdtQL = '" + sdtQL + "', email = '" + email + "'";
            db.Database.ExecuteSqlCommand(cmd);

            return RedirectToAction("ThongTinQuanLy");
        }



        // Hiển thị trang Thêm sinh viên
        public ActionResult ThemSinhVien()
        {
            if (Session["_taiKhoan"] == null) return RedirectToAction("DangNhap", "HeThong");

            return View();
        }
        // Xử lý khi người dùng nhâp thông tin của sinh viên xong
        [HttpPost]
        public ActionResult ThemSinhVien(string maSV, string hoSV, string tenSV, bool gioiTinh, DateTime ngaySinh, string lop, bool dongPhi, string anhSV, string queQuan, string sdtSV, string matKhau, string email, string maPhong)
        {
            if (Session["_taiKhoan"] == null) return RedirectToAction("DangNhap", "HeThong");

            // Lưu tạm lại dữ liệu nhập
            ViewBag.maSV = maSV;
            ViewBag.hoSV = hoSV;
            ViewBag.tenSV = tenSV;
            ViewBag.gioiTinh = gioiTinh;
            ViewBag.lop = lop;
            ViewBag.dongPhi = dongPhi;
            ViewBag.queQuan = queQuan;
            ViewBag.sdtSV = sdtSV;
            ViewBag.maPhong = maPhong;

            // Kiểm tra có nhập dấu cách trong mã sinh viên hay không ?
            if (!HT.KiemTraDauCach(maSV))
            {
                ViewBag.thongBao = "Mã sinh viên không được chứa dấu cách !";
                return View();
            }

            // Kiểm tra có nhập dấu cách trong số điện thoại hay không ?
            if (!HT.KiemTraDauCach(sdtSV))
            {
                ViewBag.thongBao = "Số điện thoại không được chứa dấu cách !";
                return View();
            }

            // Kiểm tra mã sinh viên nhập có đủ 8 ký tự số hay không ?
            if (!HT.KiemTraChuoiToanSoVaDuSoLuong(maSV, 8))
            {
                ViewBag.thongBao = "Mã sinh viên phải có độ dài là 8 ký tự và đều là số !";
                return View();
            }

            // Kiểm tra có trùng mã sinh viên hay là không ?
            var a = db.SinhViens.Where(s => s.maSV == maSV);
            if (a.Count() > 0)
            {
                ViewBag.thongBao = "Mã sinh viên đã tồn tại !";
                return View();
            }

            // Kiểm tra có nhập dấu cách trong số điện thoại hay không ?
            if (!HT.KiemTraChuoiToanSoVaDuSoLuong(sdtSV, 10))
            {
                ViewBag.thongBao = "Số điện thoại không hợp lệ !";
                return View();
            }

            // Kiểm tra có nhập dấu cách trong phòng hay không ?
            if (!HT.KiemTraChuoiToanSoVaDuSoLuong(maPhong, 3))
            {
                ViewBag.thongBao = "Mã phòng phải có độ dài là 3 ký tự và đều là số !";
                return View();
            }

            // Kiểm tra mã phòng có hợp lệ so với số phòng thật hay không ?
            if (!HT.KiemTraMaPhongHopLe(maPhong))
            {
                ViewBag.thongBao = "Không có phòng " + maPhong + " !";
                return View();
            }

            // Kiểm tra phòng đã chọn có thiếu người để thêm sinh viên mới vào
            HT_DB htdb = new HT_DB();
            if (!htdb.KiemTraPhongThieuNguoi(maPhong))
            {
                ViewBag.thongBao = "Phòng " + maPhong + " đã đủ người !";
                return View();
            }


            // Chuẩn hoá dữ liệu trước khi đưa vào database
            maSV = maSV.Trim();
            hoSV = hoSV.Trim();
            tenSV = tenSV.Trim();
            lop = lop.Trim();
            queQuan = queQuan.Trim();
            sdtSV = sdtSV.Trim();
            maPhong = maPhong.Trim();

            string ngay_sinh = ngaySinh.ToString("yyyy-MM-dd");
            byte gioi_tinh = 1;
            if (!gioiTinh) gioi_tinh = 0;

            byte dong_phi = 0;
            if (dongPhi) dong_phi = 1;

            anhSV = "avt_default.jpg";
            matKhau = "1";
            email = "";

            string cmd = "insert into SinhVien values ('" + maSV + "', N'" + hoSV + "', N'" + tenSV + "', " + gioi_tinh + ", '" + ngay_sinh + "', '" + lop + "', " + dong_phi + ", N'" + anhSV + "', N'" + queQuan + "', '" + sdtSV + "', '" + matKhau + "', '" + email + "', '" + maPhong + "')";
            db.Database.ExecuteSqlCommand(cmd);

            var js = "<script>window.location.href='/QuanLies/TimKiemSinhVien'; localStorage.clear()</script>";
            return Content(js, "text/html");
        }



        // Hiển thị và xử lý trên trang Tìm kiếm sinh viên
        public ActionResult TimKiemSinhVien(string timThongTin = "")
        {
            if (Session["_taiKhoan"] == null) return RedirectToAction("DangNhap", "HeThong");

            ViewBag.timThongTin = timThongTin;
            timThongTin = timThongTin.Trim();

            // Chuyển đổi để tìm 'đóng phí ktx'
            short dongPhi = -1;
            string thuong = timThongTin.ToLower().Trim();
            if (thuong == "chưa đóng" || thuong == "chưa") dongPhi = 0;
            if (thuong == "đã đóng" || thuong == "đã") dongPhi = 1;

            // Truy vấn tìm kết quả
            string cmd = "select * from SinhVien";
            if (timThongTin.Length > 0)
                cmd += " where (maSV = '" + timThongTin + "') or (hoSV + ' ' + tenSV like N'%" + timThongTin + "%') or (lop like '%" + timThongTin + "%') or (sdtSV = '" + timThongTin + "') or (maPhong = '" + timThongTin + "') or (dongPhi = " + dongPhi + ")";

            var a = db.Database.SqlQuery<SinhVien>(cmd).ToList();
            return View(a);
        }



        // Hiển thị trang Cập nhật thông tin sinh viên
        public ActionResult CapNhatThongTinSinhVien(string id)
        {
            if (Session["_taiKhoan"] == null) return RedirectToAction("DangNhap", "HeThong");

            var a = db.SinhViens.Find(id);

            return View(a);
        }
        // Tiến hành xử lý lưu sinh viên sau khi cập nhật
        [HttpPost]
        public ActionResult CapNhatThongTinSinhVien(string maSV, string hoSV, string tenSV, bool gioiTinh, string ngaySinh, bool dongPhi, string matKhau, string maPhong, string lop, string anhSV, string queQuan, string email, string sdtSV)
        {
            if (Session["_taiKhoan"] == null) return RedirectToAction("DangNhap", "HeThong");

            // Lưu dữ liệu tạm từ web sau khi nhập
            ViewBag.maSV = maSV;
            ViewBag.hoSV = hoSV;
            ViewBag.tenSV = tenSV;
            ViewBag.gioiTinh = gioiTinh;
            ViewBag.ngaySinh = ngaySinh;
            ViewBag.dongPhi = dongPhi;
            ViewBag.matKhau = matKhau;
            ViewBag.maPhong = maPhong;
            ViewBag.lop = lop;
            ViewBag.anhSV = anhSV;
            ViewBag.queQuan = queQuan;
            ViewBag.email = email;
            ViewBag.sdtSV = sdtSV;

            // Kiểm tra định dạng ngày
            try
            {
                ngaySinh = DateTime.ParseExact(ngaySinh, "dd/MM/yyyy", null).ToString("yyyy-MM-dd");
            }
            catch
            {
                ViewBag.thongBao = "Dữ liệu ngày không đúng !";
                return View();
            }

            // Kiểm tra có nhập dấu cách trong phòng hay không ?
            if (!HT.KiemTraChuoiToanSoVaDuSoLuong(maPhong, 3))
            {
                ViewBag.thongBao = "Mã phòng phải có độ dài là 3 ký tự và đều là số !";
                return View();
            }

            // Kiểm tra mã phòng có hợp lệ so với số phòng thật hay không ?
            if (!HT.KiemTraMaPhongHopLe(maPhong))
            {
                ViewBag.thongBao = "Không có phòng " + maPhong + " !";
                return View();
            }

            // Kiểm tra phòng đã chọn có thiếu người để thêm sinh viên mới vào
            HT_DB htdb = new HT_DB();
            if (!htdb.KiemTraPhongThieuNguoi(maPhong))
            {
                ViewBag.thongBao = "Phòng " + maPhong + " đã đủ người !";
                return View();
            }

            // chuẩn hoá dữ liệu trước khi lưu vào database
            hoSV = hoSV.Trim();
            tenSV = tenSV.Trim();
            matKhau = matKhau.Trim();
            maPhong = maPhong.Trim();

            byte gioi_tinh = 1, dong_phi = 0;
            if (!gioiTinh) gioi_tinh = 0;
            if (dongPhi) dong_phi = 1;

            string cmd = "update SinhVien set hoSV = N'" + hoSV + "', tenSV = N'" + tenSV + "', gioiTinh = " + gioi_tinh + ", ngaySinh = '" + ngaySinh + "', dongPhi = " + dong_phi + ", matKhau = '" + matKhau + "', maPhong = '" + maPhong + "' where maSV = '" + maSV + "'";
            db.Database.ExecuteSqlCommand(cmd);

            return RedirectToAction("TimKiemSinhVien");
        }



        // Hiển thị trang Xem thông tin sinh viên
        public ActionResult XemThongTinSinhVien(string id)
        {
            if (Session["_taiKhoan"] == null) return RedirectToAction("DangNhap", "HeThong");

            var a = db.SinhViens.Find(id);

            return View(a);
        }



        // Hiển thị trang Xoá sinh viên
        public ActionResult XoaSinhVien(string id)
        {
            if (Session["_taiKhoan"] == null) return RedirectToAction("DangNhap", "HeThong");

            var a = db.SinhViens.Find(id);

            return View(a);
        }
        [HttpPost]
        // Xử lý khi người dùng xoá sinh viên
        public ActionResult XoaSinhVien(string maSV, string cmd)
        {
            if (Session["_taiKhoan"] == null) return RedirectToAction("DangNhap", "HeThong");

            cmd = "delete SinhVien where maSV = '" + maSV + "'";
            db.Database.ExecuteSqlCommand(cmd);

            return RedirectToAction("TimKiemSinhVien");
        }



        // Hiển thị và xử lý trên trang Thống kê
        public ActionResult ThongKe(string phongTim = "")
        {
            if (Session["_taiKhoan"] == null) return RedirectToAction("DangNhap", "HeThong");

            // Lưu tạm phòng cần tìm
            ViewBag.phongTim = phongTim;

            // Truy vấn số lượng sinh viên hiện có
            var soLuongSinhvien = db.SinhViens.ToList();
            ViewBag.soLuongSinhVien = soLuongSinhvien.Count();

            // Truy vấn số lượng sinh viên hiện có và chưa đóng phí KTX
            var sinhVienChuaDongPhi = db.Database.SqlQuery<SinhVien>("select * from SinhVien where dongPhi = 0");
            ViewBag.sinhvienChuaDongPhi = sinhVienChuaDongPhi.Count();

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
