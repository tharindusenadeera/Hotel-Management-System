using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChoiseManagement.Models.Hotel;
using ChoiseManagement.Models.ViewModels;

namespace ChoiseManagement.Controllers
{
    public class OrderController : BaseController
    {
        HotelModel db = new HotelModel();
        public ActionResult Index(int reservationId, int? categoryId, string search = "")
        {
            try
            {
              Session["RESEVATION"] = reservationId;
                Guest_Details Guest = new Guest_Details();
                Guest = ((Guest_Details)Session["logindetails"]);

               ViewBag.rid = ((int)Session["RESEVATION"]);
                ViewBag.id = Guest.Guest_First_Name;

                OrderViewModel hpvm = new OrderViewModel();
                hpvm.NavBarCategories = db.Food_Categories.ToList();

                if (categoryId.HasValue && categoryId != null)
                    hpvm.foods = db.Food_Items.Where(i => i.Item_Category_ID == categoryId && (i.Item_Name.Contains(search) || i.Description.Contains(search))).ToList();
                else
                    hpvm.foods = db.Food_Items.Where(i => i.Item_Name.Contains(search) || i.Description.Contains(search)).ToList();

                return View(hpvm);
            }
            catch (Exception){ return View(); }
           

        }

        public ActionResult OrderIndex()
        {
            Session["Total"] = 0;
            List<OrderItemViewModel> civml = new List<OrderItemViewModel>();

            if (Session["FoodItems"] != null)
            {
                civml = ((List<OrderItemViewModel>)Session["FoodItems"]);
                foreach (var Order in civml)
                {
                    Session["Total"] = ((int)Session["Total"]) + Order.SubTotal;
                }

            }

            ViewBag.Total = ((int)Session["Total"]);
            ViewBag.rid = ((int)Session["RESEVATION"]);

            return View(civml);
        }

        [HttpGet]
        public ActionResult AddFoods(int ItemCode)
        {
            try
            {
                Food_Items item = db.Food_Items.FirstOrDefault(i => i.Item_Code == ItemCode);

                OrderItemViewModel cvm = new OrderItemViewModel();
                cvm.Item = item;
                cvm.Qty = 1;
                cvm.SubTotal = (item.Portion_Price ?? 0 * 1);

                if (Session["FoodItems"] == null)
                    Session["FoodItems"] = new List<OrderItemViewModel>();

                ((List<OrderItemViewModel>)Session["FoodItems"]).Add(cvm);

                //if (Session["Total"] == null)
                //    Session["Total"] = cvm.SubTotal;
                //else
                //    Session["Total"] = ((int)Session["Total"]) + cvm.SubTotal;

                //ViewBag.Total = Session["Total"];

                return RedirectToAction("OrderIndex");
            }
            catch(Exception ex)
            {
                
                return View();
            }
            
        }


        [HttpPost]
        public ActionResult UpdateOrder(int ItemCode, int Qty)
        {
            try
            {
                if (Qty == 0)
                {
                    OrderItemViewModel cvm = ((List<OrderItemViewModel>)Session["FoodItems"]).FirstOrDefault(i => i.Item.Item_Code == ItemCode);
                    ((List<OrderItemViewModel>)Session["FoodItems"]).Remove(cvm);
                }
                else
                {

                    ((List<OrderItemViewModel>)Session["FoodItems"]).FirstOrDefault(i => i.Item.Item_Code == ItemCode).Qty = Qty;
                    ((List<OrderItemViewModel>)Session["FoodItems"]).FirstOrDefault(i => i.Item.Item_Code == ItemCode).SubTotal = (((List<OrderItemViewModel>)Session["FoodItems"]).FirstOrDefault(i => i.Item.Item_Code == ItemCode).Item.Portion_Price ?? 0) * Qty;
                    // Session["Total"] = ((int)Session["Total"]) + (((List<OrderItemViewModel>)Session["FoodItems"]).FirstOrDefault(i => i.Item.Item_Code == ItemCode).Item.Portion_Price ?? 0) * Qty;
                }
                return RedirectToAction("OrderIndex");
            }
            catch(Exception ez)
            {
                return View();
            }
            
        }

        public ActionResult SaveOrder()
        {
            try
            {
                Bill bill = new Bill();
                Order order = new Order();
                int RID = ((int)Session["RESEVATION"]);
                var details = ((List<OrderItemViewModel>)Session["FoodItems"]);
                foreach (var item in details)
                {
                    order.Item_Id = item.Item.Id;
                    order.Item_Quantity = item.Qty;
                    order.Item_Portion_Price = item.Item.Portion_Price;
                    order.Total_Item_Price = item.SubTotal;
                    order.Reservation_Id = RID;
                    db.Orders.Add(order);
                    db.SaveChanges();

                    var billId = db.Bills.Where(r => r.Reservation_ID == RID).SingleOrDefault();

                    billId.Total_Charge = billId.Total_Charge + item.SubTotal;
                    db.SaveChanges();

                    Session["FoodItems"]= null;
                    Session["Total"] = 0;

                }
                return RedirectToAction("MyAcnt", "Home", new { guest = ((Guest_Details)Session["logindetails"]).Guest_Id });
            }
            catch(Exception ex)
            {
                
                ViewBag.error = "Error On Order";
                return View();
            }
            

            
        }
      
    }
}