using LogicLayer.IServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class emerging_products: Form
    {
        private readonly IProductServices ProductServices;
        public emerging_products(IProductServices ProductServices)
        {
            InitializeComponent();
            this.ProductServices = ProductServices;
        }

        public emerging_products()
        {
            InitializeComponent();
        }


    }
}
