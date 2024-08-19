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
						},
						opt_width: new int[] {
							0
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
						},
						opt_width: new int[] {
							0, 0
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
						},
						opt_width: new int[] {
							0
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
						},
						opt_width: new int[] {
							0, 0
						}
					);
				}
			}
			
//			INNER CONTENT (TAB_PAGE 2)
			for (int i = 0; i < 3; i++)
			{
				if (i < 2)
				{
					CreateFormEntry(
						useful: new int[] {2, i},
						text_label: text_inner_pages[2][i],
						element_location: new int[] {
							(tabs.Width / 2) - 80, 65 * (i + 1),
							(tabs.Width / 2) - 80, 65 * (i + 1) + 25
						},
						opt_width: new int[] {
							160
						}
					);
				}
				else
				{
					CreateFormOutput(
						useful: new int[] {2, i},
						element_text: new string[] {
							text_inner_pages[2][3],
							text_inner_pages[2][2]
						},
						button_tag: "name_format",
						element_location: new int[] {
							(tabs.Width / 2) - 60, (tabs.Height / 2) + 10,
							(tabs.Width / 2) - 35, (tabs.Height / 2) + 60,
							(tabs.Width / 2) - 80, (tabs.Height / 2) + 85
						},
						opt_width: new int[] {
							120, 160
						}
					);
				}
			}
			
//			INNER CONTENT (TAB_PAGE 3)
			for (int i = 0; i < 4; i++)
			{
				TabPage page = tabs.TabPages[3] as TabPage;

				if (i < 3)
				{
					CreateFormEntry(
						useful: new int[] {3, i},
						text_label: text_inner_pages[3][i],
						element_location: new int[] {
							100, 65 * (i + 1) + 30,
							100, 65 * (i + 1) + 55
						},
						opt_width: new int[] {
							0
						}
					);
				}
				else{
					CreateFormOutput(
						useful: new int[] {3, i},
						element_text: new string[] {
							text_inner_pages[3][4],
							text_inner_pages[3][3]
						},
						button_tag: "date_format",
						element_location: new int[] {
							tabs.Width - 220, (tabs.Height / 2) - 50,
							tabs.Width - 192, tabs.Height / 2,
							tabs.Width - 220, (tabs.Height / 2) + 25
						},
						opt_width: new int[] {
							0, 0
						}
					);
				}
			}
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
			
			float total = 0; string format = "";
			
			switch (btn.Tag.ToString())
			{
				case "average":					
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
						entry.Text = (total / 5).ToString();
					}
					break;
					
				case "strength":					
					for (int i = 0; i < 2; i++)
					{
						entry = SearchTabObject("page1_entry" + i.ToString(), 1) as TextBox;
						
						try
						{
							total = (i == 0) ? float.Parse(entry.Text) : total * float.Parse(entry.Text);
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
						entry = SearchTabObject("page1_entry2", 1) as TextBox;
						entry.Text = total.ToString();
					}
					break;
					
				case "name_format":
					for (int i = 0; i < 2; i++)
					{
						entry = SearchTabObject("page2_entry" + i.ToString(), 2) as TextBox;
						
						try
						{
							bool verification = true;
							
							foreach (char letter in entry.Text)
							{
								int code = Convert.ToInt32(letter);

								if (code != 32 && code < 65 || code > 90)
								{
									if (code < 97 || code > 122)
									{
										MessageBox.Show("Por favor, apenas coloque seu nome/sobrenome, sem números ou caracteres especiais/acentuados (?)...");
										format = ""; verification = false;
										break;
									}
								}
							}
							
							if (verification == true)
							{
								format += (format.Length > 0) ? " " + entry.Text : entry.Text;
								entry = null;
							}
						}
						catch
						{
							MessageBox.Show("Por favor, apenas coloque seu nome/sobrenome, sem números ou caracteres especiais/acentuados (?)...");
							format = "";
							break;
						}
					}
					
				
					if (entry == null && format != "")
					{
						entry = SearchTabObject("page2_entry2", 2) as TextBox;
						entry.Text = format;
					}
					
					break;
				case "date_format":
					DateTime dt;
					
					string[] month = new string[]
					{
						"january", "february", "march", "april", "may", "june", "july", "august", "september", "october", "november", "december"
					};
					bool validation = false;
					
					for (int i = 0; i < 3; i++)
					{
						entry = SearchTabObject("page3_entry" + i.ToString(), 3) as TextBox;

						if (entry.Text.Length > 0)
						{
							if (i == 1)
							{
								int mcount = 1;
								
								foreach (string selected in month)
								{
									if (entry.Text.ToLower() != selected && entry.Text.ToLower() != selected.Substring(0, 3))
									{
										mcount++;
									}
									else
									{
										break;
									}
								}
								
								if (mcount >= 12)
								{
									format += (entry.Text.Length == 1) ? "/0" + entry.Text + "/" : "/" + entry.Text + "/";
								}
								else
								{
									format += (mcount < 10) ? "/0" + mcount.ToString() + "/" : "/" + mcount.ToString() + "/";
								}
							}
							else if (i == 0)
							{
								format += (entry.Text.Length == 1) ? "0" + entry.Text : entry.Text;
							}
							else
							{
								format += (entry.Text.Length == 2) ? (DateTime.Now.Year).ToString().Substring(0, 2) + entry.Text : entry.Text;
							}
						}
					}
					
					MessageBox.Show(format);
					validation = DateTime.TryParseExact(format, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt);
					if (validation == true)
					{
						entry = SearchTabObject("page3_entry3", 3) as TextBox;
						entry.Text = format;
					}
					else
					{
						MessageBox.Show("Por favor, utilize uma data válida. Use apenas números, de preferência.\nNo mês, pode-se utilizar o nome do mês (Inglês)...");
					}
					break;
				case "income":
					break;
			}
		}
		
		void CreateFormEntry(int[] useful, string text_label, int[]element_location, int[] opt_width)
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
			entry.Width = (opt_width[0] > 0) ? opt_width[0] : 120;
			entry.Parent = tab;
		}
		
		void CreateFormOutput(int[] useful, string[] element_text, string button_tag, int[] element_location, int[] opt_width)
		{
			TabPage tab = tabs.TabPages[useful[0]] as TabPage;
			
			Button calc = new Button();
			calc.Name = "page" + useful[0] + "_button" + useful[1].ToString();
			calc.Tag = button_tag;
			calc.Text = element_text[0];
			calc.Location = new Point(element_location[0], element_location[1]);
			calc.Size = new Size((opt_width[0] > 0) ? opt_width[0] : 100, 30);
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
			entry.Width = (opt_width[1] > 0) ? opt_width[1] : 100; 
			entry.ReadOnly = true;
			entry.Parent = tab;
		}
	}
}
