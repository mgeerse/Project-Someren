using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Someren
{
    class SomerenDB
    {  
        public static SqlConnection openConnectieDB()
        {
            string host = "spartainholland.database.windows.net";
            string db = "someren_inholland_db";
            string user = "spartainholland";
            string password = "Spartalogin1";
            //string port = "3306";

            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "spartainholland.database.windows.net";
                builder.UserID = "spartainholland";
                builder.Password = "Spartalogin1";
                builder.InitialCatalog = "someren_inholland_db";

                SqlConnection connection = new SqlConnection(builder.ConnectionString.ToString());
                connection.Open();
                return connection;

            }
            catch (SqlException e)
            {
                SqlConnection connection = null;
                Console.WriteLine(e.ToString());
                return connection;
            }            
        }

        private void sluitConnectieDB(SqlConnection connection)
        {
            connection.Close();
        }

        public static List<SomerenModel.Student> DB_gettudents()
        {
            SqlConnection connection = openConnectieDB();
            List<SomerenModel.Student> studenten_lijst = new List<SomerenModel.Student>();

            StringBuilder sb = new StringBuilder();
            // schrijf hier een query om te zorgen dat er een lijst met studenten wordt getoond
            sb.Append("SELECT [StudentId], [Naam] FROM [dbo].[A5_Student]");

            /* VOORBEELDQUERY */
            //sb.Append("SELECT TOP 20 pc.Name as CategoryName, p.name as ProductName ");
            //sb.Append("FROM [SalesLT].[ProductCategory] pc ");
            //sb.Append("JOIN [SalesLT].[Product] p ");
            //sb.Append("ON pc.productcategoryid = p.productcategoryid;");
            /* */

            String sql = sb.ToString();

            SqlCommand command = new SqlCommand(sql, connection);
            command.Prepare();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int StudentId = reader.GetInt32(0);
                string Naam = reader.GetString(1);
                SomerenModel.Student student = new SomerenModel.Student();
                student.setId(StudentId);
                student.setNaam(Naam);
                studenten_lijst.Add(student);
            }
            return studenten_lijst;
        }

        public static List<SomerenModel.Docent> DB_GetDocent()
        {
            SqlConnection connection = openConnectieDB();
            List<SomerenModel.Docent> docenten_lijst = new List<SomerenModel.Docent>();

            StringBuilder sb = new StringBuilder();
            // schrijf hier een query om te zorgen dat er een lijst met studenten wordt getoond
            sb.Append("SELECT [DocentId], [Naam] FROM [dbo].[A5_Docent]");

            String sql = sb.ToString();

            SqlCommand command = new SqlCommand(sql, connection);
            command.Prepare();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int DocentId = reader.GetInt32(0);
                string Naam = reader.GetString(1);
                SomerenModel.Docent Docent = new SomerenModel.Docent();
                Docent.setId(DocentId);
                Docent.setNaam(Naam);
                docenten_lijst.Add(Docent);
            }
            return docenten_lijst;
        }

        public static List<SomerenModel.Drankvoorraad> DB_GetDrankvoorraad()
        {
            SqlConnection connection = openConnectieDB();
            List<SomerenModel.Drankvoorraad> dranken_lijst = new List<SomerenModel.Drankvoorraad>();

            StringBuilder sb = new StringBuilder();
            // schrijf hier een query om te zorgen dat er een lijst met studenten wordt getoond
            sb.Append("SELECT * FROM dbo.A5_Voorraad WHERE Voorraad > 1 AND Prijs > 1 AND Naam<>'Water' AND Naam!='Sinas' AND Naam!='Kersensap' ORDER BY Voorraad, Prijs, Aantal_Verkocht;");

            String sql = sb.ToString();

            SqlCommand command = new SqlCommand(sql, connection);
            command.Prepare();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int DrankId = reader.GetInt32(0);
                string Naam = reader.GetString(1);
                decimal Prijs = reader.GetDecimal(2);
                int Aantal_Verkocht = reader.GetInt32(3);
                int Voorraad = reader.GetInt32(4);

                SomerenModel.Drankvoorraad Drankvoorraad = new SomerenModel.Drankvoorraad();
                Drankvoorraad.setId(DrankId);
                Drankvoorraad.setNaam(Naam);
                Drankvoorraad.setPrijs(Prijs);
                Drankvoorraad.setAantal_Verkocht(Aantal_Verkocht);
                Drankvoorraad.setVoorraad(Voorraad);
                dranken_lijst.Add(Drankvoorraad);
            }

            return dranken_lijst;
        }
    }
}
