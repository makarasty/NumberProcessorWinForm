namespace NumberProcessorWinForm
{
	public partial class Form1 : Form
	{
		private int[] numbers;
		private const int arraySize = 1000;
		private readonly Random rand = new();

		private readonly object evenLock = new();
		private readonly object oddLock = new();

		public Form1()
		{
			InitializeComponent();
		}

		private async void btnStart_Click(object sender, EventArgs e)
		{
			btnStart.Enabled = false;
			ClearPanels();

			GenerateArray();
			progressBar.Value = 0;

			progressBar.Minimum = 0;
			progressBar.Maximum = arraySize;
			progressBar.Value = 0;

			var progress = new Progress<int>(value =>
			{
				if (value <= progressBar.Maximum)
				{
					progressBar.Value = value;
				}
			});

			await ProcessNumbersAsync(progress);
			MessageBox.Show("Готово!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

			btnStart.Enabled = true;
		}

		private void GenerateArray()
		{
			numbers = new int[arraySize];
			for (int i = 0; i < arraySize; i++)
			{
				numbers[i] = rand.Next(1, 11);
			}
		}
		private void ClearPanels()
		{
			ClearPanel(panelEven);
			ClearPanel(panelOdd);
		}

		private void ClearPanel(Panel panel)
		{
			while (panel.Controls.Count > 1)
			{
				panel.Controls.RemoveAt(1);
			}
		}

		private Task ProcessNumbersAsync(IProgress<int> progress)
		{
			return Task.Run(() =>
			{
				int processed = 0;

				ParallelOptions parallelOptions = new()
				{
					MaxDegreeOfParallelism = Environment.ProcessorCount
				};

				Parallel.For(0, numbers.Length, parallelOptions, i =>
				{
					int number = numbers[i];
					Thread.Sleep(number);

					if (number % 2 == 0)
					{
						AddNumberToPanel(panelEven, number, evenLock);
					}
					else
					{
						AddNumberToPanel(panelOdd, number, oddLock);
					}

					int current = Interlocked.Increment(ref processed);
					progress.Report(current);
				});
			});
		}

		private void AddNumberToPanel(Panel panel, int number, object lockObj)
		{
			if (panel.InvokeRequired)
			{
				panel.Invoke(new Action(() => AddNumberToPanel(panel, number, lockObj)));
			}
			else
			{
				lock (lockObj)
				{
					Label lbl = new()
					{
						Text = number.ToString(),
						AutoSize = true,
						Font = new Font("Arial", 10),
						Location = new Point(10, panel.Controls.Count * 20 + 30)
					};
					panel.Controls.Add(lbl);
				}
			}
		}
	}
}
