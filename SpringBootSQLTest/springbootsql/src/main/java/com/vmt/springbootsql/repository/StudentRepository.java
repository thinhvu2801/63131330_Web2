package com.vmt.springbootsql.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.vmt.springbootsql.domain.Student;

@Repository
public interface StudentRepository extends JpaRepository<Student, Long> {

}