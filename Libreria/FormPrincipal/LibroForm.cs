using Entidades.Libros;
using LogicaNegocio.Libreria;
using System;
using System.Data;
using System.Windows.Forms;

namespace Libreria.FormPrincipal
{
    public partial class LibroForm : Form
    {
        private readonly Libros _libroLN;
        private LibrosCls _libro;

        public LibroForm(Libros libroLN)
        {
            InitializeComponent();
            _libroLN = libroLN; // Inicializar la lógica de negocio
        }


        private void LibroForm_Load(object sender, EventArgs e)
        {
            CargarListaLibros();
        }

        private void CargarListaLibros()
        {
            try
            {
                _libro = new LibrosCls();
                _libroLN.Index(ref _libro);

                if (_libro.Resultados != null && _libro.Resultados.Rows.Count > 0)
                {
                    listBoxLibros.Items.Clear(); // Limpiar la lista antes de llenarla
                    foreach (DataRow row in _libro.Resultados.Rows)
                    {
                        listBoxLibros.Items.Add($"{row["Id"]}: {row["Titulo"]}");
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron libros.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de libros: {ex.Message}");
            }
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            try
            {
                _libro = new LibrosCls
                {
                    Titulo = txtTitle.Text,
                    IsAvailable1 = true // Libro disponible por defecto
                };
                _libroLN.Create(ref _libro);
                MessageBox.Show("Libro agregado exitosamente.");
                CargarListaLibros(); // Actualizar la lista de libros después de agregar uno nuevo
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar libro: {ex.Message}");
            }
        }

        private void btnLoanBook_Click(object sender, EventArgs e)
        {
            try
            {
                _libro = new LibrosCls { Id = int.Parse(txtBookId.Text) };
                _libroLN.Read(ref _libro); // Leer el libro desde la base de datos

                if (_libro.IsAvailable1)
                {
                    _libro.IsAvailable1 = false; // Marcar como no disponible
                    _libroLN.Update(ref _libro);
                    MessageBox.Show("Libro prestado exitosamente.");
                    CargarListaLibros(); // Actualizar la lista de libros después de prestar uno
                }
                else
                {
                    MessageBox.Show("El libro no está disponible.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al prestar libro: {ex.Message}");
            }
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            try
            {
                _libro = new LibrosCls { Id = int.Parse(txtBookId.Text) };
                _libroLN.Read(ref _libro); // Leer el libro desde la base de datos

                if (!_libro.IsAvailable1)
                {
                    _libro.IsAvailable1 = true; // Marcar como disponible
                    _libroLN.Update(ref _libro);
                    MessageBox.Show("Libro devuelto exitosamente.");
                    CargarListaLibros(); // Actualizar la lista de libros después de devolver uno
                }
                else
                {
                    MessageBox.Show("El libro ya está disponible.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al devolver libro: {ex.Message}");
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
