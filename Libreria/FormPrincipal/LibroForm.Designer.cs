namespace Libreria.FormPrincipal
{
    partial class LibroForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtBookId = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblBookId = new System.Windows.Forms.Label();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.btnLoanBook = new System.Windows.Forms.Button();
            this.btnReturnBook = new System.Windows.Forms.Button();
            this.listBoxLibros = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(125, 34);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(200, 20);
            this.txtTitle.TabIndex = 0;
            // 
            // txtBookId
            // 
            this.txtBookId.Location = new System.Drawing.Point(125, 72);
            this.txtBookId.Name = "txtBookId";
            this.txtBookId.Size = new System.Drawing.Size(100, 20);
            this.txtBookId.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(30, 37);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(38, 13);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Título:";
            // 
            // lblBookId
            // 
            this.lblBookId.AutoSize = true;
            this.lblBookId.Location = new System.Drawing.Point(30, 75);
            this.lblBookId.Name = "lblBookId";
            this.lblBookId.Size = new System.Drawing.Size(18, 13);
            this.lblBookId.TabIndex = 3;
            this.lblBookId.Text = "ID";
            // 
            // btnAddBook
            // 
            this.btnAddBook.Location = new System.Drawing.Point(33, 120);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(75, 23);
            this.btnAddBook.TabIndex = 4;
            this.btnAddBook.Text = "Agregar Libro";
            this.btnAddBook.UseVisualStyleBackColor = true;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // btnLoanBook
            // 
            this.btnLoanBook.Location = new System.Drawing.Point(125, 120);
            this.btnLoanBook.Name = "btnLoanBook";
            this.btnLoanBook.Size = new System.Drawing.Size(75, 23);
            this.btnLoanBook.TabIndex = 5;
            this.btnLoanBook.Text = "Prestar Libro";
            this.btnLoanBook.UseVisualStyleBackColor = true;
            this.btnLoanBook.Click += new System.EventHandler(this.btnLoanBook_Click);
            // 
            // btnReturnBook
            // 
            this.btnReturnBook.Location = new System.Drawing.Point(219, 120);
            this.btnReturnBook.Name = "btnReturnBook";
            this.btnReturnBook.Size = new System.Drawing.Size(95, 23);
            this.btnReturnBook.TabIndex = 6;
            this.btnReturnBook.Text = "Devolver Libro";
            this.btnReturnBook.UseVisualStyleBackColor = true;
            this.btnReturnBook.Click += new System.EventHandler(this.btnReturnBook_Click);
            // 
            // listBoxLibros
            // 
            this.listBoxLibros.Location = new System.Drawing.Point(33, 160);
            this.listBoxLibros.Name = "listBoxLibros";
            this.listBoxLibros.Size = new System.Drawing.Size(281, 160);
            this.listBoxLibros.TabIndex = 7;
            // 
            // Libro
            // 
            this.ClientSize = new System.Drawing.Size(348, 340);
            this.Controls.Add(this.listBoxLibros);
            this.Controls.Add(this.btnReturnBook);
            this.Controls.Add(this.btnLoanBook);
            this.Controls.Add(this.btnAddBook);
            this.Controls.Add(this.lblBookId);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtBookId);
            this.Controls.Add(this.txtTitle);
            this.Name = "Libro";
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
        private System.Windows.Forms.ListBox listBoxLibros; // Declarar ListBox
    }
}