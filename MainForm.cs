using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExchangeEmailClient;

namespace EmailClientTester
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetDefaults();
        }

        private string AppTitle = "Email Client Tester";

        private void SetDefaults()
        {
            txtDomain.Text = "xelocity";
            txtEmailAddress.Text = "chris.power@xelocity.com";
            txtUserName.Text = "Chris Power";
            txtPassword.Text = "twfxirf29";

            txtSubject.Text = "Test email";
            txtBody.Text = "This is a test email from the Exchange Email Client test program.";
            txtTo.Text = "chris.power@nettel.net.nz;cpower@aut.ac.nz;chris.power@xelocity.com";
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            gridFetch.Visible = true;
            lblFetchCount.Visible = true;
            lblFetchCount.Text = "Busy...";
            lblFetchCount.Refresh();
            gridFetch.Rows.Clear();
            //DataGridViewColumn new DataGridViewColumn();
            //gridFetch.Columns.Add(
            try
            {
                ExEmailRetriever importer = new ExEmailRetriever();
                importer.ConnectByEmailAddress(txtEmailAddress.Text, txtUserName.Text, txtPassword.Text, txtDomain.Text);
                // filters
                importer.HasAttachments = chkHasAttachments.Checked;
                importer.OnlyUnreadEmail = chkOnlyRead.Checked;
                importer.SubjectContains = txtSubjectContains.Text;
                importer.NameOfSender = txtNameOfSender.Text;

                int results = importer.Retrieve();
                for (int index = 1; index <= results; index++)
                {
                    ExEmailResult result = importer.GetResult(index); // 1..n
                    int rowIndex = gridFetch.Rows.Add();
                    DataGridViewRow row = gridFetch.Rows[rowIndex];
                    row.Cells[ColObject.Index].Value = result;
                    row.Cells[ColSender.Index].Value = result.SenderAddress;
                    row.Cells[ColSubject.Index].Value = result.Subject;
                    row.Cells[ColIsRead.Index].Value = result.IsRead;
                    row.Cells[ColHasAttachments.Index].Value = result.HasAttachments;
                    row.Cells[ColReceived.Index].Value = result.Received.ToString();
                    row.Cells[ColBody.Index].Value = "(click)";
                }

                this.Cursor = Cursors.Default;
                lblFetchCount.Text = "Fetched " + results.ToString() + " emails";
                // MessageBox.Show("Auto-discovered mail server url " + importer.Url + "."); good!
                // int count = importer.CountMatches();
                // MessageBox.Show("Count of matching emails is " + count.ToString() + ".");
            }
            catch (Exception ex)
            {
                lblFetchCount.Text = "Failed";
                MessageBox.Show(ex.Message, AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ExEmailSender worker = new ExEmailSender();
                worker.ConnectByEmailAddress(txtEmailAddress.Text, txtUserName.Text, txtPassword.Text, txtDomain.Text);
                /*
                char[] separators = new char[] { ',', ';' };
                string[] toAddresses = txtTo.Text.Split(separators);
                string[] attachments = new string[0];
                worker.Send(toAddresses, txtSubject.Text, txtBody.Text, attachments);
                 */
                worker.Send(txtTo.Text, txtSubject.Text, txtBody.Text, "");

                this.Cursor = Cursors.Default;
                // MessageBox.Show("Auto-discovered mail server url " + importer.Url + "."); good!
                MessageBox.Show("Sent email to " + txtTo.Text + ".");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ExEmailWorker worker = new ExEmailWorker();
                worker.ConnectByEmailAddress(txtEmailAddress.Text, txtUserName.Text, txtPassword.Text, txtDomain.Text);

                this.Cursor = Cursors.Default;
                MessageBox.Show("Connection test succeeded.\n\nAuto-discovered mail server url " + worker.Url + ".");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            tabControl.Size = this.ClientSize;
            gridFetch.Width = tabPageFetch.ClientSize.Width - gridFetch.Left * 2;
            gridFetch.Height = tabPageFetch.ClientSize.Height - gridFetch.Top - gridFetch.Left;
        }

        private void gridFetch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // on-demand content
            if (e.RowIndex < 0 || e.RowIndex >= gridFetch.Rows.Count)
                return;

            ExEmailResult result = gridFetch.Rows[e.RowIndex].Cells[ColObject.Index].Value as ExEmailResult;
            // Body - fetch and display Body
            // Attachments - show attachment names
            if (e.ColumnIndex == ColBody.Index)
            {
                string body = result.Body;
                MessageBox.Show("Body:\n" + body, AppTitle);
            }
            if (e.ColumnIndex == ColHasAttachments.Index)
            {
                int count = result.AttachmentCount;
                if (count == 0)
                {
                    MessageBox.Show("This email has no attachments.", AppTitle);
                    return;
                }
                string list = "";
                for (int index = 0; index < count; index++)
                {
                    list = list + "\n" + result.AttachmentName(index);
                }
                if (MessageBox.Show("Save attachments?\n" + list, AppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string folder = folderBrowserDialog.SelectedPath;
                        for (int index = 0; index < count; index++)
                        {
                            string attachmentName = result.AttachmentName(index);
                            result.SaveAttachmentFile(index, folder + "\\" + attachmentName);
                        }
                        MessageBox.Show("Saved attachment" + ((count > 1) ? "s" : "") + ".", AppTitle);
                    }
                }
            } 
        }
    }
}
