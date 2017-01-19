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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
                id = Request.QueryString["id"];
            if (Request.QueryString["action"] != null)
                action = Request.QueryString["action"];

            if (!IsPostBack)
            {
                List<SOrder> orders = ClassList.findUnprovedOrder();
                GridView2.DataSource = orders;
                GridView2.DataBind();
          
               if(id!=null&&action!=null)
                {
                    if(action.Equals("Details"))
                    {
                        List<OrderItem> items = ClassList.findOrderItemByPurchaseOrder(Convert.ToInt32(id));                       
                        GridView1.DataSource = items;
                        GridView1.DataBind();
                    }
                    if(action.Equals("Reject"))
                    {
                        //SOrder rejorder = ClassList.findOrderByPurchaseOrder(Convert.ToInt32(id));
                        //ClassList.deleteOrderByPurchaseOrder(Convert.ToInt32(id));
                        //orders.Remove(rejorder);
                        //GridView2.DataBind();
                        if (TextBox1.Text.Trim() != "")
                        {
                            SOrder rejorder = ClassList.findOrderByPurchaseOrder(Convert.ToInt32(id));
                            ClassList.deleteOrderByPurchaseOrder(Convert.ToInt32(id));
                            orders.Remove(rejorder);
                           

                            SmtpClient smtpClient = new SmtpClient("lynx.class.iss.nus.edu.sg", 25);
                            MailMessage mail = new MailMessage();
                            string reason = TextBox1.Text;
                            mail.Body = "Your order with purchase order number: " + rejorder.purchaseordernumber + " is rejected. Reason: " + reason;

                            //Setting From , To and CC
                            mail.From = new MailAddress("hellocomplex007@gmail.com", "MyWeb Site");
                            mail.To.Add(new MailAddress("hellocomplex007@gmail.com"));
                            //  mail.CC.Add(new MailAddress("843168572@qq.com"));
                            smtpClient.Send(mail);
                            TextBox1.Text = "";
                            GridView2.DataBind();
                        }
                        else
                        {
                            Label1.Text = "Please write in reject reason!";
                        }

                    }
                    if(action.Equals("Approve"))
                    {
                        SOrder apporder = ClassList.findOrderByPurchaseOrder(Convert.ToInt32(id));
                        ClassList.approveOrderByPurchaseOrder(Convert.ToInt32(id));
                        orders.Remove(apporder);
                        GridView2.DataBind();
                        Label1.Text = "All the orders are approved today and planed to deliver at " + DateTime.Parse(ClassList.findThreeworkingday(DateTime.Today).ToString()).ToString("MM-dd-yyyy")+" .";
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
                                SmtpClient smtpClient = new SmtpClient("lynx.class.iss.nus.edu.sg", 25);
                                MailMessage mail = new MailMessage();
                                string reason = TextBox1.Text;
                                mail.Body = "Your order with purchase order number: " + i.purchaseordernumber + " is rejected. Reason: " + reason;
                                //Setting From , To and CC
                                mail.From = new MailAddress("hellocomplex007@gmail.com", "MyWeb Site");
                                mail.To.Add(new MailAddress("hellocomplex007@gmail.com"));
                                //  mail.CC.Add(new MailAddress("843168572@qq.com"));
                                smtpClient.Send(mail);

                                TextBox1.Text = DateTime.Today.ToString();
                            }

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

        protected void reject_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox checkboxdelete = ((CheckBox)GridView1.Rows[i].FindControl("reject"));

                if (checkboxdelete.Checked == true)
                {
                    Label lblrollno = ((Label)GridView1.Rows[i].FindControl("lblrollno"));

                    int rolNo = Convert.ToInt32(lblrollno.Text);
                  
                }
            }
        }
    }
}