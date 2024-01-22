<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Insert title here</title>
    <style>
        body {
            font-family: 'Arial', sans-serif;
            background-color: #f2f2f2;
            color: #333;
            margin: 0;
            padding: 0;
        }

        h1 {
            color: #008080;
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
            background-color: #008080;
            color: #fff;
            cursor: pointer;
        }

        input[type="submit"]:hover {
            background-color: #006666;
        }
    </style>
</head>
<body>
    <h1>Chào mừng đến với phần mềm tính BMI</h1>
    <form action="BMI" method="post">
        <div class="chieucao">
            <span>Nhập vào chiều cao của bạn (mét):</span>
            <input type="text" name="dulieucc">
        </div>
        <div class="cannang">
            <span>Nhập vào cân nặng của bạn:</span>
            <input type="text" name="dulieucn">
        </div>
        <input type="submit" value="Xác nhận">
    </form>
</body>
</html>
