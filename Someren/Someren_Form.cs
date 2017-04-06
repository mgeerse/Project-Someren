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
        private void button3_Click(object sender, EventArgs e)
        {
            List<string> activiteiten = new List<string>();

            foreach (ListView c in panel1.Controls)
            {
                ListView.CheckedListViewItemCollection vc = c.CheckedItems;

                string[] strValues = new string[c.CheckedItems.Count];

                for (int i = 0; i < vc.Count; i++)
                {
                    strValues[i] = c.Items[vc[i].Index].SubItems[0].Text;
                    activiteiten.Add(strValues[i].ToString());
                }
            }
        }

        private void drankvoorraadToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            this.groupBox1.Text = "Bardienst";
            this.panel1.Controls.Add(SomerenUI.showDrankvoorraad());
        }

        private void activiteitenlijstToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            this.groupBox1.Text = "Activiteitenlijst";
            this.panel1.Controls.Add(SomerenUI.showactiviteitenlijst());
            this.panel1.Controls.Add(SomerenUI.activiteittoevoegen());
            this.panel1.Controls.Add(SomerenUI.activiteitwijzigen());
            this.panel1.Controls.Add(SomerenUI.activiteittonen());

            Button verwijderKnop = new Button();
            verwijderKnop.Left = 405;
            verwijderKnop.Top = 90;
            verwijderKnop.Text = "Verwijderen";
            verwijderKnop.Name = "verwijderKnop";
            verwijderKnop.Click += new EventHandler(verwijderKnopEvent);
            verwijderKnop.Click += new EventHandler(activiteitenlijstToolStripMenuItem_Click);

            this.panel1.Controls.Add(verwijderKnop);

        }

        public void verwijderKnopEvent(object sender, EventArgs e)
        {
            Control[] d = Controls.Find("Activiteitenlijst", true);
            ListView[] x = (ListView[])d;

            string activiteitGeselecteerd = "";
            foreach (ListView item in x)
            {
                for (int i = item.SelectedItems.Count - 1; i >= 0; i--)
                {
                    if (item.Items[i].Selected)
                    {
                        item.Items[i].Remove();
                        activiteitGeselecteerd = item.SelectedItems[i].ToString();
                    }
                }
            }
            SomerenDB.DB_DeleteActiviteit(activiteitGeselecteerd);

            this.panel1.Update();
        }

        //MessageBox.Show("einde");
    }
}
