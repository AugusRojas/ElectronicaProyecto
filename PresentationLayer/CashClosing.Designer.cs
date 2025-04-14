namespace PresentationLayer
{
    partial class CashClosing
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
            txtCard = new TextBox();
            btnCashClose = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtTotal = new TextBox();
            txtTrasnfer = new TextBox();
            txtCash = new TextBox();
            panel1 = new Panel();
            labelHour = new Label();
            labelDate = new Label();
            dataGridViewProducts = new DataGridView();
            label5 = new Label();
            txtTotalDay = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).BeginInit();
            SuspendLayout();
            // 
            // txtCard
            // 
            txtCard.Location = new Point(147, 63);
            txtCard.Name = "txtCard";
            txtCard.Size = new Size(125, 27);
            txtCard.TabIndex = 0;
            // 
            // btnCashClose
            // 
            btnCashClose.Location = new Point(639, 398);
            btnCashClose.Name = "btnCashClose";
            btnCashClose.Size = new Size(149, 29);
            btnCashClose.TabIndex = 1;
            btnCashClose.Text = "Cerrar e Imprimir caja";
            btnCashClose.UseVisualStyleBackColor = true;
            btnCashClose.Click += btnCashClose_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 23);
            label1.Name = "label1";
            label1.Size = new Size(62, 20);
            label1.TabIndex = 2;
            label1.Text = "Efectivo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 70);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 3;
            label2.Text = "Tarjeta";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 128);
            label3.Name = "label3";
            label3.Size = new Size(96, 20);
            label3.TabIndex = 4;
            label3.Text = "Transferencia";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(68, 185);
            label4.Name = "label4";
            label4.Size = new Size(42, 20);
            label4.TabIndex = 5;
            label4.Text = "Total";
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(147, 178);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(125, 27);
            txtTotal.TabIndex = 6;
            // 
            // txtTrasnfer
            // 
            txtTrasnfer.Location = new Point(147, 121);
            txtTrasnfer.Name = "txtTrasnfer";
            txtTrasnfer.Size = new Size(125, 27);
            txtTrasnfer.TabIndex = 7;
            // 
            // txtCash
            // 
            txtCash.Location = new Point(147, 16);
            txtCash.Name = "txtCash";
            txtCash.Size = new Size(125, 27);
            txtCash.TabIndex = 8;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(txtTrasnfer);
            panel1.Controls.Add(txtCash);
            panel1.Controls.Add(txtCard);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtTotal);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(302, 209);
            panel1.TabIndex = 9;
            // 
            // labelHour
            // 
            labelHour.AutoSize = true;
            labelHour.Font = new Font("Verdana", 11.25F, FontStyle.Bold);
            labelHour.Location = new Point(389, 35);
            labelHour.Name = "labelHour";
            labelHour.Size = new Size(163, 23);
            labelHour.TabIndex = 40;
            labelHour.Text = "Hora de cierre";
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Font = new Font("Verdana", 11.25F, FontStyle.Bold);
            labelDate.Location = new Point(571, 35);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(163, 23);
            labelDate.TabIndex = 41;
            labelDate.Text = "Hora de cierre";
            // 
            // dataGridViewProducts
            // 
            dataGridViewProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProducts.Location = new Point(320, 103);
            dataGridViewProducts.Name = "dataGridViewProducts";
            dataGridViewProducts.RowHeadersWidth = 51;
            dataGridViewProducts.Size = new Size(727, 266);
            dataGridViewProducts.TabIndex = 42;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(772, 372);
            label5.Name = "label5";
            label5.Size = new Size(96, 20);
            label5.TabIndex = 43;
            label5.Text = "Total Del Dia";
            // 
            // txtTotalDay
            // 
            txtTotalDay.AutoSize = true;
            txtTotalDay.Location = new Point(963, 372);
            txtTotalDay.Name = "txtTotalDay";
            txtTotalDay.Size = new Size(17, 20);
            txtTotalDay.TabIndex = 44;
            txtTotalDay.Text = "0";
            // 
            // CashClosing
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1059, 450);
            Controls.Add(txtTotalDay);
            Controls.Add(label5);
            Controls.Add(dataGridViewProducts);
            Controls.Add(labelDate);
            Controls.Add(labelHour);
            Controls.Add(panel1);
            Controls.Add(btnCashClose);
            Name = "CashClosing";
            Text = "CashClosing";
            FormClosing += CashClosing_FormClosing;
            Load += CashClosing_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCard;
        private Button btnCashClose;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtTotal;
        private TextBox txtTrasnfer;
        private TextBox txtCash;
        private Panel panel1;
        private Label labelHour;
        private Label labelDate;
        private DataGridView dataGridViewProducts;
        private Label label5;
        private Label txtTotalDay;
    }
}