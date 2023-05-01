<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="Board.WebSite.Form.Logout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>ログアウトしました</h1>
        <br />
        <br />
        <p>ログイン画面に戻り、ログインしてください</p>
    </div>
    <div><a href="Login.aspx">ログイン画面</a></div>
</asp:Content>
