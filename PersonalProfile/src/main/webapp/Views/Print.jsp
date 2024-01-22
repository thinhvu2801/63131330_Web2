<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>About Me</title>
    <style>
        body {
            font-family: 'Arial', sans-serif;
            background-color: #f2f2f2;
            text-align: center;
            margin: 0;
            padding: 0;
        }

        #container {
            max-width: 600px;
            margin: 50px auto;
            background-color: #ffffff;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        h1 {
            color: #4CAF50;
        }

        img {
            border-radius: 50%;
            max-width: 150px;
            margin-top: 20px;
        }

        p {
            color: #333333;
            font-size: 18px;
        }
    </style>
</head>
<body>

    <div id="container">
        <img src="https://th.bing.com/th/id/OIP.AJ3TCbxW9ECr7LANwlrBlwHaHa?rs=1&pid=ImgDetMain" alt="Avatar">
        <h1>Thông tin cá nhân của tôi</h1>
        <p>Họ và tên: <%= "Vũ Minh Thịnh" %></p>
        <p>Ngày sinh: <%= "28-01-2003" %></p>
        <p>Địa chỉ: <%= "Nha Trang" %></p>
        <p>Nghề nghiệp: <%= "Sinh viên CNTT" %></p>
    </div>

</body>
</html>
