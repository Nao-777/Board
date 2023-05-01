<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="ArticlEdition.aspx.cs" Inherits="Board.WebSite.MainPage.ArticlEdition" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--<link rel="stylesheet" href="../../Css/MainPage/ArticlEdition.css" />-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="dMain">
        <h1>記事の編集</h1>
        <br />
        <br />
        <div>
            <div>
                タイトル<br />
                <p id="pOldTitle" runat="server"></p>
                <asp:TextBox ID="tbNewTitle" runat="server" />
            </div>
            <br />
            <div>
                内容<br />
                <p id="pOldContents" runat="server"></p>
                <asp:TextBox ID="tbNewContents" runat="server" />
            </div>
            <br />
            <p id="pAlertMessage" runat="server"></p>
            <br />
            <div>
                <a href="BulletinBoardPage.aspx">戻る</a>
            </div>
            <div>
                <asp:LinkButton ID="lbEditArticlButton" runat="server" OnClick="lbEditArticlButton_Click" Text="確定" />
            </div>
        </div>
    </div>
</asp:Content>
