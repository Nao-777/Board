<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="ArticlEdition.aspx.cs" Inherits="Board.WebSite.MainPage.ArticlEdition" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--<link rel="stylesheet" href="../../Css/MainPage/ArticlEdition.css" />-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="dMain">
        <h1>記事の編集</h1>
    </div>
    <div class="allForm">
        <table class="allForm-table">
            <tr>
                <th class="InputForm-Name"><p id="pOldTitle" runat="server"></p></th>
                <td class="InputForm-Contents">
                    <asp:TextBox ID="tbNewTitle" CssClass="form-text" runat="server" />
                </td>
            </tr>
            <tr>
                <th class="InputForm-Name"><p id="pOldContents" runat="server"></p></th>
                <td class="InputForm-Contents">
                    <asp:TextBox ID="tbNewContents" CssClass="form-text" runat="server" />
                </td>
            </tr>
        </table>
        <div>
            <p id="pAlertMessage" runat="server"></p>
        </div>
        <div class="btn_div">
	        <a href="BulletinBoardPage.aspx" class="btn">戻る</a>
        </div>
        <div class="btn_div">
            <asp:LinkButton ID="lbEditArticlButton" CssClass="btn" runat="server" OnClick="lbEditArticlButton_Click" Text="確定" />
        </div>
    </div>
</asp:Content>
