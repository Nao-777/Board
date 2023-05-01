<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="NewRegistrationConfirmation.aspx.cs" Inherits="Board.WebSite.Form.NewRegistrationConfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>確認画面</h1>
    </div>
    <div>
        <p>氏名</p>
            <br />
        <p id="pUserName" runat="server"></p>
        <br />
        <p>ログインID</p>
            <br />
        <p id="pLoginID" runat="server"></p>
        <br />
        <p>パスワード設定</p>
            <br />
        <p id="pUserPassword" runat="server"></p>
        <br />
        <div>
            <p id="alertMsg" runat="server"></p>
        </div>
        <br />
        <a href="NewRegistration.aspx">キャンセル</a>
        <br />
        <asp:LinkButton ID="lbNewRegistrationButton" runat="server" onClick="lbNewRegistrationButton_Click" Text="登録" />
    </div>
</asp:Content>
