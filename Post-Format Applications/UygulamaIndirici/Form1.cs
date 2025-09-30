using System;
using System.ComponentModel;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Drawing;

namespace UygulamaIndirici
{
    public partial class Form1 : Form
    {
        private WebClient webClient;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        public Form1()
        {
            InitializeComponent();

            pnlHeader.MouseDown += PnlHeader_MouseDown;

            guna2Button1.Click += (s, e) => this.Close();
            guna2Button1.ForeColor = Color.White;

            guna2Button2.Click += (s, e) => this.WindowState = FormWindowState.Minimized;
            guna2Button2.ForeColor = Color.White;

            btnIndir.Click += BtnIndir_Click;
            button18.Click += Button18_Click;
            button19.Click += Button19_Click;

            guna2ShadowForm1.SetShadowForm(this);

            progressBar1.Value = 0;
            labelStatus.Text = "İndirilmeye hazır...";
            labelProgress.Text = "0%";

            ToolTip toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 100;
            toolTip.ShowAlways = true;

            toolTip.SetToolTip(btnIndir, "dnSpy: .NET uygulamalarını analiz ve düzenlemek için kullanılır.");
            toolTip.SetToolTip(button18, "WinRAR: Sıkıştırılmış dosyaları açmak ve oluşturmak için.");
            toolTip.SetToolTip(button19, "KMSpico: Windows/Office etkinleştirme aracı.");
            toolTip.SetToolTip(guna2Button8, "Display Driver Uninstaller: Ekran kartı sürücülerini tamamen kaldırır.");
            toolTip.SetToolTip(guna2Button9, "WinTools: Sistem bakım ve optimizasyon araçları.");
            toolTip.SetToolTip(guna2Button7, "Everything: Bilgisayardaki dosyaları süper hızlı bulur.");
            toolTip.SetToolTip(guna2Button15, "MemTest86: RAM (bellek) hatalarını test eder.");
            toolTip.SetToolTip(guna2Button14, "Microsoft Toolkit: Microsoft ürünleri için etkinleştirme aracı.");
            toolTip.SetToolTip(guna2Button13, "AnyDesk: Uzak masaüstü bağlantısı kurar.");
            toolTip.SetToolTip(guna2Button12, "Re-Loader: Yazılım lisanslama aracı.");
            toolTip.SetToolTip(guna2Button6, "ExpressVPN: VPN hizmeti sunar.");
            toolTip.SetToolTip(guna2Button11, "IDM: Dosya indirmelerini hızlandırır.");
            toolTip.SetToolTip(guna2Button10, "Rufus: USB'den sistem kurulumu yapar.");
            toolTip.SetToolTip(guna2Button25, "WinToUSB: Windows'u USB belleğe kurar.");
            toolTip.SetToolTip(guna2Button29, "UltraCopier: Dosya kopyalama işlemlerini hızlandırır.");
            toolTip.SetToolTip(guna2Button3, "Glary Disk Cleaner: Disk temizleme aracıdır.");
            toolTip.SetToolTip(guna2Button24, "StartIsBack: Klasik başlat menüsünü geri getirir.");
            toolTip.SetToolTip(guna2Button23, "Wise Program Uninstaller: Programları tamamen kaldırır.");
            toolTip.SetToolTip(guna2Button22, "ChrisPC: İnternet hız sınırlama ve ağ trafiği yönetimi sağlar.");
            toolTip.SetToolTip(guna2Button26, "Hexagon BWMeter: Ağ trafiğini izleme ve bant genişliği ölçme aracı.");
            toolTip.SetToolTip(guna2Button18, "PassFab: Windows parolasını sıfırlamak için kullanılan araç.");
            toolTip.SetToolTip(guna2Button17, "CPU-Z: Sistem donanım bilgilerini detaylı gösteren program.");
            toolTip.SetToolTip(guna2Button4, "Rohos Logon Key: USB belleği Windows giriş anahtarı olarak kullanır.");
            toolTip.SetToolTip(guna2Button16, "Process Hacker: Gelişmiş görev yöneticisi ve işlem analiz aracıdır.");
            toolTip.SetToolTip(guna2Button27, "Systweak Disk Speedup: Disk birleştirme ve optimizasyon aracı.");
            toolTip.SetToolTip(guna2Button5, "KMS Activator Ultimate: Windows ve Office için etkinleştirme aracı.");
            toolTip.SetToolTip(guna2Button21, "Adobe Product Key Finder: Adobe ürün anahtarlarını bulmak için.");
            toolTip.SetToolTip(guna2Button20, "FixWin10: Windows 10 sorunlarını otomatik onaran bir araç.");
            toolTip.SetToolTip(guna2Button19, "Ultimate Windows Tweaker: Windows ince ayar ve özelleştirme aracı.");
            toolTip.SetToolTip(guna2Button28, "Win10 Tweaker: Windows 10'u detaylı bir şekilde özelleştirme yazılımı.");
        }

