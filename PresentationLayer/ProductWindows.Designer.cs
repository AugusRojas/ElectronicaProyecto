namespace PresentationLayer
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
            components = new System.ComponentModel.Container();
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
            groupProduct = new GroupBox();
            groupCategory = new GroupBox();
            boxDeleteCategory = new ComboBox();
            txtCategoryAdd = new TextBox();
            label7 = new Label();
            label6 = new Label();
            btnDeleteCategory = new Button();
            btnAddCategory = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            ((System.ComponentModel.ISupportInitialize)dataGridViewProduct).BeginInit();
            groupProduct.SuspendLayout();
            groupCategory.SuspendLayout();
            SuspendLayout();
            // 
            // btnModify
            // 
            btnModify.Location = new Point(453, 145);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(94, 29);
            btnModify.TabIndex = 0;
            btnModify.Text = "Modificar";
            btnModify.UseVisualStyleBackColor = true;
            btnModify.Click += btnModify_Click_1;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(453, 88);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Eliminar";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click_1;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(453, 29);
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
            label1.Location = new Point(29, 263);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 3;
            label1.Text = "Buscar";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(125, 75);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 4;
            label2.Text = "Precio";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(47, 29);
            label3.Name = "label3";
            label3.Size = new Size(129, 20);
            label3.TabIndex = 5;
            label3.Text = "Nombre producto";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(131, 114);
            label4.Name = "label4";
            label4.Size = new Size(45, 20);
            label4.TabIndex = 6;
            label4.Text = "Stock";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(101, 155);
            label5.Name = "label5";
            label5.Size = new Size(74, 20);
            label5.TabIndex = 7;
            label5.Text = "Categoria";
            // 
            // dataGridViewProduct
            // 
            dataGridViewProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProduct.Location = new Point(29, 286);
            dataGridViewProduct.Name = "dataGridViewProduct";
            dataGridViewProduct.RowHeadersWidth = 51;
            dataGridViewProduct.Size = new Size(1097, 261);
            dataGridViewProduct.TabIndex = 8;
            dataGridViewProduct.CellDoubleClick += dataGridViewProduct_CellDoubleClick;
            // 
            // txtProduct
            // 
            txtProduct.Location = new Point(196, 26);
            txtProduct.Name = "txtProduct";
            txtProduct.Size = new Size(125, 27);
            txtProduct.TabIndex = 9;
            txtProduct.KeyPress += txtProduct_KeyPress;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(196, 68);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(125, 27);
            txtPrice.TabIndex = 10;
            txtPrice.KeyPress += txtPrice_KeyPress;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(197, 107);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(125, 27);
            txtStock.TabIndex = 11;
            txtStock.KeyPress += txtStock_KeyPress;
            // 
            // boxCategory
            // 
            boxCategory.FormattingEnabled = true;
            boxCategory.Location = new Point(197, 147);
            boxCategory.Name = "boxCategory";
            boxCategory.Size = new Size(125, 28);
            boxCategory.TabIndex = 12;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(87, 253);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(256, 27);
            btnSearch.TabIndex = 13;
            btnSearch.TextChanged += btnSearch_TextChanged;
            // 
            // groupProduct
            // 
            groupProduct.Controls.Add(txtProduct);
            groupProduct.Controls.Add(label4);
            groupProduct.Controls.Add(btnAdd);
            groupProduct.Controls.Add(boxCategory);
            groupProduct.Controls.Add(label3);
            groupProduct.Controls.Add(label2);
            groupProduct.Controls.Add(btnDelete);
            groupProduct.Controls.Add(label5);
            groupProduct.Controls.Add(btnModify);
            groupProduct.Controls.Add(txtStock);
            groupProduct.Controls.Add(txtPrice);
            groupProduct.Location = new Point(29, 12);
            groupProduct.Name = "groupProduct";
            groupProduct.Size = new Size(564, 201);
            groupProduct.TabIndex = 14;
            groupProduct.TabStop = false;
            groupProduct.Text = "Productos";
            // 
            // groupCategory
            // 
            groupCategory.Controls.Add(boxDeleteCategory);
            groupCategory.Controls.Add(txtCategoryAdd);
            groupCategory.Controls.Add(label7);
            groupCategory.Controls.Add(label6);
            groupCategory.Controls.Add(btnDeleteCategory);
            groupCategory.Controls.Add(btnAddCategory);
            groupCategory.Location = new Point(609, 26);
            groupCategory.Name = "groupCategory";
            groupCategory.Size = new Size(447, 187);
            groupCategory.TabIndex = 15;
            groupCategory.TabStop = false;
            groupCategory.Text = "Categorias";
            // 
            // boxDeleteCategory
            // 
            boxDeleteCategory.FormattingEnabled = true;
            boxDeleteCategory.Location = new Point(135, 96);
            boxDeleteCategory.Name = "boxDeleteCategory";
            boxDeleteCategory.Size = new Size(151, 28);
            boxDeleteCategory.TabIndex = 15;
            // 
            // txtCategoryAdd
            // 
            txtCategoryAdd.Location = new Point(135, 36);
            txtCategoryAdd.Name = "txtCategoryAdd";
            txtCategoryAdd.Size = new Size(151, 27);
            txtCategoryAdd.TabIndex = 13;
            txtCategoryAdd.KeyPress += txtCategoryAdd_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(0, 105);
            label7.Name = "label7";
            label7.Size = new Size(130, 20);
            label7.TabIndex = 14;
            label7.Text = "Eliminar categoria";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 43);
            label6.Name = "label6";
            label6.Size = new Size(130, 20);
            label6.TabIndex = 13;
            label6.Text = "Agregar categoria";
            // 
            // btnDeleteCategory
            // 
            btnDeleteCategory.Location = new Point(347, 96);
            btnDeleteCategory.Name = "btnDeleteCategory";
            btnDeleteCategory.Size = new Size(94, 29);
            btnDeleteCategory.TabIndex = 13;
            btnDeleteCategory.Text = "Eliminar";
            btnDeleteCategory.UseVisualStyleBackColor = true;
            btnDeleteCategory.Click += btnDeleteCategory_Click;
            // 
            // btnAddCategory
            // 
            btnAddCategory.Location = new Point(347, 54);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(94, 29);
            btnAddCategory.TabIndex = 13;
            btnAddCategory.Text = "Agregar";
            btnAddCategory.UseVisualStyleBackColor = true;
            btnAddCategory.Click += btnAddCategory_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // ProductWindows
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1130, 611);
            Controls.Add(groupCategory);
            Controls.Add(groupProduct);
            Controls.Add(btnSearch);
            Controls.Add(dataGridViewProduct);
            Controls.Add(label1);
            Name = "ProductWindows";
            Text = "ProductWindows";
            Load += ProductWindows_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewProduct).EndInit();
            groupProduct.ResumeLayout(false);
            groupProduct.PerformLayout();
            groupCategory.ResumeLayout(false);
            groupCategory.PerformLayout();
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
        private GroupBox groupProduct;
        private GroupBox groupCategory;
        private ComboBox boxDeleteCategory;
        private TextBox txtCategoryAdd;
        private Label label7;
        private Label label6;
        private Button btnDeleteCategory;
        private Button btnAddCategory;
        private ContextMenuStrip contextMenuStrip1;
    }
}