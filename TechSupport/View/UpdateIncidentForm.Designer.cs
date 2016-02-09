namespace TechSupport
{
    partial class UpdateIncidentForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.IncidentIDBox = new System.Windows.Forms.TextBox();
            this.TitleBox = new System.Windows.Forms.TextBox();
            this.DateOpenedBox = new System.Windows.Forms.TextBox();
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            this.TextToAddBox = new System.Windows.Forms.TextBox();
            this.GetIncidentBtn = new System.Windows.Forms.Button();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.CloseIncidentBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.CustomerBox = new System.Windows.Forms.TextBox();
            this.ProductBox = new System.Windows.Forms.TextBox();
            this.TechnicianBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Incident ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Customer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Product";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Technician";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "Title";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(31, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "Date Opened";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(31, 284);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 18);
            this.label7.TabIndex = 9;
            this.label7.Text = "Description";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(31, 393);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 18);
            this.label8.TabIndex = 10;
            this.label8.Text = "Text To Add";
            // 
            // IncidentIDBox
            // 
            this.IncidentIDBox.Location = new System.Drawing.Point(165, 25);
            this.IncidentIDBox.Name = "IncidentIDBox";
            this.IncidentIDBox.Size = new System.Drawing.Size(100, 20);
            this.IncidentIDBox.TabIndex = 11;
            // 
            // TitleBox
            // 
            this.TitleBox.Enabled = false;
            this.TitleBox.Location = new System.Drawing.Point(165, 191);
            this.TitleBox.Name = "TitleBox";
            this.TitleBox.Size = new System.Drawing.Size(293, 20);
            this.TitleBox.TabIndex = 15;
            // 
            // DateOpenedBox
            // 
            this.DateOpenedBox.Enabled = false;
            this.DateOpenedBox.Location = new System.Drawing.Point(164, 229);
            this.DateOpenedBox.Name = "DateOpenedBox";
            this.DateOpenedBox.Size = new System.Drawing.Size(110, 20);
            this.DateOpenedBox.TabIndex = 16;
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Enabled = false;
            this.DescriptionBox.Location = new System.Drawing.Point(165, 278);
            this.DescriptionBox.Multiline = true;
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.Size = new System.Drawing.Size(293, 87);
            this.DescriptionBox.TabIndex = 17;
            // 
            // TextToAddBox
            // 
            this.TextToAddBox.Location = new System.Drawing.Point(165, 387);
            this.TextToAddBox.Multiline = true;
            this.TextToAddBox.Name = "TextToAddBox";
            this.TextToAddBox.Size = new System.Drawing.Size(293, 94);
            this.TextToAddBox.TabIndex = 18;
            // 
            // GetIncidentBtn
            // 
            this.GetIncidentBtn.Enabled = false;
            this.GetIncidentBtn.Location = new System.Drawing.Point(297, 24);
            this.GetIncidentBtn.Name = "GetIncidentBtn";
            this.GetIncidentBtn.Size = new System.Drawing.Size(75, 23);
            this.GetIncidentBtn.TabIndex = 19;
            this.GetIncidentBtn.Text = "Get Incident";
            this.GetIncidentBtn.UseVisualStyleBackColor = true;
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Enabled = false;
            this.UpdateBtn.Location = new System.Drawing.Point(165, 506);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(75, 23);
            this.UpdateBtn.TabIndex = 20;
            this.UpdateBtn.Text = "Update";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            // 
            // CloseIncidentBtn
            // 
            this.CloseIncidentBtn.Enabled = false;
            this.CloseIncidentBtn.Location = new System.Drawing.Point(260, 506);
            this.CloseIncidentBtn.Name = "CloseIncidentBtn";
            this.CloseIncidentBtn.Size = new System.Drawing.Size(103, 23);
            this.CloseIncidentBtn.TabIndex = 21;
            this.CloseIncidentBtn.Text = "Close Incident";
            this.CloseIncidentBtn.UseVisualStyleBackColor = true;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(382, 506);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 22;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // CustomerBox
            // 
            this.CustomerBox.Enabled = false;
            this.CustomerBox.Location = new System.Drawing.Point(165, 62);
            this.CustomerBox.Name = "CustomerBox";
            this.CustomerBox.Size = new System.Drawing.Size(293, 20);
            this.CustomerBox.TabIndex = 23;
            // 
            // ProductBox
            // 
            this.ProductBox.Enabled = false;
            this.ProductBox.Location = new System.Drawing.Point(164, 106);
            this.ProductBox.Name = "ProductBox";
            this.ProductBox.Size = new System.Drawing.Size(293, 20);
            this.ProductBox.TabIndex = 24;
            // 
            // TechnicianBox
            // 
            this.TechnicianBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TechnicianBox.FormattingEnabled = true;
            this.TechnicianBox.Location = new System.Drawing.Point(165, 146);
            this.TechnicianBox.Name = "TechnicianBox";
            this.TechnicianBox.Size = new System.Drawing.Size(293, 21);
            this.TechnicianBox.TabIndex = 14;
            // 
            // UpdateIncidentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 544);
            this.Controls.Add(this.ProductBox);
            this.Controls.Add(this.CustomerBox);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.CloseIncidentBtn);
            this.Controls.Add(this.UpdateBtn);
            this.Controls.Add(this.GetIncidentBtn);
            this.Controls.Add(this.TextToAddBox);
            this.Controls.Add(this.DescriptionBox);
            this.Controls.Add(this.DateOpenedBox);
            this.Controls.Add(this.TitleBox);
            this.Controls.Add(this.TechnicianBox);
            this.Controls.Add(this.IncidentIDBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Name = "UpdateIncidentForm";
            this.Text = "UpdateIncident";
            this.Load += new System.EventHandler(this.UpdateIncidentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox IncidentIDBox;
        private System.Windows.Forms.TextBox TitleBox;
        private System.Windows.Forms.TextBox DateOpenedBox;
        private System.Windows.Forms.TextBox DescriptionBox;
        private System.Windows.Forms.TextBox TextToAddBox;
        private System.Windows.Forms.Button GetIncidentBtn;
        private System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.Button CloseIncidentBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.TextBox CustomerBox;
        private System.Windows.Forms.TextBox ProductBox;
        private System.Windows.Forms.ComboBox TechnicianBox;

    }
}