﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tinke.Dialog
{
    public partial class MapOptions : Form
    {

        public MapOptions()
        {
            InitializeComponent();
        }
        public MapOptions(int width, int height)
        {
            InitializeComponent();
            ReadLanguage();

            numericWidth.Value = width;
            numericHeight.Value = height;
        }
        private void ReadLanguage()
        {
            System.Xml.Linq.XElement xml = Tools.Helper.ObtenerTraduccion("NSCR");

            this.Text = xml.Element("S00").Value;
            label1.Text = xml.Element("S01").Value;
            label2.Text = xml.Element("S02").Value;
            checkFillTile.Text = xml.Element("S03").Value;
            label3.Text = xml.Element("S04").Value;
            label4.Text = xml.Element("S05").Value;
            btnOk.Text = xml.Element("S06").Value;
            label5.Text = xml.Element("S07").Value;
            label6.Text = xml.Element("S08").Value;
        }

        public int ImagenWidth
        {
            get { return (int)numericWidth.Value; }
        }
        public int ImageHeight
        {
            get { return (int)numericHeight.Value; }
        }
        public bool FillTiles
        {
            get { return checkFillTile.Checked; }
        }
        public int StartFillTiles
        {
            get { return (int)numericStartTile.Value; }
        }
        public int FillTilesWith
        {
            get { return (int)numericFillTile.Value; }
        }

        private void checkFillTile_CheckedChanged(object sender, EventArgs e)
        {
            groupFill.Enabled = checkFillTile.Checked;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numericMaxSize_ValueChanged(object sender, EventArgs e)
        {
            numericStartTile.Value = (numericMaxHeight.Value * numericMaxWidth.Value) / 64;
        }
        private void numericStartTile_ValueChanged(object sender, EventArgs e)
        {
            numericMaxHeight.Value = (numericStartTile.Value * 64) / numericWidth.Value;
        }
    }
}