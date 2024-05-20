DROP DATABASE IF EXISTS bookwarehouse;
CREATE DATABASE bookwarehouse;
USE bookwarehouse;

-- Tạo bảng authors
CREATE TABLE authors (
    id BIGINT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL UNIQUE,
    description VARCHAR(250) NOT NULL
);

-- Tạo bảng books
CREATE TABLE books (
    id BIGINT AUTO_INCREMENT PRIMARY KEY,
    isbn VARCHAR(50) NOT NULL,
    name VARCHAR(100) NOT NULL,
    description VARCHAR(250) NOT NULL
);

-- Tạo bảng categories
CREATE TABLE categories (
    id BIGINT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(50) NOT NULL UNIQUE
);

-- Tạo bảng publishers
CREATE TABLE publishers (
    id BIGINT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL UNIQUE
);

-- Tạo bảng liên kết giữa books và authors (many-to-many)
CREATE TABLE books_authors (
    book_id BIGINT,
    author_id BIGINT,
    PRIMARY KEY (book_id, author_id),
    FOREIGN KEY (book_id) REFERENCES books(id) ON DELETE CASCADE,
    FOREIGN KEY (author_id) REFERENCES authors(id) ON DELETE CASCADE
);

-- Tạo bảng liên kết giữa books và categories (many-to-many)
CREATE TABLE books_categories (
    book_id BIGINT,
    category_id BIGINT,
    PRIMARY KEY (book_id, category_id),
    FOREIGN KEY (book_id) REFERENCES books(id) ON DELETE CASCADE,
    FOREIGN KEY (category_id) REFERENCES categories(id) ON DELETE CASCADE
);

-- Tạo bảng liên kết giữa books và publishers (many-to-many)
CREATE TABLE books_publishers (
    book_id BIGINT,
    publisher_id BIGINT,
    PRIMARY KEY (book_id, publisher_id),
    FOREIGN KEY (book_id) REFERENCES books(id) ON DELETE CASCADE,
    FOREIGN KEY (publisher_id) REFERENCES publishers(id) ON DELETE CASCADE
);

-- Tắt chế độ safe update
SET SQL_SAFE_UPDATES = 0;

-- Chèn thêm dữ liệu vào bảng tác giả
INSERT INTO authors (name, description) VALUES
    ('Haruki Murakami', 'Tác giả người Nhật nổi tiếng với các tác phẩm văn học độc đáo.'),
    ('Nguyễn Hồng', 'Tác giả của cuốn tiểu thuyết nổi tiếng "Số Đỏ".'),
    ('Tô Hoài', 'Nhà văn Việt Nam, tác giả của nhiều tác phẩm thiếu nhi.'),
    ('Virginia Woolf', 'Tiểu thuyết gia người Anh, một trong những tác giả quan trọng của thế kỷ 20.'),
    ('Emily Brontë', 'Nhà văn người Anh, tác giả của cuốn tiểu thuyết "Wuthering Heights".'),
    ('Jane Austen', 'Nữ văn sĩ người Anh, tác giả của nhiều tiểu thuyết kinh điển.'),
    ('F. Scott Fitzgerald', 'Tiểu thuyết gia người Mỹ, tác giả của "The Great Gatsby".'),
    ('J.R.R. Tolkien', 'Tiểu thuyết gia người Anh, tác giả của "The Lord of the Rings".'),
    ('Stephen King', 'Nhà văn người Mỹ, tác giả của nhiều tiểu thuyết kinh dị nổi tiếng.'),
    ('Ernest Hemingway', 'Nhà văn người Mỹ, tác giả của nhiều tác phẩm văn học kinh điển.'),
    ('Hermann Hesse', 'Nhà văn người Đức, tác giả của "Siddhartha".'),
    ('Margaret Atwood', 'Nhà văn người Canada, tác giả của "The Handmaid''s Tale".'),
    ('Gabriel García Márquez', 'Nhà văn người Colombia, tác giả của "Love in the Time of Cholera".');
    
-- Chèn thêm dữ liệu vào bảng thể loại sách
INSERT INTO categories (name) VALUES
    ('Tiểu thuyết'),
    ('Truyện thiếu nhi'),
    ('Kinh điển'),
    ('Kinh dị'),
    ('Phiêu lưu'),
    ('Tâm lý học');

-- Chèn thêm dữ liệu vào bảng nhà xuất bản
INSERT INTO publishers (name) VALUES
    ('Vintage Books'),
    ('Nhà Xuất Bản Trẻ'),
    ('Penguin Books'),
    ('Houghton Mifflin Harcourt'),
    ('HarperCollins'),
    ('Simon & Schuster'),
    ('Faber & Faber');

