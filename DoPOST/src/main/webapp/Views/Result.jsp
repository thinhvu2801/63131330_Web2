<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Info</title>
    <style>
        body {
            font-family: 'Arial', sans-serif;
            background-color: #f5f5f5;
            color: #333;
            margin: 0;
            padding: 0;
            display: flex;
            align-items: center;
            justify-content: center;
            height: 100vh;
            flex-direction: column; /* Display elements in a column layout */
        }

        h2 {
            color: #3498db;
            text-align: center;
        }

        p {
            color: #2c3e50;
            font-size: 18px;
            text-align: center;
            margin: 0;
        }

        /* Add some animation for a vibrant look */
        h2, p {
            opacity: 0;
            animation: fadeInUp 1s ease-in-out forwards;
        }

        @keyframes fadeInUp {
            from {
                transform: translateY(20px);
                opacity: 0;
            }
            to {
                transform: translateY(0);
                opacity: 1;
            }
        }
    </style>
</head>
<body>
    <h1>Hello!</h1>
    <div>
        <p>Tên:</p>
        <h2>${KEY_TEN}</h2>
    </div>
    <div>
        <p>Lớp:</p>
        <h2>${KEY_LOP}</h2>
    </div>
</body>
</html>
