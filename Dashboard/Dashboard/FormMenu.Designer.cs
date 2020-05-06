namespace Dashboard
{
	partial class FormMenu
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnStorage = new System.Windows.Forms.Button();
			this.btnMongo = new System.Windows.Forms.Button();
			this.btnNodejs = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnStorage
			// 
			this.btnStorage.Location = new System.Drawing.Point(105, 56);
			this.btnStorage.Name = "btnStorage";
			this.btnStorage.Size = new System.Drawing.Size(139, 56);
			this.btnStorage.TabIndex = 0;
			this.btnStorage.Text = "Storage Service";
			this.btnStorage.UseVisualStyleBackColor = true;
			this.btnStorage.Click += new System.EventHandler(this.btnStorage_Click);
			// 
			// btnMongo
			// 
			this.btnMongo.Location = new System.Drawing.Point(105, 146);
			this.btnMongo.Name = "btnMongo";
			this.btnMongo.Size = new System.Drawing.Size(139, 56);
			this.btnMongo.TabIndex = 1;
			this.btnMongo.Text = "Mongo Service";
			this.btnMongo.UseVisualStyleBackColor = true;
			this.btnMongo.Click += new System.EventHandler(this.btnMongo_Click);
			// 
			// btnNodejs
			// 
			this.btnNodejs.Location = new System.Drawing.Point(105, 237);
			this.btnNodejs.Name = "btnNodejs";
			this.btnNodejs.Size = new System.Drawing.Size(139, 56);
			this.btnNodejs.TabIndex = 2;
			this.btnNodejs.Text = "Node js Service";
			this.btnNodejs.UseVisualStyleBackColor = true;
			this.btnNodejs.Click += new System.EventHandler(this.btnNodejs_Click);
			// 
			// btnExit
			// 
			this.btnExit.Location = new System.Drawing.Point(127, 328);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(92, 41);
			this.btnExit.TabIndex = 3;
			this.btnExit.Text = "Exit";
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// FormMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(343, 450);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnNodejs);
			this.Controls.Add(this.btnMongo);
			this.Controls.Add(this.btnStorage);
			this.Name = "FormMenu";
			this.Text = "Dashboard";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMenu_FormClosing);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnStorage;
		private System.Windows.Forms.Button btnMongo;
		private System.Windows.Forms.Button btnNodejs;
		private System.Windows.Forms.Button btnExit;
	}
}

