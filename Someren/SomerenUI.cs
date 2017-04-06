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
            ListView listView1 = new ListView();

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.MultiSelect = false;

            listView1.Columns.Add("Naam");
            listView1.Columns.Add("ID");
            listView1.Columns.Add("Prijs");
            listView1.Columns.Add("Verkocht");
            listView1.Columns.Add("Voorraad");

            foreach (var item in dl)
            {
                SomerenModel.Drankvoorraad Drankvoorraad = new SomerenModel.Drankvoorraad();
                ListViewItem lvi = new ListViewItem();

                lvi.Text = item.getNaam();
                lvi.SubItems.Add(item.getId().ToString());
                lvi.SubItems.Add(item.getPrijs().ToString());
                lvi.SubItems.Add(item.getAantal_Verkocht().ToString());
                lvi.SubItems.Add(item.getVoorraad().ToString());
                listView1.Items.Add(lvi);

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
            listView1.Width = 500;

            return listView1;
        }

        public static Control showactiviteitenlijst()
        {
            List<SomerenModel.activiteitenlijst> dl = SomerenDB.DB_Getactiviteitenlijst();
            ListView listView1 = new ListView();
            
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.MultiSelect = false;

            listView1.Columns.Add("ID", 70);
            listView1.Columns.Add("Omschrijving", 70);
            listView1.Columns.Add("Studenten", 70);
            listView1.Columns.Add("Begeleiders", 70);

            foreach (var item in dl)
            {
                SomerenModel.activiteitenlijst activiteitenlijst = new SomerenModel.activiteitenlijst();
                ListViewItem lvi = new ListViewItem();
                lvi.Text = item.getId().ToString();
                lvi.SubItems.Add(item.getOmschrijving());
                lvi.SubItems.Add(item.getaantalStudenten().ToString());
                lvi.SubItems.Add(item.getaantalBegeleiders().ToString());
                listView1.Items.Add(lvi);
            }

            int aantal = dl.Count();

            listView1.Height = 1000;
            listView1.Width = 500;

            return listView1;
        }

        public static Control activiteittoevoegen()
        {
            Button button = new Button();

            button.DialogResult = DialogResult.OK;=
            button.Location = new Point(20, 30);
            button.Text = " enter text";
            button.Click += new EventHandler(ButtonClickOneEvent);
            Controls.Add(button);
            return ;
        }

        public static Control addUILabel(string text)
        {
            Label l = new Label();
            l.Text = text;
            return l;
        }
    }
}
