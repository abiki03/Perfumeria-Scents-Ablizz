using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scents_Ablizz
{
    public partial class Insertar : Form
    {
        // Conexión inicializada de la base de datos
        SqlConnection conex = new SqlConnection("Server=ABIGAIL\\SQLEXPRESSS; DataBase =PerfumeriaBD; integrated Security = True");
        public Insertar()
        {
            InitializeComponent();
            CargarTamaño(); //Carga de los datos de tamaño
            CargarAromas(); // Carga de los datos de aromas
            CargarEmbalaje(); //Carga de los datos de embalaje o envase 
        }

        private void Insertar_Load(object sender, EventArgs e)
        {
        }
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            //Regresar a la ventana de inicio 
            this.Hide();
            Inicio inicio = new Inicio();
            inicio.Show();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close(); //Imagen que cierra el programa 
        }
        private void txtNombreP_TextChanged(object sender, EventArgs e)
        {
        }
        private void txtNombreP_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e); //Excepción que permite solo letras 
        }
        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e); //Excepción que permite solo números 
        }
        private void txtIDProducto_TextChanged(object sender, EventArgs e)
        {
        }
        private void txtIDProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e); //Excepción que permite solo números 
        }
        private void txtClasificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e); //Excepción que permite solo letras 
        }
        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);//Excepción que permite solo letras 
        }
        private void txtTamaño_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e); //Excepción que permite solo números
        }
        private void txtAroma_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        private void txtEmbalaje_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los valores ingresados por el usuario
                int idProducto = int.Parse(txtIDProducto.Text);  // Convertir a entero
                string nombrePerfume = txtNombreP.Text;
                string marca = txtMarca.Text;
                decimal precio = decimal.Parse(txtPrecio.Text);  // Convertir a decimal
                string clasificacion = txtClasificacion.Text;
                //Válida las selecciones del ComboBox si es válido 
                int idTamaño = (cbxTamaño.SelectedValue != DBNull.Value)? (int)cbxTamaño.SelectedValue : -1;  
                int idAroma = (cbxAroma.SelectedValue != DBNull.Value) ? (int)cbxAroma.SelectedValue : -1;
                int idEnvase = (cbxEmbalaje.SelectedValue != DBNull.Value) ? (int)cbxEmbalaje.SelectedValue : -1;
                if (idTamaño == -1)
                {
                    MessageBox.Show("Por favor, seleccione un tamaño.");
                    return; // Salir del método si no se seleccionó un tamaño válido
                }
                if (idAroma == -1)
                {
                    MessageBox.Show("Por favor, seleccione un aroma.");
                    return; // Salir del método si no se seleccionó un aroma válido
                }
                if (idEnvase == -1)
                {
                    MessageBox.Show("Por favor, seleccione un envase.");
                    return; // Salir del método si no se seleccionó un aroma válido
                }
                // Crear la consulta SQL con parámetros
                string query = "INSERT INTO Producto (Id_Producto, Nombre_Perfume, Marca, Precio, Clasificacion, Id_Tamaño, Id_Aroma, Id_Envase) " +
                               "VALUES (@Id_Producto, @Nombre_Perfume, @Marca, @Precio, @Clasificacion, @Id_Tamaño, @Id_Aroma, @Id_Envase)";
                // Crear el comando SQL
                using (SqlCommand comando = new SqlCommand(query, conex))
                {
                    // Agregar los parámetros al comando
                    comando.Parameters.AddWithValue("@Id_Producto", idProducto);
                    comando.Parameters.AddWithValue("@Nombre_Perfume", nombrePerfume);
                    comando.Parameters.AddWithValue("@Marca", marca);
                    comando.Parameters.AddWithValue("@Precio", precio);
                    comando.Parameters.AddWithValue("@Clasificacion", clasificacion);
                    comando.Parameters.AddWithValue("@Id_Tamaño", idTamaño);
                    comando.Parameters.AddWithValue("@Id_Aroma", idAroma);
                    comando.Parameters.AddWithValue("@Id_Envase", idEnvase);
                    // Abrir la conexión y ejecutar la consulta
                    conex.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Los datos se insertaron correctamente");
                    // Limpiar los campos de texto
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se guardaron los datos" + ex.Message); //Error al insertar los datos 
            }
            finally
            {
                // Asegurarse de cerrar la conexión
                if (conex.State == System.Data.ConnectionState.Open)
                {
                    conex.Close();
                }
            }
        }
        private void LimpiarCampos() //Método que limpia las cajas de texto
        {
            //Se limpia cada una de las cajas de texto y los ComboBox 
            txtIDProducto.Text = "";
            txtNombreP.Text = "";
            txtMarca.Text = "";
            txtPrecio.Text = "";
            txtClasificacion.Text = "";
            cbxTamaño.Text = "";
            cbxAroma.Text = "";
            cbxEmbalaje.Text = "";
        }
        private void txtAroma_TextChanged(object sender, EventArgs e)
        {
        }
        public void CargarTamaño() //Método para cargar detalles de la tabla Tamaño
        {
            //Se abre la conexion con la base de datos 
            conex.Open();
            //Se selecciona la tabla y el campo al que se requiere extraer los datos
            SqlCommand comando = new SqlCommand("SELECT  Id_Tamaño,Tamaño_ml FROM Tamaño", conex);
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            conex.Close(); //Cierre de la conexión

            //Insertar la fila de seleccione el tamaño en la primera posición
            DataRow fila = tabla.NewRow();
            fila["Id_Tamaño"] = DBNull.Value; //Valor nulo a algún predeterminado si es necesario
            fila["Tamaño_ml"] = "Seleccione el tamaño";
            tabla.Rows.InsertAt(fila, 0);

            //Configurar el ComboBox
            cbxTamaño.ValueMember = "Id_Tamaño"; //Valor que se almacena ID del Tamaño
            cbxTamaño.DisplayMember = "Tamaño_ml"; //Lo que se muestra sera el nombre del Tamaño
            cbxTamaño.DataSource = tabla;
        }
        public void CargarAromas() //Método para cargar detalles de la tabla Aroma 
        {
            //Se abre la conexion con la base de datos 
            conex.Open();
            //Se selecciona la tabla y el campo al que se requiere extraer los datos
            SqlCommand comando = new SqlCommand("SELECT  Id_Aroma,Aroma FROM Aroma",conex);
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            conex.Close(); //Cierre de la conexión

            //Insertar la fila de seleccione el aroma en la primera posición
            DataRow fila = tabla.NewRow();
            fila["Id_Aroma"] = DBNull.Value; //Valor nulo a algún predeterminado si es necesario
            fila["Aroma"] = "Seleccione el aroma";
            tabla.Rows.InsertAt(fila, 0);

            //Configurar el ComboBox
            cbxAroma.ValueMember = "Id_Aroma"; //Valor que se almacena ID del aroma
            cbxAroma.DisplayMember = "Aroma"; //Lo que se muestra sera el nombre del aroma
            cbxAroma.DataSource = tabla;
        }
        public void CargarEmbalaje() //Método para cargar detalles de la tabla Envase 
        {
            //Se abre la conexion con la base de datos 
            conex.Open();
            //Se selecciona la tabla y el campo al que se requiere extraer los datos
            SqlCommand comando = new SqlCommand("SELECT  Id_Envase,Tipo_Envase FROM Envase", conex);
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            conex.Close(); //Cierre de la conexión

            //Insertar la fila de seleccione el envase en la primera posición
            DataRow fila = tabla.NewRow();
            fila["Id_Envase"] = DBNull.Value; //Valor nulo a algún predeterminado si es necesario
            fila["Tipo_Envase"] = "Seleccione el envase";
            tabla.Rows.InsertAt(fila, 0);

            //Configurar el ComboBox
            cbxEmbalaje.ValueMember = "Id_Envase"; //Valor que se almacena ID del envase
            cbxEmbalaje.DisplayMember = "Tipo_Envase"; //Lo que se muestra sera el nombre del envase
            cbxEmbalaje.DataSource = tabla;
        }
    }
}
