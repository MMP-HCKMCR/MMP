<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MMP.HackMCR.Website.Default" %>
<%@ MasterType VirtualPath="~/Layout.Master" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentBody" runat="server">

    <div id="LoginContainer" class="box-container">
        <h1>Login</h1>
        <span id="GeneralError" class="error"></span>
        <table class="center-data mAll20">
            <tr>
                <td>
                    <label for="Email">Email:</label>
                </td>
                <td>
                    <input type="text" id="Email" placeholder="Email" />
                    <span id="EmailError" class="error"></span>
                </td>
            </tr>
            <tr>
                <td>
                    <label for="Password">Password:</label>
                </td>
                <td>
                    <input type="password" id="Password" placeholder="Password" />
                    <span id="PasswordError" class="error"></span>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <input type="submit" id="LoginButton" value="Login" />
                    <a id="RegisterLink" href="./Register.aspx">Click to Register</a>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
