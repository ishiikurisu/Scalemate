﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scalemate.View
{
    public partial class FormInstructions : Form
    {
        public bool Ended = false;

        public FormInstructions()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        public void SetInstructions(string instructions)
        {
            this.label1.Text = instructions;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Ended = true;
        }
    }
}