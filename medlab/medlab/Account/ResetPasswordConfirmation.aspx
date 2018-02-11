<%@ Page Title="Пароль изменен" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResetPasswordConfirmation.aspx.cs" Inherits="medlab.Account.ResetPasswordConfirmation" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <div>
        <p>Ваш пароль изменен. Щелкните <asp:HyperLink ID="login" runat="server" NavigateUrl="~/Account/Login">здесь</asp:HyperLink> для входа </p>
    </div>
</asp:Content>
