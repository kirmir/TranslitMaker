namespace TranslitMaker
{
	partial class MainForm
	{
		/// <summary>
		/// Требуется переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.dirTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.changeDirButton = new System.Windows.Forms.Button();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.subDirsCheckBox = new System.Windows.Forms.CheckBox();
			this.renameButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.logTextBox = new System.Windows.Forms.TextBox();
			this.cancelButton = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.maskTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// dirTextBox
			// 
			this.dirTextBox.Location = new System.Drawing.Point(12, 25);
			this.dirTextBox.Name = "dirTextBox";
			this.dirTextBox.Size = new System.Drawing.Size(396, 20);
			this.dirTextBox.TabIndex = 0;
			this.dirTextBox.TextChanged += new System.EventHandler(this.dirTextBox_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Каталог:";
			// 
			// changeDirButton
			// 
			this.changeDirButton.Location = new System.Drawing.Point(414, 23);
			this.changeDirButton.Name = "changeDirButton";
			this.changeDirButton.Size = new System.Drawing.Size(24, 23);
			this.changeDirButton.TabIndex = 1;
			this.changeDirButton.Text = "...";
			this.changeDirButton.UseVisualStyleBackColor = true;
			this.changeDirButton.Click += new System.EventHandler(this.changeDirButton_Click);
			// 
			// folderBrowserDialog
			// 
			this.folderBrowserDialog.Description = "Выберите папку для переименования русских имен файлов:";
			this.folderBrowserDialog.ShowNewFolderButton = false;
			// 
			// subDirsCheckBox
			// 
			this.subDirsCheckBox.AutoSize = true;
			this.subDirsCheckBox.Checked = true;
			this.subDirsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.subDirsCheckBox.Location = new System.Drawing.Point(172, 53);
			this.subDirsCheckBox.Name = "subDirsCheckBox";
			this.subDirsCheckBox.Size = new System.Drawing.Size(137, 17);
			this.subDirsCheckBox.TabIndex = 3;
			this.subDirsCheckBox.Text = "Включая подкаталоги";
			this.subDirsCheckBox.UseVisualStyleBackColor = true;
			// 
			// renameButton
			// 
			this.renameButton.Enabled = false;
			this.renameButton.Location = new System.Drawing.Point(132, 85);
			this.renameButton.Name = "renameButton";
			this.renameButton.Size = new System.Drawing.Size(106, 23);
			this.renameButton.TabIndex = 4;
			this.renameButton.Text = "Переименовать";
			this.renameButton.UseVisualStyleBackColor = true;
			this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 167);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(258, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Файлы и папки, которые не удалось обработать:";
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(12, 129);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(426, 23);
			this.progressBar.TabIndex = 6;
			// 
			// logTextBox
			// 
			this.logTextBox.Location = new System.Drawing.Point(12, 183);
			this.logTextBox.Multiline = true;
			this.logTextBox.Name = "logTextBox";
			this.logTextBox.ReadOnly = true;
			this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.logTextBox.Size = new System.Drawing.Size(426, 92);
			this.logTextBox.TabIndex = 6;
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Enabled = false;
			this.cancelButton.Location = new System.Drawing.Point(244, 85);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 5;
			this.cancelButton.Text = "Отмена";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 54);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(50, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Фильтр:";
			// 
			// maskTextBox
			// 
			this.maskTextBox.Location = new System.Drawing.Point(68, 51);
			this.maskTextBox.Name = "maskTextBox";
			this.maskTextBox.Size = new System.Drawing.Size(74, 20);
			this.maskTextBox.TabIndex = 2;
			this.maskTextBox.Text = "*.*";
			// 
			// MainForm
			// 
			this.AcceptButton = this.renameButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(450, 287);
			this.Controls.Add(this.maskTextBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.logTextBox);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.renameButton);
			this.Controls.Add(this.subDirsCheckBox);
			this.Controls.Add(this.changeDirButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dirTextBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Translit Maker";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox dirTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button changeDirButton;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.CheckBox subDirsCheckBox;
		private System.Windows.Forms.Button renameButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.TextBox logTextBox;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox maskTextBox;
	}
}

