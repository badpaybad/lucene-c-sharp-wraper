using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DucLuyenKim.LuceneIndex;

namespace DucLuyenKim.LuceneTest
{
    public partial class DialogAddToIndex : Form
    {
        public bool ModeAddIndex { get; set; }

        public DialogAddToIndex()
        {
            InitializeComponent();
        }

        private void DialogAddToIndex_Load(object sender, EventArgs e)
        {
            if (ModeAddIndex)
            {
                txtFieldName.Text = "Fullname";
                int rndId = new Random().Next();
                txtFieldValue.Text = "Fullname: " + rndId;
                txtObjId.Text = rndId.ToString();
                txtObjType.Text = "TypeOf" + rndId;
                btnOk.Visible = true;
                btnRemove.Visible = false;
                grbFields.Visible = true;
            }
            else
            {
                btnOk.Visible = false;
                btnRemove.Visible = true;
                grbFields.Visible = false;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFieldName.Text))
            {
                MessageBox.Show("ObjectFieldName can not be empty");
                txtFieldName.Focus();
                return;
            }

            var doc = new AbstractDocument();
            doc.Lucene_ObjectId = txtObjId.Text;
            doc.Lucene_ObjectType = txtObjType.Text;

            doc.PropertyNameAndValue.Add(txtFieldName.Text, txtFieldValue.Text);

            LuceneSearchProvider.AddOrUpdateToIndex(doc);

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtObjType.Text) || string.IsNullOrEmpty(txtObjId.Text))
            {
                MessageBox.Show("To remove must input ObjType and ObjId");
                txtObjType.Focus();
                return;
            }

            LuceneSearchProvider.RemoveIndexed(txtObjType.Text,txtObjId.Text);
            DialogResult = DialogResult.OK;
        }
    }
}
