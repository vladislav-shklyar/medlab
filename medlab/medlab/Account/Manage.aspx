<%@ Page Title="Управление учетной записью" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="medlab.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
            <p class="text-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="form-horizontal">
                <h4>Изменение параметров учетной записи</h4>
                <hr />
                <dl class="dl-horizontal">
                    <dt>Пароль:</dt>
                    <dd>
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Изменить]" Visible="false" ID="ChangePassword" runat="server" />
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Создать]" Visible="false" ID="CreatePassword" runat="server" />
                    </dd>
                    <dt>Внешние имена входа:</dt>
                    <dd><%: LoginsCount %>
                        <asp:HyperLink NavigateUrl="/Account/ManageLogins" Text="[Управление]" runat="server" />

                    </dd>
                    <%--
                        Номера телефонов можно использовать в качестве второго проверочного фактора для системы двухфакторной аутентификации.
                        В <a href="https://go.microsoft.com/fwlink/?LinkId=403804">этой статье</a>
                        можно узнать, как для этого приложения ASP.NET настроить двухфакторную аутентификацию с использованием SMS.
                        Настроив двухфакторную аутентификацию, раскомментируйте следующие блоки.
                    --%>
                    <%--
                    <dt>Номер телефона:</dt>
                    <% if (HasPhoneNumber)
                       { %>
                    <dd>
                        <asp:HyperLink NavigateUrl="/Account/AddPhoneNumber" runat="server" Text="[Добавить]" />
                    </dd>
                    <% }
                       else
                       { %>
                    <dd>
                        <asp:Label Text="" ID="PhoneNumber" runat="server" />
                        <asp:HyperLink NavigateUrl="/Account/AddPhoneNumber" runat="server" Text="[Изменить]" /> &nbsp;|&nbsp;
                        <asp:LinkButton Text="[Удалить]" OnClick="RemovePhone_Click" runat="server" />
                    </dd>
                    <% } %>
                    --%>

                    <dt>Двухфакторная проверка подлинности:</dt>
                    <dd>
                        <p>
                            Поставщики двухфакторной аутентификации не настроены. В <a href="https://go.microsoft.com/fwlink/?LinkId=403804">этой статье</a>
                можно узнать, как настроить двухфакторную аутентификацию для этого приложения ASP.NET.
                        </p>
                        <% if (TwoFactorEnabled)
                          { %> 
                        <%--
                        Enabled
                        <asp:LinkButton Text="[Отключить]" runat="server" CommandArgument="false" OnClick="TwoFactorDisable_Click" />
                        --%>
                        <% }
                          else
                          { %> 
                        <%--
                        Disabled
                        <asp:LinkButton Text="[Включить]" CommandArgument="true" OnClick="TwoFactorEnable_Click" runat="server" />
                        --%>
                        <% } %>
                    </dd>
                </dl>
            </div>
        </div>
    </div>

</asp:Content>
