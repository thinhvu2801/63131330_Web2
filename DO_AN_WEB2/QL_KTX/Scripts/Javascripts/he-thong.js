
// Chuyển đổi trang Đổi mật khẩu
const Link_DoiMatKhau = function () {
  window.open("../../HeThong/DoiMatKhau", "_self")
}

// Chuyển đến trang nhập
const Link_DangXuat = function () {
  if (confirm("Bạn muốn đăng xuất ?")) {
    window.open("../../HeThong/DangNhap", "_self")
  }
}

// Lưu lại ngày đã chọn vào Storage
const LuuNgay = function() {
  var layNgaySinh = document.getElementById("ngaySinh")
  localStorage.setItem("ngaySinh", layNgaySinh.value)
}

// Khi trang load để lấy giá trị ngày từ localStorage và đặt vào input với id="ngaySinh"
window.onload = function() {
  var ngaySinhDaChon = localStorage.getItem("ngaySinh")

  if (ngaySinhDaChon) {
    document.getElementById("ngaySinh").value = ngaySinhDaChon
  }
};

// Xử lý hiển thị mật khẩu
$(function() {
  $('.icon-eye').click(function() {
    var input_card = $(this).parent()
    var input_password = input_card.find('.input-password')
    var eye = $(this).find('i')
    
    if (input_password.attr('type') === 'password') {
      eye.removeClass('fa-eye-slash')
      eye.addClass('fa-eye')
    }
    else {
      eye.removeClass('fa-eye')
      eye.addClass('fa-eye-slash')
    }

    input_password.attr('type', input_password.attr('type') === 'password' ? 'text' : 'password')
  })
})