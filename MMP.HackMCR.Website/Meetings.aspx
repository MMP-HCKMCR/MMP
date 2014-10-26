<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Meetings.aspx.cs" Inherits="MMP.HackMCR.Website.Meetings" %>
<%@ MasterType VirtualPath="~/Layout.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
    <script type="text/javascript" src="./Assets/Scripts/Meetings.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <div id="UserGroupsPanel" class="mAll20">
        <div id="UsersContainer" class="box-container pAll10">
            <h4 class="mAll0">Users</h4>
            <div id="UserChecklist"></div>
        </div>

        <div id="GroupsContainer" class="box-container pAll10 mTop20">
            <h4 class="mAll0">Groups</h4>
            <div id="GroupChecklist"></div>
        </div>
    </div>

    <div id="DetailsPanel" class="mAll20">
        <div id="DetailsContainer" class="box-container pAll10">
            <table>
                <tr>
                    <td>
                        <label for="MeetingName">Name:</label>
                    </td>
                    <td>
                        <input type="text" id="MeetingName" placeholder="Name" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="MeetingDescription">Description:</label>
                    </td>
                    <td>
                        <input type="text" id="MeetingDescription" class="w900p" placeholder="Description" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="MeetingStartDate">Start Date:</label>
                    </td>
                    <td>
                        <input type="date" id="MeetingStartDate" class="w131p" />
                        <input type="time" id="MeetingStartTime" class="w131p" value="10:00" />
                        
                        <label for="MeetingEndDate" class="mLeft30">End Date:</label>
                        <input type="date" id="MeetingEndDate" class="w131p" />
                        <input type="time" id="MeetingEndTime" class="w131p" value="10:00" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="MeetingDuration">Duration:</label>
                    </td>
                    <td>
                        <select id="MeetingDuration" class="w60p">
                            <option value="0">15</option>
                            <option value="1">30</option>
                            <option value="2" selected="selected">60</option>
                            <option value="3">90</option>
                            <option value="4">120</option>
                        </select>
                        <label> minutes</label>
                        <input type="submit" id="FilterMeetingTimes" class="fright" value="Filter" />
                    </td>
                </tr>
            </table>
        </div>

        <div id="TimesContainer" class="box-container pAll10 mTop20">
            <table id="MeetingTimes">
                <thead>
                    <tr>
                        <td></td>
                        <td>Start Time</td>
                        <td>End Time</td>
                    </tr>
                </thead>
                <tbody>

                </tbody>
            </table>
            <input type="submit" id="CreateMeeting" class="center-data" value="Create Meeting" />
        </div>
    </div>
</asp:Content>
