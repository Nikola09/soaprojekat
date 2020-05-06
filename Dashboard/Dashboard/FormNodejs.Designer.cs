namespace Dashboard
{
	partial class FormNodejs
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
			this.components = new System.ComponentModel.Container();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.dataGridView2 = new System.Windows.Forms.DataGridView();
			this.dataGridView3 = new System.Windows.Forms.DataGridView();
			this.dataGridView4 = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.idDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.storageIdDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.timestampDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.accuracyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.latitudeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.longitudeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.altitudeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nodeLocationBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.idDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.storageIdDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.timestampDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.levelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.temperatureDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nodeBatteryBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.storageIdDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.timestampDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.stillDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.onFootDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.walkingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.runningDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.onBicycleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.inVehicleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tiltingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.unknownDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nodeApiiBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.storageIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.timestampDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.lumixDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.temperatureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nodeAmbientBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nodeLocationBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nodeBatteryBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nodeApiiBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nodeAmbientBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.storageIdDataGridViewTextBoxColumn,
            this.timestampDataGridViewTextBoxColumn,
            this.lumixDataGridViewTextBoxColumn,
            this.temperatureDataGridViewTextBoxColumn});
			this.dataGridView1.DataSource = this.nodeAmbientBindingSource;
			this.dataGridView1.Location = new System.Drawing.Point(12, 30);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(442, 251);
			this.dataGridView1.TabIndex = 0;
			// 
			// dataGridView2
			// 
			this.dataGridView2.AutoGenerateColumns = false;
			this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.storageIdDataGridViewTextBoxColumn1,
            this.timestampDataGridViewTextBoxColumn1,
            this.stillDataGridViewTextBoxColumn,
            this.onFootDataGridViewTextBoxColumn,
            this.walkingDataGridViewTextBoxColumn,
            this.runningDataGridViewTextBoxColumn,
            this.onBicycleDataGridViewTextBoxColumn,
            this.inVehicleDataGridViewTextBoxColumn,
            this.tiltingDataGridViewTextBoxColumn,
            this.unknownDataGridViewTextBoxColumn});
			this.dataGridView2.DataSource = this.nodeApiiBindingSource;
			this.dataGridView2.Location = new System.Drawing.Point(467, 30);
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.Size = new System.Drawing.Size(565, 251);
			this.dataGridView2.TabIndex = 1;
			// 
			// dataGridView3
			// 
			this.dataGridView3.AutoGenerateColumns = false;
			this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn2,
            this.storageIdDataGridViewTextBoxColumn2,
            this.timestampDataGridViewTextBoxColumn2,
            this.levelDataGridViewTextBoxColumn,
            this.temperatureDataGridViewTextBoxColumn1});
			this.dataGridView3.DataSource = this.nodeBatteryBindingSource;
			this.dataGridView3.Location = new System.Drawing.Point(12, 305);
			this.dataGridView3.Name = "dataGridView3";
			this.dataGridView3.Size = new System.Drawing.Size(442, 251);
			this.dataGridView3.TabIndex = 2;
			// 
			// dataGridView4
			// 
			this.dataGridView4.AutoGenerateColumns = false;
			this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn3,
            this.storageIdDataGridViewTextBoxColumn3,
            this.timestampDataGridViewTextBoxColumn3,
            this.accuracyDataGridViewTextBoxColumn,
            this.latitudeDataGridViewTextBoxColumn,
            this.longitudeDataGridViewTextBoxColumn,
            this.altitudeDataGridViewTextBoxColumn});
			this.dataGridView4.DataSource = this.nodeLocationBindingSource;
			this.dataGridView4.Location = new System.Drawing.Point(467, 305);
			this.dataGridView4.Name = "dataGridView4";
			this.dataGridView4.Size = new System.Drawing.Size(565, 251);
			this.dataGridView4.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(143, 18);
			this.label1.TabIndex = 5;
			this.label1.Text = "Ambient information:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(464, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(129, 18);
			this.label2.TabIndex = 6;
			this.label2.Text = "Action confidence:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(12, 284);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(136, 18);
			this.label3.TabIndex = 7;
			this.label3.Text = "Battery information:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(464, 284);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(147, 18);
			this.label4.TabIndex = 8;
			this.label4.Text = "Location information:";
			// 
			// idDataGridViewTextBoxColumn3
			// 
			this.idDataGridViewTextBoxColumn3.DataPropertyName = "Id";
			this.idDataGridViewTextBoxColumn3.HeaderText = "Id";
			this.idDataGridViewTextBoxColumn3.Name = "idDataGridViewTextBoxColumn3";
			// 
			// storageIdDataGridViewTextBoxColumn3
			// 
			this.storageIdDataGridViewTextBoxColumn3.DataPropertyName = "Storage_Id";
			this.storageIdDataGridViewTextBoxColumn3.HeaderText = "Storage_Id";
			this.storageIdDataGridViewTextBoxColumn3.Name = "storageIdDataGridViewTextBoxColumn3";
			// 
			// timestampDataGridViewTextBoxColumn3
			// 
			this.timestampDataGridViewTextBoxColumn3.DataPropertyName = "Timestamp";
			this.timestampDataGridViewTextBoxColumn3.HeaderText = "Timestamp";
			this.timestampDataGridViewTextBoxColumn3.Name = "timestampDataGridViewTextBoxColumn3";
			// 
			// accuracyDataGridViewTextBoxColumn
			// 
			this.accuracyDataGridViewTextBoxColumn.DataPropertyName = "Accuracy";
			this.accuracyDataGridViewTextBoxColumn.HeaderText = "Accuracy";
			this.accuracyDataGridViewTextBoxColumn.Name = "accuracyDataGridViewTextBoxColumn";
			// 
			// latitudeDataGridViewTextBoxColumn
			// 
			this.latitudeDataGridViewTextBoxColumn.DataPropertyName = "Latitude";
			this.latitudeDataGridViewTextBoxColumn.HeaderText = "Latitude";
			this.latitudeDataGridViewTextBoxColumn.Name = "latitudeDataGridViewTextBoxColumn";
			// 
			// longitudeDataGridViewTextBoxColumn
			// 
			this.longitudeDataGridViewTextBoxColumn.DataPropertyName = "Longitude";
			this.longitudeDataGridViewTextBoxColumn.HeaderText = "Longitude";
			this.longitudeDataGridViewTextBoxColumn.Name = "longitudeDataGridViewTextBoxColumn";
			// 
			// altitudeDataGridViewTextBoxColumn
			// 
			this.altitudeDataGridViewTextBoxColumn.DataPropertyName = "Altitude";
			this.altitudeDataGridViewTextBoxColumn.HeaderText = "Altitude";
			this.altitudeDataGridViewTextBoxColumn.Name = "altitudeDataGridViewTextBoxColumn";
			// 
			// nodeLocationBindingSource
			// 
			this.nodeLocationBindingSource.DataSource = typeof(Dashboard.Model.NodeLocation);
			// 
			// idDataGridViewTextBoxColumn2
			// 
			this.idDataGridViewTextBoxColumn2.DataPropertyName = "Id";
			this.idDataGridViewTextBoxColumn2.HeaderText = "Id";
			this.idDataGridViewTextBoxColumn2.Name = "idDataGridViewTextBoxColumn2";
			// 
			// storageIdDataGridViewTextBoxColumn2
			// 
			this.storageIdDataGridViewTextBoxColumn2.DataPropertyName = "Storage_Id";
			this.storageIdDataGridViewTextBoxColumn2.HeaderText = "Storage_Id";
			this.storageIdDataGridViewTextBoxColumn2.Name = "storageIdDataGridViewTextBoxColumn2";
			// 
			// timestampDataGridViewTextBoxColumn2
			// 
			this.timestampDataGridViewTextBoxColumn2.DataPropertyName = "Timestamp";
			this.timestampDataGridViewTextBoxColumn2.HeaderText = "Timestamp";
			this.timestampDataGridViewTextBoxColumn2.Name = "timestampDataGridViewTextBoxColumn2";
			// 
			// levelDataGridViewTextBoxColumn
			// 
			this.levelDataGridViewTextBoxColumn.DataPropertyName = "Level";
			this.levelDataGridViewTextBoxColumn.HeaderText = "Level";
			this.levelDataGridViewTextBoxColumn.Name = "levelDataGridViewTextBoxColumn";
			// 
			// temperatureDataGridViewTextBoxColumn1
			// 
			this.temperatureDataGridViewTextBoxColumn1.DataPropertyName = "Temperature";
			this.temperatureDataGridViewTextBoxColumn1.HeaderText = "Temperature";
			this.temperatureDataGridViewTextBoxColumn1.Name = "temperatureDataGridViewTextBoxColumn1";
			// 
			// nodeBatteryBindingSource
			// 
			this.nodeBatteryBindingSource.DataSource = typeof(Dashboard.Model.NodeBattery);
			// 
			// idDataGridViewTextBoxColumn1
			// 
			this.idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
			this.idDataGridViewTextBoxColumn1.HeaderText = "Id";
			this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
			// 
			// storageIdDataGridViewTextBoxColumn1
			// 
			this.storageIdDataGridViewTextBoxColumn1.DataPropertyName = "Storage_Id";
			this.storageIdDataGridViewTextBoxColumn1.HeaderText = "Storage_Id";
			this.storageIdDataGridViewTextBoxColumn1.Name = "storageIdDataGridViewTextBoxColumn1";
			// 
			// timestampDataGridViewTextBoxColumn1
			// 
			this.timestampDataGridViewTextBoxColumn1.DataPropertyName = "Timestamp";
			this.timestampDataGridViewTextBoxColumn1.HeaderText = "Timestamp";
			this.timestampDataGridViewTextBoxColumn1.Name = "timestampDataGridViewTextBoxColumn1";
			// 
			// stillDataGridViewTextBoxColumn
			// 
			this.stillDataGridViewTextBoxColumn.DataPropertyName = "Still";
			this.stillDataGridViewTextBoxColumn.HeaderText = "Still";
			this.stillDataGridViewTextBoxColumn.Name = "stillDataGridViewTextBoxColumn";
			// 
			// onFootDataGridViewTextBoxColumn
			// 
			this.onFootDataGridViewTextBoxColumn.DataPropertyName = "OnFoot";
			this.onFootDataGridViewTextBoxColumn.HeaderText = "OnFoot";
			this.onFootDataGridViewTextBoxColumn.Name = "onFootDataGridViewTextBoxColumn";
			// 
			// walkingDataGridViewTextBoxColumn
			// 
			this.walkingDataGridViewTextBoxColumn.DataPropertyName = "Walking";
			this.walkingDataGridViewTextBoxColumn.HeaderText = "Walking";
			this.walkingDataGridViewTextBoxColumn.Name = "walkingDataGridViewTextBoxColumn";
			// 
			// runningDataGridViewTextBoxColumn
			// 
			this.runningDataGridViewTextBoxColumn.DataPropertyName = "Running";
			this.runningDataGridViewTextBoxColumn.HeaderText = "Running";
			this.runningDataGridViewTextBoxColumn.Name = "runningDataGridViewTextBoxColumn";
			// 
			// onBicycleDataGridViewTextBoxColumn
			// 
			this.onBicycleDataGridViewTextBoxColumn.DataPropertyName = "OnBicycle";
			this.onBicycleDataGridViewTextBoxColumn.HeaderText = "OnBicycle";
			this.onBicycleDataGridViewTextBoxColumn.Name = "onBicycleDataGridViewTextBoxColumn";
			// 
			// inVehicleDataGridViewTextBoxColumn
			// 
			this.inVehicleDataGridViewTextBoxColumn.DataPropertyName = "InVehicle";
			this.inVehicleDataGridViewTextBoxColumn.HeaderText = "InVehicle";
			this.inVehicleDataGridViewTextBoxColumn.Name = "inVehicleDataGridViewTextBoxColumn";
			// 
			// tiltingDataGridViewTextBoxColumn
			// 
			this.tiltingDataGridViewTextBoxColumn.DataPropertyName = "Tilting";
			this.tiltingDataGridViewTextBoxColumn.HeaderText = "Tilting";
			this.tiltingDataGridViewTextBoxColumn.Name = "tiltingDataGridViewTextBoxColumn";
			// 
			// unknownDataGridViewTextBoxColumn
			// 
			this.unknownDataGridViewTextBoxColumn.DataPropertyName = "Unknown";
			this.unknownDataGridViewTextBoxColumn.HeaderText = "Unknown";
			this.unknownDataGridViewTextBoxColumn.Name = "unknownDataGridViewTextBoxColumn";
			// 
			// nodeApiiBindingSource
			// 
			this.nodeApiiBindingSource.DataSource = typeof(Dashboard.Model.NodeApii);
			// 
			// idDataGridViewTextBoxColumn
			// 
			this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
			this.idDataGridViewTextBoxColumn.HeaderText = "Id";
			this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
			// 
			// storageIdDataGridViewTextBoxColumn
			// 
			this.storageIdDataGridViewTextBoxColumn.DataPropertyName = "Storage_Id";
			this.storageIdDataGridViewTextBoxColumn.HeaderText = "Storage_Id";
			this.storageIdDataGridViewTextBoxColumn.Name = "storageIdDataGridViewTextBoxColumn";
			// 
			// timestampDataGridViewTextBoxColumn
			// 
			this.timestampDataGridViewTextBoxColumn.DataPropertyName = "Timestamp";
			this.timestampDataGridViewTextBoxColumn.HeaderText = "Timestamp";
			this.timestampDataGridViewTextBoxColumn.Name = "timestampDataGridViewTextBoxColumn";
			// 
			// lumixDataGridViewTextBoxColumn
			// 
			this.lumixDataGridViewTextBoxColumn.DataPropertyName = "Lumix";
			this.lumixDataGridViewTextBoxColumn.HeaderText = "Lumix";
			this.lumixDataGridViewTextBoxColumn.Name = "lumixDataGridViewTextBoxColumn";
			// 
			// temperatureDataGridViewTextBoxColumn
			// 
			this.temperatureDataGridViewTextBoxColumn.DataPropertyName = "Temperature";
			this.temperatureDataGridViewTextBoxColumn.HeaderText = "Temperature";
			this.temperatureDataGridViewTextBoxColumn.Name = "temperatureDataGridViewTextBoxColumn";
			// 
			// nodeAmbientBindingSource
			// 
			this.nodeAmbientBindingSource.DataSource = typeof(Dashboard.Model.NodeAmbient);
			// 
			// FormNodejs
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1044, 562);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dataGridView4);
			this.Controls.Add(this.dataGridView3);
			this.Controls.Add(this.dataGridView2);
			this.Controls.Add(this.dataGridView1);
			this.Name = "FormNodejs";
			this.Text = "FormNodejs";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormNodejs_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nodeLocationBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nodeBatteryBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nodeApiiBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nodeAmbientBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridView dataGridView2;
		private System.Windows.Forms.DataGridView dataGridView3;
		private System.Windows.Forms.DataGridView dataGridView4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn storageIdDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn timestampDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn lumixDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn temperatureDataGridViewTextBoxColumn;
		private System.Windows.Forms.BindingSource nodeAmbientBindingSource;
		private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn storageIdDataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn timestampDataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn stillDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn onFootDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn walkingDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn runningDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn onBicycleDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn inVehicleDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn tiltingDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn unknownDataGridViewTextBoxColumn;
		private System.Windows.Forms.BindingSource nodeApiiBindingSource;
		private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn storageIdDataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn timestampDataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn levelDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn temperatureDataGridViewTextBoxColumn1;
		private System.Windows.Forms.BindingSource nodeBatteryBindingSource;
		private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn3;
		private System.Windows.Forms.DataGridViewTextBoxColumn storageIdDataGridViewTextBoxColumn3;
		private System.Windows.Forms.DataGridViewTextBoxColumn timestampDataGridViewTextBoxColumn3;
		private System.Windows.Forms.DataGridViewTextBoxColumn accuracyDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn latitudeDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn longitudeDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn altitudeDataGridViewTextBoxColumn;
		private System.Windows.Forms.BindingSource nodeLocationBindingSource;
	}
}