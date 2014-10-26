<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Meetings.aspx.cs" Inherits="MMP.HackMCR.Website.Meetings" %>
<%@ MasterType VirtualPath="~/Layout.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
    <script type="text/javascript" src="./Assets/Scripts/Meetings.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <div id="UserGroupsPanel" class="mAll20">
        <div id="UsersContainer" class="box-container pAll10">
            <h4>Users</h4>
            <div id="UserChecklist"></div>
        </div>
        <div id="GroupsContainer" class="box-container pAll10 mTop20">
            <h4>Groups</h4>
            Dummy
        </div>
    </div>

    <div id="DetailsPanel" class="mAll20">
        <div id="DetailsContainer" class="box-container pAll10">
            Dummy
        </div>
        <div id="TimesContainer" class="box-container pAll10 mTop20">
            Dummy
        </div>
    </div>
</asp:Content>
