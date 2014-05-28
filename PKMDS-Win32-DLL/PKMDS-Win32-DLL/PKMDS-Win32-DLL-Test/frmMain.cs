using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PKMDS_CS;

namespace PKMDS_Win32_DLL_Test
{
    public partial class frmMain : Form
    {

        //public string dbfile = "C:\\Users\\Michael Bond\\Dropbox\\PKMDS Databases\\veekun-pokedex.sqlite";
        //public string savefile = "C:\\Users\\Michael Bond\\Dropbox\\Saves\\Mike B2 Sav.sav";

        public string dbfile = "C:\\Users\\michaelbond\\Downloads\\PKMDS Databases\\veekun-pokedex.sqlite";
        public string savefile = "C:\\Users\\michaelbond\\Downloads\\PKMDS Databases\\Mike B2 Sav.sav";

        public frmMain()
        {
            InitializeComponent();
        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            //lblTest.Text = GetPKMName_FromSav(savefile, 0, 0, dbfile); // GetPKMName((int)(numSpecies.Value), 9, dbfile);
            this.Text = PKMDS.GetTrainerName_FromSav(savefile);
            cbBox.Items.Clear();
            for (int box = 0; box < 24; box++)
            {
                //MessageBox.Show(PKMDS.GetBoxName(savefile, box));
                cbBox.Items.Add(PKMDS.GetBoxName(savefile, box));
            }
            if (cbBox.Items.Count > 0)
            {
                cbBox.SelectedIndex = 0;
            }
        }

        private void btnTest2_Click(object sender, EventArgs e)
        {
            if (cbBox.Items.Count > 0)
            {
                lblTest.Text = PKMDS.GetPKMName_FromSav(savefile, cbBox.SelectedIndex, (int)(numSlot.Value - 1));
                //lblTest.Text = PKMDS.GetMoveName(1, 9, dbfile);
                //lblTest.Text = GetTrainerName_FromSav(savefile);
                //GetPKMStat(savefile, cbBox.SelectedIndex, (int)(numSlot.Value - 1), Convert.ToInt16(stats.HP), dbfile).ToString()
                //+ '\n' + GetPKMStat(savefile, cbBox.SelectedIndex, (int)(numSlot.Value - 1), Convert.ToInt16(stats.Attack), dbfile).ToString()
                //+ '\n' + GetPKMStat(savefile, cbBox.SelectedIndex, (int)(numSlot.Value - 1), Convert.ToInt16(stats.Defense), dbfile).ToString()
                //+ '\n' + GetPKMStat(savefile, cbBox.SelectedIndex, (int)(numSlot.Value - 1), Convert.ToInt16(stats.SpAtk), dbfile).ToString()
                //+ '\n' + GetPKMStat(savefile, cbBox.SelectedIndex, (int)(numSlot.Value - 1), Convert.ToInt16(stats.SpDef), dbfile).ToString()
                //+ '\n' + GetPKMStat(savefile, cbBox.SelectedIndex, (int)(numSlot.Value - 1), Convert.ToInt16(stats.Speed), dbfile).ToString();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            PKMDS.OpenDB(dbfile);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            PKMDS.CloseDB();
        }
    }
}
