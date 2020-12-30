namespace Лаб4
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonLoadFile = new System.Windows.Forms.Button();
            this.buttonFindWord = new System.Windows.Forms.Button();
            this.textBoxWordForSearch = new System.Windows.Forms.TextBox();
            this.listBoxFoundWords = new System.Windows.Forms.ListBox();
            this.labelWordSearchTime = new System.Windows.Forms.Label();
            this.labelWordsExtractionTime = new System.Windows.Forms.Label();
            this.labelWordsCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonLoadFile
            // 
            this.buttonLoadFile.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLoadFile.Location = new System.Drawing.Point(12, 12);
            this.buttonLoadFile.Name = "buttonLoadFile";
            this.buttonLoadFile.Size = new System.Drawing.Size(214, 38);
            this.buttonLoadFile.TabIndex = 8;
            this.buttonLoadFile.Text = "Чтение из файла";
            this.buttonLoadFile.UseVisualStyleBackColor = true;
            this.buttonLoadFile.Click += new System.EventHandler(this.buttonLoadFile_Click);
            // 
            // buttonFindWord
            // 
            this.buttonFindWord.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFindWord.Location = new System.Drawing.Point(12, 112);
            this.buttonFindWord.Name = "buttonFindWord";
            this.buttonFindWord.Size = new System.Drawing.Size(214, 23);
            this.buttonFindWord.TabIndex = 11;
            this.buttonFindWord.Text = "Найти слово в файле";
            this.buttonFindWord.UseVisualStyleBackColor = true;
            this.buttonFindWord.Click += new System.EventHandler(this.buttonFindWord_Click);
            // 
            // textBoxWordForSearch
            // 
            this.textBoxWordForSearch.Location = new System.Drawing.Point(12, 88);
            this.textBoxWordForSearch.Name = "textBoxWordForSearch";
            this.textBoxWordForSearch.Size = new System.Drawing.Size(214, 20);
            this.textBoxWordForSearch.TabIndex = 12;
            // 
            // listBoxFoundWords
            // 
            this.listBoxFoundWords.FormattingEnabled = true;
            this.listBoxFoundWords.Location = new System.Drawing.Point(12, 142);
            this.listBoxFoundWords.Name = "listBoxFoundWords";
            this.listBoxFoundWords.Size = new System.Drawing.Size(214, 121);
            this.listBoxFoundWords.TabIndex = 13;
            // 
            // labelWordSearchTime
            // 
            this.labelWordSearchTime.AutoSize = true;
            this.labelWordSearchTime.Font = new System.Drawing.Font("DS-Digital", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWordSearchTime.Location = new System.Drawing.Point(244, 94);
            this.labelWordSearchTime.Name = "labelWordSearchTime";
            this.labelWordSearchTime.Size = new System.Drawing.Size(0, 16);
            this.labelWordSearchTime.TabIndex = 14;
            // 
            // labelWordsExtractionTime
            // 
            this.labelWordsExtractionTime.AutoSize = true;
            this.labelWordsExtractionTime.Font = new System.Drawing.Font("DS-Digital", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWordsExtractionTime.Location = new System.Drawing.Point(244, 23);
            this.labelWordsExtractionTime.Name = "labelWordsExtractionTime";
            this.labelWordsExtractionTime.Size = new System.Drawing.Size(0, 16);
            this.labelWordsExtractionTime.TabIndex = 15;
            // 
            // labelWordsCount
            // 
            this.labelWordsCount.AutoSize = true;
            this.labelWordsCount.Font = new System.Drawing.Font("DS-Digital", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWordsCount.Location = new System.Drawing.Point(244, 59);
            this.labelWordsCount.Name = "labelWordsCount";
            this.labelWordsCount.Size = new System.Drawing.Size(0, 16);
            this.labelWordsCount.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(9, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "Количество уникальных слов в файле:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 283);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelWordsCount);
            this.Controls.Add(this.labelWordsExtractionTime);
            this.Controls.Add(this.labelWordSearchTime);
            this.Controls.Add(this.listBoxFoundWords);
            this.Controls.Add(this.textBoxWordForSearch);
            this.Controls.Add(this.buttonFindWord);
            this.Controls.Add(this.buttonLoadFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonLoadFile;
        private System.Windows.Forms.Button buttonFindWord;
        private System.Windows.Forms.TextBox textBoxWordForSearch;
        private System.Windows.Forms.ListBox listBoxFoundWords;
        private System.Windows.Forms.Label labelWordSearchTime;
        private System.Windows.Forms.Label labelWordsExtractionTime;
        private System.Windows.Forms.Label labelWordsCount;
        private System.Windows.Forms.Label label1;
    }
}

