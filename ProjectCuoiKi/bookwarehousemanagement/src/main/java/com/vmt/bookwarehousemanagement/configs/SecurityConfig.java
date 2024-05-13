// package com.vmt.bookwarehousemanagement.configs;

// import org.springframework.context.annotation.Configuration;
// import org.springframework.security.config.annotation.authentication.builders.AuthenticationManagerBuilder;
// import org.springframework.security.config.annotation.web.builders.HttpSecurity;
// import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
// import org.springframework.security.config.annotation.web.configuration.WebSecurityConfigurerAdapter;

// @Configuration
// @EnableWebSecurity
// public class SecurityConfig extends WebSecurityConfigurerAdapter {

//     @Override
//     protected void configure(HttpSecurity http) throws Exception {
//         http
//                 .authorizeRequests(requests -> requests
//                         .antMatchers("/", "/home").permitAll() // Cho phép truy cập vào trang home và các trang có URL "/"
//                         .anyRequest().authenticated())
//                 .formLogin(login -> login // Cấu hình cho phép người dùng đăng nhập
//                         .loginPage("/login") // Chuyển hướng đến trang login
//                         .permitAll())
//                 .logout(logout -> logout // Cấu hình cho phép logout
//                         .permitAll());
//     }

//     @Override
//     protected void configure(AuthenticationManagerBuilder auth) throws Exception {
//         auth
//             .inMemoryAuthentication()
//                 .withUser("admin")
//                 .password("{noop}admin")
//                 .roles("USER");
//     }
// }
