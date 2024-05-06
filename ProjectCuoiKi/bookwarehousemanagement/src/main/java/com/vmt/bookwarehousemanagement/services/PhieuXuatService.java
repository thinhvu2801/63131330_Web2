package com.vmt.bookwarehousemanagement.services;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.vmt.bookwarehousemanagement.entities.PhieuXuat;
import com.vmt.bookwarehousemanagement.repositories.PhieuXuatRepository;

import java.util.List;
import java.util.Optional;

@Service
public class PhieuXuatService {

    @Autowired
    private PhieuXuatRepository phieuXuatRepository;

    public List<PhieuXuat> getAllPhieuXuat() {
        return phieuXuatRepository.findAll();
    }

    public Optional<PhieuXuat> getPhieuXuatById(Long id) {
        return phieuXuatRepository.findById(id);
    }

    public PhieuXuat saveOrUpdatePhieuXuat(PhieuXuat phieuXuat) {
        return phieuXuatRepository.save(phieuXuat);
    }

    public void deletePhieuXuat(Long id) {
        phieuXuatRepository.deleteById(id);
    }
}
