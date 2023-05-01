<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Board.WebSite.Form.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        ログインIDを入力してください
            <br />
        <asp:TextBox ID="tbLoginID" runat="server" />
        <br />
        <br />
        パスワードを入力してください
            <br />
        <asp:TextBox ID="tbPasswordID" runat="server" />
        <br />
        <div>
            <p id="pAlertMessage" runat="server"></p>
        </div>
        <br />
        <asp:LinkButton ID="lbLogin" runat="server" OnClick="lbLogin_Click" Text="ログインボタン" />
        <br />
        <br />
        <a href="NewRegistration.aspx">新規登録の方はこちら</a>
        <br />
    </div>
</asp:Content>
