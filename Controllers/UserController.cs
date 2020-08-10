using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using TestDotNet.Models;
using TestDotNet.Utils;

namespace TestDotNet.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        // GET: User
        public ActionResult Index()
        {
            DataTable dtUser = new DataTable();
            using(SqlConnection sqlCon = new SqlConnection(GlobalConsts.ConnectionString))
            {
                sqlCon.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Users", sqlCon);
                dataAdapter.Fill(dtUser);
            }
            return View(dtUser);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View(new UserModel());
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserModel userModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(GlobalConsts.ConnectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO Users VALUES(@Name, @AddressBookID)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@Name", userModel.Name);
                sqlCmd.Parameters.AddWithValue("@AddressBookID", userModel.AddressID);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            UserModel userModel = new UserModel();
            DataTable dtUser = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(GlobalConsts.ConnectionString))
            {
                sqlCon.Open();
                string query = "SELECT * FROM Users WHERE ID = @ID";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, sqlCon);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@ID", id);
                dataAdapter.Fill(dtUser);
            }
            if (dtUser.Rows.Count == 1)
            {
                userModel.ID = Convert.ToInt32(dtUser.Rows[0][0].ToString());
                userModel.Name = dtUser.Rows[0][1].ToString();
                userModel.AddressID = Convert.ToInt32(dtUser.Rows[0][2].ToString());
                return View(userModel);
            }
            else return RedirectToAction("Index");
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(UserModel userModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(GlobalConsts.ConnectionString))
            {
                sqlCon.Open();
                string query = "UPDATE Users SET Name = @Name, AddressBookID = @AddressBookID WHERE ID = @ID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@ID", userModel.ID);
                sqlCmd.Parameters.AddWithValue("@Name", userModel.Name);
                sqlCmd.Parameters.AddWithValue("@AddressBookID", userModel.AddressID);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(GlobalConsts.ConnectionString))
            {
                sqlCon.Open();
                string query = "DELETE Users WHERE ID = @ID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@ID", id);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
    }
}
