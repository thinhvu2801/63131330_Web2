package com.vmt.springbootsql.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import com.vmt.springbootsql.domain.Student;
import com.vmt.springbootsql.repository.StudentRepository;

@Service
public class StudentService {
    
    @Autowired
    private StudentRepository repo;
    
    public List<Student> listAll() {
        return repo.findAll();
    }
     
    public void save(Student std) {
        repo.save(std);
    }
     
    public Student get(long id) {
        return repo.findById(id).get();
    }
     
    public void delete(long id) {
        repo.deleteById(id);
    }

}