// package com.vmt.bookwarehousemanagement.entities;

// import javax.persistence.Column;
// import javax.persistence.Entity;
// import javax.persistence.GeneratedValue;
// import javax.persistence.GenerationType;
// import javax.persistence.Id;
// import javax.persistence.Table;

// import lombok.Getter;
// import lombok.NoArgsConstructor;
// import lombok.Setter;

// @Getter
// @Setter
// @NoArgsConstructor
// @Entity
// @Table(name = "users")
// public class User {

//     @Id
//     @GeneratedValue(strategy = GenerationType.IDENTITY)
//     private Long id;

//     @Column(name = "username", length = 100, nullable = false, unique = true)
//     private String username;

//     @Column(name = "password", length = 100, nullable = false)
//     private String password;


//     public User(String username, String password) {
//         this.username = username;
//         this.password = password;
//     }



// }
