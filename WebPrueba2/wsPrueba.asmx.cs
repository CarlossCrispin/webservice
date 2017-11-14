using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebPrueba2
{
    /// <summary>
    /// Descripción breve de wsPrueba
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsPrueba : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public int Suma(int num1, int num2)
        {
            return num1 + num2;
        }
        [WebMethod]
        public int Suma1()
        {
            int num1 = 5, num2 = 5;

            return num1 + num2;
        }
        [WebMethod]
        public string Palabra(string st)
        {
            string st1 = st.ToLower();

            return st1;
        }
        [WebMethod]
        public DataSet Consulta1()
        { 
            
            string sConnectionString;
            //string st1 = usuario;
            sConnectionString = "server=localhost;uid=root;pwd=;database=users";
            MySqlConnection objConn = new MySqlConnection(sConnectionString);
            objConn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from usuarios ", objConn);
            DataSet ds = new DataSet("usuarios");
            
            da.FillSchema(ds, SchemaType.Source, "usuarios");
            da.Fill(ds, "usuarios");
            return ds;
        }
        [WebMethod]
        public DataTable connectoToMySql(string usuario="")
        {
            string connString = "SERVER=localhost" + ";" +
                "DATABASE=users;" +
                "UID=root;" +
                "PASSWORD=;";

            MySqlConnection cnMySQL = new MySqlConnection(connString);

            MySqlCommand cmdMySQL = cnMySQL.CreateCommand();

            MySqlDataReader reader;

            if(usuario.Equals("")){
                //cmdMySQL.CommandText = "select * from usuarios";
                cmdMySQL.CommandText = "select * from usuarios";

                cnMySQL.Open();

                reader = cmdMySQL.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);


                cnMySQL.Close();

                return dt;
            }
            else
            {
                cmdMySQL.CommandText = "select * from usuarios where usuario='"+usuario+"'";

                cnMySQL.Open();

                reader = cmdMySQL.ExecuteReader();
                Console.WriteLine("fdefrg");

                DataTable dt = new DataTable();
                dt.Load(reader);


                cnMySQL.Close();

                return dt;
            }
           
        }
        [WebMethod]
        public string Consulta2(string nom)
        {
            
            try
            {
                //SqlDataReader retorno;
                //string dato = "root";
                string sConnectionString;
                sConnectionString = "server=localhost; database=users; Uid=root; pwd=;";
                MySqlConnection objConn = new MySqlConnection(sConnectionString);
                objConn.Open();
                /// MySqlCommand comando = new MySqlCommand(string.Format("select * from usuarios where user_name='{0}'", nom), objConn);
                MySqlDataAdapter da = new MySqlDataAdapter("select * from usuarios where usuario='" + nom + "'", objConn);
                DataSet ds = new DataSet("usuarios");

                da.FillSchema(ds, SchemaType.Source, "usuarios");
                da.Fill(ds, "usuarios");
                //MySqlDataReader _reader = comando.ExecuteReader();
                //retorno = comando.ExecuteReader();
                if (ds.Tables["usuarios"].Rows.Count == 0)
                {
                    string a = "no exite nada";
                    da.Fill(ds, "usuarios");
                    DataSet c = new DataSet("no hay nada");
                    //array.ToDataSet();
                    return a;
                }
                else
                {
                    string b = "si exite algo";
                    //DataSet b = new DataSet("si hay algo");
                    return b;
                }


            }
            catch (SqlException ex)
            {

                string err=("SQL Query Failed : " + ex.ToString());
                return err;
            }
        }
        [WebMethod]
        public DataSet Consulta(string nom)
        {
            //SqlDataReader retorno;
            //string dato = "root";
            string sConnectionString;
            sConnectionString = "server=localhost; database=users; Uid=root; pwd=;";
            MySqlConnection objConn = new MySqlConnection(sConnectionString);
            objConn.Open();
            /// MySqlCommand comando = new MySqlCommand(string.Format("select * from usuarios where user_name='{0}'", nom), objConn);
            MySqlDataAdapter da = new MySqlDataAdapter("select * from usuarios where usuario='" + nom + "'", objConn);
            DataSet ds = new DataSet("usuarios");

            da.FillSchema(ds, SchemaType.Source, "usuarios");
            da.Fill(ds, "usuarios");
            //MySqlDataReader _reader = comando.ExecuteReader();
            //retorno = comando.ExecuteReader();
            if (ds.Tables["usuarios"].Rows.Count == 0)
             {
              

                DataSet ds1 = new DataSet();
                DataTable dt = new DataTable();
                ds1.Tables.Add(dt);
                dt.Columns.Add("ERRoR", typeof(string));
                dt.Columns.Add("Saldo", typeof(int));
                dt.Rows.Add("USUARIO INCORRECTO",123455);

                return ds1;
             }
             else
             {
                 //string b = "si exite algo";
                 DataSet b = new DataSet("si hay algo");
                 return ds;
             }

            //return ds;
        }
    }

}
