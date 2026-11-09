namespace LabGraphics;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        this.button1 = new System.Windows.Forms.Button();
        this.comboBox1 = new System.Windows.Forms.ComboBox();
        this.pictureBox1 = new System.Windows.Forms.PictureBox();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        this.SuspendLayout();
        //
        // button1
        //
        this.button1.Location = new System.Drawing.Point(300, 12);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(120, 28);
        this.button1.TabIndex = 0;
        this.button1.Text = "Draw";
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new System.EventHandler(this.button1_Click);
        //
        // comboBox1
        //
        this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.comboBox1.FormattingEnabled = true;
        this.comboBox1.Location = new System.Drawing.Point(12, 14);
        this.comboBox1.Name = "comboBox1";
        this.comboBox1.Size = new System.Drawing.Size(270, 24);
        this.comboBox1.TabIndex = 1;
        //
        // pictureBox1
        //
        this.pictureBox1.BackColor = System.Drawing.Color.White;
        this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pictureBox1.Location = new System.Drawing.Point(12, 52);
        this.pictureBox1.Name = "pictureBox1";
        this.pictureBox1.Size = new System.Drawing.Size(513, 326);
        this.pictureBox1.TabIndex = 2;
        this.pictureBox1.TabStop = false;
        //
        // Form1
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(540, 392);
        this.Controls.Add(this.pictureBox1);
        this.Controls.Add(this.comboBox1);
        this.Controls.Add(this.button1);
        this.Name = "Form1";
        this.Text = "Lab work - Graphics";
        this.Load += new System.EventHandler(this.Form1_Load);
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        this.ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.PictureBox pictureBox1;
}
