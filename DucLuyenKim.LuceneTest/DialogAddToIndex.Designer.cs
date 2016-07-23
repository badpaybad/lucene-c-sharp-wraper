namespace DucLuyenKim.LuceneTest
{
    partial class DialogAddToIndex
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtObjType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtObjId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFieldName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFieldValue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.grbFields = new System.Windows.Forms.GroupBox();
            this.grbFields.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(159, 312);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(97, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Add To Index";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(280, 312);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtObjType
            // 
            this.txtObjType.Location = new System.Drawing.Point(105, 30);
            this.txtObjType.Name = "txtObjType";
            this.txtObjType.Size = new System.Drawing.Size(151, 20);
            this.txtObjType.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "ObjectType";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "ObjectId";
            // 
            // txtObjId
            // 
            this.txtObjId.Location = new System.Drawing.Point(105, 65);
            this.txtObjId.Name = "txtObjId";
            this.txtObjId.Size = new System.Drawing.Size(151, 20);
            this.txtObjId.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "ObjectFieldValue";
            // 
            // txtFieldName
            // 
            this.txtFieldName.Location = new System.Drawing.Point(100, 23);
            this.txtFieldName.Name = "txtFieldName";
            this.txtFieldName.Size = new System.Drawing.Size(230, 20);
            this.txtFieldName.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "ObjectFieldName";
            // 
            // txtFieldValue
            // 
            this.txtFieldValue.Location = new System.Drawing.Point(9, 86);
            this.txtFieldValue.Multiline = true;
            this.txtFieldValue.Name = "txtFieldValue";
            this.txtFieldValue.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFieldValue.Size = new System.Drawing.Size(310, 71);
            this.txtFieldValue.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(239, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "this is sample for field, we can add more than one";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(125, 312);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(102, 23);
            this.btnRemove.TabIndex = 11;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // grbFields
            // 
            this.grbFields.Controls.Add(this.label4);
            this.grbFields.Controls.Add(this.txtFieldName);
            this.grbFields.Controls.Add(this.label5);
            this.grbFields.Controls.Add(this.label3);
            this.grbFields.Controls.Add(this.txtFieldValue);
            this.grbFields.Location = new System.Drawing.Point(25, 101);
            this.grbFields.Name = "grbFields";
            this.grbFields.Size = new System.Drawing.Size(336, 188);
            this.grbFields.TabIndex = 12;
            this.grbFields.TabStop = false;
            this.grbFields.Text = "Fields";
            // 
            // DialogAddToIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 349);
            this.Controls.Add(this.grbFields);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtObjId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtObjType);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "DialogAddToIndex";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DialogAddToIndex";
            this.Load += new System.EventHandler(this.DialogAddToIndex_Load);
            this.grbFields.ResumeLayout(false);
            this.grbFields.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtObjType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtObjId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFieldName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFieldValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.GroupBox grbFields;
    }
}