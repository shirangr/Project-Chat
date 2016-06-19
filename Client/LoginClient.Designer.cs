namespace ClientSide
{
    partial class LoginClient
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
            this.lblIP = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblNickname = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.txtbxIP = new System.Windows.Forms.TextBox();
            this.txtbxNickName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.numericPort = new System.Windows.Forms.NumericUpDown();
            this.cbxColor = new System.Windows.Forms.ComboBox();
            this.epIP = new System.Windows.Forms.ErrorProvider(this.components);
            this.epPort = new System.Windows.Forms.ErrorProvider(this.components);
            this.epNickname = new System.Windows.Forms.ErrorProvider(this.components);
            this.epColor = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epNickname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epColor)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(13, 33);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(58, 13);
            this.lblIP.TabIndex = 6;
            this.lblIP.Text = "IP Address";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(13, 72);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(26, 13);
            this.lblPort.TabIndex = 7;
            this.lblPort.Text = "Port";
            // 
            // lblNickname
            // 
            this.lblNickname.AutoSize = true;
            this.lblNickname.Location = new System.Drawing.Point(13, 112);
            this.lblNickname.Name = "lblNickname";
            this.lblNickname.Size = new System.Drawing.Size(55, 13);
            this.lblNickname.TabIndex = 8;
            this.lblNickname.Text = "Nickname";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(13, 153);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(31, 13);
            this.lblColor.TabIndex = 9;
            this.lblColor.Text = "Color";
            // 
            // txtbxIP
            // 
            this.txtbxIP.Location = new System.Drawing.Point(85, 33);
            this.txtbxIP.Name = "txtbxIP";
            this.txtbxIP.Size = new System.Drawing.Size(100, 20);
            this.txtbxIP.TabIndex = 0;
            this.txtbxIP.Text = "127.0.0.1";
            this.txtbxIP.Validating += new System.ComponentModel.CancelEventHandler(this.txtbxIP_Validating);
            // 
            // txtbxNickName
            // 
            this.txtbxNickName.Location = new System.Drawing.Point(85, 111);
            this.txtbxNickName.Name = "txtbxNickName";
            this.txtbxNickName.Size = new System.Drawing.Size(122, 20);
            this.txtbxNickName.TabIndex = 2;
            this.txtbxNickName.Validating += new System.ComponentModel.CancelEventHandler(this.txtbxNickName_Validating);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(16, 198);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(110, 198);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // numericPort
            // 
            this.numericPort.Location = new System.Drawing.Point(85, 72);
            this.numericPort.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
            this.numericPort.Minimum = new decimal(new int[] {
            1025,
            0,
            0,
            0});
            this.numericPort.Name = "numericPort";
            this.numericPort.Size = new System.Drawing.Size(100, 20);
            this.numericPort.TabIndex = 1;
            this.numericPort.Value = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.numericPort.Validating += new System.ComponentModel.CancelEventHandler(this.numericPort_Validating);
            // 
            // cbxColor
            // 
            this.cbxColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxColor.FormattingEnabled = true;
            this.cbxColor.Location = new System.Drawing.Point(85, 150);
            this.cbxColor.Name = "cbxColor";
            this.cbxColor.Size = new System.Drawing.Size(100, 21);
            this.cbxColor.TabIndex = 3;
            this.cbxColor.DropDown += new System.EventHandler(this.cbxColor_DropDown);
            this.cbxColor.Validating += new System.ComponentModel.CancelEventHandler(this.cbxColor_Validating);
            // 
            // epIP
            // 
            this.epIP.ContainerControl = this;
            // 
            // epPort
            // 
            this.epPort.ContainerControl = this;
            // 
            // epNickname
            // 
            this.epNickname.ContainerControl = this;
            // 
            // epColor
            // 
            this.epColor.ContainerControl = this;
            // 
            // LoginClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 246);
            this.Controls.Add(this.cbxColor);
            this.Controls.Add(this.numericPort);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtbxNickName);
            this.Controls.Add(this.txtbxIP);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.lblNickname);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblIP);
            this.Name = "LoginClient";
            this.Text = "LoginWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginClient_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epNickname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblNickname;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.TextBox txtbxIP;
        private System.Windows.Forms.TextBox txtbxNickName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown numericPort;
        private System.Windows.Forms.ComboBox cbxColor;
        private System.Windows.Forms.ErrorProvider epIP;
        private System.Windows.Forms.ErrorProvider epPort;
        private System.Windows.Forms.ErrorProvider epNickname;
        private System.Windows.Forms.ErrorProvider epColor;
    }
}