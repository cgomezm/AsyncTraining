namespace UiFormApp
{
    partial class UiForm
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
            this.downloadBtnLeft = new System.Windows.Forms.Button();
            this.downloadBtnRight = new System.Windows.Forms.Button();
            this.urlTextBoxLeft = new System.Windows.Forms.TextBox();
            this.urlTextBoxRight = new System.Windows.Forms.TextBox();
            this.contentTxbLeft = new System.Windows.Forms.RichTextBox();
            this.contentTxbRight = new System.Windows.Forms.RichTextBox();
            this.logLabelLeft = new System.Windows.Forms.Label();
            this.logLabelRight = new System.Windows.Forms.Label();
            this.btnDonwloadTask = new System.Windows.Forms.Button();
            this.btnDownloadAsyncTask = new System.Windows.Forms.Button();
            this.btnDownloadBgWorker = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // downloadBtnLeft
            // 
            this.downloadBtnLeft.Location = new System.Drawing.Point(17, 50);
            this.downloadBtnLeft.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.downloadBtnLeft.Name = "downloadBtnLeft";
            this.downloadBtnLeft.Size = new System.Drawing.Size(177, 28);
            this.downloadBtnLeft.TabIndex = 0;
            this.downloadBtnLeft.Text = "Download Thread";
            this.downloadBtnLeft.UseVisualStyleBackColor = true;
            this.downloadBtnLeft.Click += new System.EventHandler(this.DownloadBtnLeft_Click);
            // 
            // downloadBtnRight
            // 
            this.downloadBtnRight.Location = new System.Drawing.Point(256, 50);
            this.downloadBtnRight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.downloadBtnRight.Name = "downloadBtnRight";
            this.downloadBtnRight.Size = new System.Drawing.Size(192, 28);
            this.downloadBtnRight.TabIndex = 1;
            this.downloadBtnRight.Text = "Download ThreadPool";
            this.downloadBtnRight.UseVisualStyleBackColor = true;
            this.downloadBtnRight.Click += new System.EventHandler(this.DownloadBtnRight_Click);
            // 
            // urlTextBoxLeft
            // 
            this.urlTextBoxLeft.Location = new System.Drawing.Point(17, 15);
            this.urlTextBoxLeft.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.urlTextBoxLeft.Name = "urlTextBoxLeft";
            this.urlTextBoxLeft.Size = new System.Drawing.Size(431, 22);
            this.urlTextBoxLeft.TabIndex = 2;
            // 
            // urlTextBoxRight
            // 
            this.urlTextBoxRight.Location = new System.Drawing.Point(472, 15);
            this.urlTextBoxRight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.urlTextBoxRight.Name = "urlTextBoxRight";
            this.urlTextBoxRight.Size = new System.Drawing.Size(431, 22);
            this.urlTextBoxRight.TabIndex = 3;
            // 
            // contentTxbLeft
            // 
            this.contentTxbLeft.Location = new System.Drawing.Point(17, 86);
            this.contentTxbLeft.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.contentTxbLeft.Name = "contentTxbLeft";
            this.contentTxbLeft.Size = new System.Drawing.Size(431, 393);
            this.contentTxbLeft.TabIndex = 4;
            this.contentTxbLeft.Text = "";
            // 
            // contentTxbRight
            // 
            this.contentTxbRight.Location = new System.Drawing.Point(472, 86);
            this.contentTxbRight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.contentTxbRight.Name = "contentTxbRight";
            this.contentTxbRight.Size = new System.Drawing.Size(431, 393);
            this.contentTxbRight.TabIndex = 5;
            this.contentTxbRight.Text = "";
            // 
            // logLabelLeft
            // 
            this.logLabelLeft.AutoSize = true;
            this.logLabelLeft.Location = new System.Drawing.Point(16, 526);
            this.logLabelLeft.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.logLabelLeft.Name = "logLabelLeft";
            this.logLabelLeft.Size = new System.Drawing.Size(0, 17);
            this.logLabelLeft.TabIndex = 6;
            // 
            // logLabelRight
            // 
            this.logLabelRight.AutoSize = true;
            this.logLabelRight.Location = new System.Drawing.Point(468, 526);
            this.logLabelRight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.logLabelRight.Name = "logLabelRight";
            this.logLabelRight.Size = new System.Drawing.Size(0, 17);
            this.logLabelRight.TabIndex = 7;
            // 
            // btnDonwloadTask
            // 
            this.btnDonwloadTask.Location = new System.Drawing.Point(472, 50);
            this.btnDonwloadTask.Margin = new System.Windows.Forms.Padding(4);
            this.btnDonwloadTask.Name = "btnDonwloadTask";
            this.btnDonwloadTask.Size = new System.Drawing.Size(141, 28);
            this.btnDonwloadTask.TabIndex = 8;
            this.btnDonwloadTask.Text = "Download Task";
            this.btnDonwloadTask.UseVisualStyleBackColor = true;
            this.btnDonwloadTask.Click += new System.EventHandler(this.btnDonwloadTask_Click);
            // 
            // btnDownloadAsyncTask
            // 
            this.btnDownloadAsyncTask.Location = new System.Drawing.Point(621, 50);
            this.btnDownloadAsyncTask.Margin = new System.Windows.Forms.Padding(4);
            this.btnDownloadAsyncTask.Name = "btnDownloadAsyncTask";
            this.btnDownloadAsyncTask.Size = new System.Drawing.Size(153, 28);
            this.btnDownloadAsyncTask.TabIndex = 9;
            this.btnDownloadAsyncTask.Text = "DL AsyncTask";
            this.btnDownloadAsyncTask.UseVisualStyleBackColor = true;
            this.btnDownloadAsyncTask.Click += new System.EventHandler(this.btnDownloadAsyncTask_Click);
            // 
            // btnDownloadBgWorker
            // 
            this.btnDownloadBgWorker.Location = new System.Drawing.Point(782, 50);
            this.btnDownloadBgWorker.Margin = new System.Windows.Forms.Padding(4);
            this.btnDownloadBgWorker.Name = "btnDownloadBgWorker";
            this.btnDownloadBgWorker.Size = new System.Drawing.Size(121, 28);
            this.btnDownloadBgWorker.TabIndex = 10;
            this.btnDownloadBgWorker.Text = "DL BgWorker";
            this.btnDownloadBgWorker.UseVisualStyleBackColor = true;
            this.btnDownloadBgWorker.Click += new System.EventHandler(this.btnDownloadBgWorker_Click);
            // 
            // UiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 660);
            this.Controls.Add(this.btnDownloadBgWorker);
            this.Controls.Add(this.btnDownloadAsyncTask);
            this.Controls.Add(this.btnDonwloadTask);
            this.Controls.Add(this.logLabelRight);
            this.Controls.Add(this.logLabelLeft);
            this.Controls.Add(this.contentTxbRight);
            this.Controls.Add(this.contentTxbLeft);
            this.Controls.Add(this.urlTextBoxRight);
            this.Controls.Add(this.urlTextBoxLeft);
            this.Controls.Add(this.downloadBtnRight);
            this.Controls.Add(this.downloadBtnLeft);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UiForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button downloadBtnLeft;
        private System.Windows.Forms.Button downloadBtnRight;
        private System.Windows.Forms.TextBox urlTextBoxLeft;
        private System.Windows.Forms.TextBox urlTextBoxRight;
        private System.Windows.Forms.RichTextBox contentTxbLeft;
        private System.Windows.Forms.RichTextBox contentTxbRight;
        private System.Windows.Forms.Label logLabelLeft;
        private System.Windows.Forms.Label logLabelRight;
        private System.Windows.Forms.Button btnDonwloadTask;
        private System.Windows.Forms.Button btnDownloadAsyncTask;
        private System.Windows.Forms.Button btnDownloadBgWorker;
    }
}

