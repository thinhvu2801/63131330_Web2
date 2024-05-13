// package com.vmt.bookwarehousemanagement.services;

// import com.vmt.bookwarehousemanagement.entities.User;
// import com.vmt.bookwarehousemanagement.repositories.UserRepository;
// import com.vmt.bookwarehousemanagement.services.UserService;
// import org.springframework.beans.factory.annotation.Autowired;
// import org.springframework.stereotype.Service;

// @Service
// public class UserServiceImpl implements UserService {

//     private final UserRepository userRepository;

//     @Autowired
//     public UserServiceImpl(UserRepository userRepository) {
//         this.userRepository = userRepository;
//     }

//     @Override
//     public User findByUsername(String username) {
//         return userRepository.findByUsername(username);
//     }
// }
