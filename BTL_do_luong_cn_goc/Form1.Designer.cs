namespace BTL_do_luong_cn
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
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCOM = new System.Windows.Forms.ComboBox();
            this.cboBaudrate = new System.Windows.Forms.ComboBox();
            this.BttConnect = new System.Windows.Forms.Button();
            this.BttDisconnect = new System.Windows.Forms.Button();
            this.BttExit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lbState = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.serCOM = new System.IO.Ports.SerialPort(this.components);
            this.textBoxA = new System.Windows.Forms.TextBox();
            this.textBoxB = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSetC2 = new System.Windows.Forms.Button();
            this.btnSetC1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.trackBarB = new System.Windows.Forms.TrackBar();
            this.trackBarA = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarA)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select COM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Select Baudrate";
            // 
            // cboCOM
            // 
            this.cboCOM.FormattingEnabled = true;
            this.cboCOM.Location = new System.Drawing.Point(219, 55);
            this.cboCOM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboCOM.Name = "cboCOM";
            this.cboCOM.Size = new System.Drawing.Size(143, 33);
            this.cboCOM.TabIndex = 3;
            // 
            // cboBaudrate
            // 
            this.cboBaudrate.FormattingEnabled = true;
            this.cboBaudrate.Location = new System.Drawing.Point(219, 124);
            this.cboBaudrate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboBaudrate.Name = "cboBaudrate";
            this.cboBaudrate.Size = new System.Drawing.Size(143, 33);
            this.cboBaudrate.TabIndex = 4;
            // 
            // BttConnect
            // 
            this.BttConnect.BackColor = System.Drawing.Color.Lime;
            this.BttConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BttConnect.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BttConnect.Location = new System.Drawing.Point(28, 366);
            this.BttConnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BttConnect.Name = "BttConnect";
            this.BttConnect.Size = new System.Drawing.Size(143, 50);
            this.BttConnect.TabIndex = 5;
            this.BttConnect.Text = "Connect";
            this.BttConnect.UseVisualStyleBackColor = false;
            this.BttConnect.Click += new System.EventHandler(this.BttConnect_Click);
            // 
            // BttDisconnect
            // 
            this.BttDisconnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.BttDisconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BttDisconnect.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BttDisconnect.Location = new System.Drawing.Point(213, 366);
            this.BttDisconnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BttDisconnect.Name = "BttDisconnect";
            this.BttDisconnect.Size = new System.Drawing.Size(143, 50);
            this.BttDisconnect.TabIndex = 6;
            this.BttDisconnect.Text = "Disconnect";
            this.BttDisconnect.UseVisualStyleBackColor = false;
            this.BttDisconnect.Click += new System.EventHandler(this.BttDisconnect_Click);
            // 
            // BttExit
            // 
            this.BttExit.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BttExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BttExit.Location = new System.Drawing.Point(117, 447);
            this.BttExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BttExit.Name = "BttExit";
            this.BttExit.Size = new System.Drawing.Size(144, 46);
            this.BttExit.TabIndex = 7;
            this.BttExit.Text = "Exit";
            this.BttExit.UseVisualStyleBackColor = false;
            this.BttExit.Click += new System.EventHandler(this.BttExit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 289);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "State";
            // 
            // lbState
            // 
            this.lbState.AutoSize = true;
            this.lbState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbState.Location = new System.Drawing.Point(213, 289);
            this.lbState.Name = "lbState";
            this.lbState.Size = new System.Drawing.Size(143, 25);
            this.lbState.TabIndex = 9;
            this.lbState.Text = "Disconnected";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "Receive Data";
            // 
            // serCOM
            // 
            this.serCOM.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serCOM_DataReceived);
            // 
            // textBoxA
            // 
            this.textBoxA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxA.Location = new System.Drawing.Point(461, 49);
            this.textBoxA.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxA.Multiline = true;
            this.textBoxA.Name = "textBoxA";
            this.textBoxA.ReadOnly = true;
            this.textBoxA.Size = new System.Drawing.Size(107, 34);
            this.textBoxA.TabIndex = 14;
            // 
            // textBoxB
            // 
            this.textBoxB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxB.Location = new System.Drawing.Point(461, 113);
            this.textBoxB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxB.Multiline = true;
            this.textBoxB.Name = "textBoxB";
            this.textBoxB.ReadOnly = true;
            this.textBoxB.Size = new System.Drawing.Size(107, 31);
            this.textBoxB.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSetC2);
            this.groupBox1.Controls.Add(this.btnSetC1);
            this.groupBox1.Controls.Add(this.textBoxB);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBoxA);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.trackBarB);
            this.groupBox1.Controls.Add(this.trackBarA);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(687, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(712, 184);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Calib";
            // 
            // btnSetC2
            // 
            this.btnSetC2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSetC2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSetC2.Location = new System.Drawing.Point(588, 99);
            this.btnSetC2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSetC2.Name = "btnSetC2";
            this.btnSetC2.Size = new System.Drawing.Size(118, 52);
            this.btnSetC2.TabIndex = 21;
            this.btnSetC2.Text = "Send C2";
            this.btnSetC2.UseVisualStyleBackColor = false;
            this.btnSetC2.Click += new System.EventHandler(this.btnSetC2_Click);
            // 
            // btnSetC1
            // 
            this.btnSetC1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSetC1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSetC1.Location = new System.Drawing.Point(588, 38);
            this.btnSetC1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSetC1.Name = "btnSetC1";
            this.btnSetC1.Size = new System.Drawing.Size(118, 52);
            this.btnSetC1.TabIndex = 20;
            this.btnSetC1.Text = "Send C1";
            this.btnSetC1.UseVisualStyleBackColor = false;
            this.btnSetC1.Click += new System.EventHandler(this.btnSetC1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(35, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 25);
            this.label8.TabIndex = 19;
            this.label8.Text = "C2 value";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(35, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 25);
            this.label7.TabIndex = 18;
            this.label7.Text = "C1 value";
            // 
            // trackBarB
            // 
            this.trackBarB.LargeChange = 50;
            this.trackBarB.Location = new System.Drawing.Point(125, 113);
            this.trackBarB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBarB.Maximum = 800;
            this.trackBarB.Name = "trackBarB";
            this.trackBarB.Size = new System.Drawing.Size(331, 56);
            this.trackBarB.TabIndex = 13;
            this.trackBarB.Scroll += new System.EventHandler(this.trackBarB_Scroll);
            // 
            // trackBarA
            // 
            this.trackBarA.Location = new System.Drawing.Point(125, 46);
            this.trackBarA.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBarA.Maximum = 800;
            this.trackBarA.Name = "trackBarA";
            this.trackBarA.Size = new System.Drawing.Size(331, 56);
            this.trackBarA.TabIndex = 12;
            this.trackBarA.Scroll += new System.EventHandler(this.trackBarA_Scroll);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lbState);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.BttExit);
            this.groupBox2.Controls.Add(this.cboBaudrate);
            this.groupBox2.Controls.Add(this.BttDisconnect);
            this.groupBox2.Controls.Add(this.cboCOM);
            this.groupBox2.Controls.Add(this.BttConnect);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(9, 12);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(645, 527);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Serial Port";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(28, 233);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(595, 36);
            this.textBox1.TabIndex = 11;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(687, 196);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(5);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(712, 337);
            this.zedGraphControl1.TabIndex = 21;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1426, 569);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarA)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboCOM;
        private System.Windows.Forms.ComboBox cboBaudrate;
        private System.Windows.Forms.Button BttConnect;
        private System.Windows.Forms.Button BttDisconnect;
        private System.Windows.Forms.Button BttExit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbState;
        private System.Windows.Forms.Label label6;
        private System.IO.Ports.SerialPort serCOM;
        private System.Windows.Forms.TextBox textBoxA;
        private System.Windows.Forms.TextBox textBoxB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSetC1;
        private System.Windows.Forms.TrackBar trackBarB;
        private System.Windows.Forms.TrackBar trackBarA;
        private System.Windows.Forms.Button btnSetC2;
    }
}

