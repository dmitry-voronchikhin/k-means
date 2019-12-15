namespace k_means
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid = new System.Windows.Forms.DataGridView();
            this.addColumnButton = new System.Windows.Forms.Button();
            this.delColumnButton = new System.Windows.Forms.Button();
            this.addColumnBox = new System.Windows.Forms.TextBox();
            this.delColumnBox = new System.Windows.Forms.ComboBox();
            this.solveButton = new System.Windows.Forms.Button();
            this.kBox = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tmpGrid = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmpGrid)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(13, 27);
            this.grid.Name = "grid";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.grid.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.grid.Size = new System.Drawing.Size(662, 330);
            this.grid.TabIndex = 0;
            // 
            // addColumnButton
            // 
            this.addColumnButton.Location = new System.Drawing.Point(684, 53);
            this.addColumnButton.Name = "addColumnButton";
            this.addColumnButton.Size = new System.Drawing.Size(161, 23);
            this.addColumnButton.TabIndex = 1;
            this.addColumnButton.Text = "Добавить столбец";
            this.addColumnButton.UseVisualStyleBackColor = true;
            this.addColumnButton.Click += new System.EventHandler(this.addColumnButton_Click);
            // 
            // delColumnButton
            // 
            this.delColumnButton.Location = new System.Drawing.Point(684, 121);
            this.delColumnButton.Name = "delColumnButton";
            this.delColumnButton.Size = new System.Drawing.Size(161, 23);
            this.delColumnButton.TabIndex = 1;
            this.delColumnButton.Text = "Удалить столбец";
            this.delColumnButton.UseVisualStyleBackColor = true;
            this.delColumnButton.Click += new System.EventHandler(this.delColumnButton_Click);
            // 
            // addColumnBox
            // 
            this.addColumnBox.Location = new System.Drawing.Point(684, 27);
            this.addColumnBox.Name = "addColumnBox";
            this.addColumnBox.Size = new System.Drawing.Size(161, 20);
            this.addColumnBox.TabIndex = 2;
            // 
            // delColumnBox
            // 
            this.delColumnBox.FormattingEnabled = true;
            this.delColumnBox.Location = new System.Drawing.Point(684, 94);
            this.delColumnBox.Name = "delColumnBox";
            this.delColumnBox.Size = new System.Drawing.Size(161, 21);
            this.delColumnBox.TabIndex = 3;
            // 
            // solveButton
            // 
            this.solveButton.Location = new System.Drawing.Point(684, 218);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(161, 35);
            this.solveButton.TabIndex = 4;
            this.solveButton.Text = "Решить";
            this.solveButton.UseVisualStyleBackColor = true;
            this.solveButton.Click += new System.EventHandler(this.solveButton_Click);
            // 
            // kBox
            // 
            this.kBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.kBox.Location = new System.Drawing.Point(706, 192);
            this.kBox.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.kBox.Name = "kBox";
            this.kBox.ReadOnly = true;
            this.kBox.Size = new System.Drawing.Size(139, 20);
            this.kBox.TabIndex = 7;
            this.kBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kBox.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(681, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "k:";
            // 
            // tmpGrid
            // 
            this.tmpGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tmpGrid.Location = new System.Drawing.Point(867, 27);
            this.tmpGrid.Name = "tmpGrid";
            this.tmpGrid.Size = new System.Drawing.Size(446, 330);
            this.tmpGrid.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1325, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 369);
            this.Controls.Add(this.tmpGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kBox);
            this.Controls.Add(this.solveButton);
            this.Controls.Add(this.delColumnBox);
            this.Controls.Add(this.addColumnBox);
            this.Controls.Add(this.delColumnButton);
            this.Controls.Add(this.addColumnButton);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "k-means";
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmpGrid)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button addColumnButton;
        private System.Windows.Forms.Button delColumnButton;
        private System.Windows.Forms.TextBox addColumnBox;
        private System.Windows.Forms.ComboBox delColumnBox;
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.NumericUpDown kBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView tmpGrid;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
    }
}

