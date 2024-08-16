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
		
		string[] tab_title = new string[]
		{
			"Average", "Strength", "Name Formatting", "Date formatting", "Income"
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
				tab.Text = tab_title[i];
				tab.BackColor = Color.White;
				tabs.TabPages.Add(tab);
			}
		}
		
		object SearchObject(string name)
		{
			foreach (Control control in this.Controls)
			{
				if (control is TabPage || control is TextBox || control is Button)
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
