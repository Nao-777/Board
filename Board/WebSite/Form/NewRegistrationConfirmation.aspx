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
    </div>
    <div>
        <div>
            <p id="alertMsg" runat="server"></p>
        </div>
        <div class="btn_div">
            <a href="NewRegistration.aspx" class="btn">キャンセル</a>
        </div>
        <div class="btn_div">
            <asp:LinkButton ID="lbNewRegistrationButton" CssClass="btn" runat="server" onClick="lbNewRegistrationButton_Click" Text="登録" />
        </div>
    </div>
</asp:Content>
