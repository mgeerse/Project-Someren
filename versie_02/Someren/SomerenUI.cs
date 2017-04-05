using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Someren.Properties;

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

            }
            c.Items.Add(li);


            int aantal = sl.Count();

            c.Height = 370;

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

            c.Height = 370;

            return c;
        }

        public static Control kassaShowDrank()
        {
            List<SomerenModel.Drank> dl = SomerenDB.DB_GetDrank();
            ListBox Clb = new ListBox();
            Clb.Left = 200;
            Clb.Width = 200;
            Clb.Height = 375;

            int index = 0;

            foreach (var item in dl)
            {
                Clb.Items.Insert(index, item.getNaam());
                index++;
            }
            return Clb;
        }
        public static Control kassaShowStudenten()
        {
            List<SomerenModel.Student> sl = SomerenDB.DB_gettudents();
            ListBox studenten = new ListBox();

            studenten.Width = 200;
            studenten.Height = 375;
            foreach (var item in sl)
            {
                studenten.Items.Add(item.getNaam());

            }

            return studenten;
        }

        public static Control kassaShowAantal()
        {
            NumericUpDown aantalDrankjes = new NumericUpDown();

            aantalDrankjes.DecimalPlaces = 0;
            aantalDrankjes.Minimum = 0;
            aantalDrankjes.Maximum = 100;
            aantalDrankjes.Left = 405;

            return aantalDrankjes;
        }

        public static Control kassaShowAfrekenen()
        {
            Button button = new Button();
            button.Click += new EventHandler(afrekenenHandler);
            button.Text = "Afrekenen";
            button.Left = 405;

            return button;
        }

        public static void studentChecked(object sender, EventArgs e)
        {
        }

        public static void afrekenenHandler(object sender, EventArgs e)
        {
            //afrekeken

            
        }

        public static Control kassaShowLabel()
        {
            Label label = new Label();

            label.Text = "Aantal drankjes:";
            label.Left = 405;

            return label;
        }

        public static Control addUILabel(string text)
        {
            Label l = new Label();
            l.Text = text;
            return l;
        }
    }
}