-- Chèn thêm dữ liệu vào bảng sách
INSERT INTO books (isbn, name, description) VALUES
    ('978-4-16-148410-0', 'Norwegian Wood', 'Tiểu thuyết của Haruki Murakami.'),
    ('978-604-77-2371-3', 'Số Đỏ', 'Tiểu thuyết của Nguyễn Hồng.'),
    ('978-604-77-2372-0', 'Dế Mèn Phiêu Lưu Ký',  'Truyện thiếu nhi của Tô Hoài.'),
    ('978-0-15-107255-8', 'Mrs. Dalloway',  'Tiểu thuyết của Virginia Woolf được viết trong một ngày.'),
    ('978-0-06-112008-4', 'Wuthering Heights',  'Cuốn tiểu thuyết nổi tiếng của Emily Brontë.'),
    ('978-0-006-20244-6', 'Pride and Prejudice', 'A novel by Jane Austen.'),
    ('978-0-445-23643-0', 'The Great Gatsby', 'A novel by F. Scott Fitzgerald.'),
    ('978-0-544-37966-9', 'The Lord of the Rings', 'A fantasy novel by J.R.R. Tolkien.'),
    ('978-0-451-22148-3', 'It', 'A horror novel by Stephen King.'),
    ('978-1-4532-3523-7', 'The Old Man and the Sea', 'A novel by Ernest Hemingway.'),
    ('978-0-15-694876-6', 'To the Lighthouse', 'A novel by Virginia Woolf.'),
    ('978-0-14-038154-5', 'Wuthering Heights', 'A novel by Emily Brontë.'),
    ('978-0-8041-7231-9', 'Siddhartha', 'A novel by Hermann Hesse.'),
    ('978-1-9821-2823-3', 'The Handmaid''s Tale', 'A novel by Margaret Atwood.'),
    ('978-1-4000-3039-7', 'Love in the Time of Cholera', 'A novel by Gabriel García Márquez.');


-- Dựa vào thông tin sách, thêm dữ liệu vào bảng liên kết với tác giả
INSERT INTO books_authors (book_id, author_id) VALUES
    (1, 1),  -- Norwegian Wood - Haruki Murakami
    (2, 2),  -- Số Đỏ - Nguyễn Hồng
    (3, 3),  -- Dế Mèn Phiêu Lưu Ký - Tô Hoài
    (4, 4),  -- Mrs. Dalloway - Virginia Woolf
    (5, 5),  -- Wuthering Heights - Emily Brontë
    (6, 6),  -- Pride and Prejudice - Jane Austen
    (7, 7),  -- The Great Gatsby - F. Scott Fitzgerald
    (8, 8),  -- The Lord of the Rings - J.R.R. Tolkien
    (9, 9),  -- It - Stephen King
    (10, 10),  -- The Old Man and the Sea - Ernest Hemingway
    (11, 4),  -- To the Lighthouse - Virginia Woolf
    (12, 5),  -- Wuthering Heights - Emily Brontë
    (13, 11), -- Siddhartha - Hermann Hesse
    (14, 12), -- The Handmaid's Tale - Margaret Atwood
    (15, 13); -- Love in the Time of Cholera - Gabriel García Márquez

-- Dựa vào thông tin sách, thêm dữ liệu vào bảng liên kết với thể loại
INSERT INTO books_categories (book_id, category_id) VALUES
    (1, 1),  -- Norwegian Wood - Tiểu thuyết
    (2, 1),  -- Số Đỏ - Tiểu thuyết
    (3, 2),  -- Dế Mèn Phiêu Lưu Ký - Truyện thiếu nhi
    (4, 1),  -- Mrs. Dalloway - Tiểu thuyết
    (5, 3),  -- Wuthering Heights - Kinh điển
    (6, 1),  -- Pride and Prejudice - Tiểu thuyết
    (7, 1),  -- The Great Gatsby - Tiểu thuyết
    (8, 5),  -- The Lord of the Rings - Phiêu lưu
    (9, 4),  -- It - Kinh dị
    (10, 5), -- The Old Man and the Sea - Phiêu lưu
    (11, 1), -- To the Lighthouse - Tiểu thuyết
    (12, 3), -- Wuthering Heights - Truyện thiếu nhi
    (13, 1), -- Siddhartha - Tiểu thuyết
    (14, 1), -- The Handmaid's Tale - Tiểu thuyết
    (15, 1); -- Love in the Time of Cholera - Tiểu thuyết

-- Dựa vào thông tin sách, thêm dữ liệu vào bảng liên kết với nhà xuất bản
INSERT INTO books_publishers (book_id, publisher_id) VALUES
    (1, 1),  -- Norwegian Wood - Vintage Books
    (2, 2),  -- Số Đỏ - Nhà Xuất Bản Trẻ
    (3, 2),  -- Dế Mèn Phiêu Lưu Ký - Nhà Xuất Bản Trẻ
    (4, 3),  -- Mrs. Dalloway - Penguin Books
    (5, 3),  -- Wuthering Heights - Penguin Books
    (6, 4),  -- Pride and Prejudice - Houghton Mifflin Harcourt
    (7, 5),  -- The Great Gatsby - HarperCollins
    (8, 6),  -- The Lord of the Rings - Simon & Schuster
    (9, 7),  -- It - Faber & Faber
    (10, 6), -- The Old Man and the Sea - Simon & Schuster
    (11, 3), -- To the Lighthouse - Penguin Books
    (12, 2), -- Wuthering Heights - Nhà Xuất Bản Trẻ
    (13, 6), -- Siddhartha - Simon & Schuster
    (14, 7), -- The Handmaid's Tale - Faber & Faber
    (15, 7); -- Love in the Time of Cholera - Faber & Faber