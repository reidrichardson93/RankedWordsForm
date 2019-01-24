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

namespace RankedWordsProto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RankedWords newRank = new RankedWords(textBox1.Text);
            listBox1.DataSource = newRank.CompareWords();
            listBox2.DataSource = newRank.GetWordList();
            label3.Text = string.Format("# Ranked = {0}", newRank.RankedWordsCount());
            label4.Text = string.Format("% Ranked = {0}%", ((newRank.RankedWordsCount() /  newRank.UserWordCount()) * 100.0).ToString("F"));
        }



        private void importTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = "";
            DialogResult result = ofdMain.ShowDialog();
            if (result == DialogResult.OK){
                path = ofdMain.FileName;
            }
            textBox1.Text = File.ReadAllText(path);
        }

        private void uniqueRankedWordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uniqueRankedWordsToolStripMenuItem.Checked = true;
            uniqueRankedWordsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            rankedWordsCountToolStripMenuItem.Checked = false;
            rankedWordsCountToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Unchecked;
            listBox2.Hide();
            label5.Hide();
            listBox1.Show();
            label2.Show();
            listBox1.TabIndex = 6;
            listBox2.TabIndex = 8;
            label2.TabIndex = 1;
            label5.TabIndex = 9;
        }

        private void rankedWordsCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rankedWordsCountToolStripMenuItem.Checked = true;
            rankedWordsCountToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            uniqueRankedWordsToolStripMenuItem.Checked = false;
            uniqueRankedWordsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Unchecked;
            listBox1.Hide();
            label2.Hide();
            listBox2.Show();
            label5.Show();
            listBox1.TabIndex = 8;
            listBox2.TabIndex = 6;
            label2.TabIndex = 9;
            label5.TabIndex = 1;
        }
    }
}
