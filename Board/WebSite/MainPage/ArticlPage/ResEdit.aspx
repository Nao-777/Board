<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="ResEdit.aspx.cs" Inherits="Board.WebSite.MainPage.ArticlPage.ResEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="parent">
        <div id="InputForm">
            <div>
                <h1>メッセージ編集</h1>
            </div>
            <p id="pMessage" runat="server"></p>
            <p id="pAlertMessage" runat="server"></p>
            <asp:TextBox ID="tbReMessage" runat="server" />
            <asp:LinkButton ID="lbChangeMessage" runat="server" OnClick="lbChangeMessage_Click" Text="確定"></asp:LinkButton>
        </div>
    </div>
    <asp:LinkButton ID="backToResEdit" runat="server" OnClick="backToResEdit_Click" Text="戻る"></asp:LinkButton>
</asp:Content>
