using ChoiseManagement.Models.ViewModels;
using ChoiseManagement.Models.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace ChoiseManagement.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        //-----------------make connection----------------------------//
        HotelModel db = new HotelModel();

        //-----------------make connection----------------------------//


        public ActionResult Index()
        {
            Guest_Details Guest = new Guest_Details();
            Guest = ((Guest_Details)Session["logindetails"]);
            if (Guest!=null)
            {
                ViewBag.Name = Guest.Guest_First_Name;
            }
            
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        //----------------------Showing all Rooms and book-------------------------//
        [HttpGet]
        public ActionResult Rooms(int? categoryId)
        {
            RoomViewModel RVM = new RoomViewModel();
            RVM.catogories = db.Room_Catagorys.Where(c => c.IsActive == true).ToList();

            if (categoryId.HasValue && categoryId != null)
                RVM.RoomList = db.Rooms.Where(i => i.Room_Category_Id == categoryId).ToList();
            else
                RVM.RoomList = db.Rooms.ToList();

            Guest_Details Guest = new Guest_Details();
            Guest = ((Guest_Details)Session["logindetails"]);
            if (Guest != null)
            {
                ViewBag.Name = Guest.Guest_First_Name;
            }


            return View(RVM);
        }


        //----------------------Showing searched Rooms and book-------------------------//

        [HttpPost]
        public ActionResult RoomsSearch(DTOSearch det, int? categoryId)
        {
            DateTime date = DateTime.Today;
            if (date<=det.Arival_Date)
            {
                //make object of view model
                RoomViewModel RVM = new RoomViewModel();
                //make categorys
                RVM.catogories = db.Room_Catagorys.Where(c => c.IsActive == true).ToList();

                // var reservedRooms = db.RoomBookings.Where(r => r.ArivalDate <= det.Arival_Date && r.DepartureDate >= det.Departure_Date).Select(b => b.RoomNo).Distinct().ToList();
                var reservedRooms = db.RoomBookings.Where(r => !(r.ArivalDate >= det.Departure_Date) && !(r.DepartureDate <= det.Arival_Date)).Select(v => v.RoomNo).Distinct().ToList();
                IEnumerable<Room> rooms = db.Rooms.Where(a => !reservedRooms.Contains(a.Room_Number)).ToList();

                int total = det.Adults + det.Childerens;
                IEnumerable<Room> FreeRooms = rooms.Where(a => a.RoomCapacity >= total).ToList();

                Session["FreeRooms"] = FreeRooms;

                var freeRooms = ((IEnumerable<Room>)Session["FreeRooms"]);
                RVM.RoomList = freeRooms;

                Guest_Details Guest = new Guest_Details();
                Guest = ((Guest_Details)Session["logindetails"]);
                if (Guest != null)
                {
                    ViewBag.Name = Guest.Guest_First_Name;
                }

                //if (categoryId.HasValue && categoryId != null)
                //{
                //    RVM.RoomList = freeRooms.Where(i => i.Room_Category_Id == categoryId).ToList();
                //}
                //else
                //{
                //    RVM.RoomList = freeRooms;
                //}

                // IEnumerable<RoomBooking> se=   db.RoomBookings.Where((x => x.ArivalDate <= det.Arival_Date && x.DepartureDate<=det.Arival_Date) ||(y=>y.));
                //IEnumerable<RoomBooking> se = from r in db.RoomBookings where(r =>r.ArivalDate <= det.Arival_Date && r.DepartureDate <= det.Arival_Date) select r;
                //from x in db.RoomBookings where (x.ArivalDate >= det.Departure_Date && x.DepartureDate >= det.Departure_Date)) select x;
                //IEnumerable<RoomBooking> one = db.RoomBookings.Where(r => r.ArivalDate <= det.Arival_Date && r.DepartureDate <= det.Arival_Date).ToList();
                //IEnumerable<RoomBooking> two = db.RoomBookings.Where(y => y.ArivalDate >= det.Departure_Date && y.DepartureDate >= det.Departure_Date).ToList();
                //  IEnumerable<RoomBooking> set = db.RoomBookings.ToList().Where(r => r.ArivalDate <= det.Arival_Date && r.DepartureDate <= det.Arival_Date).Where(y => y.ArivalDate >= det.Departure_Date && y.DepartureDate >= det.Departure_Date);
                // var swet = db.RoomBookings.Where(r => r.ArivalDate > det.Departure_Date || r.DepartureDate < det.Arival_Date).Select(b=>b.RoomNo).Distinct().ToList();


                //var reservedRooms = db.RoomBookings.
                //    Where(r => r.ArivalDate <= det.Arival_Date && r.DepartureDate >= det.Departure_Date).
                //    Select(b => b.RoomNo).Distinct().ToList();



                //var rooms=  db.Rooms.Where(a =>!reservedRooms.Contains(a.Room_Number)).ToList();
                //RVM.RoomList = rooms;
                //r.DepartureDate <= det.Arival_Date).ToList();
                //IEnumerable<RoomBooking> sweot = db.RoomBookings.Where(r => r.ArivalDate >= det.Departure_Date).ToList();
                //IEnumerable<RoomBooking> sweoit = db.RoomBookings.Where(r => r.DepartureDate <= det.Arival_Date).ToList();

                //IEnumerable<Room> roomsa = db.Rooms.Where(a => !test.Contains(a.Room_Number)).ToList();
                //IEnumerable<RoomBooking> sweoait = sweot.Concat(sweoit).ToList();

                //var NILL = db.RoomBookings.Where(r => r.ArivalDate >= det.Arival_Date && r.DepartureDate <= det.Departure_Date ||
                //r.ArivalDate >= det.Arival_Date && r.DepartureDate >= det.Departure_Date ||
                //r.ArivalDate < det.Arival_Date && r.DepartureDate <= det.Departure_Date ||
                //r.ArivalDate <= det.Arival_Date && r.DepartureDate >= det.Departure_Date).Select(b => b.RoomNo).Distinct().ToList();


                //foreach (RoomBooking item in se)
                //{
                //    int? NOS = item.RoomNo;
                //}
                // var ee= sweoait.GroupBy(test1 => test1.RoomNo).Select(grp => grp.First()).ToList();



                //IEnumerable <Room> rrr = from r in db.Rooms join b in ee on r.Room_Number equals b.RoomNo into joinDeptEmp select new { name = r.Room_Category_Id });
                // RVM.RoomList = rrr;
                //int cap = det.Adults + det.Childerens;
                //IEnumerable<Room> tt =(from m in db.Rooms where (!(m.Check_In_Date >= det.Arival_Date && m.Check_Out_Date <= det.Departure_Date) && m.RoomCapacity >= cap) select m).ToList();
                //RoomViewModel rooms = new RoomViewModel();
                //rooms.RoomList = tt;


                return View(RVM);

            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }


        //----------------------End of Showing search Rooms-------------------------//
        [HttpGet]
        public ActionResult freesession(int categoryId)
        {
            RoomViewModel RVM = new RoomViewModel();
            //make categorys
            RVM.catogories = db.Room_Catagorys.Where(c => c.IsActive == true).ToList();

            var freeRooms = ((IEnumerable<Room>)Session["FreeRooms"]);

            RVM.RoomList = freeRooms.Where(i => i.Room_Category_Id == categoryId).ToList();

            return View("RoomsSearch", RVM);
        }

        //----------------------After login Showing Rooms-------------------------//
        [HttpGet]
        public ActionResult AfterLoginRooms(int RoomNo)
        {
            Room show = db.Rooms.Where(m => m.Room_Number == RoomNo).SingleOrDefault();


            return View(show);
        }
        //----------------------End of After login Showing Rooms-------------------------//


        //--------------------------------- Register part--------------------------//
        [HttpGet]
        public ActionResult Register()
        {


            return View();
        }

        [HttpPost]
        public ActionResult Register(DTOGuestDetails details)
        {
           var emails = db.Guest_Details.Where(q => q.Guest_Email == details.Guest_Email).ToList();
            if (emails.Count==0)
            {
                var originalPassword = details.Password;

                MD5 md5 = new MD5CryptoServiceProvider();
                Byte[] originalBytes = ASCIIEncoding.Default.GetBytes(originalPassword);
                Byte[] encodedBytes = md5.ComputeHash(originalBytes);

                string hashPassword = BitConverter.ToString(encodedBytes);
                if (ModelState.IsValid)
                {
                    Guest_Details gd = new Guest_Details();


                    gd.Guest_Title = details.Guest_Title;
                    gd.Guest_First_Name = details.Guest_First_Name;
                    gd.Guest_Last_Name = details.Guest_Last_Name;
                    gd.Guest_Address = details.Guest_Address;
                    gd.Guest_MobileNO = details.PhoneNumber;
                    //  gd.Guest_CreditCardNo = details.Guest_CreditCardNo;
                    gd.Paasword = hashPassword;
                    gd.Guest_Email = details.Guest_Email;

                    db.Guest_Details.Add(gd);
                    db.SaveChanges();

                    int No = Convert.ToInt32(Session["RoomNo"]);
                    return RedirectToAction("login", "Home", new { roomNo = No });

                }
            }
            else
            {
                ViewBag.errorss = "The Email You Entered is Already in Use.Please Use Another Email";
                return View();
            }
            
           

            return View();
            
        }

        //---------------------------------End of Register part--------------------------//

        //---------------------------------login part--------------------------//
        [HttpGet]
        public ActionResult login(int? roomNo)
        {
            Session["RoomNo"] = roomNo;

            return View();
        }

        
        [HttpPost]
        public ActionResult login(DTOlogin log)
        {
            var originalPassword = log.Paasword;
            //----make hash password-------------------------------//

            MD5 md5 = new MD5CryptoServiceProvider();

            Byte[] originalBytes = ASCIIEncoding.Default.GetBytes(originalPassword);

            Byte[] encodedBytes = md5.ComputeHash(originalBytes);

            string hashPassword = BitConverter.ToString(encodedBytes);

            int? No = Convert.ToInt32(Session["RoomNo"]);
            if (ModelState.IsValid)
            {
                Guest_Details details = db.Guest_Details.Where(i => i.Guest_Email == log.Guest_Email && i.Paasword == hashPassword).SingleOrDefault();
                Session["logindetails"] = details;
                if (Session["logindetails"] != null)
                {
                    if (Session["logindetails"] != null && No != 0)
                    {
                        return RedirectToAction("Reservation", "Home");
                    }
                    else if(Session["logindetails"] != null && No == 0)
                    {
                        Guest_Details GuestNew = new Guest_Details();

                        GuestNew = ((Guest_Details)Session["logindetails"]);

                        int gestId=GuestNew.Guest_Id;

                        Session["GestId"] = gestId;

                        return RedirectToAction("MyAcnt", "Home",new {gest=gestId });

                    }
                }
               
                else
                {
                    ViewBag.error = "Please Enter Valid User Name and Password";
                    return View();
                }

            }
            return View();
        }
        //---------------------------------End of login part--------------------------//


        //---------------------LogOut Part---------------------------//


        public ActionResult LogOut()
        {
            Session["RoomNo"] = null;
            Session["logindetails"] = null;
            return RedirectToAction("Index");
        }


        //---------------------------------Reservation part--------------------------//
        [HttpGet]
        public ActionResult Reservation(int roomNo)
        {
            ReservationViewModel RVM = new ReservationViewModel();

            if (Session["logindetails"] == null)
            {
                return RedirectToAction("login");
            }

            Session["RoomNo"] = roomNo;
            int No = Convert.ToInt32(Session["RoomNo"]);

            Room SelectedRoom = db.Rooms.Where(r => r.Room_Id == No).FirstOrDefault();

            RVM.selectedRoom = SelectedRoom;

            Session["capasity"] = SelectedRoom.RoomCapacity;

            Guest_Details Guest = new Guest_Details();
            Guest = ((Guest_Details)Session["logindetails"]);
            ViewBag.Name = Guest.Guest_First_Name;
            Session["RVM"] = RVM;
            return View(RVM);
        }
        [HttpPost]
        public ActionResult Reservation(ReservationViewModel details)
        {
            ReservationViewModel RVM = new ReservationViewModel();
            RVM = ((ReservationViewModel)Session["RVM"]);

            Guest_Details Guest = new Guest_Details();
            Guest = ((Guest_Details)Session["logindetails"]);

           

            if (ModelState.IsValid)
            {
                DateTime date = DateTime.Today;
                if (date<=details.reseravation.Check_In)
                {
                    if (details.reseravation.Check_In<=details.reseravation.Check_Out)
                    {
                        Reservation resrved = new Reservation();
                        RoomBooking bookings = new RoomBooking();
                        Bill bill = new Bill();


                        int No = Convert.ToInt32(Session["RoomNo"]);
                        Room det = db.Rooms.Where(m => m.Room_Number == No).FirstOrDefault();
                        // IEnumerable<RoomBooking> reservedRooms = db.RoomBookings.Where(m => m.RoomNo == No).ToList().Where(a => (a.ArivalDate >= details.reseravation.Check_In) && a.DepartureDate <= details.reseravation.Check_Out);
                        var reservedRooms = db.RoomBookings.Where(r => !(r.ArivalDate >= details.reseravation.Check_Out) && !(r.DepartureDate <= details.reseravation.Check_In)).Distinct().ToList().Where(w => w.RoomNo == No).SingleOrDefault();

                        int packageid = details.reseravation.Package_Id;
                        int? packageprice = db.Packages.Where(y => y.Package_ID == packageid).Select(p => p.Package_Price).SingleOrDefault();


                        int cap = details.reseravation.Childrens + details.reseravation.Adults;
                        int capacity = Convert.ToInt32(Session["capasity"]);
                        if (cap <= capacity)
                        {
                            if (reservedRooms == null)
                            {


                                resrved.Guest_Id = Guest.Guest_Id;
                                resrved.Package_Id = details.reseravation.Package_Id;
                                resrved.Room_Number = No;
                                resrved.Check_In = details.reseravation.Check_In;
                                resrved.Check_Out = details.reseravation.Check_Out;
                                resrved.Adults = details.reseravation.Adults;
                                resrved.Childrens = details.reseravation.Childrens;
                                db.Reservations.Add(resrved);
                                db.SaveChanges();
                                Reservation lastRow = (from r in db.Reservations orderby r.Reservation_Id descending select r).FirstOrDefault();

                                bookings.ReservationId = lastRow.Reservation_Id;
                                bookings.ArivalDate = details.reseravation.Check_In;
                                bookings.DepartureDate = details.reseravation.Check_Out;
                                bookings.RoomNo = No;
                                bookings.CategoryId = det.Room_Category_Id;
                                db.RoomBookings.Add(bookings);
                                db.SaveChanges();


                                bill.Reservation_ID = lastRow.Reservation_Id;
                                bill.Total_Charge = packageprice;
                                db.Bills.Add(bill);
                                db.SaveChanges();

                                Session["lastReservation"] = lastRow;
                                // Session["RoomNo"]
                                //Session["capasity"]

                            }
                            else
                            {
                                ViewBag.Error = "Sorry," + Guest.Guest_Title + "." + Guest.Guest_First_Name + ".This Room is already Booked for the selected days.Please look for another room or select a different date";
                                return View(RVM);
                            }
                        }
                        else
                        {
                            ViewBag.cap = "Sorry you can not select No.of heads more than capacity of the room ";
                            return View(RVM);
                        }
                    }
                    else
                    {
                        ViewBag.date = "Check In Cannot be greater than Check Out";
                        return View(RVM);
                    }
                    

                }
                else
                {
                    ViewBag.date = "You Cannot reserve for past dates.select a valid date";
                    return View(RVM);
                }
                
            }
            else
            {

                ModelState.AddModelError("E1", "invalid");
                return View(RVM);


            }

            return RedirectToAction("Email");

        }
        //---------------------------------End of Reservation part--------------------------//



        //----------------------------------------sending email----------------------------//
        public ActionResult Email()
        {
            Guest_Details Guest = new Guest_Details();
            Guest = ((Guest_Details)Session["logindetails"]);
            string recivermail = Guest.Guest_Email;
            Reservation lastresrvation = new Reservation();
            lastresrvation = ((Reservation)Session["lastReservation"]);

            string bodymail = Guest.Guest_Title + "." + Guest.Guest_First_Name + " you have successfully reserved a room from " + lastresrvation.Check_In + " to " + lastresrvation.Check_Out + " .Thank you for the selecting Hotel Beach Castle.";
            
            try
            {
                if (ModelState.IsValid)
                {
                    var SenderEmail = new MailAddress("miniprojecthotelmanagement@gmail.com", "Hotel Beach Castle.com");
                    var ReciverEmail = new MailAddress(recivermail, Guest.Guest_First_Name);

                    var Password = "2perfect";
                    var subject = "Hotel Beach Castle Room Reservation has Completed";
                    var body = bodymail;

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(SenderEmail.Address, Password)

                    };
                    using (var mess = new MailMessage(SenderEmail, ReciverEmail)
                    {
                        Subject = "Hotel Beach Castle Room Reservation has Completed",
                        Body = bodymail
                    })
                    {
                        smtp.Send(mess);
                    }
                    return RedirectToAction("MyAcnt", new { gest = Guest.Guest_Id });
                }

            }
            catch (Exception)
            {
                ViewBag.error = "Mail Not Send";
            }
            return View();
        }



        public ActionResult MyAcnt()
        {
            int gest = ((int)Session["GestId"]);
          var rr=  db.Reservations.Where(g => g.Guest_Id == gest).Select(q=>q.Reservation_Id).ToList();
            var Reservations = db.RoomBookings.Where(a => rr.Contains(a.ReservationId)).ToList();

            Guest_Details Guest = new Guest_Details();
            Guest = ((Guest_Details)Session["logindetails"]);
            if (Guest == null)
            {
                //ViewBag.Name = "";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Name = Guest.Guest_First_Name;
            }
            

            return View(Reservations);
        }

        public ActionResult ViewOrder(int reservationId)
        {
            var order = db.Orders.Where(t => t.Reservation_Id == reservationId).ToList();
           

            return View(order);
        }

        public ActionResult ee()
        {
            try
            {
                var originalPassword = "malith";

                MD5 md5 = new MD5CryptoServiceProvider();
                Byte[] originalBytes = ASCIIEncoding.Default.GetBytes(originalPassword);
                Byte[] encodedBytes = md5.ComputeHash(originalBytes);

                var name=BitConverter.ToString(encodedBytes);
                return View();
            }
            catch
            {
                return View();
            }
          
        }
        
        public ActionResult Delete(int id)
        {
           var result= db.Reservations.Where(w => w.Reservation_Id == id).SingleOrDefault();
            db.Reservations.Remove(result);
            db.SaveChanges();
            return RedirectToAction("MyAcnt");

        }

        public ActionResult DeleteItem(int id)
        {
            var result = db.Orders.Where(w => w.Item_Id == id).ToList();
            db.Orders.RemoveRange(result);
            db.SaveChanges();
            return RedirectToAction("MyAcnt");


        }







    }


}
