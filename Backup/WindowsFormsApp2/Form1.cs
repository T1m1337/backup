using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private object openFileDialog1;
        private object form1;

        public Form1()
        {
            InitializeComponent();
            textBox2.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            checkBox2.Checked = true;
            checkBox3.Checked = true;
            checkBox4.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders"; //Registry Key wo Standardpfade angegeben sind
            RegistryKey registry = Registry.CurrentUser.OpenSubKey(path); //öffnet den Unterordner des Keys
            if (checkBox1.Checked == true)
            {
                string name = registry.GetValue("Desktop").ToString(); // wandelt den Pfad aus dem Key in einen String um
                string var = Environment.ExpandEnvironmentVariables(name); // wenn eine Environment Variable vorhanden ist, wird sie ausgeklappt
                string target = textBox1.Text; // liest Text aus Textfeld aus
                string desktop = "\\Desktop";
                Directory.CreateDirectory(target); // erstellt Ordner im Zielverzeichnis
                string sourcefile = name; //eigentlich sourcedirectory
                string targetpath = target + desktop;
                foreach (string dirPath in Directory.GetDirectories(sourcefile, "*",
                SearchOption.AllDirectories))
                {
                        Directory.CreateDirectory(dirPath.Replace(sourcefile, targetpath));
                }
                foreach (string newPath in Directory.GetFiles(sourcefile, "*.*", SearchOption.AllDirectories)) // Diese Schleifen kopieren die Files und überschreiben die alten.
                {
                    File.Copy(newPath, newPath.Replace(sourcefile, targetpath), true);
                }
            }

            if (checkBox2.Checked == true)
            {
                string name = registry.GetValue("Personal").ToString();
                string var = Environment.ExpandEnvironmentVariables(name);
                string target = textBox1.Text;
                string documents = "//Documents";
                Directory.CreateDirectory(target);
                string sourcefile1 = var;
                string targetpath1 = target + documents;
                foreach (string dirPath in Directory.GetDirectories(sourcefile1, "*",
                SearchOption.AllDirectories))
                {
                    Directory.CreateDirectory(dirPath.Replace(sourcefile1, targetpath1));
                }
                foreach (string newPath in Directory.GetFiles(sourcefile1, "*.*", SearchOption.AllDirectories))
                {
                    File.Copy(newPath, newPath.Replace(sourcefile1, targetpath1), true);
                }
            }
            

            if (checkBox3.Checked == true)
            {
                string name = registry.GetValue("My Pictures").ToString();
                string var = Environment.ExpandEnvironmentVariables(name);
                string target = textBox1.Text;
                string pictures = "//Pictures";
                Directory.CreateDirectory(target);
                string sourcefile2 =  var;
                string targetpath2 = target + pictures;

                foreach (string dirPath in Directory.GetDirectories(sourcefile2, "*",
                SearchOption.AllDirectories))
                   Directory.CreateDirectory(dirPath.Replace(sourcefile2, targetpath2));

                foreach (string newPath in Directory.GetFiles(sourcefile2, "*.*", SearchOption.AllDirectories))
                {
                    File.Copy(newPath, newPath.Replace(sourcefile2, targetpath2), true);
                }
            }


            if (checkBox4.Checked == true)
            {
                string target = textBox1.Text;
                Directory.CreateDirectory(target);
                string data = "//data";
                string targetpath3 = target + data;
                string sourcefile3 = textBox2.Text;

                foreach (string dirPath in Directory.GetDirectories(sourcefile3, "*", SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(sourcefile3, targetpath3));

                foreach (string newPath in Directory.GetFiles(sourcefile3, "*.*", SearchOption.AllDirectories))
                {   
                    File.Copy(newPath, newPath.Replace(sourcefile3, targetpath3), true);
                }
            }
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.hsr.ch/de/");
        }

        private void checkBox4_Click(object sender, EventArgs e)
        {
            if (checkBox4.CheckState != CheckState.Checked)
            {
                textBox2.Enabled = false;
            }
            else
            {
                textBox2.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string path = null;
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    path = fbd.SelectedPath;
                }
            }
            textBox2.Text = path;
        }
    }
}
