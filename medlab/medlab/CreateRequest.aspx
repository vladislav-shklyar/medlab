<%@ Page Title="Создание заявки" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateRequest.aspx.cs" Inherits="medlab.CreateRequest" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
 <h2><%:Title%></h2>   
     <asp:ValidationSummary runat="server" CssClass="text-danger" />
           <asp:UpdatePanel ID="OuterUpdatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">    <%--Создаём панель для обновления--%>
            <ContentTemplate>
                <asp:DropDownList ID="Category" runat="server" CssClass="form-control" OnSelectedIndexChanged="Category_SelectedIndexChanged" AutoPostBack="True"> 
                    <%--Добавляем постбэк на изменение дроплиста--%>
                </asp:DropDownList>        
             <h4>Введите требуемое количество товаров</h4>
              <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="item_id"> <%--Добавляем гридвью--%>
                  <Columns>
                      <asp:TemplateField HeaderText="Количество">
                            <ItemTemplate>
                                <asp:TextBox ID="Amount" runat="server" Style="position: static" CssClass ="gv" text ='0' AutoPostBack ="False" TabIndex ="0"  Width="50 px"  Height ="15px" Visible ="true" TextMode="Number"></asp:TextBox>
                                     <asp:CompareValidator runat="server"
                                        ControlToValidate="Amount"
                                        Operator="DataTypeCheck"
                                        Type="Integer"
                                        ErrorMessage="Введите целое число"
                                        Display="Dynamic"
                                        Text="!"/>
                                     <asp:CompareValidator runat="server"
                                        ControlToValidate="Amount"
                                        Operator="GreaterThanEqual"
                                        ValueToCompare="1"
                                        Type="Integer"
                                        ErrorMessage="Число оказалось менее 1"
                                        Display="Dynamic"
                                        Text="!"/>
                            </ItemTemplate>
                        </asp:TemplateField>
              <asp:BoundField ItemStyle-Width="150px" DataField="item_id" HeaderText="item_id" Visible="False" />
              <asp:BoundField ItemStyle-Width="150px" DataField="item_name" HeaderText="item_name" />
                  </Columns>
              </asp:GridView> 
                </ContentTemplate>
                <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Category" EventName="SelectedIndexChanged" /> <%--Добавляем триггер на изменение индекса дроплиста--%>
                    </Triggers>
                </asp:UpdatePanel>
    <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Создать заявку" CssClass="btn btn-default" />
            </div>
        </div>
    </asp:Content>


