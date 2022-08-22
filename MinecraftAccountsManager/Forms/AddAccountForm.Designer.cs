partial class AddAccountForm
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
            this.CloseB = new System.Windows.Forms.Button();
            this.FormTitle = new System.Windows.Forms.Label();
            this.DisplayP = new System.Windows.Forms.Panel();
            this.ContinueB = new System.Windows.Forms.Button();
            this.NameTB = new System.Windows.Forms.TextBox();
            this.NameL = new System.Windows.Forms.Label();
            this.EmailTB = new System.Windows.Forms.TextBox();
            this.EmailL = new System.Windows.Forms.Label();
            this.PasswordL = new System.Windows.Forms.Label();
            this.AccessTokenL = new System.Windows.Forms.Label();
            this.AccessTokenTB = new System.Windows.Forms.TextBox();
            this.PasswordTB = new System.Windows.Forms.TextBox();
            this.DisplayP.SuspendLayout();
            this.SuspendLayout();
            // 
            // CloseB
            // 
            this.CloseB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseB.FlatAppearance.BorderSize = 0;
            this.CloseB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.CloseB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.CloseB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CloseB.Location = new System.Drawing.Point(280, 0);
            this.CloseB.Margin = new System.Windows.Forms.Padding(0);
            this.CloseB.Name = "CloseB";
            this.CloseB.Size = new System.Drawing.Size(22, 22);
            this.CloseB.TabIndex = 7;
            this.CloseB.Text = "X";
            this.CloseB.UseVisualStyleBackColor = true;
            // 
            // FormTitle
            // 
            this.FormTitle.AutoSize = true;
            this.FormTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FormTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormTitle.Location = new System.Drawing.Point(2, 4);
            this.FormTitle.Name = "FormTitle";
            this.FormTitle.Size = new System.Drawing.Size(120, 24);
            this.FormTitle.TabIndex = 8;
            this.FormTitle.Text = "Add Account";
            // 
            // DisplayP
            // 
            this.DisplayP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.DisplayP.Controls.Add(this.PasswordTB);
            this.DisplayP.Controls.Add(this.AccessTokenTB);
            this.DisplayP.Controls.Add(this.AccessTokenL);
            this.DisplayP.Controls.Add(this.PasswordL);
            this.DisplayP.Controls.Add(this.EmailTB);
            this.DisplayP.Controls.Add(this.EmailL);
            this.DisplayP.Controls.Add(this.ContinueB);
            this.DisplayP.Controls.Add(this.NameTB);
            this.DisplayP.Controls.Add(this.NameL);
            this.DisplayP.Location = new System.Drawing.Point(0, 30);
            this.DisplayP.Name = "DisplayP";
            this.DisplayP.Size = new System.Drawing.Size(300, 109);
            this.DisplayP.TabIndex = 9;
            // 
            // ContinueB
            // 
            this.ContinueB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.ContinueB.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ContinueB.FlatAppearance.BorderSize = 0;
            this.ContinueB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ContinueB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ContinueB.Location = new System.Drawing.Point(6, 85);
            this.ContinueB.Margin = new System.Windows.Forms.Padding(0);
            this.ContinueB.Name = "ContinueB";
            this.ContinueB.Size = new System.Drawing.Size(94, 22);
            this.ContinueB.TabIndex = 8;
            this.ContinueB.Text = "Continue";
            this.ContinueB.UseVisualStyleBackColor = false;
            // 
            // NameTB
            // 
            this.NameTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.NameTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NameTB.ForeColor = System.Drawing.Color.Silver;
            this.NameTB.Location = new System.Drawing.Point(50, 7);
            this.NameTB.MaxLength = 16;
            this.NameTB.Name = "NameTB";
            this.NameTB.Size = new System.Drawing.Size(245, 15);
            this.NameTB.TabIndex = 7;
            // 
            // NameL
            // 
            this.NameL.AutoSize = true;
            this.NameL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NameL.Location = new System.Drawing.Point(4, 6);
            this.NameL.Name = "NameL";
            this.NameL.Size = new System.Drawing.Size(47, 16);
            this.NameL.TabIndex = 0;
            this.NameL.Text = "Name:";
            // 
            // EmailTB
            // 
            this.EmailTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.EmailTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EmailTB.ForeColor = System.Drawing.Color.Silver;
            this.EmailTB.Location = new System.Drawing.Point(46, 27);
            this.EmailTB.MaxLength = 80;
            this.EmailTB.Name = "EmailTB";
            this.EmailTB.Size = new System.Drawing.Size(249, 15);
            this.EmailTB.TabIndex = 10;
            // 
            // EmailL
            // 
            this.EmailL.AutoSize = true;
            this.EmailL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EmailL.Location = new System.Drawing.Point(4, 26);
            this.EmailL.Name = "EmailL";
            this.EmailL.Size = new System.Drawing.Size(44, 16);
            this.EmailL.TabIndex = 9;
            this.EmailL.Text = "Email:";
            // 
            // PasswordL
            // 
            this.PasswordL.AutoSize = true;
            this.PasswordL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PasswordL.Location = new System.Drawing.Point(4, 46);
            this.PasswordL.Name = "PasswordL";
            this.PasswordL.Size = new System.Drawing.Size(70, 16);
            this.PasswordL.TabIndex = 11;
            this.PasswordL.Text = "Password:";
            // 
            // AccessTokenL
            // 
            this.AccessTokenL.AutoSize = true;
            this.AccessTokenL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AccessTokenL.Location = new System.Drawing.Point(4, 66);
            this.AccessTokenL.Name = "AccessTokenL";
            this.AccessTokenL.Size = new System.Drawing.Size(94, 16);
            this.AccessTokenL.TabIndex = 12;
            this.AccessTokenL.Text = "AccessToken:";
            // 
            // AccessTokenTB
            // 
            this.AccessTokenTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.AccessTokenTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AccessTokenTB.ForeColor = System.Drawing.Color.Silver;
            this.AccessTokenTB.Location = new System.Drawing.Point(96, 67);
            this.AccessTokenTB.MaxLength = 1024;
            this.AccessTokenTB.Name = "AccessTokenTB";
            this.AccessTokenTB.Size = new System.Drawing.Size(199, 15);
            this.AccessTokenTB.TabIndex = 13;
            // 
            // PasswordTB
            // 
            this.PasswordTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.PasswordTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasswordTB.ForeColor = System.Drawing.Color.Silver;
            this.PasswordTB.Location = new System.Drawing.Point(70, 47);
            this.PasswordTB.MaxLength = 1024;
            this.PasswordTB.Name = "PasswordTB";
            this.PasswordTB.Size = new System.Drawing.Size(225, 15);
            this.PasswordTB.TabIndex = 14;
            // 
            // AddAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(300, 140);
            this.Controls.Add(this.DisplayP);
            this.Controls.Add(this.FormTitle);
            this.Controls.Add(this.CloseB);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Silver;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddAccountForm";
            this.Text = "AddAccountForm";
            this.DisplayP.ResumeLayout(false);
            this.DisplayP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private Button CloseB;
    private Label FormTitle;
    private Panel DisplayP;
    private Button ContinueB;
    public TextBox NameTB;
    private Label NameL;
    public TextBox EmailTB;
    private Label EmailL;
    private Label AccessTokenL;
    private Label PasswordL;
    public TextBox PasswordTB;
    public TextBox AccessTokenTB;
}