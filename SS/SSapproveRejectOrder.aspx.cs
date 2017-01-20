using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SS
{
    public partial class SSapproveRejectOrder : System.Web.UI.Page
    {
        string id = "";
        string action = "";
        string reason = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
                id = Request.QueryString["id"];
            if (Request.QueryString["action"] != null)
            {
                action = Request.QueryString["action"];
                reason = TextBox1.Text.ToString();
            }



            if (!IsPostBack)
            {
                List<SOrder> orders = ClassList.findUnprovedOrder();
                if(orders.Count==0)
                {
                    Label1.Text = "No unpproved order.";
                }
                else
                {
                    GridView2.DataSource = orders;
                    GridView2.DataBind();
                }
              

                if (id != null && action != null)
                {
                    if (action.Equals("Details"))
                    {
                        List<OrderItem> items = ClassList.findOrderItemByPurchaseOrder(Convert.ToInt32(id));
                        GridView1.DataSource = items;
                        GridView1.DataBind();
                    }
                    if (action.Equals("Reject"))
                    {
                        
                        if (TextBox1.Text.Trim() != "")
                        {
                            SOrder rejorder = ClassList.findOrderByPurchaseOrder(Convert.ToInt32(id));
                            ClassList.deleteOrderByPurchaseOrder(Convert.ToInt32(id));
                            orders.Remove(rejorder);
                            string message = "Your order: " + rejorder.purchaseordernumber + " is rejected. Reason: " + reason;
                            ClassList.sendEmail(message);         
                            TextBox1.Text = "";                         
                            Response.Redirect("~/SSapproveRejectOrder.aspx");
                        }
                        else
                        {
                            Label1.Text = "Please write in reject reason!" ;
                        }

                    }
                    if (action.Equals("Approve"))
                    {
                        SOrder apporder = ClassList.findOrderByPurchaseOrder(Convert.ToInt32(id));
                        ClassList.approveOrderByPurchaseOrder(Convert.ToInt32(id));
                        orders.Remove(apporder);
                        GridView2.DataBind();
                        Label1.Text = "All the orders are approved today and planed to deliver at " + DateTime.Parse(ClassList.findThreeworkingday(DateTime.Today).ToString()).ToString("MM-dd-yyyy") + " .";
                    }

                    if (action.Equals("ApproveAll"))
                    {
                        foreach (SOrder i in orders)
                        {
                            ClassList.approveOrderByPurchaseOrder(i.purchaseordernumber);
                        }

                        GridView2.DataSource = null;
                        GridView2.DataBind();
                        Label1.Text = "The orders approved today are planed to deliver at " + DateTime.Parse(ClassList.findThreeworkingday(DateTime.Today).ToString()).ToString("MM-dd-yyyy") + " .";
                    }
                    if (action.Equals("RejectAll"))
                    {
                        if (TextBox1.Text.Trim() != "")
                        {
                            foreach (SOrder i in orders)
                            {
                                ClassList.deleteOrderByPurchaseOrder(i.purchaseordernumber);
                                string message = "Your order: " + i.purchaseordernumber + " is rejected. Reason: " + reason;
                                ClassList.sendEmail(message);
                              
                            }
                            TextBox1.Text = "";
                            GridView2.DataSource = null;
                            GridView2.DataBind();
                            Label1.Text = "All orders are rejected .";
                        }
                        else
                        {
                            Label1.Text = "Please write in reject reason!";
                        }
                    }
                }


            }
            else
            {

                if (action.Equals("Reject"))
                {
                  
                    if (TextBox1.Text.Trim() != "")
                    {                     
                        SOrder rejorder = ClassList.findOrderByPurchaseOrder(Convert.ToInt32(id));
                        ClassList.deleteOrderByPurchaseOrder(Convert.ToInt32(id));
                        string message = "Your order: " + rejorder.purchaseordernumber + " is rejected. Reason: " + reason;
                        ClassList.sendEmail(message);
                        TextBox1.Text = "";                    
                        Response.Redirect("~/SSapproveRejectOrder.aspx");
                    }
                    else
                    {
                        Label1.Text = "Please write in reject reason!";
                    }
                }
                if (action.Equals("RejectAll"))
                {
                    List<SOrder> orders = ClassList.findUnprovedOrder();
                    if (TextBox1.Text.Trim() != "")
                    {
                        foreach (SOrder i in orders)
                        {
                            ClassList.deleteOrderByPurchaseOrder(i.purchaseordernumber);
                            string message = "Your order: " + i.purchaseordernumber + " is rejected. Reason: " + reason;
                            ClassList.sendEmail(message);

                        }
                        TextBox1.Text = "";
                        GridView2.DataSource = null;
                        GridView2.DataBind();
                        Label1.Text = "All orders are rejected .";
                    }
                    else
                    {
                        Label1.Text = "Please write in reject reason!";
                    }
                }

            }
          
        }

       
    }
}