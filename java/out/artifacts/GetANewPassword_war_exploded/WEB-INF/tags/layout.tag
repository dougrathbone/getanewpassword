<%@tag description="Base page template" pageEncoding="UTF-8"%>
<%@attribute name="header" fragment="true" %>

<!DOCTYPE html>
<html>
    <head>
        <title>Get a new Password - Secure password generator using Correct-Horse-Battery-Staple</title>
        <meta http-equiv="content-type" content="text/html; charset=utf-8" />
        <meta name="description" content="A fast and simple password generator based on the Correct-Horse-Battery-Staple comix from XKCD." />
        <meta name="keywords" content="password generator, generate password, password, correct horse battery staple, secure password" />
        <link rel="favicon" href="/favicon.ico"/>
        <link href="http://fonts.googleapis.com/css?family=Open+Sans:300,800" rel="stylesheet" type="text/css" />
        <link href="http://fonts.googleapis.com/css?family=Oleo+Script:400" rel="stylesheet" type="text/css" />
        <script src="/content/5grid/jquery.js"></script>
        <script src="/content/5grid/init.js?use=mobile,desktop,1000px&amp;mobileUI=1&amp;mobileUI.theme=none&amp;mobileUI_titleBarOverlaid=1&amp;mobileUI_titleBarHeight=60&amp;viewport_is1000px=1060&amp;mobileUI_openerWidth=80"></script>
        <noscript>
            <link rel="stylesheet" href="/content/5grid/core.css" />
            <link rel="stylesheet" href="/content/5grid/core-desktop.css" />
            <link rel="stylesheet" href="/content/5grid/core-1200px.css" />
            <link rel="stylesheet" href="/content/5grid/core-noscript.css" />
            <link rel="stylesheet" href="/content/style.css" />
            <link rel="stylesheet" href="/content/style-desktop.css" />
        </noscript>
        <!--[if lte IE 8]><link rel="stylesheet" href="/Content/ie8.css" /><![endif]-->
        <!--[if lte IE 7]><link rel="stylesheet" href="/Content/ie7.css" /><![endif]-->

        <jsp:invoke fragment="header"/>
    </head>
    <body class="homepage">
        @Html.Partial("_GoogleAnalytics")
        <div id="header-wrapper">
            <div class="5grid-layout">
                <div class="row">
                    <div class="12u">
                        <header id="header">
                            <div id="logo">
                                <h1><a href="#" class="mobileUI-site-name">getanewpassword.com</a></h1>
                            </div>
                        </header>
                    </div>
                </div>
            </div>
        </div>
        <div id="banner-wrapper">
            <div class="5grid-layout">
                <div class="row">
                    <div class="12u">
                        <div id="banner" class="box">
                            <div class="5grid">
                                <jsp:doBody />
                            </div>
                        </div>
                    </div>
                </div>
                <p>
                    Inspired by <a href="http://xkcd.com/936/" rel="nofollow">xkcd</a> and <a href="http://correcthorsebatterystaple.net/" rel="nofollow">CorrectHorseBatteryStaple.net</a>
                </p>
            </div>
        </div>
        <script src="/content/site.js" async="async"></script>
    </body>
</html>
