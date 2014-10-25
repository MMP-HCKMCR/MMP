<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MMP.HackMCR.Website.Register" %>
<%@ MasterType VirtualPath="~/Layout.Master" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentBody" runat="server">
    
    <div id="RegisterContainer" class="box-container">
        <table class="center-data mAll20">
            <tr>
                <td>
                    <label for="Email">Email:</label>
                </td>
                <td>
                    <input type="email" id="Email" placeholder="Email" />
                </td>
            </tr>
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
                    <input type="text" id="Password" placeholder="Password" />
                </td>
            </tr>
            <tr>
                <td>
                    <label for="FullName">Full Name:</label>
                </td>
                <td>
                    <input type="text" id="FullName" placeholder="Full Name" />
                </td>
            </tr>
            <tr>
                <td>
                    <label for="MobileNumber">Mobile Number:</label>
                </td>
                <td>
                    <input type="text" id="MobileNumber" placeholder="Mobile Number" />
                </td>
            </tr>
            <tr>
                <td>
                    <label for="OneDiaryToken">One Diary Token:</label>
                </td>
                <td>
                    <input type="text" id="OneDiaryToken" placeholder="One Diary Token" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <input type="submit" id="Register" value="Register" />
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
