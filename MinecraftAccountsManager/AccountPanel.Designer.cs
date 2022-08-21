namespace MinecraftAccountsManager;

partial class AccountPanel
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.SkinHeadAvatarPB = new System.Windows.Forms.PictureBox();
            this.NameL = new System.Windows.Forms.Label();
            this.StatusL = new System.Windows.Forms.Label();
            this.ActiveWindowB = new System.Windows.Forms.Button();
            this.LaunchB = new System.Windows.Forms.Button();
            this.HealthL = new System.Windows.Forms.Label();
            this.ChangeAccountB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SkinHeadAvatarPB)).BeginInit();
            this.SuspendLayout();
            // 
            // SkinHeadAvatarPB
            // 
            this.SkinHeadAvatarPB.Location = new System.Drawing.Point(2, 2);
            this.SkinHeadAvatarPB.Name = "SkinHeadAvatarPB";
            this.SkinHeadAvatarPB.Size = new System.Drawing.Size(32, 32);
            this.SkinHeadAvatarPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.SkinHeadAvatarPB.TabIndex = 0;
            this.SkinHeadAvatarPB.TabStop = false;
            // 
            // NameL
            // 
            this.NameL.AutoSize = true;
            this.NameL.Location = new System.Drawing.Point(37, 2);
            this.NameL.Name = "NameL";
            this.NameL.Size = new System.Drawing.Size(73, 16);
            this.NameL.TabIndex = 1;
            this.NameL.Text = "UserName";
            // 
            // StatusL
            // 
            this.StatusL.AutoSize = true;
            this.StatusL.Location = new System.Drawing.Point(37, 18);
            this.StatusL.Name = "StatusL";
            this.StatusL.Size = new System.Drawing.Size(90, 16);
            this.StatusL.TabIndex = 4;
            this.StatusL.Text = "Not Launched";
            // 
            // ActiveWindowB
            // 
            this.ActiveWindowB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.ActiveWindowB.Enabled = false;
            this.ActiveWindowB.FlatAppearance.BorderSize = 0;
            this.ActiveWindowB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.ActiveWindowB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.ActiveWindowB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ActiveWindowB.Location = new System.Drawing.Point(329, 2);
            this.ActiveWindowB.Name = "ActiveWindowB";
            this.ActiveWindowB.Size = new System.Drawing.Size(54, 30);
            this.ActiveWindowB.TabIndex = 5;
            this.ActiveWindowB.Text = "Active";
            this.ActiveWindowB.UseVisualStyleBackColor = false;
            this.ActiveWindowB.Click += new System.EventHandler(this.ActiveWindow_Click);
            // 
            // LaunchB
            // 
            this.LaunchB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.LaunchB.FlatAppearance.BorderSize = 0;
            this.LaunchB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.LaunchB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.LaunchB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LaunchB.Location = new System.Drawing.Point(259, 2);
            this.LaunchB.Name = "LaunchB";
            this.LaunchB.Size = new System.Drawing.Size(64, 30);
            this.LaunchB.TabIndex = 6;
            this.LaunchB.Text = "Launch";
            this.LaunchB.UseVisualStyleBackColor = false;
            this.LaunchB.Click += new System.EventHandler(this.LaunchB_Click);
            // 
            // HealthL
            // 
            this.HealthL.AutoSize = true;
            this.HealthL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HealthL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HealthL.Location = new System.Drawing.Point(173, 16);
            this.HealthL.Name = "HealthL";
            this.HealthL.Size = new System.Drawing.Size(25, 16);
            this.HealthL.TabIndex = 7;
            this.HealthL.Text = "hp:";
            this.HealthL.Visible = false;
            // 
            // ChangeAccountB
            // 
            this.ChangeAccountB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.ChangeAccountB.FlatAppearance.BorderSize = 0;
            this.ChangeAccountB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.ChangeAccountB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.ChangeAccountB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeAccountB.Location = new System.Drawing.Point(221, 3);
            this.ChangeAccountB.Name = "ChangeAccountB";
            this.ChangeAccountB.Size = new System.Drawing.Size(30, 30);
            this.ChangeAccountB.TabIndex = 8;
            this.ChangeAccountB.Text = "c";
            this.ChangeAccountB.UseVisualStyleBackColor = false;
            this.ChangeAccountB.Click += new System.EventHandler(this.ChangeAccountB_Click);
            // 
            // AccountPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.Controls.Add(this.ChangeAccountB);
            this.Controls.Add(this.HealthL);
            this.Controls.Add(this.LaunchB);
            this.Controls.Add(this.ActiveWindowB);
            this.Controls.Add(this.StatusL);
            this.Controls.Add(this.NameL);
            this.Controls.Add(this.SkinHeadAvatarPB);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Silver;
            this.Name = "AccountPanel";
            this.Size = new System.Drawing.Size(385, 36);
            this.Load += new System.EventHandler(this.AccountPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SkinHeadAvatarPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    public PictureBox SkinHeadAvatarPB;
    private Label NameL;
    private Label StatusL;
    private Button ActiveWindowB;
    private Button LaunchB;
    private Label HealthL;
    private Button ChangeAccountB;
}
