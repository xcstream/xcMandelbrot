using System;
using System.Drawing;
using System.Windows.Forms;
using System.Numerics;
namespace xcMandelbrot
{
    public partial class Form1 : Form
    {
        int maxIterations = 100;
        double scalingFactor = 1.0 / 200.0;
        int iteration = 0;
        Color[] colors;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            colors = new Color[] { Color.Blue, Color.Orange, Color.Yellow, Color.Green, Color.Red, Color.Indigo, Color.Purple };
            Complex current = new Complex(0.0, 0.0);
            Complex temp = new Complex(0.0, 0.0);
            Bitmap image = new Bitmap(600, 400);
            for (int x = 0; x < image.Width; x++)
                for (int y = 0; y < image.Height; y++, iteration = 0)
                {
                    current = new Complex(x * scalingFactor - 2, y * scalingFactor - 1);
                    temp = current;
                    while (temp.Magnitude <= 2 && ++iteration < maxIterations)
                        temp = temp * temp + current;//f(z,c) => z^2 + c平面上的每一个点转换成复数,按这个公式迭代,算到大小超过2或者迭代次数超过100为止,迭代次数决定点的颜色
                    image.SetPixel(x, y, getColor(iteration));
                }
            BackgroundImage = image;
        }
        Color getColor(int i)  // 根据迭代次数选择不同的颜色
        {
            if (i == maxIterations) return Color.Black;
            if (i < 10) return Color.Blue;
            return colors[i % colors.Length];
        }
    }
}
