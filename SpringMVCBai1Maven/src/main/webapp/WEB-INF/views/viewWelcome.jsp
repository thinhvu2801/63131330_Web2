<%@ page pageEncoding="UTF-8"%>
<%@ page isELIgnored="false" %>
 <%@taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<link href="<c:url value="/resources/css/styles.css" />" rel="stylesheet">
	<!-- no jstl, use 
	<link href="${pageContext.request.contextPath}/resources/css/style.css" rel="stylesheet" >	
	 -->
<script src="<c:url value="/resources/js/test.js" />"></script>
<script src="${pageContext.request.contextPath}/resources/js/jquery.1.10.2.min.js" />"></script>
<title>welcom page</title>
</head>
<body>
	<h1>Chào  mừng MVC </h1>
	${msg}
</body>
</html>