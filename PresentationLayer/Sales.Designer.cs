﻿namespace PresentationLayer
{
    partial class Sales
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            panel1 = new Panel();
            btnCashClosing = new Button();
            comboBoxMethod = new ComboBox();
            label_Total = new Label();
            label8 = new Label();
            buttonPagar = new Button();
            dataGridView1 = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Producto = new DataGridViewTextBoxColumn();
            Precio = new DataGridViewTextBoxColumn();
            Cantidad_a_vender = new DataGridViewTextBoxColumn();
            Descuento = new DataGridViewTextBoxColumn();
            Subtotal = new DataGridViewTextBoxColumn();
            X = new DataGridViewButtonColumn();
            label_hour = new Label();
            label2 = new Label();
            label_date = new Label();
            panel2 = new Panel();
            label_stock = new Label();
            txtDiscount = new TextBox();
            button1 = new Button();
            buttonAgregar = new Button();
            numericUpDownquantity = new NumericUpDown();
            label7 = new Label();
            label9 = new Label();
            label6 = new Label();
            label5 = new Label();
            label10 = new Label();
            label4 = new Label();
            txt_nameProduct = new TextBox();
            txt_price = new TextBox();
            Codigo_txt = new TextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            menuStrip1 = new MenuStrip();
            productsToolStripMenuItem = new ToolStripMenuItem();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownquantity).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(236, 28);
            label1.Name = "label1";
            label1.Size = new Size(361, 32);
            label1.TabIndex = 0;
            label1.Text = "VENTA DE PRODUCTOS";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientActiveCaption;
            panel1.Controls.Add(btnCashClosing);
            panel1.Controls.Add(comboBoxMethod);
            panel1.Controls.Add(label_Total);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(buttonPagar);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(label_hour);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label_date);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(-6, 90);
            panel1.Name = "panel1";
            panel1.Size = new Size(808, 517);
            panel1.TabIndex = 1;
            // 
            // btnCashClosing
            // 
            btnCashClosing.Location = new Point(725, 472);
            btnCashClosing.Margin = new Padding(3, 2, 3, 2);
            btnCashClosing.Name = "btnCashClosing";
            btnCashClosing.Size = new Size(82, 22);
            btnCashClosing.TabIndex = 6;
            btnCashClosing.Text = "Cerrar caja";
            btnCashClosing.UseVisualStyleBackColor = true;
            btnCashClosing.Click += btnCashClosing_Click;
            // 
            // comboBoxMethod
            // 
            comboBoxMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMethod.FormattingEnabled = true;
            comboBoxMethod.Location = new Point(682, 418);
            comboBoxMethod.Margin = new Padding(3, 2, 3, 2);
            comboBoxMethod.Name = "comboBoxMethod";
            comboBoxMethod.Size = new Size(106, 23);
            comboBoxMethod.TabIndex = 5;
            // 
            // label_Total
            // 
            label_Total.AutoSize = true;
            label_Total.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Total.Location = new Point(376, 434);
            label_Total.Name = "label_Total";
            label_Total.Size = new Size(20, 25);
            label_Total.TabIndex = 4;
            label_Total.Text = ".";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(158, 434);
            label8.Name = "label8";
            label8.Size = new Size(188, 25);
            label8.TabIndex = 4;
            label8.Text = "Precio a Pagar:";
            // 
            // buttonPagar
            // 
            buttonPagar.Location = new Point(16, 418);
            buttonPagar.Margin = new Padding(3, 2, 3, 2);
            buttonPagar.Name = "buttonPagar";
            buttonPagar.Size = new Size(130, 42);
            buttonPagar.TabIndex = 3;
            buttonPagar.Text = "Vender";
            buttonPagar.UseVisualStyleBackColor = true;
            buttonPagar.Click += buttonPagar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Id, Producto, Precio, Cantidad_a_vender, Descuento, Subtotal, X });
            dataGridView1.Location = new Point(20, 215);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(771, 199);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Width = 125;
            // 
            // Producto
            // 
            Producto.HeaderText = "Producto";
            Producto.MinimumWidth = 6;
            Producto.Name = "Producto";
            Producto.ReadOnly = true;
            Producto.Width = 125;
            // 
            // Precio
            // 
            Precio.HeaderText = "Precio";
            Precio.MinimumWidth = 6;
            Precio.Name = "Precio";
            Precio.ReadOnly = true;
            Precio.Width = 125;
            // 
            // Cantidad_a_vender
            // 
            Cantidad_a_vender.HeaderText = "Cantidad_a_vender";
            Cantidad_a_vender.MinimumWidth = 6;
            Cantidad_a_vender.Name = "Cantidad_a_vender";
            Cantidad_a_vender.ReadOnly = true;
            Cantidad_a_vender.Width = 125;
            // 
            // Descuento
            // 
            Descuento.HeaderText = "Descuento";
            Descuento.MinimumWidth = 6;
            Descuento.Name = "Descuento";
            Descuento.ReadOnly = true;
            Descuento.Width = 125;
            // 
            // Subtotal
            // 
            Subtotal.HeaderText = "Subtotal";
            Subtotal.MinimumWidth = 6;
            Subtotal.Name = "Subtotal";
            Subtotal.ReadOnly = true;
            Subtotal.Width = 125;
            // 
            // X
            // 
            X.HeaderText = "X";
            X.MinimumWidth = 6;
            X.Name = "X";
            X.ReadOnly = true;
            X.Width = 125;
            // 
            // label_hour
            // 
            label_hour.AutoSize = true;
            label_hour.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_hour.Location = new Point(707, 12);
            label_hour.Name = "label_hour";
            label_hour.Size = new Size(57, 18);
            label_hour.TabIndex = 1;
            label_hour.Text = "HORA";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(471, 334);
            label2.Name = "label2";
            label2.Size = new Size(124, 20);
            label2.TabIndex = 1;
            label2.Text = "Metodo de Pago";
            // 
            // label_date
            // 
            label_date.AutoSize = true;
            label_date.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_date.Location = new Point(542, 12);
            label_date.Name = "label_date";
            label_date.Size = new Size(63, 18);
            label_date.TabIndex = 1;
            label_date.Text = "FECHA";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLight;
            panel2.Controls.Add(label_stock);
            panel2.Controls.Add(txtDiscount);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(buttonAgregar);
            panel2.Controls.Add(numericUpDownquantity);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txt_nameProduct);
            panel2.Controls.Add(txt_price);
            panel2.Controls.Add(Codigo_txt);
            panel2.Location = new Point(17, 46);
            panel2.Name = "panel2";
            panel2.Size = new Size(772, 164);
            panel2.TabIndex = 0;
            // 
            // label_stock
            // 
            label_stock.AutoSize = true;
            label_stock.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_stock.Location = new Point(303, 111);
            label_stock.Name = "label_stock";
            label_stock.Size = new Size(13, 20);
            label_stock.TabIndex = 6;
            label_stock.Text = ".";
            // 
            // txtDiscount
            // 
            txtDiscount.Location = new Point(514, 57);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.Size = new Size(71, 23);
            txtDiscount.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(27, 15);
            button1.Name = "button1";
            button1.Size = new Size(103, 23);
            button1.TabIndex = 4;
            button1.Text = "Buscar Producto";
            button1.UseVisualStyleBackColor = true;
            // 
            // buttonAgregar
            // 
            buttonAgregar.Location = new Point(655, 57);
            buttonAgregar.Name = "buttonAgregar";
            buttonAgregar.Size = new Size(74, 58);
            buttonAgregar.TabIndex = 3;
            buttonAgregar.Text = "Agregar";
            buttonAgregar.UseVisualStyleBackColor = true;
            buttonAgregar.Click += buttonAgregar_Click;
            // 
            // numericUpDownquantity
            // 
            numericUpDownquantity.Location = new Point(322, 57);
            numericUpDownquantity.Name = "numericUpDownquantity";
            numericUpDownquantity.Size = new Size(77, 23);
            numericUpDownquantity.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(245, 111);
            label7.Name = "label7";
            label7.Size = new Size(52, 20);
            label7.TabIndex = 1;
            label7.Text = "Stock:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(425, 57);
            label9.Name = "label9";
            label9.Size = new Size(83, 20);
            label9.TabIndex = 1;
            label9.Text = "Descuento";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(245, 59);
            label6.Name = "label6";
            label6.Size = new Size(71, 20);
            label6.TabIndex = 1;
            label6.Text = "Cantidad";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(27, 111);
            label5.Name = "label5";
            label5.Size = new Size(73, 20);
            label5.TabIndex = 1;
            label5.Text = "Producto";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(425, 111);
            label10.Name = "label10";
            label10.Size = new Size(52, 20);
            label10.TabIndex = 1;
            label10.Text = "Precio";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(27, 60);
            label4.Name = "label4";
            label4.Size = new Size(76, 20);
            label4.TabIndex = 1;
            label4.Text = "Codigo Id";
            // 
            // txt_nameProduct
            // 
            txt_nameProduct.Location = new Point(109, 112);
            txt_nameProduct.Name = "txt_nameProduct";
            txt_nameProduct.Size = new Size(100, 23);
            txt_nameProduct.TabIndex = 0;
            txt_nameProduct.TextChanged += txt_nameProduct_TextChanged;
            txt_nameProduct.KeyDown += txt_nameProduct_KeyDown;
            // 
            // txt_price
            // 
            txt_price.Location = new Point(486, 111);
            txt_price.Name = "txt_price";
            txt_price.ReadOnly = true;
            txt_price.Size = new Size(100, 23);
            txt_price.TabIndex = 0;
            // 
            // Codigo_txt
            // 
            Codigo_txt.Location = new Point(109, 60);
            Codigo_txt.Name = "Codigo_txt";
            Codigo_txt.ReadOnly = true;
            Codigo_txt.Size = new Size(100, 23);
            Codigo_txt.TabIndex = 0;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { productsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(795, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // productsToolStripMenuItem
            // 
            productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            productsToolStripMenuItem.Size = new Size(73, 20);
            productsToolStripMenuItem.Text = "Productos";
            productsToolStripMenuItem.Click += productsToolStripMenuItem_Click;
            // 
            // Sales
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(795, 562);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Sales";
            Text = "Sales";
            Load += Sales_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownquantity).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Panel panel2;
        private Label label_hour;
        private Label label_date;
        private Label label5;
        private Label label4;
        private TextBox txt_nameProduct;
        private TextBox Codigo_txt;
        private Label label7;
        private Label label6;
        private NumericUpDown numericUpDownquantity;
        private DataGridView dataGridView1;
        private Button buttonAgregar;
        private Button button1;
        private Label label8;
        private Button buttonPagar;
        private TextBox txtDiscount;
        private Label label9;
        private Label label10;
        private TextBox txt_price;
        private Label label_stock;
        private Label label_Total;
        private System.Windows.Forms.Timer timer1;
        private ComboBox comboBoxMethod;
        private Label label2;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Producto;
        private DataGridViewTextBoxColumn Precio;
        private DataGridViewTextBoxColumn Cantidad_a_vender;
        private DataGridViewTextBoxColumn Descuento;
        private DataGridViewTextBoxColumn Subtotal;
        private DataGridViewButtonColumn X;
        private Button btnCashClosing;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem productsToolStripMenuItem;
    }
}