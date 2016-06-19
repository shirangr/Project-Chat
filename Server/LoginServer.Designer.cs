namespace ServerSide
{
    partial class LoginServer
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
            this.numericPort2 = new System.Windows.Forms.NumericUpDown();
            this.btnCancel2 = new System.Windows.Forms.Button();
            this.btnOK2 = new System.Windows.Forms.Button();
            this.txtbxIP2 = new System.Windows.Forms.TextBox();
            this.lblPort2 = new System.Windows.Forms.Label();
            this.lblIP2 = new System.Windows.Forms.Label();
            this.epIP = new System.Windows.Forms.ErrorProvider(this.components);
            this.epPort = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericPort2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPort)).BeginInit();
            this.SuspendLayout();
            // 
            // numericPort2
            // 
            this.numericPort2.Location = new System.Drawing.Point(91, 66);
            this.numericPort2.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
            this.numericPort2.Minimum = new decimal(new int[] {
            1025,
            0,
            0,
            0});
            this.numericPort2.Name = "numericPort2";
            this.numericPort2.Size = new System.Drawing.Size(100, 20);
            this.numericPort2.TabIndex = 1;
            this.numericPort2.Value = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.numericPort2.Validating += new System.ComponentModel.CancelEventHandler(this.numericPort2_Validating);
            // 
            // btnCancel2
            // 
            this.btnCancel2.Location = new System.Drawing.Point(106, 102);
            this.btnCancel2.Name = "btnCancel2";
            this.btnCancel2.Size = new System.Drawing.Size(75, 23);
            this.btnCancel2.TabIndex = 3;
            this.btnCancel2.Text = "Cancel";
            this.btnCancel2.UseVisualStyleBackColor = true;
            this.btnCancel2.Click += new System.EventHandler(this.btnCancel2_Click);
            // 
            // btnOK2
            // 
            this.btnOK2.Location = new System.Drawing.Point(12, 102);
            this.btnOK2.Name = "btnOK2";
            this.btnOK2.Size = new System.Drawing.Size(75, 23);
            this.btnOK2.TabIndex = 2;
            this.btnOK2.Text = "OK";
            this.btnOK2.UseVisualStyleBackColor = true;
            this.btnOK2.Click += new System.EventHandler(this.btnOK2_Click);
            // 
            // txtbxIP2
            // 
            this.txtbxIP2.Location = new System.Drawing.Point(91, 27);
            this.txtbxIP2.Name = "txtbxIP2";
            this.txtbxIP2.Size = new System.Drawing.Size(100, 20);
            this.txtbxIP2.TabIndex = 0;
            this.txtbxIP2.Text = "127.0.0.1";
            this.txtbxIP2.Validating += new System.ComponentModel.CancelEventHandler(this.txtbxIP2_Validating);
            // 
            // lblPort2
            // 
            this.lblPort2.AutoSize = true;
            this.lblPort2.Location = new System.Drawing.Point(19, 66);
            this.lblPort2.Name = "lblPort2";
            this.lblPort2.Size = new System.Drawing.Size(26, 13);
            this.lblPort2.TabIndex = 13;
            this.lblPort2.Text = "Port";
            // 
            // lblIP2
            // 
            this.lblIP2.AutoSize = true;
            this.lblIP2.Location = new System.Drawing.Point(19, 27);
            this.lblIP2.Name = "lblIP2";
            this.lblIP2.Size = new System.Drawing.Size(58, 13);
            this.lblIP2.TabIndex = 12;
            this.lblIP2.Text = "IP Address";
            // 
            // epIP
            // 
            this.epIP.ContainerControl = this;
            // 
            // epPort
            // 
            this.epPort.ContainerControl = this;
            // 
            // LoginServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 157);
            this.Controls.Add(this.numericPort2);
            this.Controls.Add(this.btnCancel2);
            this.Controls.Add(this.btnOK2);
            this.Controls.Add(this.txtbxIP2);
            this.Controls.Add(this.lblPort2);
            this.Controls.Add(this.lblIP2);
            this.Name = "LoginServer";
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginServer_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericPort2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericPort2;
        private System.Windows.Forms.Button btnCancel2;
        private System.Windows.Forms.Button btnOK2;
        private System.Windows.Forms.TextBox txtbxIP2;
        private System.Windows.Forms.Label lblPort2;
        private System.Windows.Forms.Label lblIP2;
        private System.Windows.Forms.ErrorProvider epIP;
        private System.Windows.Forms.ErrorProvider epPort;
    }
}

