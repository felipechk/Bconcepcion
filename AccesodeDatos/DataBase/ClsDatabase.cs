using System;
using System.Data;
using System.Data.SqlClient;

namespace AccesodeDatos.ClsDatabase
{
    public class ClsDatabase
    {
        #region Variables Privadas
        private SqlConnection _connection;
        private SqlDataAdapter _adapter;
        private SqlCommand _command;
        private DataSet _dataSet;
        private DataTable _parámetros;
        private string _tableName, _nombreSP, _mensajeErrorDB, _valorScalar, _nombreDB;
        private bool _scalar;
        #endregion

        #region Variables Públicas
        public SqlConnection Connection { get => _connection; set => _connection = value; }
        public SqlDataAdapter Adapter { get => _adapter; set => _adapter = value; }
        public SqlCommand Command { get => _command; set => _command = value; }
        public DataSet DataSet { get => _dataSet; set => _dataSet = value; }
        public DataTable Parámetros { get => _parámetros; set => _parámetros = value; }
        public string TableName { get => _tableName; set => _tableName = value; }
        public string NombreSP { get => _nombreSP; set => _nombreSP = value; }
        public string MensajeErrorDB { get => _mensajeErrorDB; set => _mensajeErrorDB = value; }
        public string ValorScalar { get => _valorScalar; set => _valorScalar = value; }
        public string NombreDB { get => _nombreDB; set => _nombreDB = value; }
        public bool Scalar { get => _scalar; set => _scalar = value; }
        #endregion

        #region Constructores
        public ClsDatabase()
        {
            Parámetros = new DataTable("SpParámetros");
            Parámetros.Columns.Add("Nombre");
            Parámetros.Columns.Add("Tipo de Dato");
            Parámetros.Columns.Add("Valor");
            NombreDB = "LibreriaDB";
        }
        #endregion

        #region Métodos Privados
        private void ConexionBaseDatos(ref ClsDatabase OBdatabase)
        {
            switch (OBdatabase.NombreDB)
            {
                case "LibreriaDB":
                    OBdatabase.Connection = new SqlConnection(Properties.Settings.Default.CadenaConexion_LibreriaDB);
                    break;
                default:
                    break;
            }
        }
        private void ValidarConexionBaseDatos(ref ClsDatabase OBdatabase)
        {
            if(OBdatabase.Connection.State == ConnectionState.Closed)
            {
                OBdatabase.Connection.Open();
            }
            else
            {
                OBdatabase.Connection.Close();
                OBdatabase.Connection.Dispose();
            }
        }
        private void AgregarParámetros(ref ClsDatabase OBdatabase)
        {
            if(OBdatabase.Parámetros != null)
            {
                SqlDbType TipoDatoSql = new SqlDbType();
                foreach (DataRow item in OBdatabase.Parámetros.Rows)
                {
                    switch (item[1])
                    {
                        case "1":
                            TipoDatoSql = SqlDbType.Bit;
                            break;
                        case "2":
                            TipoDatoSql = SqlDbType.TinyInt;
                            break;
                        case "3":
                            TipoDatoSql = SqlDbType.SmallInt;
                            break;
                        case "4":
                            TipoDatoSql = SqlDbType.Int;
                            break;
                        case "5":
                            TipoDatoSql = SqlDbType.BigInt;
                            break;
                        case "6":
                            TipoDatoSql = SqlDbType.Decimal;
                            break;
                        case "7":
                            TipoDatoSql = SqlDbType.SmallMoney;
                            break;
                        case "8":
                            TipoDatoSql = SqlDbType.Money;
                            break;
                        case "9":
                            TipoDatoSql = SqlDbType.Float;
                            break;
                        case "10":
                            TipoDatoSql = SqlDbType.Real;
                            break;
                        case "11":
                            TipoDatoSql = SqlDbType.Date;
                            break;
                        case "12":
                            TipoDatoSql = SqlDbType.Time;
                            break;
                        case "13":
                            TipoDatoSql = SqlDbType.SmallDateTime;
                            break;
                        case "14":
                            TipoDatoSql = SqlDbType.Char;
                            break;
                        case "15":
                            TipoDatoSql = SqlDbType.NChar;
                            break;
                        case "16":
                            TipoDatoSql = SqlDbType.VarChar;
                            break;
                        case "17":
                            TipoDatoSql = SqlDbType.NVarChar;
                            break;
                        default:
                            break;
                    }
                    if (OBdatabase.Scalar)
                    {
                        if (item[2].ToString().Equals(string.Empty))
                        {
                            OBdatabase.Command.Parameters.Add(item[0].ToString(), TipoDatoSql).Value = DBNull.Value;
                        }
                        else
                        {
                            OBdatabase.Command.Parameters.Add(item[0].ToString(), TipoDatoSql).Value = item[2].ToString();
                        }
                    }
                    else
                    {
                        if (item[2].ToString().Equals(string.Empty))
                        {
                            OBdatabase.Adapter.SelectCommand.Parameters.Add(item[0].ToString(), TipoDatoSql).Value = DBNull.Value;
                        }
                        else
                        {
                            OBdatabase.Adapter.SelectCommand.Parameters.Add(item[0].ToString(), TipoDatoSql).Value = item[2].ToString();
                        }
                    }
                }
            }
        }
        private void PrepararConexión(ref ClsDatabase OBdatabase)
        {
            ConexionBaseDatos(ref OBdatabase);
            ValidarConexionBaseDatos(ref OBdatabase);
        }
        private void EjecutarDataAdapter(ref ClsDatabase OBdatabase)
        {
            try
            {
                PrepararConexión(ref OBdatabase);
                OBdatabase.Adapter = new SqlDataAdapter(OBdatabase.NombreSP, OBdatabase.Connection);
                OBdatabase.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                AgregarParámetros(ref OBdatabase);
                OBdatabase.DataSet = new DataSet();
                OBdatabase.Adapter.Fill(OBdatabase.DataSet, OBdatabase.TableName);
            }
            catch (Exception ex)
            {
                OBdatabase.MensajeErrorDB = ex.Message.ToString();
            }
            finally
            {
                if(OBdatabase.Connection.State == ConnectionState.Open)
                {
                    ValidarConexionBaseDatos(ref OBdatabase);
                }
            }
        }
        private void EjecutarCommand(ref ClsDatabase OBdatabase)
        {
            try
            {
                PrepararConexión(ref OBdatabase);
                OBdatabase.Command = new SqlCommand(OBdatabase.NombreSP, OBdatabase.Connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                AgregarParámetros(ref OBdatabase);
                if (OBdatabase.Scalar)
                {
                    OBdatabase.ValorScalar = OBdatabase.Command.ExecuteScalar().ToString().Trim();
                }
                else
                {
                    OBdatabase.Command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                OBdatabase.MensajeErrorDB = ex.Message.ToString();
            }
            finally
            {
                if (OBdatabase.Connection.State == ConnectionState.Open)
                {
                    ValidarConexionBaseDatos(ref OBdatabase);
                }
            }
        }
        #endregion

        #region Métodos Públicos
        public void CRUD(ref ClsDatabase OBdatabase)
        {
            if (OBdatabase.Scalar)
            {
                EjecutarCommand(ref OBdatabase);
            }
            else
            {
                EjecutarDataAdapter(ref OBdatabase);
            }
        }
        #endregion
    }
}
