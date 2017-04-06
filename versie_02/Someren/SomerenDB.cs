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
            connection.Close();
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
            connection.Close();
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
            connection.Close();
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

        public static string GetDocentFromDocentId(int DocentId)
        {
            string DocentNaam = " ";
            SqlConnection connection = openConnectieDB();
            SqlCommand command = new SqlCommand("SELECT [Naam] FROM A5_Docent WHERE DocentId = @DocentId", connection);
            command.Parameters.Add("@DocentId", System.Data.SqlDbType.Int).Value = DocentId;
            command.Prepare();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                DocentNaam = reader.GetString(0);
            }
            connection.Close();
            return DocentNaam;
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
            connection.Close();
            return dranken_lijst;
        }
        public static List<SomerenModel.Begeleider> DB_GetBegeleiders()
        {
            //Gemaakt door Maarten Geerse
            SqlConnection connection = openConnectieDB();
            List<SomerenModel.Begeleider> begeleider_lijst = new List<SomerenModel.Begeleider>();

            StringBuilder sb = new StringBuilder();
            // schrijf hier een query om te zorgen dat er een lijst met studenten wordt getoond
            sb.Append("SELECT [Naam] FROM [dbo].[A5_Docent]");
            sb.Append("INNER JOIN A5_Begeleider ON A5_Docent.DocentId = A5_Begeleider.DocentId");
            //sb.Append("ORDERBY [Naam]"); Loopt vast op een ORDER BY QUERY????

            String sqlCommand = sb.ToString();

            SqlCommand command = new SqlCommand(sqlCommand, connection);
            command.Prepare();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                SomerenModel.Begeleider begeleider = new SomerenModel.Begeleider();
                begeleider.setNaam(reader.GetString(0));
                begeleider_lijst.Add(begeleider);
            }
            connection.Close();
            return begeleider_lijst;
        }

        public static List<SomerenModel.Docent> DB_getDocentNotBegeleider()
        {
            //Gemaakt door Maarten Geerse
            SqlConnection connection = openConnectieDB();
            List<SomerenModel.Docent> docent_Lijst = new List<SomerenModel.Docent>();

            StringBuilder sb = new StringBuilder();
            // schrijf hier een query om te zorgen dat er een lijst met studenten wordt getoond
            sb.Append("SELECT [A5_Docent].[Naam]");
            sb.Append("FROM [A5_Docent]");
            sb.Append("LEFT JOIN [A5_Begeleider] ON ([A5_Docent].[DocentId] = [A5_Begeleider].[DocentId])");
            sb.Append("WHERE [A5_Begeleider].[DocentId] IS NULL");

            String sqlCommand = sb.ToString();

            SqlCommand command = new SqlCommand(sqlCommand, connection);
            command.Prepare();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                SomerenModel.Docent Docent = new SomerenModel.Docent();
                Docent.setNaam(reader.GetString(0));
                docent_Lijst.Add(Docent);
            }
            connection.Close();
            return docent_Lijst;
        }

        public static void DB_BegeleiderNaarDocent(string naamBegeleider)
        {
            //Gemaakt door Maarten Geerse
            int DocentId = DB_GetDocentId(naamBegeleider);
            SqlConnection connection = openConnectieDB();

            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM A5_Begeleider WHERE DocentId = @DocentId");
            String sqlCommand = sb.ToString();
            SqlCommand command = new SqlCommand(sqlCommand, connection);
            command.Parameters.Add("@DocentId", System.Data.SqlDbType.Int).Value = DocentId;
            command.Prepare();
            command.ExecuteNonQuery();
            sb.Clear();
            command.Dispose();

            StringBuilder stringTwee = new StringBuilder();
            stringTwee.Append("INSERT INTO A5_Docent (Naam) VALUES (@Naam)");
            String sqlCommandTwee = stringTwee.ToString();
            SqlCommand commandTwee = new SqlCommand(sqlCommandTwee, connection);
            commandTwee.Parameters.Add("@Naam", System.Data.SqlDbType.NVarChar, 50).Value = naamBegeleider;
            //command.Parameters.Add("@DocentId", System.Data.SqlDbType.Int).Value = DocentId;
            command.Prepare();
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
        }

        public static void DB_DocentNaarBegeleider(string docentNaam)
        {
            //Gemaakt door Maarten Geerse
            int DocentId = DB_GetDocentId(docentNaam);
            SqlConnection connection = openConnectieDB();
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO dbo.A5_Begeleider (DocentId) VALUES (@DocentId)");
            String sqlcommand = sb.ToString();

            SqlCommand command = new SqlCommand(sqlcommand, connection);
            command.Prepare();
            command.Parameters.Add("@DocentId", System.Data.SqlDbType.Int).Value = DocentId;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static int DB_GetDocentId(string DocentNaam)
        {
            //Gemaakt door Maarten Geerse
            SqlConnection connection = openConnectieDB();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT [DocentId] FROM [A5_Docent] WHERE [Naam] = @Naam");

            String sqlCommand = sb.ToString();
            SqlCommand command = new SqlCommand(sqlCommand, connection);
            command.Parameters.Add("@Naam", System.Data.SqlDbType.NVarChar, 50).Value = DocentNaam;
            command.Prepare();
            int DocentId = (int)command.ExecuteScalar();
            connection.Close();
            return DocentId;
        }

        public static List<SomerenModel.Activiteit> DB_GetActiviteiten()
        {
            //Gemaakt door Maarten Geerse
            List<SomerenModel.Activiteit> Activiteiten = new List<SomerenModel.Activiteit>();

            SqlConnection connection = openConnectieDB();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT [ActiviteitID], [Omschrijving], [aantalStudenten], [aantalBegeleiders] FROM [A5_Activiteit]");

            String sqlCommand = sb.ToString();
            SqlCommand command = new SqlCommand(sqlCommand, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                SomerenModel.Activiteit Activiteit = new SomerenModel.Activiteit();
                Activiteit.setId(reader.GetInt32(0));
                Activiteit.setOmschrijving(reader.GetString(1));
                Activiteit.setAantalStudenten(reader.GetInt32(2));
                Activiteit.setAantalBegeleiders(reader.GetInt32(3));

                Activiteiten.Add(Activiteit);
            }
            connection.Close();
            return Activiteiten;
        }

        public static List<SomerenModel.Rooster> DB_GetRooster()
        {
            //Gemaakt door Maarten Geerse
            List<SomerenModel.Rooster> Rooster = new List<SomerenModel.Rooster>();

            SqlConnection connection = openConnectieDB();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT [Activiteit], [Begeleider], [Datum], [tijdStart], [tijdEind] FROM [A5_Rooster]");
            String sqlCommand = sb.ToString();
            SqlCommand command = new SqlCommand(sqlCommand, connection);
            command.Prepare();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                SomerenModel.Rooster RoosterItems = new SomerenModel.Rooster();
                RoosterItems.setId(reader.GetInt32(0));
                RoosterItems.setBegeleider(reader.GetInt32(1));
                RoosterItems.setDatum(reader.GetString(2));
                RoosterItems.setStartTijd(reader.GetInt32(3));
                RoosterItems.setEindTijs(reader.GetInt32(4));
                Rooster.Add(RoosterItems);
            }
            connection.Close();
            return Rooster;
        }

        // public void 
    }
}
