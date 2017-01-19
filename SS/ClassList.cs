using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SS
{
    public class ClassList
    {
       static  team6adprojectdbEntities2 ds = new team6adprojectdbEntities2();
        public static List<SOrder> findUnprovedOrder()
        {
            List<SOrder>  orders = new List<SOrder>();         
            orders = ds.SOrders.Where(x => x.approvercode == null).Select(y => y).ToList<SOrder>();
            return orders;
        }
        public static Supplier findSupplierByCode(string suppliercode)
        {
            Supplier supplier = new Supplier();
            supplier = ds.Suppliers.Where(x => x.suppliercode == suppliercode).Select(y => y).FirstOrDefault();
            return supplier;
        }
        public static Employee findEmployeeByCode(int employeecode)
        {
            Employee employee = new Employee();
            employee=ds.Employees.Where(x=>x.employeecode==employeecode).Select(y => y).FirstOrDefault();
            return employee;
        }
        public static List<OrderItem> findOrderItemByPurchaseOrder(int purchaseorder)
        {
            List<OrderItem> orderitems = new List<OrderItem>();
            orderitems=ds.OrderItems.Where(x=>x.purchaseordernumber==purchaseorder).Select(y => y).ToList<OrderItem>();
            return orderitems;
        }

        //add 1/19
        public static SOrder findOrderByPurchaseOrder(int purchaseorder)
        {
            SOrder thisorder = ds.SOrders.Where(x => x.purchaseordernumber == purchaseorder).Select(y => y).FirstOrDefault();
            return thisorder;
        }

        public static void deleteOrderByPurchaseOrder(int purchaseorder)
        {
            SOrder thisorder = findOrderByPurchaseOrder(purchaseorder);
            ds.SOrders.Remove(thisorder);
            ds.SaveChanges();
        }

        public static void approveOrderByPurchaseOrder(int purchaseorder)
            {
            SOrder s = findOrderByPurchaseOrder(purchaseorder);
            DateTime dt;
            //need to change approvercode after session['employeecode'] is create
            s.approvercode = 1029;
            s.approvaldate = DateTime.Today;
            if (s.approvaldate.HasValue)
            {
                dt = s.approvaldate.Value;
                s.expecteddeliverydate = findThreeworkingday(dt);
            }
            ds.SaveChanges();
          
        }
        public static DateTime findThreeworkingday(DateTime today)
        {

            DateTime endday = today;

            if (today.DayOfWeek == DayOfWeek.Monday)
            {
                endday = today.AddDays(4);
            }
            if (today.DayOfWeek == DayOfWeek.Tuesday)
            {
                endday = today.AddDays(6);
            }
            if (today.DayOfWeek == DayOfWeek.Wednesday)
            {
                endday = today.AddDays(6);
            }
            if (today.DayOfWeek == DayOfWeek.Thursday)
            {
                endday = today.AddDays(6);
            }
            if (today.DayOfWeek == DayOfWeek.Friday)
            {
                endday = today.AddDays(6);
            }
            if (today.DayOfWeek == DayOfWeek.Saturday)
            {
                endday = today.AddDays(5);
            }
            if (today.DayOfWeek == DayOfWeek.Sunday)
            {
                endday = today.AddDays(5);
            }
            return endday;
        }
           
    }
}