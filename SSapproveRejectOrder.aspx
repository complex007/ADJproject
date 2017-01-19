<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SSapproveRejectOrder.aspx.cs" Inherits="SS.SSapproveRejectOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <h3>ApproveRejectOrdersForm</h3>
    <p>
       

        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="purchaseordernumber" Height="185px" Width="1072px" >
            <Columns>
                <asp:BoundField DataField="purchaseordernumber" HeaderText="Purchase Order Number" ReadOnly="True" SortExpression="purchaseordernumber" />
                <asp:BoundField DataField="employee.employeename" HeaderText="Ordered By" SortExpression="storeclerkcode" NullDisplayText="System" />
                <asp:BoundField DataField="orderdate" HeaderText="Order Date" SortExpression="orderdate" DataFormatString="{0:dd-MM-yyyy}"  />
                <asp:BoundField DataField="totalcost" HeaderText="Total Cost" SortExpression="totalcost" />
                <asp:BoundField DataField="suppliercode" HeaderText="Supplier" SortExpression="suppliercode" />
                   <asp:TemplateField>
                    <ItemTemplate>
                         <a href='SSapproveRejectOrder.aspx?id=<%# Eval("purchaseordernumber") %>&action=Details'>Details</a>
                    </ItemTemplate>
                       </asp:TemplateField>
                   <asp:TemplateField>
                    <ItemTemplate>
                         <a href='SSapproveRejectOrder.aspx?id=<%# Eval("purchaseordernumber") %>&action=Approve'>Approve</a>
                    </ItemTemplate>
                            </asp:TemplateField>
                        <asp:TemplateField>
                       <ItemTemplate>
                         <a href='SSapproveRejectOrder.aspx?id=<%# Eval("purchaseordernumber") %>&action=Reject'>Reject</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>     
    </p>
    <table style="width: 1069px; height: 188px">
        <tr>
            <td class="modal-lg" style="width: 1707px">
                 <asp:Label ID="Label1" runat="server" Text="Label" ></asp:Label>
            </td>
           <td style="width: 684px"><asp:LinkButton runat="server" ID="approveall"><a href='SSapproveRejectOrder.aspx?action=ApproveAll'>Approve All</a> </asp:LinkButton></td>
             <td>
                                  <asp:LinkButton runat="server" ID="rejectall"> <a href='SSapproveRejectOrder.aspx?action=RejectAll'>Reject All</a> </asp:LinkButton>
             </td>
        </tr>
        <tr>
            <td class="modal-lg" style="width: 1707px"></td>
             <td style="width: 684px"></td>
             <td> <asp:Label ID="Label2" runat="server" Text="Reject Reason : "></asp:Label></td>
        </tr>
        <tr>
            <td class="modal-lg" style="width: 1707px"></td>
             <td style="width: 684px">
                
            </td>
            <td>
                
                 <asp:TextBox ID="TextBox1" runat="server" Height="70px" Width="271px" style="margin-top: 29" AutoPostBack="true"></asp:TextBox>

            </td>
            <td>
                  
       
        

            </td>
        </tr>
    </table>
   
    

     

    <br />
   
    
    <asp:GridView ID="GridView1" runat="server">

    </asp:GridView>
    <br />
    </asp:Content>
