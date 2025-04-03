using DataLayer.Models;
using LogicLayer.ValidatorService;
using DataLayer.Repositories;
using System.Threading.Tasks;

namespace PresentationLayer
{
    public partial class Form1 : Form
    {
        private readonly CategoryService _categoryValidation;
        public Form1(CategoryService categoryValidation)
        {
            InitializeComponent();
            _categoryValidation = categoryValidation;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                await _categoryValidation.AddCategory(new Category()
                {
                    name = textBox1.Text
                });

                MessageBox.Show("Categor�a agregada con �xito.", "�xito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) // Capturamos la excepci�n si la validaci�n falla
            {
                MessageBox.Show(ex.Message, "Error de Validaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = await _categoryValidation.GetCategories();
            var categories = await _categoryValidation.GetComboBox();
            comboBox1.DataSource = categories;  // Enlaza la lista de categor�as
            comboBox1.DisplayMember = "name";  // Nombre que se muestra
            comboBox1.ValueMember = "idCategory";  // Valor interno (id de la categor�a) 
        }


    }
}

