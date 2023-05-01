<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="MyPage.aspx.cs" Inherits="Board.WebSite.MyPage.MyPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        ログインID
        <p id="pLoginID" runat="server"></p>
        <br />
        名前
        <p id="pUserName" runat="server"></p>
    </div>
    <br />
    <div>      
        <a href="RevisedUserInfomationPage/RevisedUserInfomation.aspx">ユーザ情報編集</a>
        <br />
        <a href="DeleteUserInformation/DeleteUserInformationPage.aspx">退会する</a>
        <br />
        <a href="../MainPage/BulletinBoardPage.aspx">戻る</a>
    </div>
</asp:Content>
