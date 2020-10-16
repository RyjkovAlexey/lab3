namespace Clock
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
            this.myWatch1 = new Clock.myWatch();
            this.SuspendLayout();
            // 
            // myWatch1
            // 
            this.myWatch1.Location = new System.Drawing.Point(107, 68);
            this.myWatch1.Name = "myWatch1";
            this.myWatch1.Size = new System.Drawing.Size(319, 319);
            this.myWatch1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 512);
            this.Controls.Add(this.myWatch1);
            this.Name = "Form1";
            this.Text = "Часы демонстрация";
            this.ResumeLayout(false);

        }

        #endregion

        private myWatch myWatch1;
    }
}

