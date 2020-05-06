using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Dashboard.Model;

namespace Dashboard
{
	public partial class FormNodejs : Form
	{
		private List<NodeAmbient> ambients;
		private List<NodeApii> apiis;
		private List<NodeBattery> batteries;
		private List<NodeLocation> locations;
		private System.Timers.Timer timer1;
		private const int reloadTime = 5000;
		private string url = "http://localhost:4000/";
		private string urlAmbient = "api/ambients";
		private string urlApii = "api/apiis";
		private string urlBattery = "api/batteries";
		private string urlLocation = "api/locations";
		public FormNodejs()
		{
			InitializeComponent();
			timer1 = new System.Timers.Timer
			{
				Interval = reloadTime,
				AutoReset = true
			};
			timer1.Elapsed += Timer1_Elapsed;
			ambients = new List<NodeAmbient>();
			apiis = new List<NodeApii>();
			batteries = new List<NodeBattery>();
			locations = new List<NodeLocation>();
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
			});
			dataGridView2.Invoke((MethodInvoker)delegate
			{
				dataGridView2.DataSource = null;
				dataGridView2.DataSource = apiis;
			});
			dataGridView3.Invoke((MethodInvoker)delegate
			{
				dataGridView3.DataSource = null;
				dataGridView3.DataSource = batteries;
			});
			dataGridView4.Invoke((MethodInvoker)delegate
			{
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
					var dataObjects = JsonConvert.DeserializeObject<List<NodeAmbient>>(response.Content.ReadAsStringAsync().Result);  //Make sure to add a reference to System.Net.Http.Formatting.dll

					ambients = dataObjects;
				}
				else
				{
					Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
				}
				HttpResponseMessage response2 = clientt.GetAsync(urlApii).Result;
				if (response2.IsSuccessStatusCode)
				{
					var dataObjects = JsonConvert.DeserializeObject<List<NodeApii>>(response.Content.ReadAsStringAsync().Result);

					apiis = dataObjects;
				}
				else
				{
					Console.WriteLine("{0} ({1})", (int)response2.StatusCode, response2.ReasonPhrase);
				}
				HttpResponseMessage response3 = clientt.GetAsync(urlBattery).Result;
				if (response3.IsSuccessStatusCode)
				{
					var dataObjects = JsonConvert.DeserializeObject<List<NodeBattery>>(response3.Content.ReadAsStringAsync().Result);

					batteries = dataObjects;
				}
				else
				{
					Console.WriteLine("{0} ({1})", (int)response3.StatusCode, response3.ReasonPhrase);
				}
				HttpResponseMessage response4 = clientt.GetAsync(urlLocation).Result;
				if (response4.IsSuccessStatusCode)
				{
					var dataObjects = JsonConvert.DeserializeObject<List<NodeLocation>>(response4.Content.ReadAsStringAsync().Result);

					locations = dataObjects;
				}
				else
				{
					Console.WriteLine("{0} ({1})", (int)response4.StatusCode, response4.ReasonPhrase);
				}
				

			}
			catch (Exception e)
			{
				Console.WriteLine("Connection failed " + e.ToString());
				return false;
			}
			//Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
			clientt.Dispose();
			return true;
		}

		private void FormNodejs_FormClosing(object sender, FormClosingEventArgs e)
		{
			timer1.Stop();
		}
	}
}
