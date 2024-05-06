package com.vmt.bookwarehousemanagement.services;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.vmt.bookwarehousemanagement.entities.ThuKho;
import com.vmt.bookwarehousemanagement.repositories.ThuKhoRepository;

import java.util.List;

@Service
public class ThuKhoService {

    @Autowired
    private ThuKhoRepository thuKhoRepository;

    public List<ThuKho> getAllThuKho() {
        return thuKhoRepository.findAll();
    }

    // Other methods as needed
}
