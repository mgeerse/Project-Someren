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
            ListBox studenten = new ListBox();

            studenten.Width = 200;
            studenten.Height = 375;
            foreach (var item in sl)
            {
                studenten.Items.Add(item.getNaam());
            }
            return studenten;
        }

        public static Control showDocent()
        {
            List<SomerenModel.Docent> dl = SomerenDB.DB_GetDocent();
            ListBox docenten = new ListBox();

            docenten.Width = 200;
            docenten.Height = 375;
            foreach (var item in dl)
            {
                docenten.Items.Add(item.getNaam());
            }
            return docenten;
        }

        public static Control kassaShowDrank()
        {
            List<SomerenModel.Drank> dl = SomerenDB.DB_GetDrank();
            ListView Dranken = new ListView();
            Dranken.Left = 200;
            Dranken.Width = 200;
            Dranken.Height = 375;
            Dranken.CheckBoxes = true;
            int index = 0;

            foreach (var item in dl)
            {
                Dranken.Items.Insert(index, item.getNaam());
                index++;
            }
            return Dranken;
        }
        public static Control kassaShowStudenten()
        {
            List<SomerenModel.Student> sl = SomerenDB.DB_gettudents();
            ListView Studenten = new ListView();
            Studenten.Name = "Studenten";
            Studenten.Width = 200;
            Studenten.Height = 375;
            Studenten.CheckBoxes = true;
            foreach (var item in sl)
            {
                Studenten.Items.Add(item.getNaam());
            }

            return Studenten;
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
            ////MessageBox.Show("afgerekend!");
            //Control[] c = Someren_Form.Instance.panel1.Controls.Find("StudentenLB", true);

            ////ListBox[] lb = (ListBox[])c;

            

            ////afrekeken
            //foreach (ListBox item in c)
            //{
            //    MessageBox.Show(item.Name);
            //}

            List<string> Geselecteerd = new List<string>();
            string[] strValues;
            foreach (ListView c in Someren_Form.Instance.panel1.Controls.Find("Studenten", true))
            {
                ListView.CheckedListViewItemCollection vc = c.CheckedItems;
                strValues = new string[c.CheckedItems.Count];

                for (int i = 0; i < vc.Count; i++)
                {
                    strValues[i] = c.Items[vc[i].Index].SubItems[0].Text;
                }
            }


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

        public static Control omzetBeginKalender()
        {
            MonthCalendar kalender = new MonthCalendar();

            return kalender;
        }

        public static Control omzetEindKalender()
        {
            MonthCalendar kalender = new MonthCalendar();
            kalender.Left = 200;
            return kalender;
        }

    }
}
