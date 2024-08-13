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
				ComboBox combo = new ComboBox();
				combo.Width = 80;
				combo.Location = new Point((i == 0) ? 20 : 120, (i == 0) ? 163 : 336);
				combo.Name = "combo" + i.ToString();
									
				foreach (string item in combo_item)
				{
					combo.Items.Add(item);
				}
				
				combo.Parent = this;
			}
			
			for (int i = 0; i < 3; i++)
			{
				Button btn = new Button();
				btn.Text = control_text[i];
				btn.Name = "button" + i.ToString();
				btn.Tag = control_text[i];
				btn.Location = new Point(20, (i == 0) ? 270 : 380);
				
				if (i == 2)
				{
					btn.Left += 100;
				}
				
				btn.Size = new Size(80, 30);
				btn.Font = new Font(FontFamily.GenericSerif, 12f);
				btn.Click += ButtonClick;
				btn.Parent = this;
			}
			
			try {
				database.LoadFile("simple_db.txt", RichTextBoxStreamType.PlainText);
			} catch {
				database.SaveFile("simple_db.txt", RichTextBoxStreamType.PlainText);
			}
		}
		
		void ButtonClick(object sender, EventArgs e)
		{
			Button btn = sender as Button;
			
			listing.Items.Clear();
			
			switch (btn.Tag.ToString())
			{
				case "save":
					string data = null;
					
					for (int i = 0; i < 4; i++)
					{
						TextBox entry = null; ComboBox combo = null;
						
						if (i < 3)
						{
							entry = ObjSearch("entry" + i.ToString()) as TextBox;
							if (entry.Text.Length < 1)
							{
								MessageBox.Show("Por favor, preencha todos os dados pedido.");
								data = null;
								break;
							}
						}
						else
						{
							combo = ObjSearch("combo0") as ComboBox;
							if (combo.Text.Length < 1)
							{
								MessageBox.Show("Por favor, preencha todos os dados pedido.");
								data = null;
								break;
							}
						}
						
						try
						{
							data += (i < 3) ? entry.Text + "  |  " : combo.Text;
						}
						catch
						{
							MessageBox.Show("Por favor, preencha os dados sem qualquer formatação e de forma adequada.");
							data = null;
							break;
						}
					}
					
					if (data != null)
					{
						listing.Items.Add(data); database.Text += data;
						database.SaveFile("simple_db.txt", RichTextBoxStreamType.PlainText);
					}
					
					break;
				case "consult":
					break;
				case "search":
					break;
			}
		}
		
		object ObjSearch(string name)
		{
			foreach (Control control in this.Controls)
			{
				if (control is TextBox || control is ComboBox)
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
