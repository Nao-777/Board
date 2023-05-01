<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="DeleteUserInformationPage.aspx.cs" Inherits="Board.WebSite.MyPage.DeleteUserInformation.DeleteUserInformationPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3>本当に退会しますか</h3>
        <div>
            <asp:LinkButton ID="lbDeleteButton" runat="server" OnClick="lbDeleteButton_Click" Text="退会する" />
        </div>
        <div>
            <a href="../MyPage.aspx">キャンセル</a>
        </div>
    </div>
</asp:Content>
