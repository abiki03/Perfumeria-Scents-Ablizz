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

namespace Scents_Ablizz
{
    public partial class Consultar : Form
    {
        public Consultar()
        {
            InitializeComponent();
        }
        // Conexión inicializada de la base de datos
        SqlConnection conex = new SqlConnection("Server=ABIGAIL\\SQLEXPRESSS; DataBase =PerfumeriaBD; integrated Security = True");
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close(); //Imagen que cierra el programa 
        }
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            //Regresar a la ventana de inicio 
            this.Hide();
            Inicio inicio = new Inicio();
            inicio.Show();
        }
        private void Consultar_Load(object sender, EventArgs e)
        {
            //Configuración de autocompletado 
            cbxProductos.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //Sugerencias de posibles considencias 
            cbxProductos.AutoCompleteSource = AutoCompleteSource.ListItems;
            //Consulta SQL a la tabla producto para recuperar Nombre_Perfume 
            SqlCommand comando = new SqlCommand("SELECT Nombre_Perfume FROM Producto", conex);
            conex.Open(); //Abrir la conexión con la base de datos  
            SqlDataReader registro = comando.ExecuteReader();
            while (registro.Read()) //Mientras se lea un nombre
            {
                cbxProductos.Items.Add(registro["Nombre_Perfume"].ToString()); //Extraer elementos de la consulta
            }
            conex.Close();//Cerrar la conexión con la base de datos 
        }
        private void cbxProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void cbxProductos_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Verificar si hay un producto seleccionado
            if (cbxProductos.SelectedItem != null)
            {
                // Obtener el nombre del producto seleccionado
                string selectedPerfume = cbxProductos.SelectedItem.ToString(); 
                MostrarDetallesProducto(selectedPerfume); //Llama al método y envia el nombre del perfume 
            }
        }
        private void MostrarDetallesProducto(string selectedPerfume)
        {
            try
            {
                // Verificar la conexión con la base de datos
                if (conex.State != System.Data.ConnectionState.Open)
                {
                    conex.Open();
                }
                // Consulta para obtener los detalles del producto
                SqlCommand comando = new SqlCommand("SELECT * FROM Producto WHERE Nombre_Perfume = @Nombre_Perfume", conex);
                comando.Parameters.AddWithValue("@Nombre_Perfume", selectedPerfume);
                SqlDataReader registro = comando.ExecuteReader();
                // Comprobar si se encontraron resultados
                if (registro.Read())
                {
                    // Obtener los datos del producto
                    string IdPerfume = $"{registro["Id_Producto"]}";
                    string marca = $"{registro["Marca"]}";
                    string clasificacion = $"{registro["Clasificacion"]}";
                    string precio = ($"$ {registro["Precio"]}");
                    string tamaño = ($"{registro["Id_Tamaño"]}");
                    string aroma = ($"{registro["Id_Aroma"]}");
                    string envase = ($"{registro["Id_Envase"]}");

                    // Mostrar los detalles en los cuadros de texto
                    txtNombreP.Text = IdPerfume;
                    txtMarca.Text = marca;
                    txtClasificacion.Text = clasificacion;
                    txtPrecio.Text = precio;

                    conex.Close(); // Cierra la conexión

                    // Consultar el tamaño
                    conex.Open();
                    //Consulta SQL en donde recupera la columna que coincida con el parametro 
                    SqlCommand comandoTamaño = new SqlCommand("SELECT Tamaño_ml FROM Tamaño WHERE Id_Tamaño = @Id_Tamaño", conex);
                    comandoTamaño.Parameters.AddWithValue("@Id_Tamaño", tamaño); //Insertar el valor
                    SqlDataReader registroTamaño = comandoTamaño.ExecuteReader(); //Lee los resultados 
                    if (registroTamaño.Read()) //Si devuelve un resultado 
                    {
                        //Se accede al valor de la columna y se convierte en ToString() se asigna a la caja de texto
                        txtTamaño.Text = registroTamaño["Tamaño_ml"].ToString();
                    }
                    else
                    {
                        txtTamaño.Text = "Tamaño no encontrado.";
                    }
                    conex.Close(); // Cierra la conexión

                    // Consultar el aroma
                    conex.Open();
                    //Consulta SQL en donde recupera la columna que coincida con el parametro 
                    SqlCommand comandoAroma = new SqlCommand("SELECT Aroma FROM Aroma WHERE Id_Aroma = @Id_Aroma", conex);
                    comandoAroma.Parameters.AddWithValue("@Id_Aroma", aroma); //Insertar el valor
                    SqlDataReader registroAroma = comandoAroma.ExecuteReader(); //Lee los resultados 
                    if (registroAroma.Read())//Si devuelve un resultado
                    {
                        //Se accede al valor de la columna y se convierte en ToString() se asigna a la caja de texto
                        txtAroma.Text = registroAroma["Aroma"].ToString();
                    }
                    else
                    {
                        txtAroma.Text = "Aroma no encontrado.";
                    }
                    conex.Close(); // Cierra la conexión

                    // Consultar el envase
                    conex.Open();
                    //Consulta SQL en donde recupera la columna que coincida con el parametro 
                    SqlCommand comandoEnvase = new SqlCommand("SELECT Tipo_Envase FROM Envase WHERE Id_Envase = @Id_Envase", conex);
                    comandoEnvase.Parameters.AddWithValue("@Id_Envase", envase); //Insertar el valor
                    SqlDataReader registroEnvase = comandoEnvase.ExecuteReader();//Lee los resultados 
                    if (registroEnvase.Read()) //Si devuelve un resultado
                    {
                        //Se accede al valor de la columna y se convierte en ToString() se asigna a la caja de texto
                        txtEmbalaje.Text = registroEnvase["Tipo_Envase"].ToString();
                    }
                    else
                    {
                        txtEmbalaje.Text = "Envase no encontrado."; //Error al no encontrar selección
                    }
                }
                else
                {
                    //Error al no encontrar el producto
                    MessageBox.Show("Producto no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                //Error en la conexión 
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //Finalizar la conexión con la base de datos 
                if (conex.State == System.Data.ConnectionState.Open)
                {
                    conex.Close();
                }
            }
        }
        private void cbxProductos_TextChanged(object sender, EventArgs e)
        {
        }
        private void cbxProductos_KeyPress(object sender, KeyPressEventArgs e)
        {  
        }
        private void cbxProductos_KeyDown(object sender, KeyEventArgs e)
        {
        }
        private void cbxProductos_DropDownClosed(object sender, EventArgs e)
        {  
        }
        private void cbxProductos_DropDown(object sender, EventArgs e)
        {
        }
    }
}
