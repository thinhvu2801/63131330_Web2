package com.vmt.bookwarehousemanagement.services;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.vmt.bookwarehousemanagement.entities.Sach;
import com.vmt.bookwarehousemanagement.repositories.SachRepository;

import java.util.List;
import java.util.Optional;

@Service
public class SachService {

    @Autowired
    private SachRepository sachRepository;

    // Lấy tất cả sách
    public List<Sach> getAllSach() {
        return sachRepository.findAll();
    }

    // Tìm sách theo ID
    public Optional<Sach> getSachById(Long id) {
        return sachRepository.findById(id);
    }

    // Thêm hoặc cập nhật sách
    public Sach saveOrUpdateSach(Sach sach) {
        return sachRepository.save(sach);
    }

    // Xoá sách
    public void deleteSach(Long id) {
        sachRepository.deleteById(id);
    }
}
