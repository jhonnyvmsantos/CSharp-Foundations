using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace simple_database
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}
		
		ListBox listing = new ListBox();
		RichTextBox database = new RichTextBox();
		
		string[] entry_label = new string[]
		{
			"name", "office", "section", "salary"
		};
		
		string[] combo_item = new string[]
		{
			"section 1", "section 2", "section 3","section 4", "section 5"
		};
		
		string[] control_text = new string[]
		{
			"save", "consult", "search"
		};
		
		void MainFormLoad(object sender, EventArgs e)
		{
			this.MaximizeBox = false;
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
						
			listing.Size = new Size(300, this.Height - 50);
			listing.Location = new Point(260, 5);
			listing.Parent = this;
			
			database.Size = new Size(300, this.Height - 50);
			database.Location = new Point(580, 5);
			database.ReadOnly = true;
			database.Parent = this;
			
			for (int i = 0; i < 4; i++)
			{
				Label label = new Label();
				label.Text = entry_label[i];
				label.Name = "label" + i.ToString();
				label.AutoSize = true;
				label.Location = new Point(20, 20 + 60 * i);
				label.Font = new Font(FontFamily.GenericSerif, 14f);
				label.Parent = this;
				
				TextBox entry = new TextBox();
				entry.Width = (i == 3) ? 80 : 180;
				entry.Location = new Point(20, (i < 2) ? 20 + 25 + 60 * i : 112 * i);
				entry.Name = "entry" + i.ToString();
				entry.Parent = this;
			}
			
			for (int i = 0; i < 2; i++)
			{
				ComboBox entry = new ComboBox();
				entry.Width = 80;
				entry.Location = new Point((i == 0) ? 20 : 120, (i == 0) ? 163 : 336);
				entry.Name = "combo" + i.ToString();
									
				foreach (string item in combo_item)
				{
					entry.Items.Add(item);
				}
				
				entry.Parent = this;
			}
			
			for (int i = 0; i < 3; i++)
			{
				Button btn = new Button();
				btn.Text = control_text[i];
				btn.Location = new Point(20, (i == 0) ? 270 : 380);
				
				if (i == 2)
				{
					btn.Left += 100;
				}
				
				btn.Size = new Size(80, 30);
				btn.Font = new Font(FontFamily.GenericSerif, 12f);
				btn.Parent = this;
			}
		}
	}
}
