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

        public static List<SomerenModel.Drank> DB_GetDrank()
        {
            SqlConnection connection = openConnectieDB();
            List<SomerenModel.Drank> drank_lijst = new List<SomerenModel.Drank>();

            StringBuilder sb = new StringBuilder();
            // schrijf hier een query om te zorgen dat er een lijst met studenten wordt getoond
            sb.Append("SELECT [Naam], [Prijs], [Voorraad], [Aantal_Verkocht], [DrankId] FROM [dbo].[A5_Voorraad]");

            String sql = sb.ToString();

            SqlCommand command = new SqlCommand(sql, connection);
            command.Prepare();

           SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                decimal Prijs = reader.GetDecimal(1);
                string Naam = reader.GetString(0);
                int voorraad = reader.GetInt32(2);
                int aantalverkocht = reader.GetInt32(3);
                int drankid = reader.GetInt32(4);

                SomerenModel.Drank Drank = new SomerenModel.Drank();

                Drank.setPrijs(Prijs);
                Drank.setNaam(Naam);
                Drank.setVoorraad(voorraad);
                Drank.setVerkocht(aantalverkocht);
                Drank.setId(drankid);

                drank_lijst.Add(Drank);
            }
            return drank_lijst;
        }

        
        public static int DB_GetStudentId(string naam)
        {
            SqlConnection connection = openConnectieDB();
            string query = "SELECT StudentId FROM A5_Student WHERE Naam = @Naam";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@Naam", System.Data.SqlDbType.NVarChar).Value = naam;
            command.Prepare();
            return (int)command.ExecuteScalar();
        }


        public void DB_VerkoopDrank(int studentId, string drank)
        {
            SqlConnection connection = openConnectieDB();

            string query = "INSERT INTO A5_Verkopen [Student], [Datum], [Drank], [Aantal] VALUES(@StudentId, @Datum, @Drank, Aantal = @Aantal)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@StudentId", System.Data.SqlDbType.Int).Value = studentId;
            command.Parameters.Add("Datum", System.Data.SqlDbType.DateTime).Value = System.Data.SqlDbType.DateTime;
            command.Parameters.Add("Drank", System.Data.SqlDbType.NVarChar).Value = drank;
            command.Prepare();
            command.ExecuteNonQuery();


            sluitConnectieDB(connection);
        }

        public static List<SomerenModel.Drankvoorraad> DB_GetDrankvoorraad()
        {
            SqlConnection connection = openConnectieDB();
            List<SomerenModel.Drankvoorraad> dranken_lijst = new List<SomerenModel.Drankvoorraad>();

            StringBuilder sb = new StringBuilder();

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

        public static List<SomerenModel.activiteitenlijst> DB_Getactiviteitenlijst()
        {
            SqlConnection connection = openConnectieDB();
            List<SomerenModel.activiteitenlijst> activiteiten_lijst = new List<SomerenModel.activiteitenlijst>();

            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT * FROM dbo.A5_Activiteit;");

            String sql = sb.ToString();

            SqlCommand command = new SqlCommand(sql, connection);
            command.Prepare();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int ActiviteitID = reader.GetInt32(0);
                string Omschrijving = reader.GetString(1);
                int aantalStudenten = reader.GetInt32(2);
                int aantalBegeleiders = reader.GetInt32(3);

                SomerenModel.activiteitenlijst activiteitenlijst = new SomerenModel.activiteitenlijst();
                activiteitenlijst.setId(ActiviteitID);
                activiteitenlijst.setOmschrijving(Omschrijving);
                activiteitenlijst.setaantalStudenten(aantalStudenten);
                activiteitenlijst.setaantalBegeleiders(aantalBegeleiders);
                activiteiten_lijst.Add(activiteitenlijst);
            }

            return activiteiten_lijst;
        }

        public void DB_AddActiviteit(int ActiviteitID, string Omschrijving)
        {
            SqlConnection connection = openConnectieDB();

            string query = "INSERT INTO A5_Activiteit ([ActiviteitID], [Omschrijving], [aantalStudenten], [aantalBegeleiders]) VALUES(@ActiviteitID, @Omschrijving, aantalStudenten = @aantalStudenten, aantalStudenten = @aantalBegeleiders)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@ActiviteitID", System.Data.SqlDbType.Int).Value = ActiviteitID;
            command.Parameters.Add("Omschrijving", System.Data.SqlDbType.Text).Value = Omschrijving;
            command.Prepare();
            command.ExecuteNonQuery();


            sluitConnectieDB(connection);
        }

        public void DB_ChangeActiviteit(int ActiviteitID, string Omschrijving)
        {
            SqlConnection connection = openConnectieDB();

            string query = "UPDATE A5_Activiteit (ActiviteitID = @ActiviteitID, Omschrijving = @Omschrijving, aantalStudenten = @aantalStudenten, aantalBegeleiders = @aantalBegeleiders)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@ActiviteitID", System.Data.SqlDbType.Int).Value = ActiviteitID;
            command.Parameters.Add("Omschrijving", System.Data.SqlDbType.Text).Value = Omschrijving;
            command.Prepare();
            command.ExecuteNonQuery();


            sluitConnectieDB(connection);
        }

        public static int DB_GetActiviteitID(string Omschrijving)
        {
            SqlConnection connection = openConnectieDB();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT [ActiviteitID] FROM [A5_Activiteit] WHERE [Omschrijving] = @Omschrijving");

            String sqlCommand = sb.ToString();
            SqlCommand command = new SqlCommand(sqlCommand, connection);
            command.Parameters.Add("@Omschrijving", System.Data.SqlDbType.Text).Value = Omschrijving;
            command.Prepare();

            int ActiviteitID = (int)command.ExecuteScalar();
            return ActiviteitID;

        }

        public static void DB_DeleteActiviteit(string Omschrijving)
        {
            int ActiviteitID = DB_GetActiviteitID(Omschrijving);
            SqlConnection connection = openConnectieDB();

            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM A5_Activiteit WHERE ActiviteitID = @ActiviteitID");
            String sqlCommand = sb.ToString();
            SqlCommand command = new SqlCommand(sqlCommand, connection);
            command.Parameters.Add("@ActiviteitID", System.Data.SqlDbType.Int).Value = ActiviteitID;
            command.Prepare();
            command.ExecuteNonQuery();
            sb.Clear();
            command.Dispose();
        }


        // public void 
    }
}
