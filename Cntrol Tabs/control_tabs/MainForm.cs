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
				tab.Name = "tab_page" + i.ToString();
				tab.Text = tab_pages[i];
				tab.BackColor = Color.White;
				tabs.TabPages.Add(tab);
			}
			
//			INNER CONTENT (TAB_PAGE 0)
			for (int i = 0; i < 6; i++)
			{
				if (i < 5)
				{
					CreateFormEntry(
						useful: new int[] {0, i},
						text_label: text_inner_pages[0][0] + i.ToString(),
						element_location: new int[] {
							60, 65 * (i + 1) - 20, 
							60,  65 * (i + 1) + 5
						}
					);
				}
				else
				{
					CreateFormOutput(
						useful: new int[] {0, i},
						element_text: new string[] {
							text_inner_pages[0][2],
							text_inner_pages[0][1]
						},
						button_tag: "average",
						element_location: new int[] {
							tabs.Width - 180, (tabs.Height / 2) - 50,
							tabs.Width - 160, tabs.Height / 2,
							tabs.Width - 180, (tabs.Height / 2) + 25
						}
					);
				}
			}
			
//			INNER CONTENT (TAB_PAGE 1)
			for (int i = 0; i < 3; i++)
			{
				TabPage page = tabs.TabPages[1] as TabPage;

				if (i < 2)
				{
					CreateFormEntry(
						useful: new int[] {1, i},
						text_label: text_inner_pages[1][i],
						element_location: new int[] {
							60, 65 * (i + 1) + 65,
							60, 65 * (i + 1) + 90
						}
					);
				}
				else{
					CreateFormOutput(
						useful: new int[] {1, i},
						element_text: new string[] {
							text_inner_pages[1][3],
							text_inner_pages[1][2]
						},
						button_tag: "strength",
						element_location: new int[] {
							tabs.Width - 180, (tabs.Height / 2) - 50,
							tabs.Width - 160, tabs.Height / 2,
							tabs.Width - 180, (tabs.Height / 2) + 25
						}
					);
				}
			}
			
//			INNER CONTENT (TAB_PAGE 2)
			for (int i = 0; i < 4; i++)
			{
				
			}
//			INNER CONTENT (TAB_PAGE 3)
//			INNER CONTENT (TAB_PAGE 4)
		}
		
		object SearchTabObject(string name, int tab)
		{
			foreach (Control control in tabs.TabPages[tab].Controls)
			{
				if (control is TextBox || control is Button)
				{
					if (control.Name.Contains(name) == true)
					{
						return control;
					}
				}
			}
			
			return null;
		}
		
		void ButtonClick(object sender, EventArgs e)
		{
			Button btn = sender as Button;
			TextBox entry = null;
			
			switch (btn.Tag.ToString())
			{
				case "average":
					float total = 0;
					
					for (int i = 0; i < 5; i++)
					{
						entry = SearchTabObject("page0_entry" + i.ToString(), 0) as TextBox;
						
						try
						{
							total += float.Parse(entry.Text);
							entry = null;
						}
						catch
						{
							MessageBox.Show("Por favor, utilize números inteiros - flutuantes, apenas...\nUtilize \",\" para números decimais");
							total = 0;
							break;
						}
					}
					
					if (entry == null)
					{
						entry = SearchTabObject("page0_entry5", 0) as TextBox;
						entry.Text = (total != 0) ? (total / 5).ToString() : "";
					}
					break;
					
				case "strength":
					break;
			}
		}
		
		void CreateFormEntry(int[] useful, string text_label, int[]element_location)
		{
			TabPage tab = tabs.TabPages[useful[0]] as TabPage;
			
			Label label = new Label();
			label.AutoSize = true;
			label.Name = "page" + useful[0].ToString() + "_label" + useful[1].ToString();
			label.Text = text_label;
			label.Location = new Point(element_location[0], element_location[1]);
			label.Font = new Font(FontFamily.GenericSerif, 12f);
			label.Parent = tab;
			
			TextBox entry = new TextBox();
			entry.Name = "page" + useful[0].ToString() + "_entry" + useful[1].ToString();
			entry.Location = new Point(element_location[2], element_location[3]);
			entry.Width = 120;
			entry.Parent = tab;
		}
		
		void CreateFormOutput(int[] useful, string[] element_text, string button_tag, int[] element_location)
		{
			TabPage tab = tabs.TabPages[useful[0]] as TabPage;
			
			Button calc = new Button();
			calc.Name = "page" + useful[0] + "_button" + useful[1].ToString();
			calc.Tag = button_tag;
			calc.Text = element_text[0];
			calc.Location = new Point(element_location[0], element_location[1]);
			calc.Size = new Size(100, 30);
			calc.Click += ButtonClick;
			calc.Parent = tab;
			
			Label label = new Label();
			label.AutoSize = true;
			label.Name = "page" + useful[0] + "_label" + useful[1].ToString();
			label.Text = element_text[1];
			label.Location = new Point(element_location[2], element_location[3]);
			label.Font = new Font(FontFamily.GenericSerif, 12f);
			label.Parent = tab;
			
			TextBox entry = new TextBox();
			entry.Name = "page" + useful[0] + "_entry" + useful[1].ToString();
			entry.Location = new Point(element_location[4], element_location[5]);
			entry.Width = 100; entry.ReadOnly = true;
			entry.Parent = tab;
		}
	}
}
