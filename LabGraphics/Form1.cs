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
        comboBox1.Items.Add("Task 7: sun with 12 rays");
        comboBox1.Items.Add("Task 8: chain of circles");
        comboBox1.Items.Add("Task 9: star");
        comboBox1.Items.Add("Task 10: ladder of rectangles");
        comboBox1.Items.Add("Task 11: frame of squares");
        comboBox1.Items.Add("Task 12: spiral");
        comboBox1.Items.Add("Task 13: flag");
        comboBox1.Items.Add("Task 14: clock face");
        comboBox1.Items.Add("Task 15: random mosaic");
        comboBox1.Items.Add("Task 16: waves");
        comboBox1.Items.Add("Task 17: smiley face");
        comboBox1.Items.Add("Task 18: cube");
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
        if (n == 8) Task7(g);
        if (n == 9) Task8(g);
        if (n == 10) Task9(g);
        if (n == 11) Task10(g);
        if (n == 12) Task11(g);
        if (n == 13) Task12(g);
        if (n == 14) Task13(g);
        if (n == 15) Task14(g);
        if (n == 16) Task15(g);
        if (n == 17) Task16(g);
        if (n == 18) Task17(g);
        if (n == 19) Task18(g);

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

    // Task 7: sun with 12 rays
    private void Task7(Graphics g)
    {
        int cx = 256;
        int cy = 163;
        Pen rayPen = new Pen(Color.Orange, 3);
        for (int i = 0; i < 12; i++)
        {
            double angle = i * 30 * Math.PI / 180;
            int x1 = cx + (int)(60 * Math.Cos(angle));
            int y1 = cy + (int)(60 * Math.Sin(angle));
            int x2 = cx + (int)(130 * Math.Cos(angle));
            int y2 = cy + (int)(130 * Math.Sin(angle));
            g.DrawLine(rayPen, x1, y1, x2, y2);
        }
        g.FillEllipse(Brushes.Yellow, cx - 50, cy - 50, 100, 100);
        g.DrawEllipse(Pens.Orange, cx - 50, cy - 50, 100, 100);
    }

    // Task 8: chain of circles along a horizontal line
    private void Task8(Graphics g)
    {
        int y = 163;
        g.DrawLine(Pens.Gray, 10, y, 500, y);
        for (int x = 20; x < 480; x += 40)
        {
            g.FillEllipse(Brushes.DodgerBlue, x, y - 20, 40, 40);
            g.DrawEllipse(Pens.Black, x, y - 20, 40, 40);
        }
    }

    // Task 9: star with 5 points
    private void Task9(Graphics g)
    {
        int cx = 256;
        int cy = 170;
        int R = 130;
        int r = 55;
        Point[] star = new Point[10];
        for (int i = 0; i < 10; i++)
        {
            double angle = (i * 36 - 90) * Math.PI / 180;
            int rad;
            if (i % 2 == 0) rad = R;
            else rad = r;
            star[i] = new Point(cx + (int)(rad * Math.Cos(angle)), cy + (int)(rad * Math.Sin(angle)));
        }
        g.FillPolygon(Brushes.Gold, star);
        g.DrawPolygon(Pens.DarkOrange, star);
    }

    // Task 10: ladder of rectangles, each one is higher
    private void Task10(Graphics g)
    {
        int x = 30;
        int h = 40;
        for (int i = 0; i < 8; i++)
        {
            g.FillRectangle(Brushes.SteelBlue, x, 300 - h, 50, h);
            g.DrawRectangle(Pens.Black, x, 300 - h, 50, h);
            x = x + 55;
            h = h + 30;
        }
    }

    // Task 11: frame of squares around the perimeter
    private void Task11(Graphics g)
    {
        int s = 30;
        int w = pictureBox1.Width;
        int h = pictureBox1.Height;
        for (int x = 0; x < w - s; x += s)
        {
            g.FillRectangle(Brushes.Teal, x, 0, s, s);
            g.DrawRectangle(Pens.White, x, 0, s, s);
            g.FillRectangle(Brushes.Teal, x, h - s - 2, s, s);
            g.DrawRectangle(Pens.White, x, h - s - 2, s, s);
        }
        for (int y = 0; y < h - s; y += s)
        {
            g.FillRectangle(Brushes.Teal, 0, y, s, s);
            g.DrawRectangle(Pens.White, 0, y, s, s);
            g.FillRectangle(Brushes.Teal, w - s - 2, y, s, s);
            g.DrawRectangle(Pens.White, w - s - 2, y, s, s);
        }
    }

    // Task 12: spiral of lines
    private void Task12(Graphics g)
    {
        double x = 256;
        double y = 163;
        double len = 5;
        double angle = 0;
        for (int i = 0; i < 80; i++)
        {
            double nx = x + len * Math.Cos(angle);
            double ny = y + len * Math.Sin(angle);
            g.DrawLine(Pens.DarkGreen, (float)x, (float)y, (float)nx, (float)ny);
            x = nx;
            y = ny;
            angle = angle + Math.PI / 2;
            len = len + 2;
        }
    }

    // Task 13: flag with three horizontal stripes
    private void Task13(Graphics g)
    {
        g.FillRectangle(Brushes.White, 80, 60, 360, 70);
        g.FillRectangle(Brushes.Blue, 80, 130, 360, 70);
        g.FillRectangle(Brushes.Red, 80, 200, 360, 70);
        g.DrawRectangle(Pens.Black, 80, 60, 360, 210);
        // flagpole
        g.FillRectangle(Brushes.Gray, 72, 50, 8, 260);
    }

    // Task 14: clock face
    private void Task14(Graphics g)
    {
        int cx = 256;
        int cy = 163;
        int r = 140;
        g.DrawEllipse(new Pen(Color.Black, 3), cx - r, cy - r, r * 2, r * 2);
        for (int i = 0; i < 12; i++)
        {
            double angle = i * 30 * Math.PI / 180;
            int x1 = cx + (int)((r - 15) * Math.Cos(angle));
            int y1 = cy + (int)((r - 15) * Math.Sin(angle));
            int x2 = cx + (int)(r * Math.Cos(angle));
            int y2 = cy + (int)(r * Math.Sin(angle));
            g.DrawLine(new Pen(Color.Black, 2), x1, y1, x2, y2);
        }
        // hands
        g.DrawLine(new Pen(Color.Black, 4), cx, cy, cx + 60, cy - 40);
        g.DrawLine(new Pen(Color.Red, 2), cx, cy, cx - 20, cy - 90);
        g.FillEllipse(Brushes.Black, cx - 5, cy - 5, 10, 10);
    }

    // Task 15: mosaic of random colored squares
    private void Task15(Graphics g)
    {
        Random rnd = new Random();
        int s = 25;
        for (int x = 0; x < pictureBox1.Width - s; x += s)
        {
            for (int y = 0; y < pictureBox1.Height - s; y += s)
            {
                Color c = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                Brush b = new SolidBrush(c);
                g.FillRectangle(b, x, y, s, s);
            }
        }
    }

    // Task 16: waves (several sinusoidal lines)
    private void Task16(Graphics g)
    {
        Pen[] pens = { Pens.Blue, Pens.Green, Pens.Red, Pens.Purple };
        for (int k = 0; k < 4; k++)
        {
            Point[] pts = new Point[500];
            for (int x = 0; x < 500; x++)
            {
                double y = 163 + (k - 1.5) * 60 + 25 * Math.Sin(x * 0.04 + k);
                pts[x] = new Point(x + 5, (int)y);
            }
            g.DrawLines(pens[k], pts);
        }
    }

    // Task 17: smiley face
    private void Task17(Graphics g)
    {
        int cx = 256;
        int cy = 163;
        g.FillEllipse(Brushes.Yellow, cx - 120, cy - 120, 240, 240);
        g.DrawEllipse(new Pen(Color.Black, 3), cx - 120, cy - 120, 240, 240);
        // eyes
        g.FillEllipse(Brushes.Black, cx - 60, cy - 50, 30, 40);
        g.FillEllipse(Brushes.Black, cx + 30, cy - 50, 30, 40);
        // smile
        g.DrawArc(new Pen(Color.Black, 5), cx - 70, cy - 40, 140, 120, 20, 140);
    }

    // Task 18: cube in 3D projection
    private void Task18(Graphics g)
    {
        int d = 50; // shift for the back side
        // back square
        g.DrawRectangle(Pens.Gray, 190 + d, 70 - d, 140, 140);
        // front square
        g.DrawRectangle(Pens.Black, 190, 70, 140, 140);
        // lines that connect the squares
        g.DrawLine(Pens.Black, 190, 70, 190 + d, 70 - d);
        g.DrawLine(Pens.Black, 330, 70, 330 + d, 70 - d);
        g.DrawLine(Pens.Black, 190, 210, 190 + d, 210 - d);
        g.DrawLine(Pens.Black, 330, 210, 330 + d, 210 - d);
    }
}
