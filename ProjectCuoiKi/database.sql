CREATE DATABASE IF NOT EXISTS bookwarehouse;
USE bookwarehouse;
drop database bookwarehouse;

-- Table: authors
CREATE TABLE authors (
    id BIGINT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL UNIQUE,
    description VARCHAR(250) NOT NULL
);

-- Table: categories
CREATE TABLE categories (
    id BIGINT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(50) NOT NULL UNIQUE
);

-- Table: publishers
CREATE TABLE publishers (
    id BIGINT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL UNIQUE
);

-- Table: books
CREATE TABLE books (
    id BIGINT AUTO_INCREMENT PRIMARY KEY,
    isbn VARCHAR(50) NOT NULL UNIQUE,
    name VARCHAR(100) NOT NULL,
    serialName VARCHAR(50) NOT NULL,
    description VARCHAR(250) NOT NULL
);

-- Table for Many-to-Many relationship between books and authors
CREATE TABLE books_authors (
    book_id BIGINT,
    author_id BIGINT,
    PRIMARY KEY (book_id, author_id),
    FOREIGN KEY (book_id) REFERENCES books(id),
    FOREIGN KEY (author_id) REFERENCES authors(id)
);

-- Table for Many-to-Many relationship between books and categories
CREATE TABLE books_categories (
    book_id BIGINT,
    category_id BIGINT,
    PRIMARY KEY (book_id, category_id),
    FOREIGN KEY (book_id) REFERENCES books(id),
    FOREIGN KEY (category_id) REFERENCES categories(id)
);

-- Table for Many-to-Many relationship between books and publishers
CREATE TABLE books_publishers (
    book_id BIGINT,
    publisher_id BIGINT,
    PRIMARY KEY (book_id, publisher_id),
    FOREIGN KEY (book_id) REFERENCES books(id),
    FOREIGN KEY (publisher_id) REFERENCES publishers(id)
);

-- Table: users
CREATE TABLE users (
    id BIGINT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(100) NOT NULL UNIQUE,
    password VARCHAR(100) NOT NULL
);
-- Chèn dữ liệu vào bảng tác giả
INSERT INTO authors (name, description) VALUES
    ('Nguyễn Nhật Ánh', 'Tác giả nổi tiếng của văn học thiếu nhi Việt Nam.'),
    ('Haruki Murakami', 'Nhà văn nổi tiếng của Nhật Bản, tác phẩm nổi bật bao gồm "Norwegian Wood" và "Kafka on the Shore".');

-- Chèn dữ liệu vào bảng thể loại sách
INSERT INTO categories (name) VALUES
    ('Tiểu thuyết'),
    ('Kinh tế'),
    ('Khoa học');

-- Chèn dữ liệu vào bảng nhà xuất bản
INSERT INTO publishers (name) VALUES
    ('Nhà Xuất Bản Kim Đồng'),
    ('NXB Trẻ'),
    ('NXB Thế Giới');

-- Chèn dữ liệu vào bảng sách
INSERT INTO books (isbn, name, serialName, description) VALUES
    ('978-4-16-148410-0', 'Norwegian Wood', 'Bản gốc', 'Tiểu thuyết của Haruki Murakami.'),
    ('978-604-77-2371-3', 'Số Đỏ', 'Tái bản lần thứ 100', 'Tiểu thuyết của Nguyễn Hồng.'),
    ('978-604-77-2372-0', 'Dế Mèn Phiêu Lưu Ký', 'Tái bản', 'Truyện thiếu nhi của Tô Hoài.');

-- Chèn dữ liệu vào bảng many-to-many giữa sách và tác giả
INSERT INTO books_authors (book_id, author_id) VALUES
    (1, 2),
    (2, 1),
    (3, 1);

-- Chèn dữ liệu vào bảng many-to-many giữa sách và thể loại
INSERT INTO books_categories (book_id, category_id) VALUES
    (1, 1),
    (2, 1),
    (2, 2),
    (3, 1),
    (3, 3);

-- Chèn dữ liệu vào bảng many-to-many giữa sách và nhà xuất bản
INSERT INTO books_publishers (book_id, publisher_id) VALUES
    (1, 2),
    (2, 1),
    (3, 3);

-- Chèn dữ liệu vào bảng người dùng (ví dụ)
INSERT INTO users (username, password) VALUES
    ('admin', 'admin');
select * from users;
