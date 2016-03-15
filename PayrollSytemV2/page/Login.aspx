<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="PayrollSytemV2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payroll System</title>
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css"/>
    <link href="Content/AdminLTE.min.css" rel="stylesheet" />
    <script type="text/javascript" src="../Scripts/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap.min.js"></script>
</head>
<body class="hold-transition login-page">
    <form id="form1" runat="server">
    <div class="login-box">
      <div class="login-logo">
        <a href="../../index2.html"><b>Admin</b>LTE</a>
      </div><!-- /.login-logo -->
      <div class="login-box-body">
          <p class="login-box-msg">Sign in to start your session</p>
          <div class="form-group has-feedback">
            <asp:TextBox ID="email" runat="server" class="form-control" placeholder="Username"></asp:TextBox>
            <span class="glyphicon glyphicon-user form-control-feedback"></span>
          </div>
          <div class="form-group has-feedback">
            <asp:TextBox ID="password" runat="server" class="form-control" placeholder="Password"></asp:TextBox>
            <span class="glyphicon glyphicon-lock form-control-feedback"></span>
          </div>
          <div class="row">
              <div class="col-xs-4">
                <button type="submit" class="btn btn-primary btn-block btn-flat">Sign In</button>
              </div><!-- /.col -->
          </div>
      </div>
    </div>
    </form>
</body>
</html>
