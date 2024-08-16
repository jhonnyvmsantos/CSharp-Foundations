using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace control_tabs
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}
		
		TabControl tabs = new TabControl();
		Button btn = new Button();
		
		string[] tab_pages = new string[]
		{
			"Average", "Strength", "Name Formatting", "Date formatting", "Income"
		};
		
		string[][] text_inner_pages = new string[5][]
		{
			new string[]{ "Number", "Average", "Calculate" },
			new string[]{ "Mass", "Acceleration", "Strength", "Calculate" },
			new string[]{ "Name", "Lastname", "Full Name", "Format" },
			new string[]{ "Day", "Month", "Year", "Date", "Format" },
			new string[]{ "Interest Rate", "Amount Applied", "Income", "Calculate" },
		};
		
		void MainFormLoad(object sender, EventArgs e)
		{
			this.MaximizeBox = false;
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			
			tabs.Width = this.Width - 50;
			tabs.Height = this.Height - 70;
			tabs.Left = 17; tabs.Top = 15;
			tabs.Parent = this;
			
			for (int i = 0; i < 5; i++)
			{
				TabPage tab = new TabPage();
				tab.Name = "tab" + i.ToString();
				tab.Text = tab_pages[i];
				tab.BackColor = Color.White;
				tabs.TabPages.Add(tab);
			}
			
			for (int i = 0; i < 6; i++)
			{
				TabPage page = tabs.TabPages[0] as TabPage;

				if (i < 5)
				{
					Label label = new Label();
					label.AutoSize = true;
					label.Name = "page0_label" + i.ToString();
					label.Text = text_inner_pages[0][0] + i.ToString();
					label.Location = new Point(60, 65 * (i + 1) - 20);
					label.Font = new Font(FontFamily.GenericSerif, 12f);
					label.Parent = page;
					
					TextBox entry = new TextBox();
					entry.Name = "page0_entry" + i.ToString();
					entry.Location = new Point(60, 65 * (i + 1) + 5);
					entry.Width = 120;
					entry.Parent = page;
				}
				else
				{
					Button calc = new Button();
					calc.Name = "page0_btn" + i.ToString();
					calc.Text = text_inner_pages[0][2];
					calc.Location = new Point(page.Width - 160, (page.Height / 2) - 50);
					calc.Size = new Size(100, 30);
					calc.Parent = page;
					
					Label label = new Label();
					label.AutoSize = true;
					label.Name = "page0_label" + i.ToString();
					label.Text = text_inner_pages[0][1];
					label.Location = new Point(page.Width - 140, page.Height / 2);
					label.Font = new Font(FontFamily.GenericSerif, 12f);
					label.Parent = page;
					
					TextBox entry = new TextBox();
					entry.Name = "page0_entry" + i.ToString();
					entry.Location = new Point(page.Width - 160, (page.Height / 2) + 25);
					entry.Width = 100; entry.ReadOnly = true;
					entry.Parent = page;
				}
			}
		}
		
		object SearchObject(string name)
		{
			foreach (Control control in this.Controls)
			{
				if (control is TextBox || control is Button)
				{
					if (control.Name.Contains(name))
					{
						return control;
					}
				}
			}
			
			return null;
		}
	}
}
