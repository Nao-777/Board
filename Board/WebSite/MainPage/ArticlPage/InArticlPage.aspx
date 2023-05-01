<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="InArticlPage.aspx.cs" Inherits="Board.WebSite.MainPage.ArticlPage.InArticlPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../../../CSS/MainPage/InArticlPage.css" />
</asp:Content>
<asp:Content ID="cInputForm" ContentPlaceHolderID="cInputForm" runat="server">
    <!--どのスレの画面に入ったかわかるようにタイトルと内容、作成者を表示する場所-->
    <div class="dMainArticl">
        <div>
            <h1 id="hArticlTitle" runat="server">タイトル</h1>
            <p>内容</p>
            <p id="pArticlContents" runat="server">コンテンツ</p>
        </div>
        <div>
            <p id="pUserName" runat="server">名前</p>
        </div>
    </div>
    <!--メッセージ送信-->
    <div id="dMessageForm">
        <div>
            <p>メッセージ作成</p>
            <asp:TextBox ID="tbMessage" runat="server" />
            <asp:LinkButton ID="lbSendMessage" runat="server" OnClick="lbSendMessage_Click" Text="送信"></asp:LinkButton>
            <p id="pAlertMessage" runat="server"></p>
        </div>
    </div>
    <br />
    <a href="../BulletinBoardPage.aspx">戻る</a>
</asp:Content>
<asp:Content ID="cMainDisplay" ContentPlaceHolderID="cMainDisplay" runat="server">
    <!--メッセージの一覧-->
    <div class="messages">
        <asp:LinkButton runat="server" ID="lbBeforeButton" OnClick="lbBeforeButton_Click" Text="前へ" Visible="false" />
        <asp:LinkButton runat="server" ID="lbNextbutton" OnClick="lbNextButton_Click" Text="次へ" Visible="true" />
        <asp:Repeater ID="rMessage" runat="server">
            <itemtemplate>
                <div class="message">
                    <div class="pLabelMessage">
                        <asp:Literal ID="pMessageNumber" runat="server">--</asp:Literal>
                        <p class="UserName">名前：<%#: Eval("userName") %></p>
                        <p class="Days"><%#: Eval("days") %></p>
                    </div>
                    <p><%#: Eval("userMessage") %></p>
                    <div>
                        <asp:Button ID="bDeleteButton" runat="server" OnClick="bDeleteButton_Click" CommandName='<%#: Eval("MessageID").ToString() %>' Visible="false" Text="削除" />
                        <asp:Button ID="bToEditPageButton" runat="server" OnClick="bToEditPageButton_Click" CommandName='<%#: Eval("MessageID").ToString() %>' Visible="false" Text="編集する" />
                    </div>
                </div>
            </itemtemplate>
        </asp:Repeater>
    </div>
</asp:Content>
