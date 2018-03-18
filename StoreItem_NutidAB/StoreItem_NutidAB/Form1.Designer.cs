namespace StoreItem_NutidAB
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
            this.UrlLabel = new System.Windows.Forms.Label();
            this.RestUrl = new System.Windows.Forms.TextBox();
            this.MethodComboBox = new System.Windows.Forms.ComboBox();
            this.Send = new System.Windows.Forms.Button();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.JsonDataTextBox = new System.Windows.Forms.RichTextBox();
            this.ResponseMessage = new System.Windows.Forms.RichTextBox();
            this.ResponseLabel = new System.Windows.Forms.Label();
            this.AddRow = new System.Windows.Forms.Button();
            this.PostMethodComboBox = new System.Windows.Forms.ComboBox();
            this.SelectPostMethodLabel = new System.Windows.Forms.Label();
            this.JsonInputlabel = new System.Windows.Forms.Label();
            this.DataGridLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // UrlLabel
            // 
            this.UrlLabel.AutoSize = true;
            this.UrlLabel.Location = new System.Drawing.Point(100, 9);
            this.UrlLabel.Name = "UrlLabel";
            this.UrlLabel.Size = new System.Drawing.Size(29, 13);
            this.UrlLabel.TabIndex = 0;
            this.UrlLabel.Text = "URL";
            // 
            // RestUrl
            // 
            this.RestUrl.Location = new System.Drawing.Point(103, 25);
            this.RestUrl.Name = "RestUrl";
            this.RestUrl.Size = new System.Drawing.Size(400, 20);
            this.RestUrl.TabIndex = 1;
            this.RestUrl.Text = "http://www.nutidweboffice.com/bunkersgolfhk/api/assignment";
            // 
            // MethodComboBox
            // 
            this.MethodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MethodComboBox.FormattingEnabled = true;
            this.MethodComboBox.Items.AddRange(new object[] {
            "GET",
            "POST"});
            this.MethodComboBox.Location = new System.Drawing.Point(519, 24);
            this.MethodComboBox.Name = "MethodComboBox";
            this.MethodComboBox.Size = new System.Drawing.Size(121, 21);
            this.MethodComboBox.TabIndex = 2;
            this.MethodComboBox.SelectedIndexChanged += new System.EventHandler(this.MethodComboBox_SelectedIndexChanged);
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(661, 18);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(94, 33);
            this.Send.TabIndex = 3;
            this.Send.Text = "SEND";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // DataGridView
            // 
            this.DataGridView.AllowUserToAddRows = false;
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Location = new System.Drawing.Point(103, 192);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.Size = new System.Drawing.Size(652, 122);
            this.DataGridView.TabIndex = 4;
            this.DataGridView.Visible = false;
            this.DataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DataGridView_DataError);
            // 
            // JsonDataTextBox
            // 
            this.JsonDataTextBox.Location = new System.Drawing.Point(103, 379);
            this.JsonDataTextBox.Name = "JsonDataTextBox";
            this.JsonDataTextBox.Size = new System.Drawing.Size(652, 139);
            this.JsonDataTextBox.TabIndex = 6;
            this.JsonDataTextBox.Text = "";
            this.JsonDataTextBox.Visible = false;
            // 
            // ResponseMessage
            // 
            this.ResponseMessage.Location = new System.Drawing.Point(103, 80);
            this.ResponseMessage.Name = "ResponseMessage";
            this.ResponseMessage.ReadOnly = true;
            this.ResponseMessage.Size = new System.Drawing.Size(400, 76);
            this.ResponseMessage.TabIndex = 7;
            this.ResponseMessage.Text = "";
            // 
            // ResponseLabel
            // 
            this.ResponseLabel.AutoSize = true;
            this.ResponseLabel.Location = new System.Drawing.Point(100, 64);
            this.ResponseLabel.Name = "ResponseLabel";
            this.ResponseLabel.Size = new System.Drawing.Size(104, 13);
            this.ResponseLabel.TabIndex = 8;
            this.ResponseLabel.Text = "Response  Message";
            // 
            // AddRow
            // 
            this.AddRow.Location = new System.Drawing.Point(103, 320);
            this.AddRow.Name = "AddRow";
            this.AddRow.Size = new System.Drawing.Size(75, 23);
            this.AddRow.TabIndex = 9;
            this.AddRow.Text = "Add Row";
            this.AddRow.UseVisualStyleBackColor = true;
            this.AddRow.Visible = false;
            this.AddRow.Click += new System.EventHandler(this.AddRow_Click);
            // 
            // PostMethodComboBox
            // 
            this.PostMethodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PostMethodComboBox.FormattingEnabled = true;
            this.PostMethodComboBox.Items.AddRange(new object[] {
            "Using DataGrid",
            "Using Json"});
            this.PostMethodComboBox.Location = new System.Drawing.Point(519, 80);
            this.PostMethodComboBox.Name = "PostMethodComboBox";
            this.PostMethodComboBox.Size = new System.Drawing.Size(121, 21);
            this.PostMethodComboBox.TabIndex = 10;
            this.PostMethodComboBox.SelectedIndexChanged += new System.EventHandler(this.PostMethodComboBox_SelectedIndexChanged);
            // 
            // SelectPostMethodLabel
            // 
            this.SelectPostMethodLabel.AutoSize = true;
            this.SelectPostMethodLabel.Location = new System.Drawing.Point(516, 64);
            this.SelectPostMethodLabel.Name = "SelectPostMethodLabel";
            this.SelectPostMethodLabel.Size = new System.Drawing.Size(100, 13);
            this.SelectPostMethodLabel.TabIndex = 11;
            this.SelectPostMethodLabel.Text = "Select Post Method";
            // 
            // JsonInputlabel
            // 
            this.JsonInputlabel.AutoSize = true;
            this.JsonInputlabel.Location = new System.Drawing.Point(100, 363);
            this.JsonInputlabel.Name = "JsonInputlabel";
            this.JsonInputlabel.Size = new System.Drawing.Size(56, 13);
            this.JsonInputlabel.TabIndex = 12;
            this.JsonInputlabel.Text = "Json Input";
            // 
            // DataGridLabel
            // 
            this.DataGridLabel.AutoSize = true;
            this.DataGridLabel.Location = new System.Drawing.Point(100, 176);
            this.DataGridLabel.Name = "DataGridLabel";
            this.DataGridLabel.Size = new System.Drawing.Size(52, 13);
            this.DataGridLabel.TabIndex = 13;
            this.DataGridLabel.Text = "Data Grid";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 530);
            this.Controls.Add(this.DataGridLabel);
            this.Controls.Add(this.JsonInputlabel);
            this.Controls.Add(this.SelectPostMethodLabel);
            this.Controls.Add(this.PostMethodComboBox);
            this.Controls.Add(this.AddRow);
            this.Controls.Add(this.ResponseLabel);
            this.Controls.Add(this.ResponseMessage);
            this.Controls.Add(this.JsonDataTextBox);
            this.Controls.Add(this.DataGridView);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.MethodComboBox);
            this.Controls.Add(this.RestUrl);
            this.Controls.Add(this.UrlLabel);
            this.Name = "Form1";
            this.Text = "Rest Client";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UrlLabel;
        private System.Windows.Forms.TextBox RestUrl;
        private System.Windows.Forms.ComboBox MethodComboBox;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.RichTextBox JsonDataTextBox;
        private System.Windows.Forms.RichTextBox ResponseMessage;
        private System.Windows.Forms.Label ResponseLabel;
        private System.Windows.Forms.Button AddRow;
        private System.Windows.Forms.ComboBox PostMethodComboBox;
        private System.Windows.Forms.Label SelectPostMethodLabel;
        private System.Windows.Forms.Label JsonInputlabel;
        private System.Windows.Forms.Label DataGridLabel;
    }
}

