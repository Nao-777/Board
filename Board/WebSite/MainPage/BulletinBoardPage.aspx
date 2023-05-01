<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="BulletinBoardPage.aspx.cs" Inherits="Board.WebSite.MainPage.BulletinBoardPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../../CSS/MainPage/BulletinBoardPage.css" />
</asp:Content>
<asp:Content ID="headerUser" ContentPlaceHolderID="headerUser" runat="server">
    <div class="MyPageButton">
        <a href="../User/MyPage.aspx">マイページ</a>
    </div>
</asp:Content>
<asp:Content ID="cInputForm" ContentPlaceHolderID="cInputForm" runat="server">
    <!--スレを作成する個所-->
    <div class="CreateArticl">
        <h2>スレを立てる</h2>
        <br />
        タイトルを入力してください<br />
        <asp:TextBox ID="tbTitel" runat="server" />
        <br />
        <br />
        内容を入力してください<br />
        <asp:TextBox ID="tbContents" runat="server" />
        <br />
        <br />
        <div>
            <p id="pAlertMessage" runat="server"></p>
        </div>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="lbArticlInsertButton_Click" Text="投稿" />
    </div>
    <div>
        <div>
            <asp:LinkButton ID="LinkButton5" runat="server" OnClick="lbLogoutButton_Click" Text="ログアウト" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="BulletinBoardPage" ContentPlaceHolderID="cMainDisplay" runat="server">
    <!--スレの一覧-->
    <div class="Articls">
        <asp:LinkButton runat="server" ID="lbBeforeButton" OnClick="lbBeforeButton_Click" Text="前へ" Visible="false" />
        <asp:LinkButton runat="server" ID="lbNextbutton" OnClick="lbNextButton_Click" Text="次へ" Visible="true" />
        <asp:Repeater ID="rArticle" runat="server">
            <ItemTemplate>
                <div class="Articl">
                    <div class="TitleAndContents">
                        <h1>
                            <asp:LinkButton ID="lbInArticlButton" runat="server" OnClick="lbInArticlButton_Click" CommandName='<%#: Eval("articlID") %>'><%#: Eval("articlTitle") %></asp:LinkButton></h1>
                        <p><%# Eval("articlContents") %></p>
                        <div>
                            <asp:Button ID="bDeleteArticlButton" runat="server" OnClick="bDeleteArticlButton_Click" CommandName='<%#: Eval("articlID").ToString() %>' Visible="false" Text="削除" />
                            <asp:Button ID="bToEditArticlPageButton" runat="server" OnClick="bToEditArticlPageButton_Click" CommandName='<%#: Eval("articlID").ToString() %>' Visible="false" Text="編集する" />
                        </div>
                    </div>
                    <div class="UserNameAndDays">
                        <p><%#: Eval("days") %></p>
                        <p>投稿者：<%#: Eval("userName") %></p>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
