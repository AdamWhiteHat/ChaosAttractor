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
		private static int size = 331;		
		private Bitmap outputImage;

		private Lorenz lorenzChaos;
		private ComplexModulus complexChaos;

		public MainForm()
		{
			InitializeComponent();
			outputImage = new Bitmap(size, size);
			pictureBox.Image = outputImage;

			lorenzChaos = new Lorenz(size);
			complexChaos = new ComplexModulus(size);
		}
		
		private void MainForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
			{
				GetPoints3();
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

		private void GetPoints2()
		{
			List<Tuple<int, int>> points = Step2(100);			
			foreach (Tuple<int, int> point in points)
			{
				Draw2(point.Item1, point.Item2);
			}
		}

		private void GetPoints3()
		{
			List<Tuple<int, int, int>> points = Step3(100);
			foreach (Tuple<int, int, int> point in points)
			{
				Draw3(point.Item1, point.Item2, point.Item3);
			}
		}
		
		private List<Tuple<int, int>> Step2(int count)
		{
			List<Tuple<int, int>> result = new List<Tuple<int, int>>();
			int counter = count;

			while (count-- > 0)
			{
				complexChaos.Step();
				result.Add(new Tuple<int, int>(complexChaos.X, complexChaos.Y));
			}
			return result;
		}

		private List<Tuple<int, int, int>> Step3(int count)
		{
			List<Tuple<int, int, int>> result = new List<Tuple<int, int, int>>();
			int counter = count;

			while (count-- > 0)
			{
				lorenzChaos.Step();
				result.Add(new Tuple<int, int, int>((int)lorenzChaos.x, (int)lorenzChaos.y, (int)lorenzChaos.z));
			}
			return result;	
		}
		
	}
}
