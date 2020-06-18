using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using PcapDotNet.Analysis;
using PcapDotNet.Core;
using PcapDotNet.Packets;
using PcapDotNet.Base;
using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets.Transport;
using PcapDotNet.Packets.Http;
using PcapDotNet.Packets.Icmp;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Threading;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Collections;
using System.Threading.Tasks;
using Ladin.mtaAV.Manager;
using BinarySearch;
using System.Globalization;
using Ladin.mtaAV.Utilities;
using Ladin.mtaAV.Model;
using Ladin.mtaAV.Views;

namespace Ladin.mtaAV.Monitor_SubViews
{
    public partial class UC_Network : UserControl
    {
        #region Variable
        private IList<LivePacketDevice> AdaptersList;
        private PacketDevice selectedAdapter;
        //   private bool first_time = true; //boolean variable needed on re-capturing
        public static byte[] payload;
        public static byte[] command;
        public static Dictionary<int, PacketCapture> packets = new Dictionary<int, PacketCapture>();

        private AbortableBackgroundWorker backgroundWorker1;
        private AbortableBackgroundWorker backgroundWorker2;
        private AbortableBackgroundWorker backgroundWorker3;
        //variabels needed to get info from packet
        private string count = "";
        private string time = "";
        private string source = "";
        private string destination = "";
        private string protocol = "";
        private string length = "";
        private string uri = "";
        private string pathfile = "";
        private string ip_src = "";
        private string ip_dst = "";
        private string mac_src = "";
        private string mac_dst = "";
        private int _source, _destination;
        int no = 0; //stt
        long limitSizeFile = 1024*1024;
        Queue queue = new Queue();
        Queue qfile = new Queue();
        static string runningPath = AppDomain.CurrentDomain.BaseDirectory;
        string saveFile_Download = string.Format("{0}\\Downloads\\", Path.GetFullPath(runningPath));

        #endregion
        public UC_Network()
        {
            InitializeComponent();
            LoadAdapters();
        }
        #region Method
        private void LoadAdapters()
        {
            cbx_LimitSize.SelectedIndex = 0;
            try
            {
                AdaptersList = LivePacketDevice.AllLocalMachine;//locate all adapters
            }
            catch (Exception e)
            {
                MessageBox.Show("Please make sure to run as Adminstrator and install Winpcap" + e.Message);
            }
            PcapDotNetAnalysis.OptIn = true;//enable pcap analysis

            if (AdaptersList.Count == 0)
            {
                MessageBox.Show("No adapters found !!");
                return;
            }
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            int count = 0;
            for (int i = 0; i != AdaptersList.Count; ++i)
            {
                LivePacketDevice Adapter = AdaptersList[i];
                if (Adapter.Description != null)
                {
                    foreach (NetworkInterface adapter in adapters)
                    {
                        var ipProps = adapter.GetIPProperties();
                        IPInterfaceProperties properties = adapter.GetIPProperties();
                        if (adapter.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                        {
                            string s = AdaptersList[count].Name.Remove(0, 20);
                            if (adapter.Id == AdaptersList[i].Name.Remove(0, 20))
                            {
                                cbx_CardNetwork.Items.Add(adapter.Name);
                            }
                        }
                    }
                }
            }
        }
        public byte[] PayloadToArray(Datagram data)
        {
            int payloadlength = data.Length;
            byte[] rx_payload = new byte[payloadlength];
            using (MemoryStream ms = data.ToMemoryStream())
            {
                ms.Read(rx_payload, 0, payloadlength);
            }
            return rx_payload;
        }
        public bool ByteArrayToFile(string fileName, byte[] byteArray)
        {
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(byteArray, 0, byteArray.Length);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in process: {0}", ex);
                return false;
            }
        }

