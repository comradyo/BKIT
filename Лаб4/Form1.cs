using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;


namespace Лаб4
{
    public partial class Form1 : Form
    {
        //Список для хранения уникальных слов
        List<string> fileWords = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonStartTimer_Click(object sender, EventArgs e)
        {
            //Запуск таймера
            timer1.Start();
        }

        private void buttonStopTimer_Click(object sender, EventArgs e)
        {
            //Остановка таймера
            timer1.Stop();
        }

        private void buttonLoadFile_Click(object sender, EventArgs e)
        {
            fileWords.Clear();
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "текстовые файлы|*.txt";

            if (fd.ShowDialog() == DialogResult.OK)
            {
                //Таймер, фиксирующий время поиска всех слов в файле
                Stopwatch timerWordsExtraction = new Stopwatch();
                timerWordsExtraction.Start();
                //Считывание файла в строку text
                string text = File.ReadAllText(fd.FileName);
                //Разделительные символы для чтения из файла
                char[] separators = new char[] { ' ', '.', ',', '!', '?', '/', '\t', '\n' };
                string[] textArray = text.Split(separators);
                foreach (string strTemp in textArray)
                {
                    //Удаление пробелов в начале и конце строки
                    string str = strTemp.Trim();
                    //Добавление строки в список, если строка не содержится в списке
                    if (!fileWords.Contains(str)) fileWords.Add(str);
                }
                timerWordsExtraction.Stop();
                this.labelWordsExtractionTime.Text = timerWordsExtraction.Elapsed.ToString();
                this.labelWordsCount.Text = fileWords.Count.ToString();
            }
            else
            {
                MessageBox.Show("Необходимо выбрать файл");
            }
        }

        private void buttonFindWord_Click(object sender, EventArgs e)
        {
            if (textBoxWordForSearch.Text != "" && fileWords.Count != 0)
            {
                bool isFind = false;
                Stopwatch fixedTime = new Stopwatch();
                fixedTime.Start();
                if (fileWords.Contains(textBoxWordForSearch.Text))
                    isFind = true;
                fixedTime.Stop();
                if (isFind)
                {
                    listBoxFoundWords.BeginUpdate();
                    listBoxFoundWords.Items.Add(textBoxWordForSearch.Text);
                    listBoxFoundWords.EndUpdate();
                }
                labelWordSearchTime.Text = fixedTime.Elapsed.ToString();
            }
            textBoxWordForSearch.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
