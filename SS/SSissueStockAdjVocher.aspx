﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SSissueStockAdjVocher.aspx.cs" Inherits="SS.SSissueStockAdjVocher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h3>StockAdjustVoucherForm</h3>
    <p>&nbsp;</p>
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" >
        <Columns>
             <asp:templatefield HeaderText="Select">
                    <itemtemplate>
                        <asp:checkbox ID="Select" CssClass="gridCB" runat="server"></asp:checkbox>
                    </itemtemplate>
                </asp:templatefield>
            <asp:BoundField HeaderText="Purchase Order Number" />
            <asp:BoundField HeaderText="Issued By" />
            <asp:BoundField HeaderText="Issue Date" />
            <asp:BoundField HeaderText="Cost" />
        </Columns>
    </asp:GridView>
     <asp:Button ID="approve" runat="server"  Text="Approve" BackColor="Green" />
     <asp:Button ID="reject" runat="server" Text="Reject" BackColor="Red"  />
     <br />
     <asp:PlaceHolder ID="PlaceHolder1" runat="server">

     </asp:PlaceHolder>
     <br />
     </asp:Content>