﻿namespace PresentationLayer
{
    partial class ProductWindows
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
            btnModify = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            dataGridViewProduct = new DataGridView();
            txtProduct = new TextBox();
            txtPrice = new TextBox();
            txtStock = new TextBox();
            boxCategory = new ComboBox();
            btnSearch = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProduct).BeginInit();
            SuspendLayout();
            // 
            // btnModify
            // 
            btnModify.Location = new Point(575, 68);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(94, 29);
            btnModify.TabIndex = 0;
            btnModify.Text = "Modificar";
            btnModify.UseVisualStyleBackColor = true;
            btnModify.Click += btnModify_Click_1;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(709, 68);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Eliminar";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click_1;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(575, 22);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Agregar";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(90, 222);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 3;
            label1.Text = "Buscar";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(149, 77);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 4;
            label2.Text = "Precio";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(71, 31);
            label3.Name = "label3";
            label3.Size = new Size(129, 20);
            label3.TabIndex = 5;
            label3.Text = "Nombre producto";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(350, 35);
            label4.Name = "label4";
            label4.Size = new Size(45, 20);
            label4.TabIndex = 6;
            label4.Text = "Stock";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(350, 77);
            label5.Name = "label5";
            label5.Size = new Size(74, 20);
            label5.TabIndex = 7;
            label5.Text = "Categoria";
            // 
            // dataGridViewProduct
            // 
            dataGridViewProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProduct.Location = new Point(177, 250);
            dataGridViewProduct.Name = "dataGridViewProduct";
            dataGridViewProduct.RowHeadersWidth = 51;
            dataGridViewProduct.Size = new Size(592, 188);
            dataGridViewProduct.TabIndex = 8;
            dataGridViewProduct.CellDoubleClick += dataGridViewProduct_CellDoubleClick;
            // 
            // txtProduct
            // 
            txtProduct.Location = new Point(206, 28);
            txtProduct.Name = "txtProduct";
            txtProduct.Size = new Size(125, 27);
            txtProduct.TabIndex = 9;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(206, 70);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(125, 27);
            txtPrice.TabIndex = 10;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(432, 28);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(125, 27);
            txtStock.TabIndex = 11;
            // 
            // boxCategory
            // 
            boxCategory.FormattingEnabled = true;
            boxCategory.Location = new Point(432, 68);
            boxCategory.Name = "boxCategory";
            boxCategory.Size = new Size(125, 28);
            boxCategory.TabIndex = 12;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(177, 215);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(178, 27);
            btnSearch.TabIndex = 13;
            btnSearch.TextChanged += btnSearch_TextChanged;
            // 
            // ProductWindows
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(999, 450);
            Controls.Add(btnSearch);
            Controls.Add(boxCategory);
            Controls.Add(txtStock);
            Controls.Add(txtPrice);
            Controls.Add(txtProduct);
            Controls.Add(dataGridViewProduct);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnAdd);
            Controls.Add(btnDelete);
            Controls.Add(btnModify);
            Name = "ProductWindows";
            Text = "ProductWindows";
            Load += ProductWindows_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewProduct).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnModify;
        private Button btnDelete;
        private Button btnAdd;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private DataGridView dataGridViewProduct;
        private TextBox txtProduct;
        private TextBox txtPrice;
        private TextBox txtStock;
        private ComboBox boxCategory;
        private TextBox btnSearch;
    }
}