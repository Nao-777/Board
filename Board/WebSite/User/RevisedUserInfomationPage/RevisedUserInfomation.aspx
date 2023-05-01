<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="RevisedUserInfomation.aspx.cs" Inherits="Board.WebSite.User.RevisedUserInfomationPage.RevisedUserInfomation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div>
            <h1>MyInformation</h1>
        </div>
        <div id="UserInformationList" runat="server">
            <br />
            <div>
                ログインID
                <p id="pOldLoginID" runat="server"></p>
                <asp:TextBox ID="tbNewLoginID" runat="server" />
            </div>
            <br />
            <div>
                名前
                <p id="pOldUserName" runat="server"></p>
                <asp:TextBox ID="tbNewUserName" runat="server" />
            </div>
            <br />
            <div>
                パスワード
                <p id="pOldPassword" runat="server"></p>
                <asp:TextBox ID="tbNewPasswordText" runat="server" />
            </div>
            <br />
            <div>
                <p id="pAlertMessage" runat="server"></p>
            </div>
            <br />
            <div>
                <asp:LinkButton ID="lbRevisedConfirmationButton" runat="server" OnClick="lbRevisedConfirmationButton_Click" Text="確認する" />
            </div>
            <br />
            <a href="../MyPage.aspx">戻る</a>
        </div>
    </div>
</asp:Content>
