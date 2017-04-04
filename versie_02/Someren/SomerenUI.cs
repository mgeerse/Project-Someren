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

        public static Control showDrank()
        {
            List<SomerenModel.Drank> dl = SomerenDB.DB_GetDrank();
            ListViewItem li = new ListViewItem();
            ListView c = new ListView();

            c.CheckBoxes = true;
         
            c.Left = 125;
            c.Font = new System.Drawing.Font("Comic Sans MS", 10);
            
            foreach (var item in dl)
            {
                SomerenModel.Drank Dranken = new SomerenModel.Drank();

                var items = c.SelectedItems;
                
                Dranken.setNaam(item.getNaam());
                //Dranken.setId(item.getId());
                //Dranken.setPrijs(item.getPrijs());
                //Dranken.setVerkocht(item.getVerkocht());
                //Dranken.setVoorraad(item.getVoorraad());

                li.SubItems.Add(Dranken.getId().ToString());
                li.SubItems.Add(Dranken.getNaam());
                li.SubItems.Add(Dranken.getPrijs().ToString());
                li.SubItems.Add(Dranken.getVerkocht().ToString());
                li.SubItems.Add(Dranken.getVoorraad().ToString());
                
                c.Items.Add(Dranken.getNaam());
                //c.Items.Add(Dranken.getId().ToString());
                //c.Items.Add(Dranken.getPrijs().ToString());
                //c.Items.Add(Dranken.getVerkocht().ToString());
                //c.Items.Add(Dranken.getVoorraad().ToString());
                
                //c.Items.Add(li);
            }
            int aantal = dl.Count();

            var items = c.SelectedItems;

            c.Height = 370;
            
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
 