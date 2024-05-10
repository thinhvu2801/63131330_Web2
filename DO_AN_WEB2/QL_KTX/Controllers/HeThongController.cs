using QL_KTX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QL_KTX.Controllers
{
    public class HeThongController : Controller
    {
        // Database
        private QLKTXEntities1 db = new QLKTXEntities1();



        // Hiển thị trang Đăng nhập - index của controller hệ thống
        public ActionResult DangNhap()
        {
            Session["_taiKhoan"] = null;
            return View();
        }
        // Xử lý khi người dùng nhập đăng nhập
        [HttpPost]
        public ActionResult DangNhap(string taiKhoanNhap, string matKhauNhap)
        {
            // Lưu tạm giá trị người dùng đã nhập
            ViewBag.taiKhoanNhap = taiKhoanNhap;
            ViewBag.matKhauNhap = matKhauNhap;

            // Kiểm tra dữ liệu nhập cho tài khoản
            if (!HT.KiemTraDauCach(taiKhoanNhap))
            {
                ViewBag.thongBao = "Tài khoản không được chưa dấu cách !";
                return View();
            }

            // Kiểm tra dữ liệu nhập cho mật khẩu
            if (!HT.KiemTraDauCach(matKhauNhap))
            {
                ViewBag.thongBao = "Mật khẩu không được chưa dấu cách !";
                return View();
            }

            // Lưu tài khoản và mật khẩu nhập vào Session
            Session["_taiKhoan"] = taiKhoanNhap;

            // Kiểm tra người tài khoản truy cập (quản lý hoặc sinh viên)
            if (taiKhoanNhap == "admin")
            {
                var QL = db.QuanLies.Where(a => a.taiKhoan == taiKhoanNhap).First();
                if (QL.matKhau == matKhauNhap)
                {
                    Session["_tenNguoiTruyCap"] = QL.hoQL + ' ' + QL.tenQL;
                    return RedirectToAction("ThongTinQuanLy", "QuanLies");
                }
            }
            else
            {
                var SV = db.SinhViens.Where(a => a.maSV == taiKhoanNhap);
                if (SV.Count() > 0)
                {
                    if (SV.First().matKhau == matKhauNhap)
                    {
                        Session["_tenNguoiTruyCap"] = SV.First().hoSV + ' ' + SV.First().tenSV;
                        return RedirectToAction("ThongTinSinhVien", "SinhViens");
                    }
                }
            }
            ViewBag.thongBao = "Tài khoản hoặc mật khẩu không chính xác !";
            return View();
        }



        // Hiển thị trang Đổi mật khẩu
        public ActionResult DoiMatKhau()
        {
            return View();
        }
        // Xử lý khi người dùng đổi mật khẩu
        [HttpPost]
        public ActionResult DoiMatKhau(string taiKhoanNhap, string matKhauCuNhap, string matKhauMoiNhap, string matKhauMoiXacNhanNhap)
        {
            // Lưu tạm giá trị dữ liệu người dùng nhập vào
            ViewBag.taiKhoanNhap = taiKhoanNhap;
            ViewBag.matKhauCuNhap = matKhauCuNhap;
            ViewBag.matKhauMoiNhap = matKhauMoiNhap;
            ViewBag.matKhauMoiXacNhanNhap = matKhauMoiXacNhanNhap;

            // Kiểm tra dữ liệu nhập cho tài khoản
            if (!HT.KiemTraDauCach(taiKhoanNhap))
            {
                ViewBag.thongBao = "Tài khoản không được chưa dấu cách !";
                return View();
            }

            // Kiểm tra dữ liệu nhập cho mật khẩu cũ
            if (!HT.KiemTraDauCach(matKhauCuNhap))
            {
                ViewBag.thongBao = "Mật khẩu cũ không được chưa dấu cách !";
                return View();
            }

            // Kiểm tra dữ liệu nhập cho mật khẩu mới
            if (!HT.KiemTraDauCach(matKhauMoiNhap))
            {
                ViewBag.thongBao = "Mật khẩu mới không được chưa dấu cách !";
                return View();
            }

            // Kiểm tra dữ liệu nhập cho tài khoản
            if (!HT.KiemTraDauCach(matKhauMoiXacNhanNhap))
            {
                ViewBag.thongBao = "Mật khẩu xác nhận không được chưa dấu cách !";
                return View();
            }

            // Kiểm tra người truy cập
            HT_DB htdb = new HT_DB();
            short nguoiTruyCap = htdb.KiemTraNguoiTruyCap(taiKhoanNhap);
            string matKhauTruyCap = null;
            string cmd = null;

            // Tài khoản không chính xác
            if (nguoiTruyCap == 0)
            {
                ViewBag.thongBao = "Tài khoản không chính xác !";
                return View();
            }

            // Là quản lý
            if (nguoiTruyCap == 1)
            {
                var a = db.QuanLies.Where(s => s.taiKhoan == taiKhoanNhap).First();
                matKhauTruyCap = a.matKhau;
                cmd = "update QuanLy set matKhau = '" + matKhauMoiNhap + "'";
            }

            // Là sinh viên
            if (nguoiTruyCap == 2)
            {
                var a = db.SinhViens.Where(s => s.maSV == taiKhoanNhap).First();
                matKhauTruyCap = a.matKhau;
                cmd = "update SinhVien set matKhau = '" + matKhauMoiNhap + "' where maSV = '" + taiKhoanNhap + "'";
            }

            // Kiểm tra mật khẩu cũ nhập có chỉnh xác không ?
            if (matKhauCuNhap != matKhauTruyCap)
            {
                ViewBag.thongBao = "Mật khẩu cũ không chính xác !";
                return View();
            }

            // Kiểm tra mật khẩu mới trùng mật khẩu cũ không ?
            if (matKhauMoiNhap == matKhauCuNhap)
            {
                ViewBag.thongBao = "Mật khẩu mới không được trùng với mật khẩu cũ !";
                return View();
            }

            // Kiểm tra mật khẩu mới có trùng nhau không ?
            if (matKhauMoiNhap != matKhauMoiXacNhanNhap)
            {
                ViewBag.thongBao = "Mật khẩu xác nhận không khớp !";
                return View();
            }

            // Tiến hành đổi mật khẩu
            db.Database.ExecuteSqlCommand(cmd);

            // Khi dổi mật xong mật khẩu mới
            var js = "<script>alert('Đổi mật khẩu thành công !'); window.location.href = '/HeThong/DoiMatKhau'</script>";
            return Content(js, "text/html");
        }



        // Hiển thị trang Quên mật khẩu
        public ActionResult QuenMatKhau()
        {
            return View();
        }
        // Xử lý khi người dùng nhập lại mật khẩu mới
        [HttpPost]
        public ActionResult QuenMatKhau(string taiKhoanNhap, string email)
        {
            // Lưu tạm giá trị người dùng đã nhập
            ViewBag.taiKhoanNhap = taiKhoanNhap;
            ViewBag.email = email;

            if (!HT.KiemTraDauCach(taiKhoanNhap))
            {
                ViewBag.thongBao = "Tài khoản không được chưa dấu cách !";
                return View();
            }

            // Kiểm tra dữ liệu nhập cho email
            if (!HT.KiemTraDauCach(email))
            {
                ViewBag.thongBao = "Email không được chưa dấu cách !";
                return View();
            }

            // Kiểm tra người truy cập
            HT_DB htdb = new HT_DB();
            short nguoiTruyCap = htdb.KiemTraNguoiTruyCap(taiKhoanNhap);
            string emailTruyCap = null;
            string maTaoLai = null;

            // Tài khoản không chính xác
            if (nguoiTruyCap == 0)
            {
                ViewBag.thongBao = "Tài khoản không chính xác !";
                return View();
            }

            // Là quản lý
            if (nguoiTruyCap == 1)
            {
                var a = db.QuanLies.Where(s => s.taiKhoan == taiKhoanNhap).First();
                emailTruyCap = a.email;
            }

            // Là sinh viên
            if (nguoiTruyCap == 2)
            {
                var a = db.SinhViens.Where(s => s.maSV == taiKhoanNhap).First();
                emailTruyCap = a.email;
            }

            // Kiểm tra email có phải của tài khoản hay không ?
            if (email != emailTruyCap)
            {
                ViewBag.thongBao = "Email không chính xác !";
                return View();
            }

            // Xử lý khi tài khoản cần lấy lại mật khẩu hợp lệ

            // Lưu thông tin để chuyển sang trang lấy lại
            maTaoLai = HT.MaTaoLai();
            Session["_taiKhoan"] = taiKhoanNhap;
            Session["_nguoiTruyCap"] = nguoiTruyCap;
            Session["_maTaoLai"] = maTaoLai;
            Session["_email"] = email;

            // Gửi mã tạo lại cho email
            HT.GuiMaTaoLai(email, maTaoLai);

            return RedirectToAction("QuenMatKhau_TaoLai");
        }



        // Hiển thị trang Quên mật khẩu - tạo lại
        public ActionResult QuenMatKhau_TaoLai()
        {
            if (Session["_taiKhoan"] == null) return RedirectToAction("QuenMatKhau");

            string email = Session["_email"].ToString();
            ViewBag.thongBao = "Kiểm tra email '" + email + "' để lấy mã xác nhận.";
            return View();
        }
        // Xử lý khi người dùng nhập nhập mật khẩu mới để tạo lại
        [HttpPost]
        public ActionResult QuenMatKhau_TaoLai(string maTaoLai, string matKhauMoi, string xacNhanMatKhauMoi)
        {
            if (Session["_taiKhoan"] == null) return RedirectToAction("QuenMatKhau");

            // Kiểm tra dữ liệu nhập vào của mã tạo lại
            if (!HT.KiemTraDauCach(maTaoLai))
            {
                ViewBag.thongBao = "Mã tạo lại không chứa dấu cách !";
                return View();
            }

            // Kiểm tra mã tạo lại có khớp không ?
            if (maTaoLai != Session["_maTaoLai"].ToString())
            {
                ViewBag.thongBao = "Mã tạo lại không chính xác !";
                return View();
            }

            // Kiểm tra dữ liệu nhập vào của mật khẩu mới
            if (!HT.KiemTraDauCach(matKhauMoi))
            {
                ViewBag.thongBao = "Mật khẩu mới không được chứa dấu cách !";
                return View();
            }

            // Kiểm tra dữ liệu nhập vào của xác nhận mật khẩu mới
            if (!HT.KiemTraDauCach(xacNhanMatKhauMoi))
            {
                ViewBag.thongBao = "Mật khẩu xác nhận không được chứa dấu cách !";
                return View();
            }

            // Kiểm tra xem mật khẩu mới có khớp mật khẩu xác nhận không ?
            if (matKhauMoi != xacNhanMatKhauMoi)
            {
                ViewBag.thongBao = "Mật khẩu xác nhận không khớp !";
                return View();
            }

            // Xử lý cấp lại mật khẩu mới
            string cmd = null;
            short nguoiTruyCap = Convert.ToInt16(Session["_nguoiTruyCap"].ToString());

            // Nếu là quản lý
            if (nguoiTruyCap == 1)
            {
                cmd = "update QuanLy set matKhau = '" + matKhauMoi + "'";
            }
            // Ngược lại, sinh viên
            else
            {
                string taiKhoanNhap = Session["_taiKhoan"].ToString();
                cmd = "update SinhVien set matKhau = '" + matKhauMoi + "' where maSV = '" + taiKhoanNhap + "'";
            }

            // Tiến hành đổi lại mật khẩu mới
            db.Database.ExecuteSqlCommand(cmd);

            // Thông báo khi đổi xong mật khẩu mới
            var js = "<script>alert('Đổi mật khẩu thành công.'); window.location.href='/HeThong/DangNhap'</script>";
            return Content(js, "text/html");
        }
    }
}