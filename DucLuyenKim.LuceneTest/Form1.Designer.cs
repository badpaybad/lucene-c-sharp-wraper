namespace DucLuyenKim.LuceneTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnShowAll = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.btnAddRandomSample = new System.Windows.Forms.ToolStripButton();
            this.btnAddToIndex = new System.Windows.Forms.ToolStripButton();
            this.btnRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtKeywords = new System.Windows.Forms.ToolStripTextBox();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txtQueryString = new System.Windows.Forms.ToolStripTextBox();
            this.btnQueryHelp = new System.Windows.Forms.ToolStripButton();
            this.btnQueryTest = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGotoMySite = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 541);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1172, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShowAll,
            this.btnRemoveAll,
            this.toolStripSeparator4,
            this.toolStripLabel3,
            this.btnAddRandomSample,
            this.btnAddToIndex,
            this.btnRemove,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.txtKeywords,
            this.btnSearch,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.txtQueryString,
            this.btnQueryHelp,
            this.btnQueryTest,
            this.toolStripSeparator3,
            this.btnGotoMySite});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1172, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnShowAll
            // 
            this.btnShowAll.Image = ((System.Drawing.Image)(resources.GetObject("btnShowAll.Image")));
            this.btnShowAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(73, 22);
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveAll.Image")));
            this.btnRemoveAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(87, 22);
            this.btnRemoveAll.Text = "Remove All";
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(38, 22);
            this.toolStripLabel3.Text = "Index:";
            // 
            // btnAddRandomSample
            // 
            this.btnAddRandomSample.Image = ((System.Drawing.Image)(resources.GetObject("btnAddRandomSample.Image")));
            this.btnAddRandomSample.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddRandomSample.Name = "btnAddRandomSample";
            this.btnAddRandomSample.Size = new System.Drawing.Size(72, 22);
            this.btnAddRandomSample.Text = "Random";
            this.btnAddRandomSample.Click += new System.EventHandler(this.btnAddRandomSample_Click);
            // 
            // btnAddToIndex
            // 
            this.btnAddToIndex.Image = ((System.Drawing.Image)(resources.GetObject("btnAddToIndex.Image")));
            this.btnAddToIndex.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddToIndex.Name = "btnAddToIndex";
            this.btnAddToIndex.Size = new System.Drawing.Size(49, 22);
            this.btnAddToIndex.Text = "Add";
            this.btnAddToIndex.Click += new System.EventHandler(this.btnAddToIndex_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.Image")));
            this.btnRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(70, 22);
            this.btnRemove.Text = "Remove";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(58, 22);
            this.toolStripLabel1.Text = "Keywords";
            // 
            // txtKeywords
            // 
            this.txtKeywords.Name = "txtKeywords";
            this.txtKeywords.Size = new System.Drawing.Size(100, 25);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(62, 22);
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(87, 22);
            this.toolStripLabel2.Text = "Luncene Query";
            // 
            // txtQueryString
            // 
            this.txtQueryString.Name = "txtQueryString";
            this.txtQueryString.Size = new System.Drawing.Size(150, 25);
            // 
            // btnQueryHelp
            // 
            this.btnQueryHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnQueryHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnQueryHelp.Image")));
            this.btnQueryHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQueryHelp.Name = "btnQueryHelp";
            this.btnQueryHelp.Size = new System.Drawing.Size(23, 22);
            this.btnQueryHelp.Text = "?";
            this.btnQueryHelp.Click += new System.EventHandler(this.btnQueryHelp_Click);
            // 
            // btnQueryTest
            // 
            this.btnQueryTest.Image = ((System.Drawing.Image)(resources.GetObject("btnQueryTest.Image")));
            this.btnQueryTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQueryTest.Name = "btnQueryTest";
            this.btnQueryTest.Size = new System.Drawing.Size(49, 22);
            this.btnQueryTest.Text = "Test";
            this.btnQueryTest.Click += new System.EventHandler(this.btnQueryTest_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnGotoMySite
            // 
            this.btnGotoMySite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnGotoMySite.Image = ((System.Drawing.Image)(resources.GetObject("btnGotoMySite.Image")));
            this.btnGotoMySite.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGotoMySite.Name = "btnGotoMySite";
            this.btnGotoMySite.Size = new System.Drawing.Size(129, 22);
            this.btnGotoMySite.Text = "http://badpaybad.info";
            this.btnGotoMySite.Click += new System.EventHandler(this.btnGotoMySite_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvResult);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1172, 516);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SearchResult";
            // 
            // dgvResult
            // 
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.Location = new System.Drawing.Point(3, 16);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.Size = new System.Drawing.Size(1166, 497);
            this.dgvResult.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 563);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.Text = "Lucene simple sample";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddToIndex;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtKeywords;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox txtQueryString;
        private System.Windows.Forms.ToolStripButton btnQueryTest;
        private System.Windows.Forms.ToolStripButton btnQueryHelp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripButton btnAddRandomSample;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.ToolStripButton btnGotoMySite;
        private System.Windows.Forms.ToolStripButton btnShowAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton btnRemove;
        private System.Windows.Forms.ToolStripButton btnRemoveAll;
    }
}

