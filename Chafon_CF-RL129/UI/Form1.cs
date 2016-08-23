﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Form1 : Form
    {
        private CF_RL129_API.API _API;
        private bool _IsConnected = false;

        public Form1()
        {
            InitializeComponent();
            this.Disposed += Form1_Disposed;
            _API = new CF_RL129_API.API();
        }

        private void Form1_Disposed(object sender, EventArgs e)
        {
            timer1.Stop();

            if(_API != null  && _API.IsConnected)
            {
                _API.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _API.Port = cbxPorts.Selected;
            _API.Connect();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tbLog.Text = _API.Log.ToString();
        }
    }
}
