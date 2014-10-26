<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MMP.HackMCR.Website.Register" %>
<%@ MasterType VirtualPath="~/Layout.Master" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentHead" runat="server">
    <script type="text/javascript" src="./Assets/Scripts/Register.js"></script>
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentBody" runat="server">
    
    <div id="RegisterContainer" class="box-container">
        <h1>Register</h1>
        <span id="GeneralError" class="error"></span>
        <table class="center-data mAll20">
            <tr>
                <td>
                    <label for="Email">Email:</label>
                </td>
                <td>
                    <input type="email" id="Email" placeholder="Email" />
                    <span id="EmailError" class="error"></span>
                </td>
            </tr>
            <tr>
                <td>
                    <label for="UserDomain">Username:</label>
                </td>
                <td>
                    <input type="text" id="UserDomain" class="w131p" placeholder="User Domain" />
                    <label>/</label>
                    <input type="text" id="Username" class="w131p" placeholder="Username" />
                    <span id="UsernameError" class="error"></span>
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
                <td>
                    <label for="FullName">Full Name:</label>
                </td>
                <td>
                    <input type="text" id="FullName" placeholder="Full Name" />
                    <span id="NameError" class="error"></span>
                </td>
            </tr>
            <tr>
                <td>
                    <label for="MobileNumber">Mobile Number:</label>
                </td>
                <td>
                    <input type="text" id="MobileNumber" placeholder="Mobile Number" />
                    <span id="MobileError" class="error"></span>
                </td>
            </tr>
            <tr>
                <td>
                    <label for="OneDiaryToken">One Diary Token:</label>
                </td>
                <td>
                    <input type="text" id="OneDiaryToken" placeholder="One Diary Token" />
                    <span id="TokenError" class="error"></span>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <input type="submit" value="Register" id="RegisterButton" />
                </td>
            </tr>
        </table>
    </div>

    <div class="overlay hidden"></div>
    <div id="RegisterSuccess" class="overlay-dialog hidden">
        <h1>Account Created</h1>
        <input type="submit" value="Continue" id="ContinueButton" onclick="redirect('Default.aspx');" />
    </div>

</asp:Content>
