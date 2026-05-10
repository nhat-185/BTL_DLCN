using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using ZedGraph;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Linq.Expressions;

namespace BTL_do_luong_cn
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
            string[] Baudrate = {"2400","9600","115200"};
            cboBaudrate.Items.AddRange(Baudrate);
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxA.Text = trackBarA.Value.ToString();
            textBoxB.Text = trackBarB.Value.ToString();

            GraphPane mypanne = zedGraphControl1.GraphPane;
            mypanne.Title.Text = "Sensor measurement";
            mypanne.XAxis.Title.Text = "Time (s)";
            mypanne.YAxis.Title.Text = "Distance (cm)";
            RollingPointPairList list = new RollingPointPairList(60000);
            LineItem dothi = mypanne.AddCurve("Distance", list, Color.Red, SymbolType.Circle);

            mypanne.XAxis.Scale.Min = 0;
            mypanne.XAxis.Scale.MinorStep = 1;
            mypanne.XAxis.Scale.MajorStep = 5;

            mypanne.YAxis.Scale.Min = 0;
            mypanne.YAxis.Scale.MinorStep = 1;
            mypanne.YAxis.Scale.MajorStep = 5;

            zedGraphControl1.AxisChange();

            cboBaudrate.Text = "115200";
            cboCOM.DataSource = SerialPort.GetPortNames();
        }

        int tong = 0;
        public void draw(double line)
        {
            LineItem duongline = zedGraphControl1.GraphPane.CurveList[0] as LineItem;
            if (duongline == null)
                return;
            IPointListEdit list = duongline.Points as IPointListEdit;
            if (list == null)
                return;

            list.Add(tong, line);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            tong += 1;
        }

        // Đồng bộ giá trị của trackBar với textBox
        private void trackBarA_Scroll(object sender, EventArgs e)
        {
            double value = trackBarA.Value * 0.1;
            textBoxA.Text = value.ToString("0.0") + " cm";
        }

        private void trackBarB_Scroll(object sender, EventArgs e)
        {
            double value = trackBarB.Value * 0.1;
            textBoxB.Text = value.ToString("0.0") + " cm";
        }


        private void textBoxA_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxA.Text, out double value))
            {
                trackBarA.Value = (int)(value * 10);
            }
        }

        private void textBoxB_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxB.Text, out double value))
            {
                trackBarB.Value = (int)(value * 10);
            }
        }

        //

        private void BttConnect_Click(object sender, EventArgs e)
        {
            try
            {
                serCOM.PortName = cboCOM.Text;
                serCOM.BaudRate = Convert.ToInt32(cboBaudrate.Text);
                serCOM.Open();

                serCOM.DtrEnable = true; // reset Arduino
                System.Threading.Thread.Sleep(500);

                if (serCOM.IsOpen)
                {
                    lbState.Text = "Connected";
                    lbState.ForeColor = Color.Green;
                }
            }
            catch
            {
                MessageBox.Show("Invalid COM");
            }
        }

        private void BttDisconnect_Click(object sender, EventArgs e)
        {
            serCOM.Close();
            if(!serCOM.IsOpen)
            {
                lbState.Text = "Disconnected";
                lbState.ForeColor = Color.Red;
            }
        }

        private void BttExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void btnSetC1_Click(object sender, EventArgs e)
        {
            if (!serCOM.IsOpen) return;

            serCOM.WriteLine("c1=" + textBoxA.Text);
        }
        private void btnSetC2_Click(object sender, EventArgs e)
        {
            if (!serCOM.IsOpen) return;

            serCOM.WriteLine("c2=" + textBoxB.Text);
        }

        bool calibDoneShown = false; // Biến để đảm bảo chỉ hiển thị thông báo hiệu chỉnh thành công một lần
        private void serCOM_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!serCOM.IsOpen) return;

            try
            {
                string data = serCOM.ReadLine();

                this.Invoke(new MethodInvoker(() =>
                {
                    textBox1.Text = data;

                    // Báo trạng thái
                    if (data.Contains("SET_C1_DONE"))
                        MessageBox.Show("Đã lưu điểm C1");

                    if (data.Contains("SET_C2_DONE"))
                        MessageBox.Show("Đã lưu điểm C2");

                    if (data.Contains("CALIB_DONE") && !calibDoneShown)
                    {
                        MessageBox.Show("Hiệu chỉnh thành công!");
                        calibDoneShown = true;
                    }
                    // Vẽ đồ thị
                    int index = data.IndexOf("C = ");
                    if (index != -1)
                    {
                        string valueStr = data.Substring(index + 4).Split('|')[0].Trim();
                        if (double.TryParse(valueStr, out double value))
                        {
                            draw(value);
                        }
                    }
                }));
            }
            catch { }
        }
    }
}
