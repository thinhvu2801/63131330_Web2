package com.vmt.bookwarehousemanagement.repositories;

import org.springframework.data.jpa.repository.JpaRepository;

import com.vmt.bookwarehousemanagement.entities.Publisher;

public interface PublisherRepository extends JpaRepository<Publisher, Long> {

}
