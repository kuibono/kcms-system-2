<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.e.admin.Login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>管理登录</title>
    <link type="text/css" rel="Stylesheet" href="../data/css/reset.css" />
    <link type="text/css" rel="Stylesheet" href="../data/css/controls.css" />
    <script type="text/javascript" src="../data/jquery-1.8.0.min.js"></script>
    <script type="text/javascript" src="../data/script/basic.js"></script>
    <style type="text/css">
        #login
        {
            width: 300px;
            position: absolute;
            top: 0;
            left: 536px;
        }
        #float
        {
            top: 50%;
            height: 196px;
            width: 838px;
            margin: -154px 0 0 -418px;
            position: absolute;
            left: 50%;
        }
        #text
        {
            padding: 0;
            position: absolute;
            left: 0;
            width: 470px;
            padding: 20px;
            font-size: 18px;
            font-weight: 300;
            line-height: 22px;
            color: #EEE;
            text-align: left;
            text-shadow: gray 0 1px 2px;
            filter: Shadow(Color='black', Direction='135', Strength='2')
        }
        #text h1
        {
            margin-bottom: 3px;
            font-size: 20px;
            font-weight: 700;
            color: white;
        }
        #bg
        {
            position: fixed;
            width: 200%;
            height: 200%;
            left: -50%;
            background-color: #000;
        }
        #bg img
        {
            display: block;
            margin: auto;
            min-width: 50%;
            min-height: 50%;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
        }
        #footer
        {
            color: rgba(255, 255, 255, .25);
            position: absolute;
            bottom: 30px;
            width: 100%;
            font-size: 12px;
            color: white;
            text-align: center;
        }
        #footer ul
        {
            list-style-type: none;
            list-style: none;
            width: 838px;
            text-align: center;
            margin: 0 auto;
            display: inline-block;
        }
        #footer ul li
        {
            list-style: none;
            margin: 0 6px 0 0;
            display: inline;
            float: left;
            text-shadow: gray 0 1px 2px;
            filter: Shadow(Color='black', Direction='135', Strength='1',alpha='.25')
        }
        #footer ul li a
        {
            color: #FFF;
        }
        #footer ul li a:hover
        {
            color: #057ED0;
        }
        #sub
        {
            color: white;
            text-shadow: 0 -1px 0 rgba(0, 0, 0, .25);
            filter: Shadow(Color='black', Direction='135', Strength='1')
            background-color: #019AD2;
            background-repeat: repeat-x;
            background-image: -khtml-gradient(linear,left top,left bottom,from(#33BCEF),to(#019AD2));
            background-image: -moz-linear-gradient(#33BCEF,#019AD2);
            background-image: -ms-linear-gradient(#33BCEF,#019AD2);
            background-image: -webkit-gradient(linear,left top,left bottom,color-stop(0%,#33BCEF),color-stop(100%,#019AD2));
            background-image: -webkit-linear-gradient(#33BCEF,#019AD2);
            background-image: -o-linear-gradient(#33BCEF,#019AD2);
            background-image: linear-gradient(#33BCEF,#019AD2);
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#33bcef',endColorstr='#019ad2',GradientType=0);
            border-color: #057ED0;
            -webkit-box-shadow: inset 0 1px 0 rgba(255, 255, 255, .1);
            -moz-box-shadow: inset 0 1px 0 rgba(255,255,255,.1);
            box-shadow: inset 0 1px 0 rgba(255, 255, 255, .1);
        }
    </style>
</head>
<body>
    <div id="bg">
        <img src="?action=img" />
    </div>
    <div id="float">
        <div id="text">
            <h1>
                Welcome to our System</h1>
            <p>
                People always say technology change life.<br />
                But who changes technologies?<br />
                Absolutely, it is me ;)
            </p>
        </div>
        <form method="post">
        <div class="panel" id="login">
            <h2>
                Administrator Login</h2>
            <div class="textrow">
                <input type="text" name="txt_UserName" class="textbox" id="t1" />
                <label class="placeholder" for="t1">
                    Enter your username/email</label>
            </div>
            <div class="textrow">
                <input type="password" name="txt_Userpass" class="textbox" id="Text1" />
                <label class="placeholder" for="Text1">
                    Enter your password</label>
            </div>
            <div class="textrow">
                <table>
                    <tr>
                        <td style="width: 220px;">
                            <input type="text" name="txt_VCode" class="textbox" id="Text2" />
                            <label class="placeholder" for="Text2">
                                Enter Characters on the right</label>
                        </td>
                        <td>
                            <img title="点击刷新验证码" alt="点击刷新验证码" src="/e/admin/tool/safecode.ashx" onclick="this.src=this.src+'?'+Math.random()" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="textrow">
                <button type="submit" class="btn" id="sub" onclick="loading('正在验证，请稍候...')">
                    Login</button>
            </div>
        </div>
        </form>
    </div>
    <div id="footer">
        <ul>
            <li><a href="/">Index</a></li>
            <li><a href="/">Website</a></li>
            <li><a href="/">Blogs</a></li>
            <li><a href="/">Twitter</a></li>
            <li><a href="/">FaceBook</a></li>
            <li>Copyright &copy; kuibono 2012</li>
        </ul>
    </div>
    
</body>
</html>
