using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.Data.SqlClient;
using adonetdemo.Models;

namespace adonetdemo.Controllers
{
    public class AdoNetDemoController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        private string _connString = @"Server=192.168.1.87\SQL2022;Database=aspnetmvc;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;User ID=sa;Password=1qaz@WSX;Integrated Security=False";
        public IActionResult GetUserList()
        {
            using var conn = new SqlConnection();
            using var cmd = new SqlCommand();
            List<Users> model = new List<Users>();
            conn.ConnectionString = _connString;
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT UserNo , UserName , Remark FROM Users ORDER BY UserNo";
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    string str_user_no = (dr["UserNo"] == null) ? "" : dr["UserNo"].ToString();
                    string str_user_name = (dr["UserName"] == null) ? "" : dr["UserName"].ToString();
                    string str_remark = (dr["Remark"] == null) ? "" : dr["Remark"].ToString();
                    model.Add(new Users() { UserNo = str_user_no, UserName = str_user_name, Remark = str_remark });
                }
            }
            dr.Close();
            conn.Close();
            return View(model);
        }
        public IActionResult GetUser(string id)//這裡參數用id是因為Program.cs內的路由參數叫做id, 兩個要一致
        {
            using var conn = new SqlConnection();
            using var cmd = new SqlCommand();
            Users model = new Users();
            model.UserNo = id;
            model.UserName = "未建檔";
            model.Remark = "查無此人!!";

            conn.ConnectionString = _connString;
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT UserNo , UserName , Remark FROM Users WHERE UserNo = @UserNo";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@UserNo", id);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                string str_user_no = (dr["UserNo"] == null) ? "" : dr["UserNo"].ToString();
                string str_user_name = (dr["UserName"] == null) ? "" : dr["UserName"].ToString();
                string str_remark = (dr["Remark"] == null) ? "" : dr["Remark"].ToString();
                model.UserNo = str_user_no;
                model.UserName = str_user_name;
                model.Remark = str_remark;
            }
            dr.Close();
            conn.Close();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            Users model = new Users();
            model.UserNo = "";
            model.UserName = "";
            model.Remark = "";
            return View(model);
        }

        [HttpPost]
        public IActionResult AddUser(Users model)
        {
            if (string.IsNullOrEmpty(model.UserNo))
            {
                ModelState.AddModelError("UserNo", "使用者編號不可空白!!");
                return View(model);
            }
            if (string.IsNullOrEmpty(model.UserName))
            {
                ModelState.AddModelError("UserName", "使用者姓名不可空白!!");
                return View(model);
            }

            using var conn = new SqlConnection();
            using var cmd = new SqlCommand();
            conn.ConnectionString = _connString;
            conn.Open();
            cmd.Connection = conn;

            // 檢查使用者代號是否已存在 尚未完成
            // cmd.CommandText = "SELECT Id FROM Users WHERE UserNo = @UserNo";
            // cmd.Parameters.Clear();
            // cmd.Parameters.AddWithValue("@UserNo", model.UserNo);
            // SqlDataReader dr = cmd.ExecuteReader();
            // if( dr.HasRows ){
            //     dr.Close();
            //     conn.Close();
            //      ModelState.AddWithValue;
            //     return View();
            // }
            // dr.Close();

            cmd.CommandText = @"
            INSERT INTO Users (IsValid , UserNo , UserName , Remark) 
            VALUES 
            (@IsValid , @UserNo , @UserName , @Remark)
            ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@IsValid", true);
            cmd.Parameters.AddWithValue("@UserNo", model.UserNo);
            cmd.Parameters.AddWithValue("@UserName", model.UserName);
            cmd.Parameters.AddWithValue("@Remark", model.Remark);
            cmd.ExecuteNonQuery();
            conn.Close();
            return RedirectToAction("GetUserList");
        }

        public ContentResult GetUserDataTableList()
        {
            string str_message = "查無資料!!";
            using var conn = new SqlConnection();
            using var cmd = new SqlCommand();
            DataTable dt_data = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            conn.ConnectionString = _connString;
            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT UserNo , UserName FROM Users ORDER BY UserNo";

                da.SelectCommand = cmd;
                da.Fill(dt_data);
                da.Dispose();
                if (dt_data.Rows.Count > 0)
                {
                    str_message = "";
                    foreach (DataRow item in dt_data.Rows)
                    {
                        string str_user_no = item["UserNo"].ToString();
                        string str_user_name = item["UserName"].ToString();
                        str_message += $"{str_user_no} ({str_user_name}) , ";
                    }
                }
            }
            catch (Exception ex)
            {
                str_message = ex.Message;
            }
            conn.Close();
            return Content(str_message);
        }

        public ContentResult CallStoreProcedure()
        {
            string str_user_no = "U099";
            string str_user_name = "陳大國";
            bool is_valid = true;
            string str_message = $"{str_user_no} {str_user_name} 新增完成!!";
            using var conn = new SqlConnection();
            using var cmd = new SqlCommand();
            conn.ConnectionString = _connString;
            try
            {
                conn.Open();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.sp_add_user"; // 這裡名稱要跟資料庫內的預存程序名稱一模一樣
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@UserNo", str_user_no);
                cmd.Parameters.AddWithValue("@UserName", str_user_name);
                cmd.Parameters.AddWithValue("@IsValid", is_valid);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                str_message = ex.Message;
            }
            conn.Close();
            return Content(str_message);
        }



    }
}