namespace PresentationLayer
{
    partial class emerging_products
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            textBox1 = new TextBox();
            comboBoxFilter = new ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(0, 80);
            panel1.Name = "panel1";
            panel1.Size = new Size(816, 344);
            panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(35, 22);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(732, 295);
            dataGridView1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(18, 29);
            label1.Name = "label1";
            label1.Size = new Size(155, 22);
            label1.TabIndex = 0;
            label1.Text = "Buscar por nombre";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(245, 31);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // comboBoxFilter
            // 
            comboBoxFilter.FormattingEnabled = true;
            comboBoxFilter.Items.AddRange(new object[] { "Nombre", "Categoria" });
            comboBoxFilter.Location = new Point(108, 31);
            comboBoxFilter.Name = "comboBoxFilter";
            comboBoxFilter.Size = new Size(121, 23);
            comboBoxFilter.TabIndex = 2;
            // 
            // emerging_products
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 419);
            Controls.Add(comboBoxFilter);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "emerging_products";
            Text = "emerging_products";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox textBox1;
        private DataGridView dataGridView1;
        private ComboBox comboBoxFilter;
    }
}