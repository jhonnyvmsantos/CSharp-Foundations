using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace simple_calculator
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}
		
		string[] operations = new string[]
		{
			"+", "-", "/", "*"
		};
		
		void MainFormLoad(object sender, EventArgs e)
		{
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			
			for (int i = 0; i < 3; i++)
			{
				TextBox entry = new TextBox();
				entry.Name = (i < 2) ? "entry" + i.ToString() : "result";
				entry.Width = 150; 
				entry.Top = (i < 2) ? (this.Height / 2 - 130) + 40 * (i + 1) : (this.Height / 2) + 20;
				entry.Left = 150;
				
				if (i == 2)
				{
					entry.ReadOnly = true;
				}
				
				entry.Parent = this;
			}
			
			for (int i = 0; i < 4; i++)
			{
				Button calc = new Button();
				calc.Name = "btn" + i.ToString();
				calc.Width = 50; calc.Height = 50;
				calc.Left = (i < 2) ? 50 : this.Width - 100;
				calc.Top = (i < 2) ? (this.Height / 2 - 10) - 80 * i : (this.Height / 2 - 10) - 80 * (i - 2);
				calc.Text = operations[i];
				calc.Font = new Font(FontFamily.GenericMonospace, 17f);
				calc.Click += CalculateClick;
				calc.Parent = this;
			}
		}
		
		void CalculateClick(object sender, EventArgs e)
		{
			Button calc = sender as Button;
			int[] numbers = new int[2];
			bool calculate = false;
			
			for (int i = 0; i < 2; i++)
			{
				TextBox entry = SearchEntry("entry" + i.ToString()) as TextBox;
				
				if (entry == null)
				{
					MessageBox.Show("Por favor, preencha ambas entradas de texto");
					break;
				}
				
				try
				{
					numbers[i] = Convert.ToInt32(entry.Text);
				
					if (i == 1)
					{
						calculate = true;
					}
				}
				catch
				{
					MessageBox.Show("Por favor, tenha em mente que essa é uma calculadora simples...\nPortanto, não use números decimais ou muito longos.");
					break;
				}
			}
			
			if (calculate == true)
			{
				TextBox result = SearchEntry("result") as TextBox;
				switch (calc.Text)
				{
					case "+":
						result.Text = (numbers[0] + numbers[1]).ToString();
						break;
					case "-":
						result.Text = (numbers[0] - numbers[1]).ToString();
						break;
					case "/":
						result.Text = (numbers[0] / numbers[1]).ToString();
						break;
					case "*":
						result.Text = (numbers[0] * numbers[1]).ToString();
						break;
				}
			}
		}
		
		object SearchEntry(string name)
		{
			foreach (Control control in this.Controls)
		    {
				if (control is TextBox && control.Name.Contains(name) == true)
		        {
					return control;
		        }
		    }
			
			return null;
		}
	}
}
