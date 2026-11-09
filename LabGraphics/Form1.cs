using System.Drawing.Drawing2D;

namespace LabGraphics;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        comboBox1.Items.Add("Demo: brushes");
        comboBox1.Items.Add("Demo: pen with arrow");
        comboBox1.SelectedIndex = 0;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        // draw on a bitmap and show it in the picturebox
        Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        Graphics g = Graphics.FromImage(bmp);
        g.Clear(Color.White);

        int n = comboBox1.SelectedIndex;
        if (n == 0) DemoBrushes(g);
        if (n == 1) DemoPen(g);

        pictureBox1.Image = bmp;
    }

    // example from the lab work (brushes)
    private void DemoBrushes(Graphics g)
    {
        g.FillRectangle(Brushes.ForestGreen, 20, 20, 30, 60);
        g.FillRectangle(Brushes.White, 50, 20, 30, 60);
        g.FillRectangle(Brushes.Red, 80, 20, 30, 60);
        g.DrawRectangle(Pens.Black, 20, 20, 90, 60);
        g.DrawString("Solid Brush", this.Font, Brushes.Black, 20, 85);

        LinearGradientBrush lgBrush_1 = new LinearGradientBrush(new RectangleF(200, 20, 90, 10),
            Color.Blue, Color.LightBlue, LinearGradientMode.Horizontal);
        g.FillRectangle(lgBrush_1, 200, 20, 90, 60);
        g.DrawString("Linear Gradient Horizontal", this.Font, Brushes.Black, 200, 85);

        LinearGradientBrush lgBrush_2 = new LinearGradientBrush(new RectangleF(0, 0, 10, 60),
            Color.Blue, Color.LightBlue, LinearGradientMode.Vertical);
        g.FillRectangle(lgBrush_2, 20, 120, 90, 60);
        g.DrawString("Linear Gradient Vertical", this.Font, Brushes.Black, 20, 185);

        // there is no brush_2.bmp so just draw a rectangle
        g.DrawRectangle(Pens.Black, 200, 120, 90, 60);
        g.DrawString("Texture Brush", this.Font, Brushes.Black, 200, 185);

        HatchBrush hBrush = new HatchBrush(HatchStyle.DottedGrid, Color.Black, Color.Gold);
        g.FillRectangle(hBrush, 20, 220, 90, 60);
        g.DrawString("HatchBrush DottedGrid", this.Font, Brushes.Black, 20, 285);

        HatchBrush hBrush_2 = new HatchBrush(HatchStyle.DiagonalCross, Color.Black, Color.Gold);
        g.FillRectangle(hBrush_2, 200, 220, 90, 60);
        g.DrawString("HatchBrush DiagonalCross", this.Font, Brushes.Black, 200, 285);
    }

    // second example from the lab work (pen)
    private void DemoPen(Graphics g)
    {
        int x = 10;
        int y = 50;
        Pen myPen = new Pen(Color.Black, 1);
        myPen.Width = 5;
        myPen.DashStyle = DashStyle.Solid;
        myPen.StartCap = LineCap.ArrowAnchor;
        myPen.EndCap = LineCap.DiamondAnchor;
        g.DrawLine(myPen, x, y, 200, y);
    }
}
