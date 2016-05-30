<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@taglib prefix="t" tagdir="/WEB-INF/tags" %>

<t:layout>
    <jsp:body>
        <div class="row">
            <div class="8u">
                <h2>New password:</h2>
                <p>
                    <span style="font-size: 38px;" id="result">${newPassword}</span>
                </p>
            </div>
            <div class="4u">
                <ul>
                    <li><a href="/" id="submitButton" class="button button-big button-icon button-icon-rarrow">Generate</a></li>
                </ul>
            </div>
        </div>
        <div class="row">
            <div class="12u">
                <p style="font-size:18px">REST API GET/POST: http://getanewpassword.com/api/generatepassword</p>
            </div>
        </div>
    </jsp:body>
</t:layout>