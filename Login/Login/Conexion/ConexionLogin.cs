using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Login.Conexion
{
    class ConexionLogin
    {
        SqlConnection MiConexion;
        public void Conectar()
        {
            MiConexion = new SqlConnection("Data Source=(local);Initial Catalog=PUNTODEVENTA;Integrated Security=True");
            MiConexion.Open();
        }
        public void Desconectar()
        {
            MiConexion.Close();
        }
        public void EjecutarSql(String Query)
        {

            Conectar();

            SqlCommand MiComando = new SqlCommand(Query, MiConexion);

            //ejecutamos la cunsulta (query) sql....
            int FilasAfectadas = MiComando.ExecuteNonQuery();

            if (FilasAfectadas > 0)
                MessageBox.Show("Usuario registrado exitosamente", "La base de datos a sido modificada", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else
                MessageBox.Show("No se pudo realizar la modificacion de la base de datos :-(", "Error del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Desconectar();
        }

        public void ActualizarGrid(DataGridView dg, string Query)
        {
            //conectarse  a la base de datos 
            this.Conectar();
            //crear dataset
            System.Data.DataSet MiDataSet = new System.Data.DataSet();

            //crear adaptador de datos
            SqlDataAdapter MiDataAdapter = new SqlDataAdapter(Query, MiConexion);

            //llenar el DataSet
            MiDataAdapter.Fill(MiDataSet, "Login");

            //Asignarle el valor adecuado a las propiedades del DataGriew
            dg.DataSource = MiDataSet;
            dg.DataMember = "Login";


            //nos desconectamos de la base de datos 
            this.Desconectar();
        }

    }
}

