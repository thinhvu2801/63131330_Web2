// package com.vmt.bookwarehousemanagement.controllers;

// import com.vmt.bookwarehousemanagement.entities.User;
// import com.vmt.bookwarehousemanagement.services.UserService;
// import org.springframework.beans.factory.annotation.Autowired;
// import org.springframework.stereotype.Controller;
// import org.springframework.ui.Model;
// import org.springframework.web.bind.annotation.*;

// @Controller
// public class LoginController {

//     @Autowired
//     private UserService userService;

//     @GetMapping("/")
//     public String loginForm() {
//         return "login";
//     }

//     @GetMapping("/login")
//     public String showLoginForm() {
//         return "login";
//     }

//     @PostMapping("/login")
//     public String loginSubmit(@RequestParam String username, @RequestParam String password, Model model) {
//         User user = userService.findByUsername(username);
//         if (user != null && user.getPassword().equals(password)) {
//             // Đăng nhập thành công, chuyển hướng tới trang list-books
//             return "list-books";}
//         // } else {
//         //     // Đăng nhập không thành công, hiển thị thông báo lỗi và trang đăng nhập lại
//         //     model.addAttribute("error", true);
//         //     return "list-books";
//         // }
//         return "list-books";
//     }

// }
