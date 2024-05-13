package com.vmt.bookwarehousemanagement.repositories;

import org.springframework.data.jpa.repository.JpaRepository;

import com.vmt.bookwarehousemanagement.entities.Category;

public interface CategoryRepository extends JpaRepository<Category, Long> {

}
