using System;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Windows.Forms;
using ZedGraph;
using System.IO;

namespace BTL_do_luong_cn
{
    public partial class Form1 : Form
    {
        string excelPath = "distance_data.csv";
        int tong = 0;
        bool calibDoneShown = false;

        public Form1()
        {
            InitializeComponent();

            string[] Baudrate = { "2400", "9600", "115200" };
            cboBaudrate.Items.AddRange(Baudrate);

            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxA.Text = (trackBarA.Value * 0.1).ToString("0.0");
            textBoxB.Text = (trackBarB.Value * 0.1).ToString("0.0");

            GraphPane mypanne = zedGraphControl1.GraphPane;
            mypanne.Title.Text = "Sensor measurement";
            mypanne.XAxis.Title.Text = "Time (s)";
            mypanne.YAxis.Title.Text = "Distance (cm)";

            RollingPointPairList list = new RollingPointPairList(60000);
            mypanne.AddCurve("Calibrated Distance C", list, Color.Red, SymbolType.Circle);

            mypanne.XAxis.Scale.Min = 0;
            mypanne.XAxis.Scale.MinorStep = 1;
            mypanne.XAxis.Scale.MajorStep = 5;

            mypanne.YAxis.Scale.Min = 0;
            mypanne.YAxis.Scale.Max = 100;
            mypanne.YAxis.Scale.MinorStep = 5;
            mypanne.YAxis.Scale.MajorStep = 10;

            zedGraphControl1.AxisChange();

            cboBaudrate.Text = "115200";
            cboCOM.DataSource = SerialPort.GetPortNames();

            // Tạo file CSV nếu chưa tồn tại
            if (!File.Exists(excelPath))
            {
                File.WriteAllText(excelPath, "Time,D,C,a,b\n");
            }
        }

        private string GetNumberOnly(string text)
        {
            return text.Replace("cm", "").Replace("CM", "").Trim().Replace(",", ".");
        }

        private bool TryGetValueFromTextBox(TextBox tb, out double value)
        {
            string cleanText = GetNumberOnly(tb.Text);

            return double.TryParse(cleanText, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
        }

        public void draw(double line)
        {
            LineItem duongline = zedGraphControl1.GraphPane.CurveList[0] as LineItem;
            if (duongline == null) return;

            IPointListEdit list = duongline.Points as IPointListEdit;
            if (list == null) return;

            list.Add(tong, line);

            GraphPane pane = zedGraphControl1.GraphPane;

            // Hiển thị cửa sổ 100 điểm gần nhất
            if (tong > 100)
            {
                pane.XAxis.Scale.Min = tong - 100;
                pane.XAxis.Scale.Max = tong;
            }
            else
            {
                pane.XAxis.Scale.Min = 0;
                pane.XAxis.Scale.Max = 100;
            }

            // Trục Y theo khoảng cách sau calib C
            pane.YAxis.Scale.Min = 0;
            pane.YAxis.Scale.Max = Math.Max(100, line + 20);

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();

            tong += 1;
        }

        private void trackBarA_Scroll(object sender, EventArgs e)
        {
            double value = trackBarA.Value * 0.1;
            textBoxA.Text = value.ToString("0.0", CultureInfo.InvariantCulture);
        }

        private void trackBarB_Scroll(object sender, EventArgs e)
        {
            double value = trackBarB.Value * 0.1;
            textBoxB.Text = value.ToString("0.0", CultureInfo.InvariantCulture);
        }

        private void textBoxA_TextChanged(object sender, EventArgs e)
        {
            if (TryGetValueFromTextBox(textBoxA, out double value))
            {
                int trackValue = (int)(value * 10);

                if (trackValue >= trackBarA.Minimum && trackValue <= trackBarA.Maximum)
                {
                    trackBarA.Value = trackValue;
                }
            }
        }

        private void textBoxB_TextChanged(object sender, EventArgs e)
        {
            if (TryGetValueFromTextBox(textBoxB, out double value))
            {
                int trackValue = (int)(value * 10);

                if (trackValue >= trackBarB.Minimum && trackValue <= trackBarB.Maximum)
                {
                    trackBarB.Value = trackValue;
                }
            }
        }

        private void BttConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (serCOM.IsOpen)
                    serCOM.Close();

                serCOM.PortName = cboCOM.Text;
                serCOM.BaudRate = Convert.ToInt32(cboBaudrate.Text);
                serCOM.NewLine = "\n";

                serCOM.Open();

                serCOM.DtrEnable = true;
                System.Threading.Thread.Sleep(2000);

                serCOM.DiscardInBuffer();
                serCOM.DiscardOutBuffer();

                lbState.Text = "Connected";
                lbState.ForeColor = Color.Green;
            }
            catch
            {
                MessageBox.Show("Invalid COM");
            }
        }

