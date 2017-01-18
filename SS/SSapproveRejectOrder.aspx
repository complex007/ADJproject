<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SSapproveRejectOrder.aspx.cs" Inherits="SS.SSapproveRejectOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <h3>ApproveRejectOrdersForm</h3>
    <p>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"  Height="120px" Width="472px">
            <Columns>
             <asp:templatefield HeaderText="Select" ShowHeader="False">
                    <itemtemplate>
                        <asp:checkbox ID="Select" CssClass="gridCB" runat="server"></asp:checkbox>
                    </itemtemplate>
                </asp:templatefield>
            <asp:BoundField HeaderText="Purchase Order Number" />
                <asp:BoundField HeaderText="Ordered By" /> 
                <asp:BoundField HeaderText="Order Date" />
                <asp:BoundField HeaderText="Total Cost" />
                 <asp:BoundField HeaderText="Supplier" />
                 
        </Columns>
        </asp:GridView>
    </p>
   
    <asp:Button ID="approve" runat="server" BackColor="Green" Text="Approve"/>
    <asp:Button ID="reject" runat="server" BackColor="Red" Text="Reject"  />
    <br />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    <br />
    </asp:Content>
