namespace Register
{
    partial class Registerform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registerform));
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbUserName = new System.Windows.Forms.Label();
            this.txtPin = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbPIN = new System.Windows.Forms.Label();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbEmail = new System.Windows.Forms.Label();
            this.btnRegister = new Guna.UI2.WinForms.Guna2Button();
            this.btnBackLogin = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(38)))), ((int)(((byte)(59)))));
            this.txtPassword.Location = new System.Drawing.Point(628, 351);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PlaceholderText = "";
            this.txtPassword.SelectedText = "";
            this.txtPassword.Size = new System.Drawing.Size(448, 41);
            this.txtPassword.TabIndex = 9;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // lbPassword
            // 
            this.lbPassword.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbPassword.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPassword.Location = new System.Drawing.Point(623, 308);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(160, 55);
            this.lbPassword.TabIndex = 8;
            this.lbPassword.Text = "Password:";
            // 
            // txtUsername
            // 
            this.txtUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsername.DefaultText = "";
            this.txtUsername.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUsername.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUsername.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsername.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsername.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUsername.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(38)))), ((int)(((byte)(59)))));
            this.txtUsername.Location = new System.Drawing.Point(628, 252);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PlaceholderText = "";
            this.txtUsername.SelectedText = "";
            this.txtUsername.Size = new System.Drawing.Size(448, 41);
            this.txtUsername.TabIndex = 7;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // lbUserName
            // 
            this.lbUserName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbUserName.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserName.Location = new System.Drawing.Point(623, 210);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(160, 55);
            this.lbUserName.TabIndex = 6;
            this.lbUserName.Text = "Username:";
            // 
            // txtPin
            // 
            this.txtPin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPin.DefaultText = "";
            this.txtPin.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPin.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPin.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPin.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(38)))), ((int)(((byte)(59)))));
            this.txtPin.Location = new System.Drawing.Point(628, 559);
            this.txtPin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPin.Name = "txtPin";
            this.txtPin.PlaceholderText = "";
            this.txtPin.SelectedText = "";
            this.txtPin.Size = new System.Drawing.Size(448, 41);
            this.txtPin.TabIndex = 13;
            this.txtPin.UseSystemPasswordChar = true;
            // 
            // lbPIN
            // 
            this.lbPIN.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbPIN.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPIN.Location = new System.Drawing.Point(623, 517);
            this.lbPIN.Name = "lbPIN";
            this.lbPIN.Size = new System.Drawing.Size(160, 55);
            this.lbPIN.TabIndex = 12;
            this.lbPIN.Text = "Enter PIN:";
            // 
            // txtEmail
            // 
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(38)))), ((int)(((byte)(59)))));
            this.txtEmail.Location = new System.Drawing.Point(628, 455);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderText = "";
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(448, 41);
            this.txtEmail.TabIndex = 11;
            // 
            // lbEmail
            // 
            this.lbEmail.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbEmail.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmail.Location = new System.Drawing.Point(623, 413);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(160, 55);
            this.lbEmail.TabIndex = 10;
            this.lbEmail.Text = "Email:";
            this.lbEmail.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.AllowDrop = true;
            this.btnRegister.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRegister.BackColor = System.Drawing.Color.Transparent;
            this.btnRegister.BorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRegister.BorderRadius = 20;
            this.btnRegister.BorderThickness = 3;
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRegister.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRegister.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRegister.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRegister.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(38)))), ((int)(((byte)(59)))));
            this.btnRegister.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRegister.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(38)))), ((int)(((byte)(59)))));
            this.btnRegister.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(192)))), ((int)(((byte)(152)))));
            this.btnRegister.HoverState.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRegister.Location = new System.Drawing.Point(894, 652);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 4, 4, 0);
            this.btnRegister.Size = new System.Drawing.Size(182, 67);
            this.btnRegister.TabIndex = 14;
            this.btnRegister.Text = "REGISTER";
            this.btnRegister.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.UpperCase;
            this.btnRegister.Tile = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnBackLogin
            // 
            this.btnBackLogin.AllowDrop = true;
            this.btnBackLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBackLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnBackLogin.BorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBackLogin.BorderRadius = 20;
            this.btnBackLogin.BorderThickness = 3;
            this.btnBackLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBackLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBackLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBackLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBackLogin.FillColor = System.Drawing.Color.Gray;
            this.btnBackLogin.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackLogin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBackLogin.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(38)))), ((int)(((byte)(59)))));
            this.btnBackLogin.HoverState.FillColor = System.Drawing.Color.Firebrick;
            this.btnBackLogin.HoverState.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBackLogin.Location = new System.Drawing.Point(628, 652);
            this.btnBackLogin.Name = "btnBackLogin";
            this.btnBackLogin.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 4, 4, 0);
            this.btnBackLogin.Size = new System.Drawing.Size(182, 67);
            this.btnBackLogin.TabIndex = 15;
            this.btnBackLogin.Text = "BACK";
            this.btnBackLogin.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.UpperCase;
            this.btnBackLogin.Tile = true;
            this.btnBackLogin.Click += new System.EventHandler(this.btnBackLogin_Click);
            // 
            // Registerform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Register.Properties.Resources.GiangSinh;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1245, 836);
            this.Controls.Add(this.btnBackLogin);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtPin);
            this.Controls.Add(this.lbPIN);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lbUserName);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Registerform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ KÝ TÚC XÁ BYES";
            this.Load += new System.EventHandler(this.Registerform_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private System.Windows.Forms.Label lbPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private System.Windows.Forms.Label lbUserName;
        private Guna.UI2.WinForms.Guna2TextBox txtPin;
        private System.Windows.Forms.Label lbPIN;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private System.Windows.Forms.Label lbEmail;
        private Guna.UI2.WinForms.Guna2Button btnRegister;
        private Guna.UI2.WinForms.Guna2Button btnBackLogin;
    }
}

