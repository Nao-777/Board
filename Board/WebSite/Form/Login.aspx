<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Board.WebSite.Form.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../../CSS/Form/Login.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="allForm">
        <table class="allForm-table">
            <tr>
                <th class="InputForm-Name">ログインIDを入力してください</th>
                <td class="InputForm-Contents">
                    <asp:TextBox ID="tbLoginID" CssClass="form-text"  runat="server"/>
                </td>
            </tr>
            <tr>
                <th class="InputForm-Name">パスワードを入力してください</th>
                <td class="InputForm-Contents">
                    <asp:TextBox ID="tbPasswordID" CssClass="form-text" runat="server" />
                </td>
            </tr>
        </table>
        <div>
            <p id="pAlertMessage" runat="server"></p>
        </div>
        <div class="btn_div">
            <asp:LinkButton ID="testLink1" CssClass="btn" runat="server" OnClick="lbLogin_Click" Text="ログイン" />
        </div>
        <div class="btn_div">
            <a href="NewRegistration.aspx" class="btn">新規登録の方はこちら</a>
        </div>
    </div>
</asp:Content>