        private void BttDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (serCOM.IsOpen)
                    serCOM.Close();

                lbState.Text = "Disconnected";
                lbState.ForeColor = Color.Red;
            }
            catch
            {
                MessageBox.Show("Disconnect error");
            }
        }

        private void BttExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSetC1_Click(object sender, EventArgs e)
        {
            if (!serCOM.IsOpen) return;

            if (!TryGetValueFromTextBox(textBoxA, out double value))
            {
                MessageBox.Show("Giá trị C1 không hợp lệ");
                return;
            }

            calibDoneShown = false;

            string sendValue = value.ToString("0.0", CultureInfo.InvariantCulture);
            serCOM.WriteLine("c1=" + sendValue);
        }

        private void btnSetC2_Click(object sender, EventArgs e)
        {
            if (!serCOM.IsOpen) return;

            if (!TryGetValueFromTextBox(textBoxB, out double value))
            {
                MessageBox.Show("Giá trị C2 không hợp lệ");
                return;
            }

            calibDoneShown = false;

            string sendValue = value.ToString("0.0", CultureInfo.InvariantCulture);
            serCOM.WriteLine("c2=" + sendValue);
        }

        private void serCOM_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!serCOM.IsOpen) return;

            try
            {
                string data = serCOM.ReadLine().Trim();

                this.Invoke(new MethodInvoker(() =>
                {
                    textBox1.Text = data;

                    if (data.Contains("SET_C1_DONE"))
                    {
                        MessageBox.Show("Đã lưu điểm C1");
                    }

                    if (data.Contains("SET_C2_DONE"))
                    {
                        MessageBox.Show("Đã lưu điểm C2");
                    }

                    if (data.Contains("CALIB_DONE") && !calibDoneShown)
                    {
                        MessageBox.Show("Hiệu chỉnh thành công!");
                        calibDoneShown = true;
                    }

                    if (data.Contains("CALIB_ERROR"))
                    {
                        MessageBox.Show("Lỗi hiệu chỉnh: 2 điểm calib quá gần nhau");
                    }

                    if (data.StartsWith("D = "))
                    {
                        ParseArduinoData(data);
                    }
                }));
            }
            catch
            {
            }
        }

        private void ParseArduinoData(string data)
        {
            try
            {
                string[] parts = data.Split('|');

                if (parts.Length < 4) return;

                double D = Convert.ToDouble(
                    parts[0].Replace("D =", "").Trim(),
                    CultureInfo.InvariantCulture
                );

                double C = Convert.ToDouble(
                    parts[1].Replace("C =", "").Trim(),
                    CultureInfo.InvariantCulture
                );

                double A = Convert.ToDouble(
                    parts[2].Replace("a =", "").Trim(),
                    CultureInfo.InvariantCulture
                );

                double B = Convert.ToDouble(
                    parts[3].Replace("b =", "").Trim(),
                    CultureInfo.InvariantCulture
                );

                draw(C);

                // Ghi dữ liệu vào file CSV
                string line = DateTime.Now.ToString("HH:mm:ss") + "," +
              D.ToString("0.00", CultureInfo.InvariantCulture) + "," +
              C.ToString("0.00", CultureInfo.InvariantCulture) + "," +
              A.ToString("0.0000", CultureInfo.InvariantCulture) + "," +
              B.ToString("0.0000", CultureInfo.InvariantCulture) + "\n";

                File.AppendAllText(excelPath, line);
            }
            catch
            {
            }
        }
    }
}