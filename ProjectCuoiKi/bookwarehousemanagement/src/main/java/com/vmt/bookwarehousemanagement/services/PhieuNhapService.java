package com.vmt.bookwarehousemanagement.services;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.vmt.bookwarehousemanagement.entities.PhieuNhap;
import com.vmt.bookwarehousemanagement.repositories.PhieuNhapRepository;

import java.util.List;

@Service
public class PhieuNhapService {

    @Autowired
    private PhieuNhapRepository phieuNhapRepository;

    public List<PhieuNhap> getAllPhieuNhap() {
        return phieuNhapRepository.findAll();
    }

    // Other methods as needed
}
