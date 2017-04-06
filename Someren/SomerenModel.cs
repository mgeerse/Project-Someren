using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Someren
{
    class SomerenModel
    {
        public class Student
        {
            int Id;
            string naam;

            public void setNaam(string naamStudent)
            {
                naam = naamStudent;
            }

            public void setId(int StudentId)
            {
                Id = StudentId;
            }

            public string getNaam()
            {
                return naam;
            }

            public int getId()
            {
                return Id;
            }
        }
        public class Docent
        {
            int Id;
            string naam;

            public void setNaam(string naamStudent)
            {
                naam = naamStudent;
            }

            public void setId(int StudentId)
            {
                Id = StudentId;
            }

            public string getNaam()
            {
                return naam;
            }

            public int getId()
            {
                return Id;
            }
        }

        public class Drankvoorraad
        {
            int Id;
            string naam;
            decimal prijs;
            int aantal_verkocht;
            int voorraad;

            public void setNaam(string naamDrank)
            {
                naam = naamDrank;
            }

            public void setId(int DrankId)
            {
                Id = DrankId;
            }

            public void setPrijs(decimal Prijs)
            {
                prijs = Prijs;
            }

            public void setAantal_Verkocht(int Aantal_Verkocht)
            {
                aantal_verkocht = Aantal_Verkocht;
            }

            public void setVoorraad(int Voorraad)
            {
                voorraad = Voorraad;
            }

            public string getNaam()
            {
                return naam;
            }

            public int getId()
            {
                return Id;
            }

            public decimal getPrijs()
            {
                return prijs;
            }

            public int getAantal_Verkocht()
            {
                return aantal_verkocht;
            }

            public int getVoorraad()
            {
                return voorraad;
            }

        }

        public class activiteitenlijst
        {
            int Id;
            string Omschrijving;
            int aantalStudenten;
            int aantalBegeleiders;

            public void setId(int ActiviteitID)
            {
                Id = ActiviteitID;
            }

            public void setOmschrijving(string dbOmschrijving)
            {
                Omschrijving = dbOmschrijving;
            }                   

            public void setaantalStudenten(int dbaantalStudenten)
            {
                aantalStudenten = dbaantalStudenten;
            }

            public void setaantalBegeleiders(int dbaantalBegeleiders)
            {
                aantalBegeleiders = dbaantalBegeleiders;
            }

            public int getId()
            {
                return Id;
            }

            public string getOmschrijving()
            {
                return Omschrijving;
            }

            public int getaantalStudenten()
            {
                return aantalStudenten;
            }

            public int getaantalBegeleiders()
            {
                return aantalBegeleiders;
            }
        }

        public class StudentList
        {
            List<SomerenModel.Student> sl = new List<SomerenModel.Student>();
            
            public void addList(SomerenModel.Student s) {
                sl.Add(s);
            }

            public List<SomerenModel.Student> getList()
            {
                return sl;
            }
        }
        public class DocentList
        {
            List<SomerenModel.Docent> dl = new List<SomerenModel.Docent>();

            public void addList(SomerenModel.Docent d)
            {
                dl.Add(d);
            }

            public List<SomerenModel.Docent> getList()
            {
                return dl;
            }
        }

        public class DrankList
        {
            List<SomerenModel.Drankvoorraad> dl = new List<SomerenModel.Drankvoorraad>();

            public void addList(SomerenModel.Drankvoorraad d)
            {
                dl.Add(d);
            }

            public List<SomerenModel.Drankvoorraad> getList()
            {
                return dl;
            }
        }

        public class activiteitenlijstList
        {
            List<SomerenModel.activiteitenlijst> dl = new List<SomerenModel.activiteitenlijst>();

            public void addList(SomerenModel.activiteitenlijst d)
            {
                dl.Add(d);
            }

            public List<SomerenModel.activiteitenlijst> getList()
            {
                return dl;
            }
        }

    }
}
