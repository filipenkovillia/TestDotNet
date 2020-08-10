using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestDotNet.Models;
using TestDotNet.Utils;

namespace TestDotNet.Controllers
{
    public class PhoneNumberController : Controller
    {
        [HttpGet]
        // GET: PhoneNumber
        public ActionResult Index()
        {
            DataTable dtPhoneNumbers = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(GlobalConsts.ConnectionString))
            {
                sqlCon.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM PhoneNumbers", sqlCon);
                dataAdapter.Fill(dtPhoneNumbers);
            }
            return View(dtPhoneNumbers);
        }

        // GET: PhoneNumber/Create
        public ActionResult Create()
        {
            return View(new PhoneNumbersModel());
        }

        // POST: PhoneNumber/Create
        [HttpPost]
        public ActionResult Create(PhoneNumbersModel phoneNumbersModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(GlobalConsts.ConnectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO PhoneNumbers VALUES(@PhoneNumber, @IsActive, @UserID)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@PhoneNumber", phoneNumbersModel.PhoneNumber);
                sqlCmd.Parameters.AddWithValue("@IsActive", phoneNumbersModel.IsActive);
                sqlCmd.Parameters.AddWithValue("@UserID", phoneNumbersModel.UserID);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: PhoneNumber/Edit/5
        public ActionResult Edit(int id)
        {
            PhoneNumbersModel phoneNumbersModel = new PhoneNumbersModel();
            DataTable dtPhoneNumber = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(GlobalConsts.ConnectionString))
            {
                sqlCon.Open();
                string query = "SELECT * FROM PhoneNumbers WHERE ID = @ID";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, sqlCon);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@ID", id);
                dataAdapter.Fill(dtPhoneNumber);
            }
            if (dtPhoneNumber.Rows.Count == 1)
            {
                phoneNumbersModel.ID = Convert.ToInt32(dtPhoneNumber.Rows[0][0].ToString());
                phoneNumbersModel.PhoneNumber = dtPhoneNumber.Rows[0][1].ToString();
                phoneNumbersModel.IsActive = Convert.ToBoolean(dtPhoneNumber.Rows[0][2].ToString());
                phoneNumbersModel.UserID = Convert.ToInt32(dtPhoneNumber.Rows[0][3].ToString());
                return View(phoneNumbersModel);
            }
            else return RedirectToAction("Index");
        }

        // POST: PhoneNumber/Edit/5
        [HttpPost]
        public ActionResult Edit(PhoneNumbersModel phoneNumbersModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(GlobalConsts.ConnectionString))
            {
                sqlCon.Open();
                string query = "UPDATE PhoneNumbers SET PhoneNumber = @PhoneNumber, IsActive = @IsActive, UserID = @UserID WHERE ID = @ID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@ID", phoneNumbersModel.ID);
                sqlCmd.Parameters.AddWithValue("@PhoneNumber", phoneNumbersModel.PhoneNumber);
                sqlCmd.Parameters.AddWithValue("@IsActive", phoneNumbersModel.IsActive);
                sqlCmd.Parameters.AddWithValue("@UserID", phoneNumbersModel.UserID);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: PhoneNumber/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(GlobalConsts.ConnectionString))
            {
                sqlCon.Open();
                string query = "DELETE PhoneNumbers WHERE ID = @ID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@ID", id);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
    }
}
