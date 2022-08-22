partial class ExitConfirm
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
            this.ConfirmL = new System.Windows.Forms.Label();
            this.KeepB = new System.Windows.Forms.Button();
            this.ExitB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ConfirmL
            // 
            this.ConfirmL.AutoSize = true;
            this.ConfirmL.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ConfirmL.Location = new System.Drawing.Point(4, 3);
            this.ConfirmL.Name = "ConfirmL";
            this.ConfirmL.Size = new System.Drawing.Size(236, 42);
            this.ConfirmL.TabIndex = 0;
            this.ConfirmL.Text = "Confirm exit?";
            // 
            // KeepB
            // 
            this.KeepB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.KeepB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.KeepB.FlatAppearance.BorderSize = 0;
            this.KeepB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.KeepB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.KeepB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KeepB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.KeepB.Location = new System.Drawing.Point(9, 53);
            this.KeepB.Margin = new System.Windows.Forms.Padding(0);
            this.KeepB.Name = "KeepB";
            this.KeepB.Size = new System.Drawing.Size(116, 22);
            this.KeepB.TabIndex = 9;
            this.KeepB.Text = "Да, не, не надо";
            this.KeepB.UseVisualStyleBackColor = false;
            // 
            // ExitB
            // 
            this.ExitB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(70)))), ((int)(((byte)(50)))));
            this.ExitB.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ExitB.FlatAppearance.BorderSize = 0;
            this.ExitB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ExitB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ExitB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ExitB.Location = new System.Drawing.Point(125, 53);
            this.ExitB.Margin = new System.Windows.Forms.Padding(0);
            this.ExitB.Name = "ExitB";
            this.ExitB.Size = new System.Drawing.Size(108, 22);
            this.ExitB.TabIndex = 10;
            this.ExitB.Text = "Естественно";
            this.ExitB.UseVisualStyleBackColor = false;
            // 
            // ExitConfirm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(242, 84);
            this.Controls.Add(this.ExitB);
            this.Controls.Add(this.KeepB);
            this.Controls.Add(this.ConfirmL);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Silver;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ExitConfirm";
            this.Text = "ExitConfirm";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private Label ConfirmL;
    private Button KeepB;
    private Button ExitB;
}