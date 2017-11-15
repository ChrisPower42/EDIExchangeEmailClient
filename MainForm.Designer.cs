namespace EmailClientTester
{
    partial class MainForm
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
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageConnection = new System.Windows.Forms.TabPage();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.tabPageFetch = new System.Windows.Forms.TabPage();
            this.lblFetchCount = new System.Windows.Forms.Label();
            this.gridFetch = new System.Windows.Forms.DataGridView();
            this.ColObject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIsRead = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColHasAttachments = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColReceived = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBody = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkHasAttachments = new System.Windows.Forms.CheckBox();
            this.chkOnlyRead = new System.Windows.Forms.CheckBox();
            this.txtNameOfSender = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSubjectContains = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPageSend = new System.Windows.Forms.TabPage();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl.SuspendLayout();
            this.tabPageConnection.SuspendLayout();
            this.tabPageFetch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFetch)).BeginInit();
            this.tabPageSend.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Location = new System.Drawing.Point(215, 184);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(75, 23);
            this.btnRetrieve.TabIndex = 0;
            this.btnRetrieve.Text = "Fetch!";
            this.btnRetrieve.UseVisualStyleBackColor = true;
            this.btnRetrieve.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Email Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "User Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Domain";
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.Location = new System.Drawing.Point(110, 20);
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(180, 20);
            this.txtEmailAddress.TabIndex = 5;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(110, 60);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(180, 20);
            this.txtUserName.TabIndex = 6;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(110, 100);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(180, 20);
            this.txtPassword.TabIndex = 7;
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(110, 140);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(180, 20);
            this.txtDomain.TabIndex = 8;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(215, 184);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 9;
            this.btnSend.Text = "Send!";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(110, 20);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(180, 20);
            this.txtTo.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "To";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(110, 60);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(180, 20);
            this.txtSubject.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Subject";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Body";
            // 
            // txtBody
            // 
            this.txtBody.Location = new System.Drawing.Point(110, 100);
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(180, 72);
            this.txtBody.TabIndex = 15;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageConnection);
            this.tabControl.Controls.Add(this.tabPageFetch);
            this.tabControl.Controls.Add(this.tabPageSend);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(462, 370);
            this.tabControl.TabIndex = 16;
            // 
            // tabPageConnection
            // 
            this.tabPageConnection.Controls.Add(this.btnTestConnection);
            this.tabPageConnection.Controls.Add(this.txtEmailAddress);
            this.tabPageConnection.Controls.Add(this.label1);
            this.tabPageConnection.Controls.Add(this.label2);
            this.tabPageConnection.Controls.Add(this.label3);
            this.tabPageConnection.Controls.Add(this.label4);
            this.tabPageConnection.Controls.Add(this.txtUserName);
            this.tabPageConnection.Controls.Add(this.txtPassword);
            this.tabPageConnection.Controls.Add(this.txtDomain);
            this.tabPageConnection.Location = new System.Drawing.Point(4, 22);
            this.tabPageConnection.Name = "tabPageConnection";
            this.tabPageConnection.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConnection.Size = new System.Drawing.Size(454, 344);
            this.tabPageConnection.TabIndex = 0;
            this.tabPageConnection.Text = "Connection";
            this.tabPageConnection.UseVisualStyleBackColor = true;
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(215, 184);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(75, 23);
            this.btnTestConnection.TabIndex = 10;
            this.btnTestConnection.Text = "Test!";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // tabPageFetch
            // 
            this.tabPageFetch.Controls.Add(this.lblFetchCount);
            this.tabPageFetch.Controls.Add(this.gridFetch);
            this.tabPageFetch.Controls.Add(this.chkHasAttachments);
            this.tabPageFetch.Controls.Add(this.chkOnlyRead);
            this.tabPageFetch.Controls.Add(this.txtNameOfSender);
            this.tabPageFetch.Controls.Add(this.label9);
            this.tabPageFetch.Controls.Add(this.txtSubjectContains);
            this.tabPageFetch.Controls.Add(this.label8);
            this.tabPageFetch.Controls.Add(this.btnRetrieve);
            this.tabPageFetch.Location = new System.Drawing.Point(4, 22);
            this.tabPageFetch.Name = "tabPageFetch";
            this.tabPageFetch.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFetch.Size = new System.Drawing.Size(454, 344);
            this.tabPageFetch.TabIndex = 1;
            this.tabPageFetch.Text = "Fetch";
            this.tabPageFetch.UseVisualStyleBackColor = true;
            // 
            // lblFetchCount
            // 
            this.lblFetchCount.AutoSize = true;
            this.lblFetchCount.Location = new System.Drawing.Point(15, 184);
            this.lblFetchCount.Name = "lblFetchCount";
            this.lblFetchCount.Size = new System.Drawing.Size(65, 13);
            this.lblFetchCount.TabIndex = 13;
            this.lblFetchCount.Text = "Fetch Count";
            this.lblFetchCount.Visible = false;
            // 
            // gridFetch
            // 
            this.gridFetch.AllowUserToAddRows = false;
            this.gridFetch.AllowUserToDeleteRows = false;
            this.gridFetch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFetch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColObject,
            this.ColSender,
            this.ColSubject,
            this.ColIsRead,
            this.ColHasAttachments,
            this.ColReceived,
            this.ColBody});
            this.gridFetch.Location = new System.Drawing.Point(8, 229);
            this.gridFetch.Name = "gridFetch";
            this.gridFetch.ReadOnly = true;
            this.gridFetch.Size = new System.Drawing.Size(440, 109);
            this.gridFetch.TabIndex = 12;
            this.gridFetch.Visible = false;
            this.gridFetch.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridFetch_CellClick);
            // 
            // ColObject
            // 
            this.ColObject.HeaderText = "Object";
            this.ColObject.Name = "ColObject";
            this.ColObject.ReadOnly = true;
            this.ColObject.Visible = false;
            // 
            // ColSender
            // 
            this.ColSender.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColSender.HeaderText = "Sender";
            this.ColSender.Name = "ColSender";
            this.ColSender.ReadOnly = true;
            this.ColSender.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColSender.Width = 66;
            // 
            // ColSubject
            // 
            this.ColSubject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColSubject.HeaderText = "Subject";
            this.ColSubject.Name = "ColSubject";
            this.ColSubject.ReadOnly = true;
            this.ColSubject.Width = 68;
            // 
            // ColIsRead
            // 
            this.ColIsRead.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColIsRead.HeaderText = "Read";
            this.ColIsRead.Name = "ColIsRead";
            this.ColIsRead.ReadOnly = true;
            this.ColIsRead.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColIsRead.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColIsRead.Width = 58;
            // 
            // ColHasAttachments
            // 
            this.ColHasAttachments.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColHasAttachments.HeaderText = "HasAttachments";
            this.ColHasAttachments.Name = "ColHasAttachments";
            this.ColHasAttachments.ReadOnly = true;
            this.ColHasAttachments.Width = 91;
            // 
            // ColReceived
            // 
            this.ColReceived.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColReceived.HeaderText = "Received";
            this.ColReceived.Name = "ColReceived";
            this.ColReceived.ReadOnly = true;
            this.ColReceived.Width = 78;
            // 
            // ColBody
            // 
            this.ColBody.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColBody.HeaderText = "Body";
            this.ColBody.Name = "ColBody";
            this.ColBody.ReadOnly = true;
            this.ColBody.Width = 56;
            // 
            // chkHasAttachments
            // 
            this.chkHasAttachments.AutoSize = true;
            this.chkHasAttachments.Location = new System.Drawing.Point(110, 140);
            this.chkHasAttachments.Name = "chkHasAttachments";
            this.chkHasAttachments.Size = new System.Drawing.Size(143, 17);
            this.chkHasAttachments.TabIndex = 11;
            this.chkHasAttachments.Text = "Emails With Attachments";
            this.chkHasAttachments.UseVisualStyleBackColor = true;
            // 
            // chkOnlyRead
            // 
            this.chkOnlyRead.AutoSize = true;
            this.chkOnlyRead.Location = new System.Drawing.Point(110, 100);
            this.chkOnlyRead.Name = "chkOnlyRead";
            this.chkOnlyRead.Size = new System.Drawing.Size(118, 17);
            this.chkOnlyRead.TabIndex = 10;
            this.chkOnlyRead.Text = "Only Unread Emails";
            this.chkOnlyRead.UseVisualStyleBackColor = true;
            // 
            // txtNameOfSender
            // 
            this.txtNameOfSender.Location = new System.Drawing.Point(110, 60);
            this.txtNameOfSender.Name = "txtNameOfSender";
            this.txtNameOfSender.Size = new System.Drawing.Size(180, 20);
            this.txtNameOfSender.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Sender\'s Name";
            // 
            // txtSubjectContains
            // 
            this.txtSubjectContains.Location = new System.Drawing.Point(110, 20);
            this.txtSubjectContains.Name = "txtSubjectContains";
            this.txtSubjectContains.Size = new System.Drawing.Size(180, 20);
            this.txtSubjectContains.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Subject Contains";
            // 
            // tabPageSend
            // 
            this.tabPageSend.Controls.Add(this.txtBody);
            this.tabPageSend.Controls.Add(this.btnSend);
            this.tabPageSend.Controls.Add(this.label7);
            this.tabPageSend.Controls.Add(this.label5);
            this.tabPageSend.Controls.Add(this.txtSubject);
            this.tabPageSend.Controls.Add(this.txtTo);
            this.tabPageSend.Controls.Add(this.label6);
            this.tabPageSend.Location = new System.Drawing.Point(4, 22);
            this.tabPageSend.Name = "tabPageSend";
            this.tabPageSend.Size = new System.Drawing.Size(454, 344);
            this.tabPageSend.TabIndex = 2;
            this.tabPageSend.Text = "Send";
            this.tabPageSend.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 374);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Exchange Email Client Tester";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.tabControl.ResumeLayout(false);
            this.tabPageConnection.ResumeLayout(false);
            this.tabPageConnection.PerformLayout();
            this.tabPageFetch.ResumeLayout(false);
            this.tabPageFetch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFetch)).EndInit();
            this.tabPageSend.ResumeLayout(false);
            this.tabPageSend.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmailAddress;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageConnection;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.TabPage tabPageFetch;
        private System.Windows.Forms.TabPage tabPageSend;
        private System.Windows.Forms.CheckBox chkHasAttachments;
        private System.Windows.Forms.CheckBox chkOnlyRead;
        private System.Windows.Forms.TextBox txtNameOfSender;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSubjectContains;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView gridFetch;
        private System.Windows.Forms.Label lblFetchCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColObject;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSender;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSubject;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColIsRead;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColHasAttachments;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColReceived;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBody;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}

