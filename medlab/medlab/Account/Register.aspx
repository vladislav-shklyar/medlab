<%@ Page Title="Регистрация" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="medlab.Account.Register" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    

    <h2><%:Title%>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    
    <div class="form-horizontal">
        
        <h4>Создание новой учетной записи</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Адрес электронной почты</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="Поле адреса электронной почты заполнять обязательно." />
            </div>
        </div>
        
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="SecondName" CssClass="col-md-2 control-label">Фамилия</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="SecondName" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="SecondName"
                    CssClass="text-danger" ErrorMessage="Поле фамилии заполнять обязательно." />
            </div>
        </div>
        

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="FirstName" CssClass="col-md-2 control-label">Имя</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="FirstName" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName"
                    CssClass="text-danger" ErrorMessage="Поле имени заполнять обязательно." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ThirdName" CssClass="col-md-2 control-label">Отчество</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ThirdName" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ThirdName"
                    CssClass="text-danger" ErrorMessage="Поле отчества заполнять обязательно." />
            </div>
        </div>
        
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="PhoneNumber" CssClass="col-md-2 control-label phonemask">Мобильный телефон</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="PhoneNumber" CssClass="form-control" TextMode="Phone" />                  
        <ajaxToolkit:MaskedEditExtender runat="server" ID="phoneedit" Mask="+7(999) 999-9999" TargetControlID="PhoneNumber"></ajaxToolkit:MaskedEditExtender>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="PhoneNumber"
                    CssClass="text-danger" ErrorMessage="Поле мобильного телефона заполнять обязательно." TargetControlID="PhoneNumber" />
            </div>
        </div>


        <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="Department" CssClass="col-md-2 control-label">Отдел</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="Department" runat="server" CssClass="form-control" OnLoad="Department_Load" OnInit="Department_Init">
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Department"
                    CssClass="text-danger" ErrorMessage="Поле отдела заполнять обязательно." />
            </div>
        </div>


        <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="Role" CssClass="col-md-2 control-label">Должность</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="Role" runat="server" CssClass="form-control">
                    <asp:ListItem Value="Chief" Text="Глава отдела">
                    </asp:ListItem>
                    <asp:ListItem Value="Worker" Text="Работник">
                    </asp:ListItem>
                </asp:DropDownList>
                
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Role"
                    CssClass="text-danger" ErrorMessage="Поле должность заполнять обязательно." />
            </div>
        </div>


        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Пароль</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="Поле пароля заполнять обязательно." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Подтверждение пароля</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Поле подтверждения пароля заполнять обязательно." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Пароль и его подтверждение не совпадают." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Регистрация" CssClass="btn btn-default" />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            </div>
        </div>




    </div>
</asp:Content>
