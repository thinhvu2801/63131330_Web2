using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QL_KTX.Models
{
    public class HT
    {
        // Kiểm tra trong chuỗi nhập vào có dáu cách hay không ?
        public static bool KiemTraDauCach(string chuoiKiemTra = "")
    {
        if (chuoiKiemTra != chuoiKiemTra.Trim()) return false;
        foreach (char s in chuoiKiemTra)
            if (s == ' ') return false;

        return true;
    }

    // Random tạo mã tạo lại cho người dùng
    public static string MaTaoLai()
    {
        Random random = new Random();
        int numberMax = 5;
        string maTaoLai = null;

        for (int i = 1; i <= numberMax; i++)
        {
            int x = random.Next(0, 10);
            maTaoLai += x;
        }

        return maTaoLai;
    }

    // Gửi mã tạo lại qua email cho người dùng
    public static void GuiMaTaoLai(string email = "", string maTaoLai = "")
    {
        // Khởi tạo cho email
        string from, password, to, subject, body;
        from = "thinh.vm.63cntt@ntu.edu.vn";
        password = "Thinhkid1";
        to = email;
        subject = "Tạo lại mật khẩu";
        body = "Mã tạo lại mật khẩu của bạn là: " + maTaoLai;

        // Tiến hành gửi
        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.From = new System.Net.Mail.MailAddress(from);
        mail.To.Add(to);
        mail.Subject = subject;
        mail.Body = body;
        mail.IsBodyHtml = true;
        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
        smtp.Credentials = new System.Net.NetworkCredential(from, password);
        smtp.EnableSsl = true;
        smtp.Send(mail);
    }

    // Kiểm tra mã sinh viên có đủ n ký tự và toàn số
    public static bool KiemTraChuoiToanSoVaDuSoLuong(string chuoi, int soLuongSo)
    {
        if (chuoi.Length != soLuongSo) return false;
        foreach (char s in chuoi)
            if (!(s >= '0' && s <= '9')) return false;

        return true;
    }

    // Kiểm tra mã phòng có hợp lệ hay không ?
    public static bool KiemTraMaPhongHopLe(string maPhong)
    {
        byte tang = Convert.ToByte(maPhong.Substring(0, 1));
        byte phong = Convert.ToByte(maPhong.Substring(1, 2));

        if (!(tang >= 1 && tang <= 5)) return false;
        if (!(phong >= 1 && phong <= 14)) return false;

        return true;
    }
}

public class HT_DB
{
        // Database
        private QLKTXEntities1 db = new QLKTXEntities1();

        // Kiểm tra tài khoản thuộc người truy cập vào là ai ?
        public short KiemTraNguoiTruyCap(string taiKhoanNhap = "")
        {
        if (taiKhoanNhap == "admin") return 1;
        var SV = db.SinhViens.Where(a => a.maSV == taiKhoanNhap);
        if (SV.Count() > 0) return 2;

        return 0;
        }

    // Kiểm tra phòng xxx có còn thiếu người không ?
    public bool KiemTraPhongThieuNguoi(string maPhong)
    {
        string cmd = "select P.maPhong, (8 - count(S.maSV)) as conThieu from Phong P left join SinhVien S on P.maPhong = S.maPhong where P.maPhong = '" + maPhong + "' group by P.maPhong";
        var a = db.Database.SqlQuery<TraCuuPhongThieuNguoi>(cmd);
        if (a.First().conThieu > 0) return true;

        return false;
    }
}
}