using System;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace TranslitMaker
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Для обновления отчета об ошибках
		/// </summary>
		/// <param name="text">Новая запись в логе</param>
		private delegate void changeLogCallback(string text);

		/// <summary>
		/// Изменение полосы прогресса
		/// </summary>
		/// <param name="position">Новая позиция в полосе прогресса или -1</param>
		/// <param name="maxPosition">Максимальное значение полосы прогресса или -1</param>
		private delegate void changeProgressCallback(int position, int maxPosition);

		/// <summary>
		/// Остановка процесса и обновление интерфейса
		/// </summary>
		private delegate void stopProcessCallback();

		/// <summary>
		/// Поток переименования файлов
		/// </summary>
		private Thread renaming;

		private void changeDirButton_Click(object sender, EventArgs e)
		{
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
				dirTextBox.Text = folderBrowserDialog.SelectedPath;
		}

		/// <summary>
		/// Списки файлов и папок для переименования
		/// </summary>
		string[] files, dirs;

		private void renameButton_Click(object sender, EventArgs e)
		{
			//Добавление слеша в конце пути при его отсутствии
			string dirName = dirTextBox.Text;
			if (dirName[dirName.Length - 1] != '\\')
				dirName += "\\";
			//Установка свойств поиска
			SearchOption options =
				subDirsCheckBox.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
			try
			{
				//Получение списка файлов и папок к обработке
				files = Directory.GetFiles(dirName, maskTextBox.Text, options);
				dirs = Directory.GetDirectories(dirName, "*.*", options);
			}
			catch
			{
				MessageBox.Show("Нет доступа к одному или нескольким объектам выбранного каталога. " +
					"Пожалуйста, выберите другой каталог.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			//Создание процесса
			renaming = new Thread(ThreadProc);
			//Настройка интерфейса
			renameButton.Enabled = false;
			cancelButton.Enabled = true;
			logTextBox.Clear();
			progressBar.Value = 0;
			//Запуск переименования
			renaming.Start();
		}

		private void dirTextBox_TextChanged(object sender, EventArgs e)
		{
			renameButton.Enabled = Directory.Exists(dirTextBox.Text);
		}

		/// <summary>
		/// Набор русских и украинских символов
		/// </summary>
		private string[] cyrillic = { "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "л", "м", "н",
										"о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ь", "ы",
										"ъ", "э", "ю", "я", "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И",
										"Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц",
										"Ч", "Ш", "Щ", "Ь", "Ы", "Ъ", "Э", "Ю", "Я", "і", "ї", "є", "І", "Ї",
										"Є" };
		/// <summary>
		/// Набор замен русским и украинским символам
		/// </summary>
		private string[] translit = { "a", "b", "v", "g", "d", "e", "e", "zh", "z", "i", "y", "k", "l", "m", "n",
										"o", "p", "r", "s", "t", "u", "f", "h", "c", "ch", "sh", "sh'", "'", "i",
										"'", "e", "yu", "ya", "A", "B", "V", "G", "D", "E", "E", "Zh", "Z", "I",
										"Y", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "F", "H", "C",
										"Ch", "Sh", "Sh'", "'", "I", "'", "E", "Yu", "Ya", "i", "i", "e", "I",
										"I", "E" };

		/// <summary>
		/// Перевод символа на транслит
		/// </summary>
		/// <param name="ch">Кирилический символ</param>
		/// <returns>Символ на транслите</returns>
		private string translitSymbol(string ch)
		{
			//Поиск соотвествия
			int i = 0;
			for (; i < cyrillic.Length; i++)
				if (cyrillic[i] == ch)
					break;
			//Возврат транслита или исходного символа
			if (i < cyrillic.Length)
				return translit[i];
			else
				return ch;
		}

		/// <summary>
		/// Перевод символов в транслит
		/// </summary>
		/// <param name="name">Исходное имя</param>
		/// <returns>Имя в транслите</returns>
		private string rename(string name)
		{
			string res = string.Empty;
			//Замена символов только в имени файла
			int i;
			for (i = name.Length - 1; i >= 0; i--)
			{
				if (name[i] == '\\')
					break;
				res = translitSymbol(name[i].ToString()) + res;
			}
			//Копирование оставшегося пути и возврат результата
			res = name.Substring(0, i + 1) + res;
			return res;
		}

		/// <summary>
		/// Функция потока переименования файлов
		/// </summary>
		private void ThreadProc()
		{
			int max = files.Length + dirs.Length;
			//Переименование файлов
			int pos = 1;
			for (int i = 0; i < files.Length; i++, pos++)
			{
				try
				{
					File.Move(files[i], rename(files[i]));
				}
				catch
				{
					updateLog(files[i]);
				}
				updateProgress(pos, max);
			}
			//Переименование папок
			for (int i = dirs.Length - 1; i >= 0; i--, pos++)
			{
				if (!Directory.Exists(dirs[i]))
					continue;
				try
				{
					Directory.Move(dirs[i], rename(dirs[i]));
				}
				catch
				{
					updateLog(dirs[i]);
				}
				updateProgress(pos, max);
			}
			//Остановка процесса
			stopProcess();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			cancelButton.Enabled = false;
			renameButton.Enabled = true;
			renaming.Abort();
		}

		/// <summary>
		/// Обновление интерфейса отчета об ошибках
		/// </summary>
		/// <param name="text">Новая запись в отчете</param>
		private void updateLog(string text)
		{
			if (logTextBox.InvokeRequired)
				Invoke(new changeLogCallback(updateLog), new object[] { text });
			else
			{
				if (logTextBox.Text.Length > 0)
					logTextBox.Text += "\r\n";
				logTextBox.Text += text;
			}
		}

		/// <summary>
		/// Изменение полосы прогресса
		/// </summary>
		/// <param name="position">Новая позиция в полосе прогресса или -1</param>
		/// <param name="maxPosition">Максимальное значение полосы прогресса или -1</param>
		private void updateProgress(int position, int maxPosition)
		{
			if (progressBar.InvokeRequired)
				Invoke(new changeProgressCallback(updateProgress), new object[] { position, maxPosition });
			else
			{
				progressBar.Maximum = maxPosition;
				progressBar.Value = position;
			}
		}

		/// <summary>
		/// Остановка процесса и обновление интерфейса
		/// </summary>
		private void stopProcess()
		{
			if (cancelButton.InvokeRequired)
				Invoke(new stopProcessCallback(stopProcess), new object[] { });
			else
			{
				cancelButton.Enabled = false;
				renameButton.Enabled = true;
				renaming.Abort();
			}
		}
	}
}
