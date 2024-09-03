using Entidades.Libros;
using LogicaNegocio.Libreria;
using System;
using System.Data;
using System.Windows.Forms;
using LogicaNegocio;
using Entidades;    


namespace Libreria.FormPrincipal
{
    public partial class LibroForm : Form
    {
        private readonly Libros _libros;
    
        
        public LibroForm()
        {
            InitializeComponent();
            _libros = new Libros();
            LoadBooks();
        }

        private void LoadBooks()
        {
            // Instancia para manejar la lógica de negocio
            LibrosCls librosCls = new LibrosCls();
            _libros.Index(ref librosCls); 


            listViewLibros.Items.Clear();


            if (librosCls.Resultados != null && librosCls.Resultados.Rows.Count > 0)
            {
               
                foreach (DataRow row in librosCls.Resultados.Rows)
                {
                    ListViewItem item = new ListViewItem(row["Id"].ToString());
                    item.SubItems.Add(row["Title"].ToString());
                    item.SubItems.Add(row["IsAvailable"].ToString() == "True" ? "Sí" : "No");

                    listViewLibros.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("No se encontraron libros en la base de datos.");
            }
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            LibrosCls nuevoLibro = new LibrosCls
            {
                Titulo = txtTitle.Text,
                IsAvailable1 = chkIsAvailable.Checked
            };

            _libros.Create(ref nuevoLibro);

            if (string.IsNullOrEmpty(nuevoLibro.MensajeError))
            {
                MessageBox.Show("Libro agregado con éxito.");
                LoadBooks(); // Recargar la lista de libros
            }
            else
            {
                MessageBox.Show("Error: " + nuevoLibro.MensajeError);
            }
        }

        private void btnLoanBook_Click(object sender, EventArgs e)
        {
            if (listViewLibros.SelectedItems.Count > 0) // Verifica que hay un libro seleccionado
            {
                var selectedItem = listViewLibros.SelectedItems[0];
                int bookId = int.Parse(selectedItem.Text); // El ID del libro está en la primera columna
                string bookTitle = selectedItem.SubItems[1].Text; // El título del libro está en la segunda columna

                // Crear una instancia de la clase para manejar la lógica de negocio
                LibrosCls libroPrestado = new LibrosCls
                {
                    Id = bookId,
                    Titulo = bookTitle, 
                    IsAvailable1 = false // Cambiar el estado a no disponible
                };

                // Llamar al método Update en la clase de lógica de negocio para actualizar el estado
                _libros.Update(ref libroPrestado);

                if (string.IsNullOrEmpty(libroPrestado.MensajeError))
                {
                    MessageBox.Show("Libro prestado con éxito.");
                    LoadBooks(); // Recargar la lista para reflejar los cambios
                }
                else
                {
                    MessageBox.Show("Error al prestar el libro: " + libroPrestado.MensajeError);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un libro para prestar.");
            }
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtBookId.Text, out int bookId))
            {
                LibrosCls libroExistente = new LibrosCls
                {
                    Id = bookId,
                    Titulo = txtTitle.Text,
                    IsAvailable1 = true 
                };

                // Llamada para actualizar el libro
                _libros.Update(ref libroExistente);

                if (string.IsNullOrEmpty(libroExistente.MensajeError))
                {
                    MessageBox.Show("Libro actualizado con éxito.");
                    LoadBooks();
                }
                else
                {
                    MessageBox.Show("Error: " + libroExistente.MensajeError);
                }
            }
            else
            {
                MessageBox.Show("El ID del libro no es válido. Por favor, ingresa un número entero.");
            }
        }
        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            if (listViewLibros.SelectedItems.Count > 0) // Verifica que hay un libro seleccionado
                {
                    var selectedItem = listViewLibros.SelectedItems[0];
                    int bookId = int.Parse(selectedItem.Text);

                    // Crear una instancia de la clase para manejar la lógica de negocio
                    LibrosCls libroAEliminar = new LibrosCls
                    {
                        Id = bookId
                    };

                    // Llamar al método para eliminar el libro
                    _libros.Delete(ref libroAEliminar);

                    if (string.IsNullOrEmpty(libroAEliminar.MensajeError))
                    {
                        MessageBox.Show("Libro eliminado con éxito.");
                        LoadBooks(); // Recargar la lista para reflejar los cambios
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el libro: " + libroAEliminar.MensajeError);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un libro para eliminar.");
                }
            
        }
        

        private void LibroForm_Load(object sender, EventArgs e)
        {
            LoadBooks();
        }
    }
}
