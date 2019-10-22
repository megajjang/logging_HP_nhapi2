namespace HP_log_nhapi
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.ED_ID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ED_PWD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ED_PWD2 = new System.Windows.Forms.TextBox();
            this.BTN_LOGIN = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.axCommOCX1 = new AxCOMMOCXLib.AxCommOCX();
            this.BTN_SBC = new System.Windows.Forms.Button();
            this.BTN_SB = new System.Windows.Forms.Button();
            this.LIST_PMCODE = new System.Windows.Forms.ListBox();
            this.ED_PMCODE = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axCommOCX1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // ED_ID
            // 
            this.ED_ID.Location = new System.Drawing.Point(44, 5);
            this.ED_ID.MaxLength = 8;
            this.ED_ID.Name = "ED_ID";
            this.ED_ID.Size = new System.Drawing.Size(69, 21);
            this.ED_ID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "PWD";
            // 
            // ED_PWD
            // 
            this.ED_PWD.Location = new System.Drawing.Point(44, 27);
            this.ED_PWD.MaxLength = 8;
            this.ED_PWD.Name = "ED_PWD";
            this.ED_PWD.PasswordChar = '*';
            this.ED_PWD.Size = new System.Drawing.Size(69, 21);
            this.ED_PWD.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "EPWD";
            // 
            // ED_PWD2
            // 
            this.ED_PWD2.Location = new System.Drawing.Point(44, 49);
            this.ED_PWD2.MaxLength = 256;
            this.ED_PWD2.Name = "ED_PWD2";
            this.ED_PWD2.PasswordChar = '*';
            this.ED_PWD2.Size = new System.Drawing.Size(121, 21);
            this.ED_PWD2.TabIndex = 5;
            // 
            // BTN_LOGIN
            // 
            this.BTN_LOGIN.Location = new System.Drawing.Point(120, 5);
            this.BTN_LOGIN.Name = "BTN_LOGIN";
            this.BTN_LOGIN.Size = new System.Drawing.Size(45, 38);
            this.BTN_LOGIN.TabIndex = 6;
            this.BTN_LOGIN.Text = "Login";
            this.BTN_LOGIN.UseVisualStyleBackColor = true;
            this.BTN_LOGIN.Click += new System.EventHandler(this.BTN_LOGIN_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.axCommOCX1);
            this.groupBox1.Controls.Add(this.BTN_SBC);
            this.groupBox1.Controls.Add(this.BTN_SB);
            this.groupBox1.Controls.Add(this.LIST_PMCODE);
            this.groupBox1.Controls.Add(this.ED_PMCODE);
            this.groupBox1.Location = new System.Drawing.Point(6, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(159, 147);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // axCommOCX1
            // 
            this.axCommOCX1.Enabled = true;
            this.axCommOCX1.Location = new System.Drawing.Point(118, 79);
            this.axCommOCX1.Name = "axCommOCX1";
            this.axCommOCX1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axCommOCX1.OcxState")));
            this.axCommOCX1.Size = new System.Drawing.Size(51, 23);
            this.axCommOCX1.TabIndex = 4;
            this.axCommOCX1.ORecvRealData += new AxCOMMOCXLib._DCommOCXEvents_ORecvRealDataEventHandler(this.axCommOCX1_ORecvRealData);
            this.axCommOCX1.OSocketStatus += new AxCOMMOCXLib._DCommOCXEvents_OSocketStatusEventHandler(this.axCommOCX1_OSocketStatus);
            this.axCommOCX1.ORecvMasterFile += new AxCOMMOCXLib._DCommOCXEvents_ORecvMasterFileEventHandler(this.axCommOCX1_ORecvMasterFile);
            // 
            // BTN_SBC
            // 
            this.BTN_SBC.Enabled = false;
            this.BTN_SBC.Location = new System.Drawing.Point(115, 38);
            this.BTN_SBC.Name = "BTN_SBC";
            this.BTN_SBC.Size = new System.Drawing.Size(44, 23);
            this.BTN_SBC.TabIndex = 3;
            this.BTN_SBC.Text = "SBC";
            this.BTN_SBC.UseVisualStyleBackColor = true;
            this.BTN_SBC.Click += new System.EventHandler(this.BTN_SBC_Click);
            // 
            // BTN_SB
            // 
            this.BTN_SB.Enabled = false;
            this.BTN_SB.Location = new System.Drawing.Point(115, 14);
            this.BTN_SB.Name = "BTN_SB";
            this.BTN_SB.Size = new System.Drawing.Size(44, 23);
            this.BTN_SB.TabIndex = 2;
            this.BTN_SB.Text = "SB";
            this.BTN_SB.UseVisualStyleBackColor = true;
            this.BTN_SB.Click += new System.EventHandler(this.BTN_SB_Click);
            // 
            // LIST_PMCODE
            // 
            this.LIST_PMCODE.FormattingEnabled = true;
            this.LIST_PMCODE.ItemHeight = 12;
            this.LIST_PMCODE.Location = new System.Drawing.Point(7, 38);
            this.LIST_PMCODE.Name = "LIST_PMCODE";
            this.LIST_PMCODE.Size = new System.Drawing.Size(100, 100);
            this.LIST_PMCODE.TabIndex = 1;
            this.LIST_PMCODE.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LIST_PMCODE_KeyUp);
            // 
            // ED_PMCODE
            // 
            this.ED_PMCODE.Location = new System.Drawing.Point(7, 15);
            this.ED_PMCODE.Name = "ED_PMCODE";
            this.ED_PMCODE.Size = new System.Drawing.Size(101, 21);
            this.ED_PMCODE.TabIndex = 0;
            this.ED_PMCODE.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ED_PMCODE_KeyUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(175, 228);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BTN_LOGIN);
            this.Controls.Add(this.ED_PWD2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ED_PWD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ED_ID);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axCommOCX1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ED_ID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ED_PWD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ED_PWD2;
        private System.Windows.Forms.Button BTN_LOGIN;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BTN_SBC;
        private System.Windows.Forms.Button BTN_SB;
        private System.Windows.Forms.ListBox LIST_PMCODE;
        private System.Windows.Forms.TextBox ED_PMCODE;
        private AxCOMMOCXLib.AxCommOCX axCommOCX1;
    }
}