        private void PnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void BtnIndir_Click(object sender, EventArgs e)
        {
            StartDownload("https://github.com/mehmet2723/MyProgram/raw/main/dnSpy.exe", "dnSpy.exe");
        }

        private void Button18_Click(object sender, EventArgs e)
        {
            StartDownload("https://github.com/mehmet2723/MyProgram/raw/refs/heads/main/WinrarFull.zip", "WinrarFull.zip");
        }

        private void Button19_Click(object sender, EventArgs e)
        {
            StartDownload("https://github.com/mehmet2723/MyProgram/raw/refs/heads/main/KmSpicoFull.zip", "KmSpicoFull.zip");
        }

        private void StartDownload(string url, string dosyaAdi)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Dosyanın kaydedileceği klasörü seçin" })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string klasorYolu = fbd.SelectedPath;
                    string hedefYol = System.IO.Path.Combine(klasorYolu, dosyaAdi);

                    webClient = new WebClient();
                    webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;
                    webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
                    try
                    {
                        webClient.DownloadFileAsync(new Uri(url), hedefYol);
                        labelStatus.Text = $"{dosyaAdi} indiriliyor...";
                        btnIndir.Enabled = false;
                        button18.Enabled = false;
                        button19.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("İndirme başlatılamadı: " + ex.Message);
                        ResetButtons();
                    }
                }
            }
        }

        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            labelProgress.Text = $"{e.ProgressPercentage}%";
        }

        private void WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("İndirme sırasında hata oluştu: " + e.Error.Message);
                labelStatus.Text = "İndirme başarısız oldu.";
            }
            else if (e.Cancelled)
            {
                labelStatus.Text = "İndirme iptal edildi.";
            }
            else
            {
                labelStatus.Text = "İndirme tamamlandı!";
                MessageBox.Show("İndirme tamamlandı!");
            }
            ResetButtons();
        }

        private void ResetButtons()
        {
            btnIndir.Enabled = true;
            button18.Enabled = true;
            button19.Enabled = true;
            progressBar1.Value = 0;
            labelProgress.Text = "0%";
        }

        private void labelStatus_Click(object sender, EventArgs e) { }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            StartDownload("https://github.com/mehmet2723/MyProgram/raw/refs/heads/main/DisplayDriveUninstaller.zip", "DisplayDriverUninstaller.zip");
        }

        private void guna2Button1_Click(object sender, EventArgs e) => this.Close();

        private void guna2Button2_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            StartDownload("https://github.com/mehmet2723/MyProgram/raw/refs/heads/main/WinTools25.zip", "WinTools25.zip");
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            StartDownload("https://github.com/mehmet2723/MyProgram/raw/refs/heads/main/Everything-1.4.1.1028.x64.zip", "Everything.zip");
        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            StartDownload("https://github.com/mehmet2723/MyProgram/raw/refs/heads/main/Memtest86Pro.zip", "Memtest86Pro.zip");
        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            StartDownload("https://github.com/mehmet2723/MyProgram/raw/refs/heads/main/MicToolkit.zip", "MicrosoftToolKit.zip");
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            StartDownload("https://github.com/mehmet2723/MyProgram/raw/refs/heads/main/AnyDesk.zip", "AnyDesk.zip");
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            StartDownload("https://github.com/mehmet2723/MyProgram/raw/refs/heads/main/Re-Loader.zip", "Re-Loader.zip");
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            StartDownload("https://github.com/mehmet2723/MyProgram/raw/refs/heads/main/ExpressVPN.zip", "ExpressVPN.zip");
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            StartDownload("https://github.com/mehmet2723/MyProgram/raw/refs/heads/main/InternetDownloadManager.zip", "InternetDownloadManager.zip");
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            StartDownload("https://github.com/mehmet2723/MyProgram/raw/refs/heads/main/Rufus.zip", "Rufus.zip");
        }

        private void guna2Button25_Click(object sender, EventArgs e)
        {
            StartDownload("https://github.com/mehmet2723/MyProgram/raw/refs/heads/main/WinToUSB.zip", "WinToUSB.zip");
        }

        private void guna2Button29_Click(object sender, EventArgs e)
        {
            StartDownload("https://github.com/mehmet2723/MyProgram/raw/refs/heads/main/UltraCopier.zip", "UltraCopier.zip");
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            StartDownload("https://github.com/mehmet2723/MyProgram/raw/refs/heads/main/GlaryDiskCleaner.zip", "GlaryDiskCleaner.zip");
        }

        private void guna2Button24_Click(object sender, EventArgs e)
        {
            StartDownload("https://github.com/mehmet2723/MyProgram/raw/refs/heads/main/StartIsBack.zip", "StartIsBack.zip");
        }

        private void guna2Button23_Click(object sender, EventArgs e)
        {
            StartDownload("https://github.com/mehmet2723/MyProgram/raw/refs/heads/main/WiseProgramUninstaller.zip", "WiseProgramUninstaller.zip");
        }

        private void guna2Button22_Click(object sender, EventArgs e)
        {
            StartDownload("https://github.com/mehmet2723/MyProgram/raw/refs/heads/main/ChrisPC.zip", "ChrisPC.zip");
        }

        private void guna2Button26_Click(object sender, EventArgs e)
        {
            StartDownload("https://github.com/mehmet2723/MyProgram/raw/refs/heads/main/HexagonBWMeter.zip", "HexagonBWMeter.zip");
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void label1_Click(object sender, EventArgs e) { }

        private void guna2Button18_Click(object sender, EventArgs e)
        {
            StartDownload("https://github.com/mehmet2723/MyProgram/raw/refs/heads/main/PassFab.zip", "PassFab.zip");
        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            StartDownload("https://github.com/mehmet2723/MyProgram/raw/refs/heads/main/CPU-Z.zip", "CPU-Z.zip");
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            StartDownload("https://github.com/mehmet2723/MyProgram/raw/refs/heads/main/RohosLegonKey.zip", "RohosLegonKey.zip");
        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {
            StartDownload("https://github.com/mehmet2723/MyProgram/raw/refs/heads/main/ProcessHacker.zip", "ProcessHacker.zip");
        }

        private void guna2Button27_Click(object sender, EventArgs e)
        {
            StartDownload("https://github.com/mehmet2723/MyProgram/raw/refs/heads/main/SystweakDiskSpeed.zip", "SystweakDiskSpeedup.zip");
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            StartDownload("https://github.com/mehmet2723/MyProgram/raw/refs/heads/main/KMS%20Activator%20Ultimate.zip", "KMSActivatorUltimate.zip");
        }

        private void guna2Button21_Click(object sender, EventArgs e)
        {
            StartDownload("https://github.com/mehmet2723/MyProgram/raw/refs/heads/main/AdobeProductKeyFinder.zip", "AdobeProductKeyFinder.zip");
        }

        private void guna2Button20_Click(object sender, EventArgs e)
        {
            StartDownload("https://github.com/mehmet2723/MyProgram/raw/refs/heads/main/FixWin10.zip", "FixWin10.zip");
        }

        private void guna2Button19_Click(object sender, EventArgs e)
        {
            StartDownload("https://github.com/mehmet2723/MyProgram/raw/refs/heads/main/UWT4.zip", "UltimateWindowsTweaker.zip");
        }

        private void guna2Button28_Click(object sender, EventArgs e)
        {
            StartDownload("https://github.com/mehmet2723/MyProgram/raw/refs/heads/main/Win10Tweaker.zip", "Win10Tweaker.zip");
        }

        private void btnIndir_Click_1(object sender, EventArgs e)
        {
            StartDownload("https://github.com/AtesSoftware/zxc/raw/refs/heads/main/dnSpy-master.zip", "dnSpy.zip");
        }
    }
}
