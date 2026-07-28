namespace Academia
{
    partial class formLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lnkOlvidaPass = new LinkLabel();
            btnIngresar = new Button();
            txtUsuario = new TextBox();
            txtPass = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(428, 175);
            label1.Name = "label1";
            label1.Size = new Size(229, 30);
            label1.TabIndex = 0;
            label1.Text = "¡Bienvenido al Sistema!\r\nPor favor digite su información de Ingreso\r\n";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(352, 239);
            label2.Name = "label2";
            label2.Size = new Size(113, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombre de Usuario:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(395, 302);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 2;
            label3.Text = "Contraseña:";
            // 
            // lnkOlvidaPass
            // 
            lnkOlvidaPass.AutoSize = true;
            lnkOlvidaPass.Location = new Point(449, 357);
            lnkOlvidaPass.Name = "lnkOlvidaPass";
            lnkOlvidaPass.Size = new Size(119, 15);
            lnkOlvidaPass.TabIndex = 3;
            lnkOlvidaPass.TabStop = true;
            lnkOlvidaPass.Text = "Olvide mi contraseña\r\n";
            lnkOlvidaPass.LinkClicked += lnkOlvidaPass_LinkClicked;
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(605, 347);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(88, 35);
            btnIngresar.TabIndex = 4;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(494, 236);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(199, 23);
            txtUsuario.TabIndex = 5;
            // 
            // txtPass
            // 
            txtPass.Location = new Point(494, 299);
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '*';
            txtPass.Size = new Size(199, 23);
            txtPass.TabIndex = 6;
            // 
            // formLogin
            // 
            AcceptButton = btnIngresar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1076, 638);
            Controls.Add(txtPass);
            Controls.Add(txtUsuario);
            Controls.Add(btnIngresar);
            Controls.Add(lnkOlvidaPass);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "formLogin";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Ingreso";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private LinkLabel lnkOlvidaPass;
        private Button btnIngresar;
        private TextBox txtUsuario;
        private TextBox txtPass;
    }
}