        private void PacketHandle(Packet packet)
        {
            try
            {
                this.count = ""; this.time = ""; this.source = ""; this.destination = ""; this.protocol = ""; this.length = ""; this.uri = ""; this.ip_src = ""; this.ip_dst = "";
                this.mac_src = ""; this.mac_dst = ""; this.uri = "";
                IpV4Datagram ip = packet.Ethernet.IpV4;
                if (packet.Count != 0 && ip.Protocol.ToString().Equals("Tcp") /*&& (save.Checked)*/)
                {
                    ip_src = ip.Source.ToString();
                    ip_dst = ip.Destination.ToString();
                    mac_src = packet.Ethernet.Source.ToString();
                    mac_dst = packet.Ethernet.Destination.ToString();
                    TcpDatagram tcp = ip.Tcp;
                    //UdpDatagram udp = ip.Udp;
                    HttpDatagram httpPacket = null;

                    if (tcp != null) _source = tcp.SourcePort;
                    if (tcp != null) _destination = tcp.DestinationPort;

                    if (tcp != null && tcp.PayloadLength != 0) //not syn or ack
                    {
                        payload = new byte[tcp.PayloadLength];
                        tcp.Payload.ToMemoryStream().Read(payload, 0, tcp.PayloadLength);// read payload from 0 to length
                        if (_destination == 8080 || _destination == 80)// request from server
                        {
                            PacketCapture packet1 = new PacketCapture();
                            if (payload.Count() > 1)
                            {
                                httpPacket = tcp.Http;
                                HttpRequestDatagram re = (HttpRequestDatagram)httpPacket;
                                packet1.Name = re.Uri;
                                string pattern = ".dll$|.pdf$|.exe$|.zip$|.doc$|.docx$|.ppt$";
                                //string pat = ".html$|.css$|.js$|.ico$";
                                string pattern1 = "=";
                                Regex filterfile = new Regex(pattern);
                                Regex dllfile = new Regex(pattern1);
                                //if (filterfile.IsMatch(re.Uri)) return;
                                if (re.Uri != null && dllfile.IsMatch(re.Uri) == false && filterfile.IsMatch(re.Uri)) 
                                {
                                    packets.Add(_source, packet1);
                                    FileDownload fdl = new FileDownload();
                                    fdl.FileName = packet1.Name;
                                    fdl.Source = _source;
                                }
                            }
                        }
                        else if (_source == 8080 || _source == 80)
                            if (packets.ContainsKey(_destination))
                            {
                                httpPacket = tcp.Http;
                                PacketCapture packet1 = packets[_destination];
                                if (packet1.Data == null)
                                {
                                    if (httpPacket.Header != null && httpPacket.Header.ContentLength != null)
                                    {
                                        packet1.Data = new byte[(uint)httpPacket.Header.ContentLength.ContentLength];
                                        Array.Copy(httpPacket.Body.ToMemoryStream().ToArray(), packet1.Data, httpPacket.Body.Length);
                                        packet1.Order = (uint)(tcp.SequenceNumber + payload.Length - httpPacket.Body.Length);
                                        packet1.Data_Length = httpPacket.Body.Length;
                                    }
                                    else
                                    {
                                        Console.WriteLine("temp");
                                        Temp tempPacket = new Temp();
                                        tempPacket.tempSeqNo = (uint)tcp.SequenceNumber;
                                        tempPacket.data = new byte[payload.Length];
                                        Array.Copy(payload, tempPacket.data, payload.Length);
                                        packet1.TempPackets.Add(tempPacket);
                                    }
                                }
                                else
                                {
                                    if (packet1.Data_Length != packet1.Data.Length)
                                    {
                                        uint x = tcp.SequenceNumber - packet1.Order;
                                        Console.WriteLine(x.ToString() + "   " + payload.Length.ToString());

                                        Array.Copy(payload, 0, packet1.Data, tcp.SequenceNumber - packet1.Order, payload.Length);
                                        packet1.Data_Length += payload.Length;
                                    }

                                    if (packet1.Data != null && packet1.Data_Length == packet1.Data.Length)
                                    {
                                        using (BinaryWriter writer = new BinaryWriter(File.Open(saveFile_Download + Directory.CreateDirectory(Path.GetFileName(packet1.Name)), FileMode.Create)))
                                        {
                                            writer.Write(packet1.Data);
                                        }
                                        FileDownload f = new FileDownload();
                                        f.FileName = saveFile_Download + Path.GetFileName(packet1.Name);
                                        f.Source = _destination;
                                        Utilities.Capture cap = new Utilities.Capture(f.FileName, packet1.Data_Length.ToString(), ip_src, ip_dst, mac_src, mac_dst);
                                        f.CaptureNetwork = cap;
                                        lock (qfile)
                                        {
                                            qfile.Enqueue(f);
                                        }
                                        packets.Remove(_destination);
                                        return;
                                    }
                                    if (packet1.Data_Length > packet1.Data.Length)
                                    {
                                        using (BinaryWriter writer = new BinaryWriter(File.Open(saveFile_Download + Directory.CreateDirectory(Path.GetFileName(packet1.Name)), FileMode.Create)))
                                        {
                                            writer.Write(packet1.Data);
                                        }
                                        FileDownload f = new FileDownload();
                                        f.FileName = saveFile_Download + Path.GetFileName(packet1.Name);
                                        f.Source = _destination;
                                        lock (qfile)
                                        {
                                            qfile.Enqueue(f);
                                        }
                                        packets.Remove(_destination);
                                    }
                                }
                            }
                        // ftp control connection
                        if (_destination == 21)
                        {
                            // SIZE
                            // command = 

                            // RETR: yêu cầu tải về


                        }
                        else if (_source == 21)
                        {
                            // 213: Trả về kích cỡ của tệp

                            // 125: Bắt đầu truyền file

                            // lấy Key = Dst(FTP-DATA) = Dst Port + 1 
                        }

                        //Đọc dư liệu FTP
                        if (_source == 20)
                        {

                        }
                    }
                }
            }
            catch { }
        }

