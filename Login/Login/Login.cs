using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            try
            {
                //creando la conexion
                SqlConnection MiConexion = new SqlConnection("Data Source=(local);Initial Catalog=PUNTODEVENTA;Integrated Security=True");
                //abriendo conexion
                MiConexion.Open();

                SqlCommand comando = new SqlCommand("select Usuario, Contraseña from Login where Usuario = '" + txtUsuario.Text + "'And Contraseña = '" + txtContraseña.Text + "' ", MiConexion);

                //ejecuta una instruccion de sql devolviendo el numero de las filas afectadas
                comando.ExecuteNonQuery();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comando);

                //Llenando el dataAdapter
                da.Fill(ds, "Login");
                //utilizado para representar una fila de la tabla q necesitas en este caso usuario
                DataRow DR;
                DR = ds.Tables["Login"].Rows[0];

                //evaluando que la contraseña y usuario sean correctos
                if ((txtUsuario.Text == DR["usuario"].ToString()) || (txtContraseña.Text == DR["contraseña"].ToString()))
                {
                    //instanciando el formulario principal
                    //MenuOpciones frm = new MenuOpciones();
                    //frm.Show();//abriendo el formulario principal
                    //MessageBox.Show("Bienvenido al Sistema");
                    //this.Hide();//esto sirve para ocultar el formulario de login

                }

            }
            catch
            {
                //en caso que la contraseña sea erronea mostrara un mensaje
                //dentro de los parentesis va: "Mensaje a mostrar","Titulo de la ventana",botones a mostrar en ste caso OK, icono a mostrar en este caso uno de error
                MessageBox.Show("Error! Su Contraseña y/o usuario son Invalidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
    }

