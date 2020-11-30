
namespace HomeworkProject.Views

{
    partial class MainForm
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
            this.showSpecialtiesButton = new System.Windows.Forms.Button();
            this.showGroupsButton = new System.Windows.Forms.Button();
            this.showStudentsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // showSpecialtiesButton
            // 
            this.showSpecialtiesButton.Location = new System.Drawing.Point(12, 12);
            this.showSpecialtiesButton.Name = "showSpecialtiesButton";
            this.showSpecialtiesButton.Size = new System.Drawing.Size(105, 39);
            this.showSpecialtiesButton.TabIndex = 0;
            this.showSpecialtiesButton.Text = "Специальности";
            this.showSpecialtiesButton.UseVisualStyleBackColor = true;
            // 
            // showGroupsButton
            // 
            this.showGroupsButton.Location = new System.Drawing.Point(139, 12);
            this.showGroupsButton.Name = "showGroupsButton";
            this.showGroupsButton.Size = new System.Drawing.Size(105, 39);
            this.showGroupsButton.TabIndex = 1;
            this.showGroupsButton.Text = "Группы";
            this.showGroupsButton.UseVisualStyleBackColor = true;
            // 
            // showStudentsButton
            // 
            this.showStudentsButton.Location = new System.Drawing.Point(273, 12);
            this.showStudentsButton.Name = "showStudentsButton";
            this.showStudentsButton.Size = new System.Drawing.Size(111, 39);
            this.showStudentsButton.TabIndex = 2;
            this.showStudentsButton.Text = "Студенты";
            this.showStudentsButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 72);
            this.Controls.Add(this.showStudentsButton);
            this.Controls.Add(this.showGroupsButton);
            this.Controls.Add(this.showSpecialtiesButton);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главное окно";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button showSpecialtiesButton;
        private System.Windows.Forms.Button showGroupsButton;
        private System.Windows.Forms.Button showStudentsButton;
    }
}

