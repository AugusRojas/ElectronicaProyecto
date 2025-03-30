using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Form1: Form
    {
        private readonly Db_Context _context;
        public Form1(Db_Context context)
        {
            _context = context;
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
