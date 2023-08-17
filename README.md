# ログイン式掲示板
ログイン式掲示板を作成してみました。  
今後も、勉強や経験を重ねて、この掲示板をアップデートさせる予定です。  
## 注意
現在(2023/08)golangとMySQL,reactを使用して、メンテナンス性の高いコードに書き換える勉強をしております。  
この掲示板を作成してから学んできたこと、webアプリケーションの勉強で学んだことなどは別のリポジトリに反映し、    
形になり次第、そのリポジトリを公開する予定です。  

## 開発環境 
- Microsoft .NET Framework 4.7.2  
- WebForm  
- C#  
- SQLserver  

## ディレクトリ構造  
```
Board
├─App_Code
│  ├─SQL
│  │  ├─BoardTable.cs
│  │  ├─ResTable.cs
│  │  ├─SqlMethod.cs
│  │  └─UserTable.cs
│  ├─BasePage.cs
│  ├─CommonMethod.cs
│  ├─Constants.cs
│  ├─ErrorMessage.cs
│  ├─SessionManager.cs
│  └─UrlCreator.cs
└─WebSite
   ├─Form
   │  ├─Login.aspx
   │  ├─Logout.aspx
   │  ├─NewRegistration.aspx
   │  └─NewRegistrationConfirmation.aspx
   ├─MainPage
   │  ├─ArticlPage
   │  │  ├─InArticlPage.aspx
   │  │  └─ResEdit.aspx
   │  ├─ArticlEdition.aspx
   │  └─BulletinBoardPage.aspx    
   └─User
      ├─DeleteUserInformation
      │  └─DeleteUserInformationPage.aspx
      ├─RevisedUserInfomationPage
      │  ├─RevisedConfirmationPage.aspx
      │  └─RevisedUserInfomation.aspx
      └─MyPage.aspx
```  
### App_Code  
 - データの共通の処理（SQL）や定数を管理するクラスが格納されているディレクトリ  
 - BasePage.cs        :すべての.aspxファイルの基クラス。主に、ユーザのログイン状況を管理など  
 - CommonMethod.cs    :主に入力文字列の判定（半角英数字、入力文字数など）を確認するメソッドのクラス  
 - Constants.cs:定数を管理するクラス  
 - ErrorMessage.cs:エラーで表示するメッセージを管理するクラス  
 - SessionManager.cs:ログインしているユーザのログインIDを格納・ログイン時間の有効期限の管理をするクラス  
 - UrlCreator.cs:URLを生成するクラス  
 - SQLディレクトリ  
    - SqlMethod.cs:SQLの共通の処理を管理するクラス  
    - BoardTable.cs:掲示板テーブルの操作をするクラス  
    - UserTable.cs:ユーザのテーブルを操作するクラス  
    - ResTable.cs:レスのテーブルを操作するクラス  
  
### WebSite  
  - 各ページが格納されているディレクトリ  
  - Form
    - Login.aspx:ログインページ  
    - Logout.aspx:ログアウトページ  
    - NewRegistration.aspx:新規登録ページ
    - NewRegistrationConfirmation.aspx:新規登録確認ページ  
  - MainPage  
    - ArticlPage  
      - InArticlPage.aspx:各スレにレスを返すページ  
      - ResEdit.aspx:送信したレスを編集するページ  
    - ArticlEdition.aspx:送信したスレを編集するページ
    - BulletinBoardPage.aspx:掲示板のメインページ。スレの一覧を表示する
  - User
    - DeleteUserInformation  
      - DeleteUserInformationPage.aspx:退会するページ   
    - RevisedUserInfomationPage
      -  RevisedConfirmationPage.aspx:登録したユーザ情報（ユーザ名、ユーザＩＤ、ユーザパスワード）の変更確認ページ
      -  RevisedUserInfomation.aspx:登録したユーザ情報（ユーザ名、ユーザＩＤ、ユーザパスワード）の変更ページ  
    -  MyPage.aspx:ユーザ情報ページ  


