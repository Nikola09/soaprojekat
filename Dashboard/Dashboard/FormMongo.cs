using Dashboard.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace Dashboard
{
	public partial class FormMongo : Form
	{
		private List<MongodbAmbient> ambients;
		private List<MongodbApii> apiis;
		private List<MongodbBattery> batteries;
		private List<MongodbLocation> locations;
		private System.Timers.Timer timer1;
		private const int reloadTime = 5000;
		private string url = "http://localhost:8885/";
		private string urlAmbient = "api/ambients";
		private string urlApii = "api/apiis";
		private string urlBattery = "api/batteries";
		private string urlLocation = "api/locations";
		public FormMongo()
		{
			InitializeComponent();
			timer1 = new System.Timers.Timer
			{
				Interval = reloadTime,
				AutoReset = true
			};
			timer1.Elapsed += Timer1_Elapsed;
			ambients = new List<MongodbAmbient>();
			apiis = new List<MongodbApii>();
			batteries = new List<MongodbBattery>();
			locations = new List<MongodbLocation>();
			if (GetAllData())
			{
				timer1.Start();
			}
			else
			{
				MessageBox.Show("Unable to connect to service.");
			}
			dataGridView1.DataSource = ambients;
			dataGridView2.DataSource = apiis;
			dataGridView3.DataSource = batteries;
			dataGridView4.DataSource = locations;
		}
		private void Timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			GetAllData();
			if (!dataGridView1.IsHandleCreated)
				return;
			dataGridView1.Invoke((MethodInvoker)delegate
			{
				dataGridView1.DataSource = null;
				dataGridView1.DataSource = ambients;
				dataGridView2.DataSource = null;
				dataGridView2.DataSource = apiis;
				dataGridView3.DataSource = null;
				dataGridView3.DataSource = batteries;
				dataGridView4.DataSource = null;
				dataGridView4.DataSource = locations;
			});
		}

		private bool GetAllData()
		{
			HttpClient clientt = new HttpClient();
			clientt.BaseAddress = new Uri(url);

			// Add an Accept header for JSON format.
			clientt.DefaultRequestHeaders.Accept.Add(
			new MediaTypeWithQualityHeaderValue("application/json"));
			try
			{
				// List data response.
				HttpResponseMessage response = clientt.GetAsync(urlAmbient).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
				if (response.IsSuccessStatusCode)
				{
					// Parse the response body.
					var dataObjects = JsonConvert.DeserializeObject<List<MongodbAmbient>>(response.Content.ReadAsStringAsync().Result);  //Make sure to add a reference to System.Net.Http.Formatting.dll

					ambients = dataObjects;
				}
				else
				{
					Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
				}

				HttpResponseMessage response2 = clientt.GetAsync(urlApii).Result;
				if (response2.IsSuccessStatusCode)
				{
					var dataObjects = JsonConvert.DeserializeObject<List<MongodbApii>>(response2.Content.ReadAsStringAsync().Result);

					apiis = dataObjects;
				}
				else
				{
					Console.WriteLine("{0} ({1})", (int)response2.StatusCode, response2.ReasonPhrase);
				}

				HttpResponseMessage response3 = clientt.GetAsync(urlBattery).Result;
				if (response3.IsSuccessStatusCode)
				{
					var dataObjects = JsonConvert.DeserializeObject<List<MongodbBattery>>(response3.Content.ReadAsStringAsync().Result);

					batteries = dataObjects;
				}
				else
				{
					Console.WriteLine("{0} ({1})", (int)response3.StatusCode, response3.ReasonPhrase);
				}

				HttpResponseMessage response4 = clientt.GetAsync(urlLocation).Result;
				if (response4.IsSuccessStatusCode)
				{
					var dataObjects = JsonConvert.DeserializeObject<List<MongodbLocation>>(response4.Content.ReadAsStringAsync().Result);

					locations = dataObjects;
				}
				else
				{
					Console.WriteLine("{0} ({1})", (int)response4.StatusCode, response4.ReasonPhrase);
				}


			}
			catch (Exception e)
			{
				Console.WriteLine("Connection failed " + e.ToString()) ;
				return false;
			}
			//Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
			clientt.Dispose();
			return true;
		}

		private void FormMongo_FormClosing(object sender, FormClosingEventArgs e)
		{
			timer1.Stop();
		}
	}
}
