<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MMP.HackMCR.Website.Default" %>
<%@ MasterType VirtualPath="~/Layout.Master" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentBody" runat="server">

    <div id="LoginContainer" class="box-container">
        <table class="center-data mAll20">
            <tr>
                <td>
                    <label for="Username">Username:</label>
                </td>
                <td>
                    <input type="text" id="Username" placeholder="Username" />
                </td>
            </tr>
            <tr>
                <td>
                    <label for="Password">Password:</label>
                </td>
                <td>
                    <input type="password" id="Password" placeholder="Password" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <input type="submit" id="Login" value="Login" />
                    <a id="RegisterLink" href="./Register.aspx">Click to Register</a>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
