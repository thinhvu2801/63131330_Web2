<%@ page pageEncoding="UTF-8"%>
<%@ page isELIgnored="false" %>
<%@taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Contact Us</title>
    <link href="<c:url value="/resources/css/styles.css" />" rel="stylesheet">

</head>
<body>
    <header>
        <nav>
            <ul>
                <li><a href="${pageContext.request.contextPath}/index">Home</a></li>
                <li><a href="${pageContext.request.contextPath}/about">About</a></li>
                <li><a href="${pageContext.request.contextPath}/contact">Contact</a></li>
                <li><a href="${pageContext.request.contextPath}/faq">FAQ</a></li>
            </ul>
        </nav>
    </header>
    
    <div class="content">
        <h1>Contact Us</h1>
        <p>This is the contact page content.</p>
    </div>

    <footer>
        <p>&copy; 2024 VMT</p>
    </footer>

    <script src="<c:url value="/resources/js/test.js" />"></script>
    <script src="${pageContext.request.contextPath}/resources/js/jquery.1.10.2.min.js"></script>
</body>
</html>
