package com.vmt.bookwarehousemanagement.entities;
import java.util.Date;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import jakarta.persistence.Table;

@Entity
@Table(name = "phieu_nhap")
public class PhieuNhap {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "phieunhap_id")
    private Long id;

    @Column(name = "ngay_nhap")
    private Date ngayNhap;

    @ManyToOne
    @JoinColumn(name = "thukho_id")
    private ThuKho thuKho;

    @ManyToOne
    @JoinColumn(name = "sach_id")
    private Sach sach;

    @Column(name = "so_luong")
    private int soLuong;

    @Column(name = "gia")
    private double gia;

    @Column(name = "tong_tien")
    private double tongTien;

    // Constructors
    public PhieuNhap() {
    }

    public PhieuNhap(Date ngayNhap, ThuKho thuKho, Sach sach, int soLuong, double gia, double tongTien) {
        this.ngayNhap = ngayNhap;
        this.thuKho = thuKho;
        this.sach = sach;
        this.soLuong = soLuong;
        this.gia = gia;
        this.tongTien = tongTien;
    }

    // Getters and setters
    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public Date getNgayNhap() {
        return ngayNhap;
    }

    public void setNgayNhap(Date ngayNhap) {
        this.ngayNhap = ngayNhap;
    }

    public ThuKho getThuKho() {
        return thuKho;
    }

    public void setThuKho(ThuKho thuKho) {
        this.thuKho = thuKho;
    }

    public Sach getSach() {
        return sach;
    }

    public void setSach(Sach sach) {
        this.sach = sach;
    }

    public int getSoLuong() {
        return soLuong;
    }

    public void setSoLuong(int soLuong) {
        this.soLuong = soLuong;
    }

    public double getGia() {
        return gia;
    }

    public void setGia(double gia) {
        this.gia = gia;
    }

    public double getTongTien() {
        return tongTien;
    }

    public void setTongTien(double tongTien) {
        this.tongTien = tongTien;
    }
}
