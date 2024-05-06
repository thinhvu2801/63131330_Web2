package com.vmt.bookwarehousemanagement.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.vmt.bookwarehousemanagement.entities.Sach;

@Repository
public interface SachRepository extends JpaRepository<Sach, Long> {
}
