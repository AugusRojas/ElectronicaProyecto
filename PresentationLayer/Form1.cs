using DataLayer.Models;
using DataLayer.Repositories;
using System.Threading.Tasks;

namespace PresentationLayer
{
    public partial class Form1 : Form
    {
        private readonly CategoryRepository categoryRepository;

        public Form1(Db_Context context)
        {
            InitializeComponent();
            categoryRepository = new CategoryRepository(context);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var nuevaCategoria = new Category { name = textBox1.Text };
                await categoryRepository.AddCategory(nuevaCategoria);
                MessageBox.Show("categoría agregada");
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = await categoryRepository.GetCategories();
        }
    }
}
