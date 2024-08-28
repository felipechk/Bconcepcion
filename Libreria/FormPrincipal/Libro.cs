using Entidades.Libros;
using LogicaNegocio.Libreria;
using System;
using System.Windows.Forms;

namespace Libreria.FormPrincipal
{
    public partial class Libro : Form
    {
        private LibrosCls libro = null;
        private readonly Libros libroLN = new Libros();
        public Libro()
        {
            InitializeComponent();
        }
        private void CargarListaLibro()
        {
            libro = new LibrosCls();
            libroLN.Index(ref libro);

        }
        private void Libro_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
