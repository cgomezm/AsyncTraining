namespace UiFormApp
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class UiForm : Form
    {
        public UiForm()
        {
            this.InitializeComponent();
        }

        private void DownloadBtnLeft_Click(object sender, System.EventArgs e)
        {
            var url = this.urlTextBoxLeft.Text;

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var t = new Thread(() =>
           {
               var source = this.DownloadString(url);

               SetControlText(this.contentTxbLeft, source);
               SetControlText(this.logLabelLeft, $@"Downloaded in {stopwatch.ElapsedMilliseconds} ms");
           });

            t.Start();
        }

        private void SetControlText(Control control, string text)
        {
            control.Invoke(new Action(() => control.Text = text));
        }

        private void DownloadBtnRight_Click(object sender, System.EventArgs e)
        {
            var url = this.urlTextBoxRight.Text;

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            ThreadPool.QueueUserWorkItem((state) =>
            {
                var source = this.DownloadString(url);
                SetControlText(this.contentTxbLeft, source);
                SetControlText(this.logLabelLeft, $@"Downloaded in {stopwatch.ElapsedMilliseconds} ms");
            });

        }

        private string DownloadString(string url)
        {

            try
            {
                return new WebClient().DownloadString(url);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private void btnDonwloadTask_Click(object sender, EventArgs e)
        {
            var url = this.urlTextBoxRight.Text;
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var t = new Task<string>(() =>
            {
                return this.DownloadString(url);

            });
            
            t.ContinueWith(prev =>
            {
                var source = prev.Result;
                SetControlText(this.contentTxbRight, source);
                SetControlText(this.logLabelRight, $@"Downloaded in {stopwatch.ElapsedMilliseconds} ms");
            });

            t.Start();
        }

        private async void btnDownloadAsyncTask_Click(object sender, EventArgs e)
        {
            var url = this.urlTextBoxRight.Text;

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var source = await DownloadStringAsync(url);
            this.contentTxbRight.Text = source;
            this.logLabelRight.Text = $@"Downloaded in {stopwatch.ElapsedMilliseconds} ms";
        }

        private async Task<string> DownloadStringAsync(string url)
        {
            try
            {
                var r = await new WebClient().DownloadStringTaskAsync(new Uri(url));
                return r;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private void btnDownloadBgWorker_Click(object sender, EventArgs e)
        {
            var bg = new BackgroundWorker();
            bg.DoWork += Bg_DoWork;
            bg.RunWorkerAsync();
        }

        private void Bg_DoWork(object sender, DoWorkEventArgs e)
        {
            var url = this.urlTextBoxRight.Text; 
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var source = DownloadString(url);
            SetControlText(this.contentTxbRight, source);
            SetControlText(this.logLabelRight, $@"Downloaded in {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}