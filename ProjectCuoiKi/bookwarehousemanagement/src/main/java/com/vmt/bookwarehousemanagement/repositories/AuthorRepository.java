package com.vmt.bookwarehousemanagement.repositories;

import org.springframework.data.jpa.repository.JpaRepository;

import com.vmt.bookwarehousemanagement.entities.Author;

public interface AuthorRepository extends JpaRepository<Author, Long> {

}
