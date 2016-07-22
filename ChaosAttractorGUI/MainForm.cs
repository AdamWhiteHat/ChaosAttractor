using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using ChaosAttractor;

namespace ChaosAttractorGUI
{
	public partial class MainForm : Form
	{		
		private Bitmap outputImage;

		private Lorenz lorenzChaos;

		public MainForm()
		{
			InitializeComponent();

			outputImage = new Bitmap(pictureBox.Width, pictureBox.Height);
			pictureBox.Image = outputImage;

			int size = Math.Min(pictureBox.Width, pictureBox.Height);
			lorenzChaos = new Lorenz(size);
			lorenzChaos.Scale = 25;
			lorenzChaos.MaxRange = size;
		}
		
		private void MainForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
			{
				GetPoints3();
				int maxOut = (int)lorenzChaos.MaxOutput;
				lblMaxOutput.Text = $" {pictureBox.Width} X {pictureBox.Height} Max: {maxOut}";
			}
		}

		private void Draw2(int a, int b)
		{
			Draw3(a, b, 0);
		}

		private void Draw3(int a, int b, int c)
		{
			outputImage.SetPixel(a, b, Color.FromArgb(c, c, c));
			pictureBox.Image = outputImage;
		}
		
		private void GetPoints3()
		{
			List<Tuple<int, int, int>> points = Step3(100);
			foreach (Tuple<int, int, int> point in points)
			{
				// Clips any truncated points (because value was outside of MaxRange
				if(point.Item1 == 0 || point.Item2 == 0 )
				{
					continue;
				}
				Draw3(point.Item1, point.Item2, 0);
			}
		}
		
		private List<Tuple<int, int, int>> Step3(int count)
		{
			List<Tuple<int, int, int>> result = new List<Tuple<int, int, int>>();
			int counter = count;

			while (count-- > 0)
			{
				lorenzChaos.Step();
				result.Add(new Tuple<int, int, int>((int)lorenzChaos.X, (int)lorenzChaos.Y, (int)lorenzChaos.Z));
			}
			return result;	
		}
		
	}
}
