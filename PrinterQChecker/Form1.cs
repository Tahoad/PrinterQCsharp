using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrinterQChecker
{
    public partial class Form1 : Form
    {
        private Timer refreshTimer;
        private LocalPrintServer localPrintServer;

        public Form1()
        {
            InitializeComponent();
            localPrintServer = new LocalPrintServer();
            InitTimer();

            lstJobs.DrawMode = DrawMode.OwnerDrawFixed;
            lstJobs.DrawItem += LstJobs_DrawItem;
        }

        private void InitTimer()
        {
            refreshTimer = new Timer();
            refreshTimer.Interval = 2000; // 5 วินาที
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            LoadPrinters();
        }

        private void LoadPrinters()
        {
            lstPrinters.Items.Clear();
            try
            {
                var queues = localPrintServer.GetPrintQueues();
                foreach (PrintQueue queue in queues)
                {
                    queue.Refresh();
                    lstPrinters.Items.Add($"{queue.Name} - คิวที่รอพิมพ์: {queue.NumberOfJobs}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
            }
        }

        private void lstPrinters_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstJobs.Items.Clear();
            if (lstPrinters.SelectedItem == null) return;

            string selectedText = lstPrinters.SelectedItem.ToString();
            string printerName = selectedText.Split(new[] { " - " }, StringSplitOptions.None)[0];

            try
            {
                PrintQueue queue = localPrintServer.GetPrintQueue(printerName);
                queue.Refresh();

                PrintJobInfoCollection jobs = queue.GetPrintJobInfoCollection();
                foreach (PrintSystemJobInfo job in jobs)
                {
                    string status = job.JobStatus.ToString(); // เช่น Printing, Paused, Error
                    string item = $"ชื่อเอกสาร: {job.Name}, ผู้ใช้: {job.Submitter}, ขนาด: {job.JobSize} bytes [{status}]";
                    lstJobs.Items.Add(item);
                }

                if (lstJobs.Items.Count == 0)
                    lstJobs.Items.Add("ไม่มีงานในคิว");
            }
            catch (Exception ex)
            {
                lstJobs.Items.Add("เกิดข้อผิดพลาด: " + ex.Message);
            }
        }

        private void btnLoadPrinters_Click(object sender, EventArgs e)
        {
            LoadPrinters();
        }

        private void LstJobs_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= lstJobs.Items.Count) return;

            string itemText = lstJobs.Items[e.Index].ToString();
            e.DrawBackground();

            // กำหนดขนาดฟอนต์ใหม่
            using (Font font = new Font("Segoe UI", 8, FontStyle.Regular))
            {
                // เลือกสีตามสถานะ
                Brush brush = Brushes.Black;
                if (itemText.Contains("Paused") || itemText.Contains("Error") || itemText.Contains("Offline") || itemText.Contains("None"))
                    brush = Brushes.Red;
                else if (itemText.Contains("Printing"))
                    brush = Brushes.Green;

                // วาดข้อความ
                e.Graphics.DrawString(itemText, font, brush, e.Bounds.Left + 4, e.Bounds.Top + 4);

                // วาดเส้นคั่นด้านล่างของรายการ
                using (Pen separatorPen = new Pen(Color.LightGray))
                {
                    e.Graphics.DrawLine(separatorPen, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
                }

                e.DrawFocusRectangle();
            }
        }
    }
}
