namespace Slau
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Gauss_Zeidel = new System.Windows.Forms.Button();
            this.Gauss_Jordano = new System.Windows.Forms.Button();
            this.Next = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(503, 89);
            this.dataGridView1.TabIndex = 0;
            // 
            // Gauss_Zeidel
            // 
            this.Gauss_Zeidel.Location = new System.Drawing.Point(2, 90);
            this.Gauss_Zeidel.Name = "Gauss_Zeidel";
            this.Gauss_Zeidel.Size = new System.Drawing.Size(92, 23);
            this.Gauss_Zeidel.TabIndex = 1;
            this.Gauss_Zeidel.Text = "Гаусс-Зейдель";
            this.Gauss_Zeidel.UseVisualStyleBackColor = true;
            this.Gauss_Zeidel.Click += new System.EventHandler(this.Gauss_Zeidel_Click);
            // 
            // Gauss_Jordano
            // 
            this.Gauss_Jordano.Location = new System.Drawing.Point(114, 90);
            this.Gauss_Jordano.Name = "Gauss_Jordano";
            this.Gauss_Jordano.Size = new System.Drawing.Size(95, 23);
            this.Gauss_Jordano.TabIndex = 2;
            this.Gauss_Jordano.Text = "Гаусс-Жордано";
            this.Gauss_Jordano.UseVisualStyleBackColor = true;
            this.Gauss_Jordano.Click += new System.EventHandler(this.Gauss_Jordano_Click);
            // 
            // Next
            // 
            this.Next.Location = new System.Drawing.Point(240, 90);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(75, 23);
            this.Next.TabIndex = 3;
            this.Next.Text = "Next";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 114);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.Gauss_Jordano);
            this.Controls.Add(this.Gauss_Zeidel);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Gauss_Zeidel;
        private System.Windows.Forms.Button Gauss_Jordano;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.Label label1;
    }
}