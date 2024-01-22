<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Stylish Form</title>
    <style>
        body {
            font-family: 'Arial', sans-serif;
            background-color: #f5f5f5;
            color: #333;
            margin: 0;
            padding: 0;
            height: 100vh;
        }

        h1 {
            color: #3498db;
            text-align: center;
        }

        form {
            max-width: 400px;
            margin: 20px auto;
            padding: 20px;
            background-color: #fff;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        span {
            display: block;
            margin-bottom: 10px;
            color: #555;
        }

        input {
            width: 100%;
            padding: 10px;
            margin-bottom: 15px;
            box-sizing: border-box;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        input[type="submit"] {
            background-color: #3498db;
            color: #fff;
            cursor: pointer;
        }

        input[type="submit"]:hover {
            background-color: #2980b9;
        }
    </style>
</head>
<body>
    <h1>NHẬP THÔNG TIN</h1>
    <form action="DoPOST" method="post">
        <span>Hãy nhập tên của bạn: </span>
        <input type="text" name="ten">
        <br>
        <span>Hãy nhập lớp của bạn:</span>
        <input type="text" name="lop">
        <br>
        <input type="submit" name="nop" value="GỬI THÔNG TIN">
    </form>
</body>
</html>
