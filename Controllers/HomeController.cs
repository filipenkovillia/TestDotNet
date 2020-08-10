using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestDotNet.Utils;

namespace TestDotNet.Controllers
{
    public class HomeController : Controller
    {
        
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Web1()
        {
            DataTable dtUser = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(GlobalConsts.ConnectionString))
            {
                sqlCon.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT Name, PhoneNumber, IsActive FROM Users LEFT JOIN PhoneNumbers on PhoneNumbers.UserID = Users.ID where AddressBookID = 1", sqlCon);
                dataAdapter.Fill(dtUser);
            }
            return View(dtUser);
        }

        public ActionResult Web2()
        {
            DataTable dtUser = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(GlobalConsts.ConnectionString))
            {
                sqlCon.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT Name, PhoneNumber, IsActive FROM Users LEFT JOIN PhoneNumbers on PhoneNumbers.UserID = Users.ID where AddressBookID = 2", sqlCon);
                dataAdapter.Fill(dtUser);
            }
            return View(dtUser);
        }
    }
}