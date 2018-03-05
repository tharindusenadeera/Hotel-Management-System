using System;
using System.Linq;
using System.Web.Mvc;
using ChoiseManagement.Models.Hotel;
using System.Net.Mail;
using ChoiseManagement.Areas.Admin.Models;
using System.Net;
using Rotativa;
using ChoiseManagement.Models.ViewModels;
using System.Collections.Generic;

namespace ChoiseManagement.Areas.Admin.Controllers
{
    public class ManagerController : Controller
    {

        HotelModel db = new HotelModel();
        // GET: Admin/Manager
        HotelModel context = new HotelModel();

        public ActionResult Index()
        {
            ViewBag.admin = "Welcome";
            return View();
        }
        public ActionResult AdminLogin()
        {

            return View();
        }
        [HttpGet]
        public ActionResult Email()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Email(Email mail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var SenderEmail = new MailAddress("tharindusenadeera081@gmail.com", "Tharindu");
                    var ReciverEmail = new MailAddress(mail.Sender, "kanchana");

                    var Password = "integrated";
                    var subject = mail.Subject;
                    var body = mail.Body;

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod=SmtpDeliveryMethod.Network,
                        UseDefaultCredentials=false,
                        Credentials=new NetworkCredential(SenderEmail.Address,Password)

                    };
                    using (var mess = new MailMessage(SenderEmail, ReciverEmail)
                    {
                        Subject = mail.Subject,
                        Body = mail.Body
                    })
                    {
                        smtp.Send(mess);
                    }
                    return View();
                }

            }
            catch (Exception)
            {
                ViewBag.error = "Mail Not Send";
            }
            return View();
        }

        public ActionResult Departure()
        {
            DateTime date = DateTime.Today;
            ViewBag.today = date;
            var todaydeprture = db.RoomBookings.Where(r => r.DepartureDate == date).ToList();
            return View(todaydeprture);
        }

        public ActionResult Arival()
        {
            DateTime date = DateTime.Today;
            ViewBag.today = date;
            var todayArival = db.RoomBookings.Where(r => r.ArivalDate == date).ToList();
            return View(todayArival);
        }

        public ActionResult Generatepdf(int tt)
        {
            var pdf = db.Reservations.Where(r => r.Reservation_Id == tt).ToList();

            return View(pdf);
        }
        public ActionResult pdf()
        {
            ActionAsPdf result = new ActionAsPdf("Departure")
            {
                FileName = Server.MapPath("~/Content/Files/TodayDeparture1.pdf")
            };  
            return result;
        }

        public ActionResult pdfd()
        {
            ActionAsPdf result = new ActionAsPdf("Arival")
            {
                FileName = Server.MapPath("~/Content/Files/TodayDeparture1.pdf")
            };
            return result;
        }
        public ActionResult MakeBill(int id)
        {
            BillViewModel BVM = new BillViewModel();

            var totalbill = db.Reservations.Where(r => r.Reservation_Id == id).ToList();
            var bill = db.Bills.Where(r => r.Reservation_ID == id).ToList();
            var Oreder=db.Orders.Where(r => r.Reservation_Id == id).ToList();
            BVM.ReservationDetails = totalbill;
           BVM.BillDetails = bill;
            BVM.Orderdetails = Oreder;
            
            return View(BVM);
        }

        public ActionResult ReservationBill(int rid)
        {
            ActionAsPdf result = new ActionAsPdf("MakeBill",new { id= rid })
            {
                FileName = Server.MapPath("~/Content/Files/TodayDeparture1.pdf")
            };
            return result;
        }
        [HttpPost]
        public ActionResult searchGuest(DTOsearch name)
        {
         List<int>  gid=  db.Guest_Details.Where(r=> r.Guest_First_Name.Contains(name.Sender)).Select(n => n.Guest_Id).ToList();
           
          
             var reservations = db.Reservations.Where(a => gid.Contains(a.Guest_Id??1)).ToList();
           
            return View(reservations);
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(DTOadmin admin)
        {
            if (ModelState.IsValid)
            {
                var login = db.Admin_login.Where(r => r.Depertment == admin.Guest_Email && r.Password == admin.Paasword).SingleOrDefault();
                if (login!=null)
                {
                    Session["admin"] = login;
                    int id = login.Depertment_Id;
                    return View("Index");
                }
                else
                {
                    ViewBag.ww = "Enter valid user name and Password";
                    return View();
                }
                
            }
            return View();
        }
        public ActionResult ViewOrder(int rid)
        {
            var order = db.Orders.Where(t => t.Reservation_Id == rid).ToList();


            return View(order);
        }
       
        public ActionResult pdforder(int rid)
        {
            ActionAsPdf result = new ActionAsPdf("ViewOrder", new { rid = rid })
            {
                FileName = Server.MapPath("~/Content/Files/TodayDeparture1.pdf")
            };
            return result;
        }

    }
}