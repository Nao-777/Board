<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="ResEdit.aspx.cs" Inherits="Board.WebSite.MainPage.ArticlPage.ResEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="InputForm">
    <h1>メッセージ編集</h1>             
</div>
    <div class="allForm">
        <table class="allForm-table">
            <tr>
                <th class="InputForm-Name"><p id="pMessage" runat="server"></p></th>
                <td class="InputForm-Contents"><asp:TextBox ID="tbReMessage" CssClass="form-text" runat="server" /></td>
            </tr>
        </table>
        <div>
            <p id="pAlertMessage" runat="server"></p>
        </div>
        <div class="btn_div">
            <asp:LinkButton ID="lbChangeMessage" runat="server" CssClass="btn" OnClick="lbChangeMessage_Click" Text="確定"></asp:LinkButton>
        </div>
        <div class="btn_div">
            <asp:LinkButton ID="backToResEdit" CssClass="btn" runat="server" OnClick="backToResEdit_Click" Text="戻る"></asp:LinkButton>
        </div>
    </div>
</asp:Content>
