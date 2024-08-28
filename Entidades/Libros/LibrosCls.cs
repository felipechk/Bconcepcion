using System.Data;

namespace Entidades.Libros
{
    public class LibrosCls
    {
        #region Atributos Privados
        private int _id;
        private string titulo;
        private bool IsAvailable;
        private string _mensajeError, _valorScalar;
        private DataTable _resultados;
        #endregion

        #region Atributos Públicos
        public int Id { get => _id; set => _id = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public bool IsAvailable1 { get => IsAvailable; set => IsAvailable = value; }
        public string MensajeError { get => _mensajeError; set => _mensajeError = value; }
        public string ValorScalar { get => _valorScalar; set => _valorScalar = value; }
        public DataTable Resultados { get => _resultados; set => _resultados = value; }
        #endregion
    }
}
