<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SSrequisitionTrendAnalysis.aspx.cs" Inherits="SS.SSrequisitionTrendAnalysis" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="row"> 
        <div class="col-sm-3">
            <table>
            <thead>
                <td>Category:</td>
            </thead>
                <tbody>
                    <tr>
                        <td>
                              <asp:ListBox ID="ListBox5" runat="server" Height="118px" Width="98px">
                                      <asp:ListItem>Clip</asp:ListItem>
                                     <asp:ListItem>Envelope</asp:ListItem>
                                     <asp:ListItem>Eraser</asp:ListItem>
                                     <asp:ListItem>Exercise</asp:ListItem>
                                     <asp:ListItem>Ruler</asp:ListItem>
                                     <asp:ListItem>Pad</asp:ListItem>
                                     <asp:ListItem>Paper</asp:ListItem>
                                     <asp:ListItem>pen</asp:ListItem>
                                     <asp:ListItem>Puncher</asp:ListItem>
                                     <asp:ListItem>Ruler</asp:ListItem>
                                     <asp:ListItem>Scissors</asp:ListItem>
                                     <asp:ListItem>Tape</asp:ListItem>
                                     <asp:ListItem>Sharpener</asp:ListItem>
                                     <asp:ListItem>Shorthand</asp:ListItem>
                                     <asp:ListItem>Stapler</asp:ListItem>
                                     <asp:ListItem>Tacks</asp:ListItem>
                                     <asp:ListItem>Tparency</asp:ListItem>
                                     <asp:ListItem>Tray</asp:ListItem>
                             </asp:ListBox>
                        </td>
                    </tr>
                </tbody>
        </table>
       

    </div>

    <div class="col-sm-3">
        
        <asp:Label ID="Lbsupplier" runat="server" Text="Department:"></asp:Label> 
    <asp:CheckBoxList ID="CheckBoxList1" runat="server" >
        <asp:ListItem>ENGL</asp:ListItem>
        <asp:ListItem>CPSC</asp:ListItem>
        <asp:ListItem>COMM</asp:ListItem>
        <asp:ListItem>REGR</asp:ListItem>
        <asp:ListItem>ZOOL</asp:ListItem>
        <asp:ListItem>STORE</asp:ListItem>        
    </asp:CheckBoxList>

  </div>
  
    <div class="col-sm-3">
        <table>
            <thead>
                 <td>Month:</td>
            </thead>
            <tbody>
                <tr>
                    <td> <asp:ScriptManager ID="ScriptManager1" runat="server"> </asp:ScriptManager>   
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>        
        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" DefaultView="Months" ClientIDMode="Static" Format="MM-yyyy" OnClientHidden="onCalendarHidden"  OnClientShown="onCalendarShown" BehaviorID="calendar1"
    Enabled="True" TargetControlID="TextBox1" />
                        </td> 
                </tr>
                <tr>
                    <td>
                     <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>        
        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" DefaultView="Months" ClientIDMode="Static" Format="MM-yyyy" OnClientHidden="onCalendarHidden2"  OnClientShown="onCalendarShown2" BehaviorID="calendar2"
    Enabled="True" TargetControlID="TextBox2" />
                        </td>
                </tr>
                <tr>
                    <td>
                     <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>        
        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" DefaultView="Months" ClientIDMode="Static" Format="MM-yyyy" OnClientHidden="onCalendarHidden3"  OnClientShown="onCalendarShown3" BehaviorID="calendar3"
    Enabled="True" TargetControlID="TextBox3" />
                        </td>
                </tr>
            </tbody>
        </table>
    
   <script src="calenderExtender.js"></script>
    </div>
   <div class="col-sm-3">
  <asp:Button ID="Btngenerate" runat="server" Text="Generate" />
      
   </div>
   </div>
   <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
</asp:Content>
