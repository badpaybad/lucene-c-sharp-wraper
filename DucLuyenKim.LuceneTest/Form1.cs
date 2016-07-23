using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DucLuyenKim.LuceneIndex;

namespace DucLuyenKim.LuceneTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            long total;
            dgvResult.DataSource = LuceneSearchProvider.GetAllIndexedRecords(out total);

        }

        private void btnAddRandomSample_Click(object sender, EventArgs e)
        {
            SampleObjectIndexServices.Instance.AddRandom();
            new Thread(() =>
               {
                   //Thread.Sleep(2000);
                   dgvResult.BeginInvoke(new MethodInvoker(() =>
                   {
                       long totalRecords;
                       dgvResult.DataSource = SampleObjectIndexServices.Instance.SelectAll();
                   }));
               }).Start();
        }

        private void btnAddToIndex_Click(object sender, EventArgs e)
        {
            var dlg = new DialogAddToIndex();
            dlg.ModeAddIndex = true;
            dlg.Text = "Add an object to index";
            var action = dlg.ShowDialog();
            if (action == DialogResult.OK)
            {
                ShowAllIndexed();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            long totalRecords;
            dgvResult.DataSource = LuceneSearchProvider.SearchByAllFields(txtKeywords.Text, out totalRecords);
        }

        private void btnQueryTest_Click(object sender, EventArgs e)
        {
            long totalRecords;
            try
            {
                dgvResult.DataSource = LuceneSearchProvider.TestQuery(string.Empty, txtQueryString.Text,
                    out totalRecords);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnQueryHelp_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://lucene.apache.org/core/2_9_4/queryparsersyntax.html");
            Process.Start(sInfo);
        }

        private void btnGotoMySite_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://badpaybad.info");
            Process.Start(sInfo);
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            ShowAllIndexed();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var dlg = new DialogAddToIndex();
            dlg.ModeAddIndex = false;
            dlg.Text = "Remove an indexed object";
            var action = dlg.ShowDialog();
            if (action == DialogResult.OK)
            {
                ShowAllIndexed();
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            LuceneSearchProvider.RemoveAllIndexed();
            ShowAllIndexed();
        }

        void ShowAllIndexed()
        {
            new Thread(() =>
            {
                //Thread.Sleep(2000);
                dgvResult.BeginInvoke(new MethodInvoker(() =>
                {
                    long totalRecords;
                    dgvResult.DataSource = LuceneSearchProvider.GetAllIndexedRecords(out totalRecords);
                }));
            }).Start();
        }

    }
}
