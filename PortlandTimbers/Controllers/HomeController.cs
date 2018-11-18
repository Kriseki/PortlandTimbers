using PortlandTimbers.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortlandTimbers.Controllers
{
    public class HomeController : Controller
    {
        private readonly string connectionString = @"Data Source=STUDENT-PC\SQLEXPRESS;Initial Catalog=Timbers;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Roster()
        {
            string queryString = @"SELECT LastName, FirstName, Nationality, Position, Number from RosterSheet";

            List<Player> ptfcRoster = new List<Player>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var roster = new Player();
                    roster.LastName = reader["LastName"].ToString();
                    roster.FirstName = reader["FirstName"].ToString();
                    roster.Nationality = reader["Nationality"].ToString();
                    roster.Position = reader["Position"].ToString();
                    roster.Number = Convert.ToInt32(reader["Number"]);
                    ptfcRoster.Add(roster);
                }
            }

                return View(ptfcRoster);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}