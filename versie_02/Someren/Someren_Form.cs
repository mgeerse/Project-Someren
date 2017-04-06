using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Someren
{
    public partial class Someren_Form : Form
    {

        private static Someren_Form instance;

        public Someren_Form() { InitializeComponent(); }

        public static Someren_Form Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Someren_Form();
                }
                return instance;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            showDashboard();
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
        }

        private void showDashboard()
        {
            panel1.Controls.Clear();

            groupBox1.Text = "TODO LIJST";
            Label l = new Label();
            l.Height = 500;
            l.Text = "-bierfust controleren";
            l.Text += "\r\n-kamerindeling maken";
            panel1.Controls.Add(l);
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            // toon hier een message "Weet je zeker dat je wilt afsluiten?"
            // Message msg = new Message();
            if ((MessageBox.Show("Weet je zeker dat je SomerenAdministratie wilt afsluiten?", "SomerenAdministratie Afsluiten?",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
            {
                Application.Exit();
            }

        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            SomerenUI.showStudents();
        }

        private void overSomerenAppToolStripMenuItem_Click(object sender, EventArgs e)
        {


            panel1.Controls.Clear();

            groupBox1.Text = "TODO LIJST";
            Label l = new Label();
            l.Height = 500;
            l.Text = "Deze applicatie is ontwikkeld voor 1.3 Project Databases, opleiding Informatica, Hogeschool Inholland Haarlem";

            panel1.Controls.Add(l);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // er gebeurt niks als je op de menustrip drukt
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showDashboard();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            this.groupBox1.Text = "Studenten";
            this.panel1.Controls.Add(SomerenUI.showStudents());

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Focus();
            this.Enabled = true;
            this.Visible = true;
        }

        private void notifyIcon1_Click(object sender, MouseEventArgs e)
        {
            this.Focus();
            this.Enabled = true;
            this.Visible = true;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toonDocentenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            this.groupBox1.Text = "Docenten";
            this.panel1.Controls.Add(SomerenUI.showDocent());
        }

        private void kassaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //kassa
            this.panel1.Controls.Clear();
            this.groupBox1.Text = "Kassa";
            this.panel1.Controls.Add(SomerenUI.kassaShowDrank());
            this.panel1.Controls.Add(SomerenUI.kassaShowStudenten());
            this.panel1.Controls.Add(SomerenUI.kassaShowAfrekenen());
            this.panel1.Controls.Add(SomerenUI.kassaShowAantal());
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {

        }

        private void drankvoorraadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void omzetrapportageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            this.groupBox1.Text = "Omzetrapportage";
            this.panel1.Controls.Add(SomerenUI.omzetBeginKalender());
            this.panel1.Controls.Add(SomerenUI.omzetEindKalender());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("geklikt!");
            //Control[] c = panel1.Controls.Find("Studenten", true);
            //try
            //{
            //    ListView naam = (ListView)c[0];
            //    ListView drank = (ListView)c[1];

            //    foreach (var item in naam)
            //    {
            //        string[] xfx = item;
            //    }

            //    }
            //    catch (Exception e)
            //    {
            //        MessageBox.Show("Je mag maar 1 ding selecteren!: "+ e);
            //    }




            //MessageBox.Show(naam.SelectedItems.ToString());
            // c.



            List<string> dingen = new List<string>();

            foreach (ListView c in panel1.Controls)
            {
                ListView.CheckedListViewItemCollection vc = c.CheckedItems;

                string[] strValues = new string[c.CheckedItems.Count];

                for (int i = 0; i < vc.Count; i++)
                {
                    strValues[i] = c.Items[vc[i].Index].SubItems[0].Text;
                    dingen.Add(strValues[i].ToString());
                }
            }
            MessageBox.Show(dingen.Count.ToString());
            foreach (var item in dingen)
            {

            }
        }

        private void drankvoorraadToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            this.groupBox1.Text = "Bardienst";
            this.panel1.Controls.Add(SomerenUI.showDrankvoorraad());
        }

        public void begeleidersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            this.groupBox1.Text = "Begeleiders";
            List<SomerenModel.Begeleider> Begeleiders = SomerenDB.DB_GetBegeleiders();
            ListBox Begeleider = new ListBox();
            ListBox Docent = new ListBox();
            Button toevoegKnop = new Button();
            Button verwijderKnop = new Button();
            Label begeleiderLabel = new Label();
            Label docentLabel = new Label();

            begeleiderLabel.Text = "Begleiders:";
            docentLabel.Text = "Docenten:";

            begeleiderLabel.Left = 75;
            docentLabel.Left = 375;

            toevoegKnop.Left = 210;
            toevoegKnop.Top = 100;
            toevoegKnop.Text = "<------";
            toevoegKnop.Name = "toevoegKnop";
            toevoegKnop.Click += new EventHandler(toevoegKnopEvent);
            toevoegKnop.Click += new EventHandler(begeleidersToolStripMenuItem_Click);
            verwijderKnop.Left = 210;
            verwijderKnop.Top = 150;
            verwijderKnop.Text = "------>";
            verwijderKnop.Name = "verwijderKnop";
            verwijderKnop.Click += new EventHandler(verwijderKnopEvent);
            verwijderKnop.Click += new EventHandler(begeleidersToolStripMenuItem_Click);
            Begeleider.Width = 200;
            Begeleider.Height = 350;
            Begeleider.Top = 20;
            Begeleider.Name = "begeleiderList";
            Docent.Left = 300;
            Docent.Width = 200;
            Docent.Top = 20;
            Docent.Height = 350;
            Docent.Name = "docentList";
            foreach (var item in Begeleiders)
            {
                Begeleider.Items.Add(item.getNaam());
            }

            List<SomerenModel.Docent> Docenten = SomerenDB.DB_getDocentNotBegeleider();

            foreach (var item in Docenten)
            {
                Docent.Items.Add(item.getNaam());
            }

            this.panel1.Controls.Add(Begeleider);
            this.panel1.Controls.Add(Docent);
            this.panel1.Controls.Add(toevoegKnop);
            this.panel1.Controls.Add(verwijderKnop);
            this.panel1.Controls.Add(docentLabel);
            this.panel1.Controls.Add(begeleiderLabel);
        }

        public void verwijderKnopEvent(object sender, EventArgs e)
        {
            //BegeleiderNaarDocent
            Control[] d = Controls.Find("begeleiderList", true);
            string begeleiderGeselecteerd = "";
            foreach (ListBox item in d)
            {
                begeleiderGeselecteerd = item.SelectedItem.ToString();
            }

            SomerenDB.DB_BegeleiderNaarDocent(begeleiderGeselecteerd);

            this.panel1.Update();
        }
        public void toevoegKnopEvent(object sender, EventArgs e)
        {
            //DocentNaarBegeleider
            Control[] c = Controls.Find("docentList", true);
            string docentGeselecteerd = "";
            foreach (ListBox item in c)
            {
                docentGeselecteerd = item.SelectedItem.ToString();
            }

            SomerenDB.DB_DocentNaarBegeleider(docentGeselecteerd);
            this.panel1.Update();
        }

        private void roosterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Gemaakt door Maarten Geerse
            panel1.Controls.Clear();
            List<SomerenModel.Rooster> Roosters = SomerenDB.DB_GetRooster();
            List<SomerenModel.Activiteit> Activiteiten = SomerenDB.DB_GetActiviteiten();
            List<SomerenModel.Docent> Docenten = SomerenDB.DB_GetDocent();
            ListView listview = new ListView();

            listview.Width = 575;
            //listview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listview.Height = 375;
            listview.View = View.Details;
            listview.GridLines = true;
            listview.FullRowSelect = true;
            listview.MultiSelect = false;

            listview.Columns.Add("Datum");
            listview.Columns.Add("Activiteit"); //Geef hier de omschrijving! Komt vanuit A5_Activiteit.Omschrijving
            listview.Columns.Add("Begintijd");
            listview.Columns.Add("Eindtijd");
            listview.Columns.Add("Begeleiders"); //Koppel hier begeleiderId aan DocentId -> Geeft naam

            for (int g = 0; g < Activiteiten.Count; g++)
            {
                for (int i = 0, l = 0, k = 0; i < Roosters.Count && l < Activiteiten.Count && k < Docenten.Count; i++, l++, k++)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = Roosters[i].getDatum();
                    lvi.SubItems.Add(Activiteiten[i].getOmschrijving());
                    lvi.SubItems.Add(Roosters[i].getStart().ToString());
                    lvi.SubItems.Add(Roosters[i].getEind().ToString());
                    lvi.SubItems.Add(SomerenDB.GetDocentFromDocentId(Docenten[k].getId()));
                    listview.Items.Add(lvi);
                }
            }

            panel1.Controls.Add(listview);
        }
        //MessageBox.Show("einde");
    }
}
