<%@ page import="java.io.*,java.util.*"%>
<%@ page import="javax.servlet.*"%>
<%@ page import="javax.servlet.http.*"%>

<%
    // Lấy thông tin đăng nhập từ form
    String username = request.getParameter("username");
    String password = request.getParameter("password");

    // Kiểm tra thông tin đăng nhập
    if ("123".equals(username) && "123".equals(password)) {
        // Đăng nhập thành công, chuyển hướng đến trang chính
        response.sendRedirect("Print.jsp");
    } else {
        // Đăng nhập thất bại, hiển thị thông báo
%>
        <html>
        <head>
            <title>Login Failed</title>
        </head>
        <body>
            <h2>Login Failed. Please check your username and password.</h2>
        </body>
        </html>
<%
    }
%>
