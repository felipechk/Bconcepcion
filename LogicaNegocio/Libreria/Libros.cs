using AccesodeDatos.ClsDatabase;
using Entidades.Libros;
using System;
using System.Data;
namespace LogicaNegocio.Libreria
{
    public class Libros
    {
        #region Variables Privadas
        private ClsDatabase Odatabase = null;

        #endregion

        #region Método Index
        public void Index(ref LibrosCls ObLibro)
        {
            Odatabase = new ClsDatabase()
            {
                TableName = "Libros",
                NombreSP = "[LibreriaDB_Index]",
                Scalar = false,
            };
            Ejecutar(ref ObLibro);
        }
        #endregion

        #region CRUD Libro
        public void Create(ref LibrosCls ObLibro)
        {
            Odatabase = new ClsDatabase()
            {
                TableName = "Libros",
                NombreSP = "[LibreriaDB_Create]",
                Scalar = true,
            };
            Odatabase.Parámetros.Rows.Add(@"@Titulo","16",ObLibro.Titulo);
            Odatabase.Parámetros.Rows.Add(@"@IsAvailable", "16", ObLibro.IsAvailable1);
            Ejecutar(ref ObLibro);
        }
        public void Read(ref LibrosCls ObLibro)
        {
            Odatabase = new ClsDatabase()
            {
                TableName = "Libros",
                NombreSP = "[LibreriaDB_Read]",
                Scalar = false,
            };
            Odatabase.Parámetros.Rows.Add(@"@Id", "4", ObLibro.Id);
            Ejecutar(ref ObLibro);
        }
        public void Update(ref LibrosCls ObLibro)
        {
            Odatabase = new ClsDatabase()
            {
                TableName = "Libros",
                NombreSP = "[LibreriaDB_Update]",
                Scalar = true,
            };
            Odatabase.Parámetros.Rows.Add(@"@Titulo", "16", ObLibro.Titulo);
            Odatabase.Parámetros.Rows.Add(@"@IsAvailable", "16", ObLibro.IsAvailable1);
            Ejecutar(ref ObLibro);
        }
        public void Delete(ref LibrosCls ObLibro)
        {
            Odatabase = new ClsDatabase()
            {
                TableName = "Libros",
                NombreSP = "[LibreriaDB_Delete]",
                Scalar = true,
            };
            Odatabase.Parámetros.Rows.Add(@"@Id", "4", ObLibro.Id);
            Ejecutar(ref ObLibro);
        }
        #endregion

        #region Métodos Privados
        private void Ejecutar(ref LibrosCls Oblibro)
        {
            Odatabase.CRUD(ref Odatabase);

            if (Odatabase.MensajeErrorDB == null) 
            {
                if (Odatabase.Scalar)
                {
                    Oblibro.ValorScalar = Odatabase.ValorScalar;
                }
                else
                {
                    Oblibro.Resultados = Odatabase.DataSet.Tables[0];
                    if (Oblibro.Resultados.Rows.Count == 1)
                    {
                        foreach (DataRow item in Oblibro.Resultados.Rows)
                        {
                            Oblibro.Id = Convert.ToByte(item["Id"].ToString());
                            Oblibro.Titulo = item["Title"].ToString();
                            Oblibro.IsAvailable1 = Convert.ToBoolean(item["IsAvailable"]);
                        }
                    }
                }
            }
            else
            {
                Oblibro.MensajeError = Odatabase.MensajeErrorDB;
            }
        }
        #endregion

    }
}
