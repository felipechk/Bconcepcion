using System.Windows.Forms;

namespace Libreria.FormPrincipal
{
    partial class LibroForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.CheckBox chkIsAvailable;
        private System.Windows.Forms.ListView listViewLibros;
        private System.Windows.Forms.Button btnDeleteBook;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.listViewLibros = new System.Windows.Forms.ListView();
            this.chkIsAvailable = new System.Windows.Forms.CheckBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtBookId = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblBookId = new System.Windows.Forms.Label();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.btnLoanBook = new System.Windows.Forms.Button();
            this.btnReturnBook = new System.Windows.Forms.Button();
            this.btnDeleteBook = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewLibros
            // 
            this.listViewLibros.FullRowSelect = true;
            this.listViewLibros.GridLines = true;
            this.listViewLibros.HideSelection = false;
            this.listViewLibros.Location = new System.Drawing.Point(35, 109);
            this.listViewLibros.Name = "listViewLibros";
            this.listViewLibros.Size = new System.Drawing.Size(346, 148);
            this.listViewLibros.TabIndex = 8;
            this.listViewLibros.UseCompatibleStateImageBehavior = false;
            this.listViewLibros.View = System.Windows.Forms.View.Details;
            this.listViewLibros.Columns.Add("ID", 50, HorizontalAlignment.Left);
            this.listViewLibros.Columns.Add("Título", 150, HorizontalAlignment.Left);
            this.listViewLibros.Columns.Add("Disponible", 100, HorizontalAlignment.Left);
            // 
            // chkIsAvailable
            // 
            this.chkIsAvailable.AutoSize = true;
            this.chkIsAvailable.Location = new System.Drawing.Point(215, 35);
            this.chkIsAvailable.Name = "chkIsAvailable";
            this.chkIsAvailable.Size = new System.Drawing.Size(75, 17);
            this.chkIsAvailable.TabIndex = 4;
            this.chkIsAvailable.Text = "Disponible";
            this.chkIsAvailable.UseVisualStyleBackColor = true;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(56, 6);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(200, 20);
            this.txtTitle.TabIndex = 0;
            // 
            // txtBookId
            // 
            this.txtBookId.Location = new System.Drawing.Point(56, 32);
            this.txtBookId.Name = "txtBookId";
            this.txtBookId.Size = new System.Drawing.Size(100, 20);
            this.txtBookId.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(38, 13);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Título:";
            // 
            // lblBookId
            // 
            this.lblBookId.AutoSize = true;
            this.lblBookId.Location = new System.Drawing.Point(32, 39);
            this.lblBookId.Name = "lblBookId";
            this.lblBookId.Size = new System.Drawing.Size(18, 13);
            this.lblBookId.TabIndex = 3;
            this.lblBookId.Text = "ID";
            // 
            // btnAddBook
            // 
            this.btnAddBook.Location = new System.Drawing.Point(15, 80);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(75, 23);
            this.btnAddBook.TabIndex = 4;
            this.btnAddBook.Text = "Agregar Libro";
            this.btnAddBook.UseVisualStyleBackColor = true;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // btnLoanBook
            // 
            this.btnLoanBook.Location = new System.Drawing.Point(109, 80);
            this.btnLoanBook.Name = "btnLoanBook";
            this.btnLoanBook.Size = new System.Drawing.Size(75, 23);
            this.btnLoanBook.TabIndex = 5;
            this.btnLoanBook.Text = "Prestar Libro";
            this.btnLoanBook.UseVisualStyleBackColor = true;
            this.btnLoanBook.Click += new System.EventHandler(this.btnLoanBook_Click);
            // 
            // btnReturnBook
            // 
            this.btnReturnBook.Location = new System.Drawing.Point(208, 80);
            this.btnReturnBook.Name = "btnReturnBook";
            this.btnReturnBook.Size = new System.Drawing.Size(95, 23);
            this.btnReturnBook.TabIndex = 6;
            this.btnReturnBook.Text = "Devolver Libro";
            this.btnReturnBook.UseVisualStyleBackColor = true;
            this.btnReturnBook.Click += new System.EventHandler(this.btnReturnBook_Click);
            // 
            // btnDeleteBook
            // 
            this.btnDeleteBook.Location = new System.Drawing.Point(320, 80);
            this.btnDeleteBook.Name = "btnDeleteBook";
            this.btnDeleteBook.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteBook.TabIndex = 7;
            this.btnDeleteBook.Text = "Eliminar Libro";
            this.btnDeleteBook.UseVisualStyleBackColor = true;
            this.btnDeleteBook.Click += new System.EventHandler(this.btnDeleteBook_Click);
            // 
            // LibroForm
            // 
            this.ClientSize = new System.Drawing.Size(410, 272);
            this.Controls.Add(this.btnDeleteBook);
            this.Controls.Add(this.listViewLibros);
            this.Controls.Add(this.chkIsAvailable);
            this.Controls.Add(this.btnReturnBook);
            this.Controls.Add(this.btnLoanBook);
            this.Controls.Add(this.btnAddBook);
            this.Controls.Add(this.lblBookId);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtBookId);
            this.Controls.Add(this.txtTitle);
            this.Name = "LibroForm";
            this.Text = "Gestión de Libros";
            this.Load += new System.EventHandler(this.LibroForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtBookId;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblBookId;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.Button btnLoanBook;
        private System.Windows.Forms.Button btnReturnBook;
    }
}