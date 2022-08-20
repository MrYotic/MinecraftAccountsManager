namespace MinecraftAccountsManager;

partial class MainWindow
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
            this.CloseB = new System.Windows.Forms.Button();
            this.AddAccountB = new System.Windows.Forms.Button();
            this.AccountsP = new System.Windows.Forms.Panel();
            this.CollapseB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CloseB
            // 
            this.CloseB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.CloseB.FlatAppearance.BorderSize = 0;
            this.CloseB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.CloseB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.CloseB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CloseB.Location = new System.Drawing.Point(580, -2);
            this.CloseB.Margin = new System.Windows.Forms.Padding(0);
            this.CloseB.Name = "CloseB";
            this.CloseB.Size = new System.Drawing.Size(22, 22);
            this.CloseB.TabIndex = 0;
            this.CloseB.Text = "X";
            this.CloseB.UseVisualStyleBackColor = false;
            this.CloseB.Click += new System.EventHandler(this.CloseB_Click);
            // 
            // AddAccountB
            // 
            this.AddAccountB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.AddAccountB.FlatAppearance.BorderSize = 0;
            this.AddAccountB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddAccountB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddAccountB.Location = new System.Drawing.Point(537, -2);
            this.AddAccountB.Margin = new System.Windows.Forms.Padding(0);
            this.AddAccountB.Name = "AddAccountB";
            this.AddAccountB.Size = new System.Drawing.Size(22, 22);
            this.AddAccountB.TabIndex = 1;
            this.AddAccountB.Text = "+";
            this.AddAccountB.UseVisualStyleBackColor = false;
            this.AddAccountB.Click += new System.EventHandler(this.AddAccountB_Click);
            // 
            // AccountsP
            // 
            this.AccountsP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.AccountsP.Location = new System.Drawing.Point(0, 20);
            this.AccountsP.Name = "AccountsP";
            this.AccountsP.Size = new System.Drawing.Size(600, 416);
            this.AccountsP.TabIndex = 2;
            // 
            // CollapseB
            // 
            this.CollapseB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.CollapseB.FlatAppearance.BorderSize = 0;
            this.CollapseB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.CollapseB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.CollapseB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CollapseB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CollapseB.Location = new System.Drawing.Point(559, -2);
            this.CollapseB.Margin = new System.Windows.Forms.Padding(0);
            this.CollapseB.Name = "CollapseB";
            this.CollapseB.Size = new System.Drawing.Size(22, 22);
            this.CollapseB.TabIndex = 3;
            this.CollapseB.Text = "卍";
            this.CollapseB.UseVisualStyleBackColor = false;
            this.CollapseB.Click += new System.EventHandler(this.CollapseB_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Lime;
            this.ClientSize = new System.Drawing.Size(600, 436);
            this.Controls.Add(this.CollapseB);
            this.Controls.Add(this.AccountsP);
            this.Controls.Add(this.AddAccountB);
            this.Controls.Add(this.CloseB);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Silver;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.TransparencyKey = System.Drawing.Color.Lime;
            this.ResumeLayout(false);

    }

    #endregion

    private Button CloseB;
    private Button AddAccountB;
    private Panel AccountsP;
    private Button CollapseB;
}
