<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="NewRegistration.aspx.cs" Inherits="Board.WebSite.Form.NewRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../../CSS/Form/NewRegistration.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="allForm">
        <h1 class="NewRegist-ttl">新規登録画面</h1>
        <table class="allForm-table">
            <tr>
                <th class="InputForm-Name">氏名</th>
                <td class="InputForm-Contents">
                    <asp:TextBox ID="tbNewNameID" CssClass="form-text" runat="server" />
                </td>
            </tr>
            <tr>
                <th class="InputForm-Name">ログインID
                    <br />*英数字4文字以上20文字以下
                </th>
                <td class="InputForm-Contents">
                    <asp:TextBox ID="tbNewLoginID" CssClass="form-text" runat="server" />
                </td>
            </tr>
            <tr>
                <th class="InputForm-Name">パスワード設定
                    <br />*英数字8文字以上20文字以下
                </th>
                <td class="InputForm-Contents">
                    <asp:TextBox ID="tbNewPasswordID" CssClass="form-text" runat="server" />
                </td>
            </tr>
        </table>
        <div>
            <p id="pAlertMsg" runat="server"></p>
        </div>
        <br />
        <div class="btn_div">
            <asp:LinkButton ID="lbNewRegistrationButton" CssClass="btn" runat="server" onClick="lbNewRegistrationButton_Click" Text="確認画面へ" />
        </div>
        <dr />
        <dr />
        <div class="btn_div">
           <a href="Login.aspx" class="btn">ログイン画面</a>
        </div>
    </div>
</asp:Content>