        private void ScanFile(FileDownload file)
        {
            //ConnectApi api = new ConnectApi();
            //api.Upload_InfoCapture("api/v1/capture", file.CaptureNetwork);
            string path = file.FileName;
            if (File.Exists(path))
            {
                FileInfo info = new FileInfo(path);
                long FileLength = info.Length;
                if (FileLength > (Convert.ToInt32(cbx_LimitSize.Text) * limitSizeFile))
                {
                    File.Delete(path);
                    return;
                }
                var scanResult = Manage.MD5Scan(path);
                Invoke(new MethodInvoker(delegate
                {
                    int index = dgv_NetworkFile.Rows.Add();
                    DataGridViewRow row = dgv_NetworkFile.Rows[index];
                    row.Tag = file.CaptureNetwork;
                    //if (scanResult.IsEmpty) dgv_NetworkFile.Rows[index].DefaultCellStyle.BackColor = Color.LimeGreen;
                    //else dgv_NetworkFile.Rows[index].DefaultCellStyle.BackColor = Color.OrangeRed;
                    row.Cells["FileName"].Value = Path.GetFileName(path);
                    if (!scanResult.IsEmpty)
                    {
                        row.Cells["Virus"].Value = scanResult.VirusName;
                        Provider.Alert("Phát hiện virus! Kiểm tra file tải về", frmAlert.alertTypeEnum.Warning);
                    }
                    else row.Cells["Virus"].Value = "Không";
                    row.Cells["Type_Scan"].Value = "Tĩnh";
                    row.Cells["Create_Date"].Value = DateTime.Now.ToString("dd/MM/yyyy HH: mm", CultureInfo.InvariantCulture);
                }));
            }
        }

        #endregion

        #region Events

        private void btn_Scan_Click(object sender, EventArgs e)
        {
            Provider.monitoring_NetworkOn = true;
            dgv_NetworkFile.DataSource = null;
            dgv_NetworkFile.Refresh();
            if (cbx_CardNetwork.SelectedIndex >= 0)
            {
                backgroundWorker1 = new AbortableBackgroundWorker
                {
                    WorkerReportsProgress = true,
                    WorkerSupportsCancellation = true
                };
                backgroundWorker2 = new AbortableBackgroundWorker
                {
                    WorkerReportsProgress = true,
                    WorkerSupportsCancellation = true
                };
                backgroundWorker3 = new AbortableBackgroundWorker
                {
                    WorkerReportsProgress = true,
                    WorkerSupportsCancellation = true
                };
                backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
                backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
                backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
                selectedAdapter = AdaptersList[cbx_CardNetwork.SelectedIndex];
                backgroundWorker1.RunWorkerAsync();
                backgroundWorker2.RunWorkerAsync();
                backgroundWorker3.RunWorkerAsync();

                btn_Scan.Enabled = false;

                timer1.Enabled = true;
                timer1.Start();
                no = 0;
            }
            else
            {
                MessageBox.Show("Chọn thiết bị mạng");
            }
        }

        private void btn_PauseScan_Click(object sender, EventArgs e)
        {
            Provider.monitoring_NetworkOn = false;
            ThreadWatcher.StopThread = true;//t
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
                backgroundWorker1.Abort();
                backgroundWorker1.Dispose();
            }
            if (backgroundWorker2.IsBusy)
            {
                backgroundWorker2.Abort();
                backgroundWorker2.Dispose();
            }
            timer1.Stop();
            //saveToolStripMenuItem.Enabled = true;
            btn_Scan.Enabled = true;
        }

