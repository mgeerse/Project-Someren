using System;
using System.Collections.Generic;
using System.Linq;
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


        public static Control addUILabel(string text)
        {
            Label l = new Label();
            l.Text = text;
            return l;
        }
    }
}
