namespace NumberProcessorWinForm
{
	partial class Form1
	{
		private System.ComponentModel.IContainer components = null;

		private System.Windows.Forms.Panel panelEven;
		private System.Windows.Forms.Panel panelOdd;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.ProgressBar progressBar;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.panelEven = new System.Windows.Forms.Panel();
			this.panelOdd = new System.Windows.Forms.Panel();
			this.btnStart = new System.Windows.Forms.Button();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// panelEven
			// 
			this.panelEven.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelEven.Location = new System.Drawing.Point(50, 100);
			this.panelEven.Name = "panelEven";
			this.panelEven.Size = new System.Drawing.Size(300, 400);
			this.panelEven.TabIndex = 0;
			// 
			// panelOdd
			// 
			this.panelOdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelOdd.Location = new System.Drawing.Point(450, 100);
			this.panelOdd.Name = "panelOdd";
			this.panelOdd.Size = new System.Drawing.Size(300, 400);
			this.panelOdd.TabIndex = 1;
			// 
			// btnStart
			// 
			this.btnStart.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.btnStart.Location = new System.Drawing.Point(350, 20);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(100, 40);
			this.btnStart.TabIndex = 2;
			this.btnStart.Text = "Почати";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(50, 520);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(700, 30);
			this.progressBar.TabIndex = 3;
			this.progressBar.Minimum = 0;
			this.progressBar.Maximum = 1000;
			this.progressBar.Value = 0;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 570);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.panelOdd);
			this.Controls.Add(this.panelEven);
			this.Name = "Form1";
			this.Text = "Супер крутий обробник чисел";
			this.ResumeLayout(false);

			InitializePanelHeaders();
		}

		private void InitializePanelHeaders()
		{
			Label lblEven = new Label
			{
				Text = "Парні",
				Location = new System.Drawing.Point(10, 10),
				AutoSize = true,
				Font = new Font("Arial", 12, FontStyle.Bold)
			};
			this.panelEven.Controls.Add(lblEven);

			Label lblOdd = new Label
			{
				Text = "Непарні",
				Location = new System.Drawing.Point(10, 10),
				AutoSize = true,
				Font = new Font("Arial", 12, FontStyle.Bold)
			};
			this.panelOdd.Controls.Add(lblOdd);
		}
	}
}