        private void btn_CancelScan_Click(object sender, EventArgs e)
        {
            Provider.monitoring_NetworkOn = false;
            ThreadWatcher.StopThread = true;//t
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
                backgroundWorker1.Abort();
                backgroundWorker1.Dispose();
            }
            if (backgroundWorker2.IsBusy)
            {
                backgroundWorker2.CancelAsync();
                backgroundWorker2.Abort();
                backgroundWorker2.Dispose();
            }
            no = 0;
            btn_Scan.Enabled = true;
            timer1.Stop();
        }

        #endregion

        #region Chạy nền bắt gói tin
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.backgroundWorker1.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            using (PacketCommunicator communicator = selectedAdapter.Open(65536, PacketDeviceOpenAttributes.Promiscuous, -1))
            {
                if (communicator.DataLink.Kind != DataLinkKind.Ethernet)
                {
                    MessageBox.Show("This program works only on Ethernet networks!");
                    return;
                }
                Packet packet = null;
                //int s = 0;
                do
                {
                    communicator.ReceivePacket(out packet);
                    if (packet != null && packet.Count != 0)
                    {
                        lock (queue)
                        {
                            queue.Enqueue(packet);
                        }
                    }
                } while (true);
            }
        }
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            do
            {
                Packet snpk = null;
                if (queue.Count == 0) continue;
                else
                {
                    lock (queue)
                    {
                        object pk = queue.Dequeue();
                        snpk = (Packet)pk;
                    }
                    PacketHandle(snpk);
                }
            } while (true);
        }
        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            FileDownload fdl = new FileDownload();
            do
            {
                if (qfile.Count == 0) continue;
                else
                {
                    lock (qfile)
                    {
                        object pk = qfile.Dequeue();
                        fdl = (FileDownload)pk;
                    }
                    ScanFile(fdl);
                }
            } while (true);
        }

        private void dgv_NetworkFile_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string columnName = dgv_NetworkFile.Columns[e.ColumnIndex].Name;
            if (columnName == "Check_File")
            {
                string path = saveFile_Download + dgv_NetworkFile.Rows[e.RowIndex].Cells["FileName"].Value.ToString();
                string[] file = { path };
                ConnectApi api = new ConnectApi();
                Provider.Alert("Bắt đầu phân tích động... !", frmAlert.alertTypeEnum.Info);
                dgv_NetworkFile.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Properties.Resources.icons8_Loader_32;
                try
                {
                    Task.Run(new Action(() => {
                        var task = api.Upload_MultiFiles<QUARANTINES>("api/v1/capture/check", file, (Utilities.Capture)dgv_NetworkFile.Rows[e.RowIndex].Tag);
                        QUARANTINES kq = task.First();
                        kq.FILENAME = path;
                        dgv_NetworkFile.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Properties.Resources.Checked_48px;
                        dgv_NetworkFile.Rows[e.RowIndex].Cells["Virus"].Value = "Có";
                        dgv_NetworkFile.Rows[e.RowIndex].Cells["Type_Scan"].Value = "Động";
                        dgv_NetworkFile.Refresh();
                        //Provider.Alert(Path.GetFileName(path) + " nhiễm mã độc! Kiểm tra file tải về", frmAlert.alertTypeEnum.Warning);
                        BeginInvoke(new Action(() =>
                        {
                            Provider.Alert(Path.GetFileName(path) + " nhiễm mã độc! Kiểm tra file tải về", frmAlert.alertTypeEnum.Warning);
                        }));
                        if (kq.VIRUS == "1")
                        {
                            Provider.list_NewQuarantines.Add(kq);
                            dgv_NetworkFile.Rows[e.RowIndex].Cells["Virus"].Value = "Có";
                            dgv_NetworkFile.Rows[e.RowIndex].Cells["Type_Scan"].Value = "Động";
                            dgv_NetworkFile.Refresh();
                            //Provider.Alert(Path.GetFileName(path) + " nhiễm mã độc! Kiểm tra file tải về", frmAlert.alertTypeEnum.Warning);
                            BeginInvoke(new Action(() =>
                            {
                                Provider.Alert(Path.GetFileName(path) + " nhiễm mã độc! Kiểm tra file tải về", frmAlert.alertTypeEnum.Warning);
                            }));
                        }
                        else
                        {
                            dgv_NetworkFile.Rows[e.RowIndex].Cells["Virus"].Value = "Không";
                            dgv_NetworkFile.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Properties.Resources.icons8_Telegram_App_32;
                        }
                    }));
                }
                catch {
                    Provider.Alert("Lỗi kết nối", frmAlert.alertTypeEnum.Error);
                }
            }
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            for (int i = dgv_NetworkFile.Rows.Count - 1; i >= 0; i--)
            {
                string path = "";
                try
                {
                    path = saveFile_Download + dgv_NetworkFile.Rows[i].Cells["FILENAME"].Value.ToString();
                    File.Delete(path);
                    Directory.Delete(runningPath + dgv_NetworkFile.Rows[i].Cells["FILENAME"].Value.ToString());
                }
                catch { }
                dgv_NetworkFile.Rows.RemoveAt(i);
            }
            dgv_NetworkFile.Refresh();
        }
        #endregion
    }

    public static class ThreadWatcher
    {
        public static bool StopThread { get; set; }
    }
    public class AbortableBackgroundWorker : BackgroundWorker
    {

        private Thread workerThread;

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            workerThread = Thread.CurrentThread;
            try
            {
                base.OnDoWork(e);
            }
            catch (ThreadAbortException)
            {
                e.Cancel = true;
                Thread.ResetAbort();
            }
        }
        public void Abort()
        {
            if (workerThread != null)
            {
                workerThread.Abort();
                workerThread = null;
            }
        }
    }
}
