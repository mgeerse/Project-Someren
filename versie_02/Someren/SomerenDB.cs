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
        
        public static List<SomerenModel.Drank> DB_UpdateDrank(int studentId)
        {
            SqlConnection connection = openConnectieDB();
            connection.Open();
            
            string zoekenquery = "SELECT Aantal FROM A5_Verkopen WHERE @StudentId = StudentId AND @DrankId = Drank";
            string insertquery = "INSERT INTO A5_Verkopen (Student, Datum, Drank, Aantal) VALUES (@StudentId, @Datum, @Drank, @Aantal)";
            string updatequery = "UPDATE A5_Verkopen SET Aantal = @Aantal WHERE @Drank = Drank AND StudentId = @StudentId";

            StringBuilder zq = new StringBuilder();
            zq.Append(zoekenquery);

            StringBuilder iq = new StringBuilder();
            iq.Append(insertquery);
            StringBuilder uq = new StringBuilder();
            uq.Append(updatequery);

            String zksql = zq.ToString();
            String insql = iq.ToString();
            String upsql = uq.ToString();

            SqlCommand zoekcommand = new SqlCommand(zksql, connection);
            SqlCommand insertcommand = new SqlCommand(insql, connection);
            SqlCommand updatecommand = new SqlCommand(upsql, connection);
            zoekcommand.Prepare();
            
            updatecommand.Prepare();

            int aantal = (int)zoekcommand.ExecuteScalar();

            string drankidquery = ;
            SqlCommand drankid = new SqlCommand("SELECT DrankId FROM A5_Voorraad WHERE Naam = @Naam", connection);
            drankid.Parameters.Add("@Naam")
            int drankid = drankid.ExecuteScalar();
            if (aantal == 0 || aantal == null)
            {
                aantal = 1;
                insertcommand.Parameters.Add("@Aantal", System.Data.SqlDbType.Int).Value = aantal;
                insertcommand.Parameters.Add("@DrankId", System.Data.SqlDbType.Int). Value = ;
                insertcommand.Prepare();
                insertcommand.ExecuteNonQuery();
            }
            else if (aantal != 0 && aantal != null)
            {
                aantal++;
                updatecommand.Parameters.Add("@Aantal", System.Data.SqlDbType.Int).Value = aantal;

                updatecommand.Prepare();
                updatecommand.ExecuteNonQuery();
            }

            return;

        }

        // public void 
    }
}
