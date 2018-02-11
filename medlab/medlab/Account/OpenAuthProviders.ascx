<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OpenAuthProviders.ascx.cs" Inherits="medlab.Account.OpenAuthProviders" %>

<div id="socialLoginList">
    <h4>Используйте для входа другую службу.</h4>
    <hr />
    <asp:ListView runat="server" ID="providerDetails" ItemType="System.String"
        SelectMethod="GetProviderNames" ViewStateMode="Disabled">
        <ItemTemplate>
            <p>
                <button type="submit" class="btn btn-default" name="provider" value="<%#: Item %>"
                    title="Войдите, используя <%#: Item %> свою учетную запись.">
                    <%#: Item %>
                </button>
            </p>
        </ItemTemplate>
        <EmptyDataTemplate>
            <div>
                <p>Внешние службы аутентификации не настроены. В <a href="https://go.microsoft.com/fwlink/?LinkId=252803">этой статье</a> можно узнать о настройке входа через внешние службы для этого приложения ASP.NET.</p>
            </div>
        </EmptyDataTemplate>
    </asp:ListView>
</div>
