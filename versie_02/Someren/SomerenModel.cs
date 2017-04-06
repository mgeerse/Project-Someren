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

        public class Drank
        {
            int Id;
            string naam;
            decimal prijs;
            int voorraad;
            int verkocht;

            public void setId(int drankId)
            {
                Id = drankId;
            }
            public void setNaam(string drankNaam)
            {
                naam = drankNaam;
            }
            public void setPrijs(decimal drankPrijs)
            {
                prijs = drankPrijs;
            }
            public void setVoorraad(int drankVoorraad)
            {
                voorraad = drankVoorraad;
            }
            public void setVerkocht(int drankVerkocht)
            {
                verkocht = drankVerkocht;
            }
            public string getNaam()
            {
                return naam;
            }
            public int getVoorraad()
            {
                return voorraad;
            }
            public decimal getPrijs()
            {
                return prijs;
            }
            public int getId()
            {
                return Id;
            }
            public int getVerkocht()
            {
                return verkocht;
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
        public class BegeleiderList
        {
            List<SomerenModel.Docent> sl = new List<SomerenModel.Docent>();

            public void addList(SomerenModel.Docent s)
            {
                sl.Add(s);
            }

            public List<SomerenModel.Docent> getList()
            {
                return sl;
            }
        }
        public class Begeleider
        {
            int id;
            string naam;
            public void setId(int docentid)
            {
                id = docentid;
            }
            public void setNaam(string Naam)
            {
                naam = Naam;
            }
            public string getNaam()
            {
                return naam;
            }
            public int getId()
            {
                return id;
            }
        }

        public class Activiteit
        {
            int ActiviteitId;
            string Omschrijving;
            int aantalStudenten;
            int aantalBegeleiders;

            public void setId(int id)
            {
                ActiviteitId = id;
            }
            public void setOmschrijving(string omschrijving)
            {
                Omschrijving = omschrijving;
            }
            public void setAantalStudenten(int aantal)
            {
                aantalStudenten = aantal;
            }
            public void setAantalBegeleiders(int aantal)
            {
                aantalBegeleiders = aantal;
            }
            public int getId()
            {
                return ActiviteitId;
            }
            public string getOmschrijving()
            {
                return Omschrijving;
            }
            public int getAantalStudenten()
            {
                return aantalStudenten;
            }
            public int getAantalBegeleiders()
            {
                return aantalBegeleiders;
            }
        }

        public class Rooster
        {
            int Activiteit;
            int Begeleider;
            string Datum;
            int tijdStart;
            int tijdEind;

            public void setId(int id)
            {
                Activiteit = id;
            }
            public void setBegeleider(int begeleiderId)
            {
                Begeleider = begeleiderId;
            }
            public void setDatum(string datum)
            {
                Datum = datum;
            }
            public void setStartTijd(int start)
            {
                tijdStart = start;
            }
            public void setEindTijs(int eind)
            {
                tijdEind = eind;
            }
            public int getId()
            {
                return Activiteit;
            }
            public int getBegeleider()
            {
                return Begeleider;
            }
            public string getDatum()
            {
                return Datum;
            }
            public int getStart()
            {
                return tijdStart;
            }
            public int getEind()
            {
                return tijdEind;
            }
        }



        public class StudentList
        {
            List<SomerenModel.Student> sl = new List<SomerenModel.Student>();

            public void addList(SomerenModel.Student s)
            {
                sl.Add(s);
            }

            public List<SomerenModel.Student> getList()
            {
                return sl;
            }
        }

        public class RoosterList
        {
            List<SomerenModel.Rooster> al = new List<SomerenModel.Rooster>();

            public void addList(SomerenModel.Rooster s)
            {
                al.Add(s);
            }

            public List<SomerenModel.Rooster> getList()
            {
                return al;
            }
        }

        public class ActiviteitList
        {
            List<SomerenModel.Activiteit> al = new List<SomerenModel.Activiteit>();

            public void addList(SomerenModel.Activiteit s)
            {
                al.Add(s);
            }

            public List<SomerenModel.Activiteit> getList()
            {
                return al;
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
    }
}
