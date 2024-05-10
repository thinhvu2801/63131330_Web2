CREATE DATABASE IF NOT EXISTS bookwarehouse;
USE bookwarehouse;

CREATE TABLE IF NOT EXISTS Sach (
    sach_id INT PRIMARY KEY AUTO_INCREMENT,
    ten_sach VARCHAR(255),
    tac_gia VARCHAR(255),
    so_luong INT,
    gia DECIMAL(10,2)
);

CREATE TABLE IF NOT EXISTS ThuKho (
    thukho_id INT PRIMARY KEY AUTO_INCREMENT,
    ho_ten VARCHAR(255),
    ngay_sinh DATE,
    gioi_tinh VARCHAR(10)
);

CREATE TABLE IF NOT EXISTS PhieuNhap (
    phieunhap_id INT PRIMARY KEY AUTO_INCREMENT,
    ngay_nhap DATE,
    thukho_id INT,
    sach_id INT,
    so_luong INT,
    gia DECIMAL(10,2),
    tong_tien DECIMAL(10,2),
    FOREIGN KEY (thukho_id) REFERENCES ThuKho(thukho_id),
    FOREIGN KEY (sach_id) REFERENCES Sach(sach_id)
);

CREATE TABLE IF NOT EXISTS PhieuXuat (
    phieuxuat_id INT PRIMARY KEY AUTO_INCREMENT,
    ngay_xuat DATE,
    thukho_id INT,
    sach_id INT,
    so_luong INT,
    gia DECIMAL(10,2),
    tong_tien DECIMAL(10,2),
    FOREIGN KEY (thukho_id) REFERENCES ThuKho(thukho_id),
    FOREIGN KEY (sach_id) REFERENCES Sach(sach_id)
);

INSERT INTO Sach (ten_sach, tac_gia, so_luong, gia)
VALUES 
('Sách A', 'Tác giả A', 100, 10.99),
('Sách B', 'Tác giả B', 150, 12.99),
('Sách C', 'Tác giả C', 200, 15.99);
