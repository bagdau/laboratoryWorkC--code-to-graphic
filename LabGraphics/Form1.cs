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
        comboBox1.Items.Add("Task 1: 5 nested circles");
        comboBox1.Items.Add("Task 2: 10 vertical lines");
        comboBox1.Items.Add("Task 3: chessboard");
        comboBox1.Items.Add("Task 4: triangle, rectangle, circle");
        comboBox1.Items.Add("Task 5: house");
        comboBox1.Items.Add("Task 6: 5 nested ellipses");
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
        if (n == 2) Task1(g);
        if (n == 3) Task2(g);
        if (n == 4) Task3(g);
        if (n == 5) Task4(g);
        if (n == 6) Task5(g);
        if (n == 7) Task6(g);

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

    // Task 1: 5 nested circles
    private void Task1(Graphics g)
    {
        int cx = 256;
        int cy = 163;
        int r = 150;
        for (int i = 0; i < 5; i++)
        {
            g.DrawEllipse(Pens.Blue, cx - r, cy - r, r * 2, r * 2);
            r = r - 28;
        }
    }

    // Task 2: 10 vertical lines, step 20 px
    private void Task2(Graphics g)
    {
        Pen pen = new Pen(Color.Red, 2);
        for (int i = 0; i < 10; i++)
        {
            int x = 40 + i * 20;
            g.DrawLine(pen, x, 30, x, 290);
        }
    }

    // Task 3: chessboard
    private void Task3(Graphics g)
    {
        int size = 38;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if ((i + j) % 2 == 0)
                    g.FillRectangle(Brushes.White, 100 + i * size, 10 + j * size, size, size);
                else
                    g.FillRectangle(Brushes.Black, 100 + i * size, 10 + j * size, size, size);
            }
        }
        g.DrawRectangle(Pens.Black, 100, 10, size * 8, size * 8);
    }

    // Task 4: triangle, rectangle and circle
    private void Task4(Graphics g)
    {
        Point[] tr = { new Point(80, 220), new Point(30, 300), new Point(130, 300) };
        g.FillPolygon(Brushes.Red, tr);
        g.FillRectangle(Brushes.Green, 190, 220, 120, 80);
        g.FillEllipse(Brushes.Orange, 370, 215, 90, 90);
    }

    // Task 5: house
    private void Task5(Graphics g)
    {
        // walls
        g.FillRectangle(Brushes.Khaki, 150, 140, 200, 150);
        g.DrawRectangle(Pens.Black, 150, 140, 200, 150);
        // roof
        Point[] roof = { new Point(130, 140), new Point(250, 50), new Point(370, 140) };
        g.FillPolygon(Brushes.Brown, roof);
        // door
        g.FillRectangle(Brushes.SaddleBrown, 170, 200, 50, 90);
        // window
        g.FillRectangle(Brushes.LightBlue, 260, 170, 60, 60);
        g.DrawRectangle(Pens.Black, 260, 170, 60, 60);
    }

    // Task 6: 5 nested ellipses with the same center
    private void Task6(Graphics g)
    {
        int cx = 256;
        int cy = 163;
        int w = 440;
        int h = 280;
        for (int i = 0; i < 5; i++)
        {
            g.DrawEllipse(Pens.Purple, cx - w / 2, cy - h / 2, w, h);
            w = w - 80;
            h = h - 50;
        }
    }
}
