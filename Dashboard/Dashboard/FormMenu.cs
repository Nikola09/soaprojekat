using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dashboard
{
	public partial class FormMenu : Form
	{
		public FormMenu()
		{
			InitializeComponent();
		}

		private void btnStorage_Click(object sender, EventArgs e)
		{
			FormStorage form = new FormStorage();
			form.Show();
		}

		private void btnMongo_Click(object sender, EventArgs e)
		{
			FormMongo form = new FormMongo();
			form.Show();
		}

		private void btnNodejs_Click(object sender, EventArgs e)
		{
			FormNodejs form = new FormNodejs();
			form.Show();
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void FormMenu_FormClosing(object sender, FormClosingEventArgs e)
		{
		}
	}
}
