using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Someren.Properties;
using System.Drawing;

namespace Someren
{
    public static class SomerenUI
    {
        public static Control showStudents()
        {
            List<SomerenModel.Student> sl = SomerenDB.DB_gettudents();
            ListViewItem li = new ListViewItem();
            ListView c = new ListView();

            foreach (var item in sl)
            {
                SomerenModel.Student Student = new SomerenModel.Student();
                Student.setNaam(item.getNaam());

                li.SubItems.Add(Student.getNaam());
                li.SubItems.Add(Student.getId().ToString());

                c.Items.Add(Student.getNaam());
                c.Items.Add(li);
            }


            int aantal = sl.Count();

            c.Height = 1000;

            return c;
        }

        public static Control showDocent()
        {
            List<SomerenModel.Docent> dl = SomerenDB.DB_GetDocent();
            ListViewItem li = new ListViewItem();
            ListView c = new ListView();

            foreach (var item in dl)
            {
                SomerenModel.Student Docent = new SomerenModel.Student();
                Docent.setNaam(item.getNaam());

                li.SubItems.Add(Docent.getNaam());
                li.SubItems.Add(Docent.getId().ToString());

                c.Items.Add(Docent.getNaam());
                c.Items.Add(li);
            }
            int aantal = dl.Count();

            c.Height = 1000;

            return c;
        }

        public static Control showDrankvoorraad()
        {
            List<SomerenModel.Drankvoorraad> dl = SomerenDB.DB_GetDrankvoorraad();

            ListViewItem lv = new ListViewItem();
            ListView listView1 = new ListView();

            listView1.Items.Add("Naam");
            listView1.Items.Add("ID");
            listView1.Items.Add("Prijs");
            listView1.Items.Add("Verkocht");
            listView1.Items.Add("Voorraad");
            foreach (var item in dl)
            {
                SomerenModel.Drankvoorraad Drankvoorraad = new SomerenModel.Drankvoorraad();
                Drankvoorraad.setId(item.getId());
                Drankvoorraad.setNaam(item.getNaam());
                Drankvoorraad.setPrijs(item.getPrijs());
                Drankvoorraad.setAantal_Verkocht(item.getAantal_Verkocht());
                Drankvoorraad.setVoorraad(item.getVoorraad());

                listView1.Items.Add(Drankvoorraad.getNaam());
                listView1.Items.Add(Drankvoorraad.getId().ToString());
                listView1.Items.Add(Drankvoorraad.getPrijs().ToString());
                listView1.Items.Add(Drankvoorraad.getAantal_Verkocht().ToString());
                listView1.Items.Add(Drankvoorraad.getVoorraad().ToString());

                if (item.getVoorraad() < 10)
                {
                    foreach (ListViewItem li in listView1.Items)
                    {                        
                            li.ForeColor = Color.Red;
                    }
                }
            }

            int aantal = dl.Count();

            listView1.Height = 1000;
            listView1.Width = 250;

            return listView1;
        }

        public static Control addUILabel(string text)
        {
            Label l = new Label();
            l.Text = text;
            return l;
        }
    }
}
