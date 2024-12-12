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
    public partial class Eliminar : Form
    {
        public Eliminar()
        {
            InitializeComponent();
        }
        //Variables Globales 
        private List<Producto> productos = new List<Producto>(); // Lista para almacenar los registros
        private int currentIndex = 0; // Índice para navegar entre los productos
        // Conexión inicializada de la base de datos 
        private SqlConnection conex = new SqlConnection("Server=ABIGAIL\\SQLEXPRESSS; DataBase =PerfumeriaBD; integrated Security = True"); 
        // Clase Producto para almacenar la información de cada producto
        public class Producto
        {
            public string Id_Producto { get; set; }
            public string Clasificacion { get; set; }
            public string Nombre_Perfume { get; set; }
            public string Marca { get; set; }
            public string Precio { get; set; }
            public string Id_Tamaño { get; set; }
            public string Id_Aroma { get; set; }
            public string Id_Envase { get; set; }
        }
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
        private void CargarRegistros() //Método para cargar los registros de productos 
        {
            try
            {
                //Consulta SQL de la tabla producto 
                using (SqlCommand comando = new SqlCommand("SELECT Id_Producto, Clasificacion, Nombre_Perfume, Marca, Precio, Id_Tamaño, Id_Aroma, Id_Envase FROM Producto", conex))
                {
                    conex.Open();//Abrir conexión
                    using (SqlDataReader registro = comando.ExecuteReader())
                    {
                        productos.Clear(); // Limpiar la lista antes de cargar nuevos registros
                        while (registro.Read()) //Recorrer las filas mientras el producto exista
                        {
                            Producto producto = new Producto //Creación del objeto 
                            {
                                //Obtener los valores de las columnas y convertirlos a string 
                                Id_Producto = registro["Id_Producto"].ToString(),
                                Clasificacion = registro["Clasificacion"].ToString(),
                                Nombre_Perfume = registro["Nombre_Perfume"].ToString(),
                                Marca = registro["Marca"].ToString(),
                                Precio = registro["Precio"].ToString(),
                                Id_Tamaño = registro["Id_Tamaño"].ToString(),
                                Id_Aroma = registro["Id_Aroma"].ToString(),
                                Id_Envase = registro["Id_Envase"].ToString()
                            };
                            productos.Add(producto); // Agregar a la lista
                        }
                        if (productos.Count > 0) //Verificar si hay productos en la lista 
                        {
                            MostrarRegistro(productos[currentIndex]); // Mostrar el primer registro
                        }
                        else
                        {
                            MessageBox.Show("No hay registros disponibles."); //Desplegar error 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los registros: " + ex.Message); //Desplegar error 
            }
            finally
            {
                conex.Close();
            }
        } 
        private void MostrarRegistro(Producto producto) //Método para mostrar todos los registros
        {
            //Información de los detalles que no contienen llaves foraneas 
            txtIDProducto.Text = producto.Id_Producto;
            txtClasificacion.Text = producto.Clasificacion;
            txtNombreP.Text = producto.Nombre_Perfume;
            txtMarca.Text = producto.Marca;
            txtPrecio.Text = producto.Precio;
            //Detalles con llaves fóraneas 
            MostrarDetallesAdicionales(producto.Id_Tamaño, producto.Id_Aroma, producto.Id_Envase);
        }
        //Método que recibe los detalles de las llaves fóraneas 
        private void MostrarDetallesAdicionales(string tamaño, string aroma, string envase)
        {
            //Verificar valores validos en los campos de Tamaño, Aroma y Envase antes de obtener los detalles correspondientes 
            if (!string.IsNullOrEmpty(tamaño))
            {
                string tamañoTexto = ObtenerDetalle("SELECT Tamaño_ml FROM Tamaño WHERE Id_Tamaño = @Id_Tamaño", tamaño, "@Id_Tamaño");
                txtTamaño.Text = tamañoTexto; //Asignar el valor obtenido
            }
            if (!string.IsNullOrEmpty(aroma))
            {
                string aromaTexto = ObtenerDetalle("SELECT Aroma FROM Aroma WHERE Id_Aroma = @Id_Aroma", aroma, "@Id_Aroma");
                txtAroma.Text = aromaTexto; //Asignar el valor obtenido
            }
            if (!string.IsNullOrEmpty(envase))
            {
                string envaseTexto = ObtenerDetalle("SELECT Tipo_Envase FROM Envase WHERE Id_Envase = @Id_Envase", envase, "@Id_Envase");
                txtEmbalaje.Text = envaseTexto; //Asignar el valor obtenido
            }
        }
        //Metodo para obtener los detalles de las llaves foraneas => Tamaño, Aroma y Envase 
        private string ObtenerDetalle(string query, string id, string parametro)
        {
            try
            {
                // Usar una nueva conexión para cada consulta
                using (SqlConnection newConnection = new SqlConnection(conex.ConnectionString))
                {
                    newConnection.Open(); //Se abre la conexión con la base de datos 
                    //Se crea un objeto comando para la consulta SQL con la conexión abierta 
                    using (SqlCommand comando = new SqlCommand(query, newConnection))
                    {
                        //Agregar parametro a la consulta con el valor id 
                        comando.Parameters.AddWithValue(parametro, id);
                        //Leer las filas retornadas por la consulta
                        using (SqlDataReader registro = comando.ExecuteReader())
                        {
                            if (registro.Read()) //Si hay resultados 
                            {
                                return registro[0].ToString(); //Devolver el valor de la primera columna 
                            }
                            else
                            {
                                return string.Empty; //Devolver una cadena vacía 
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el detalle: " + ex.Message); //Error al obtener los detalles 
                return string.Empty;
            }
        }
        private void Eliminar_Load(object sender, EventArgs e)
        {
            CargarRegistros(); // Carga el primer registro
        }
        private void txtIDProducto_Enter(object sender, EventArgs e)
        {
        }

        private void btnAvanzar_Click(object sender, EventArgs e)
        {
            //Verificar si el índice actual es menor que el número total de productos -1 
            if (currentIndex < productos.Count - 1) // Si hay más registros
            {
                currentIndex++; //Incremento al índice 
                //Llamar al método MostrarRegistro y pasar el producto correspondiente en la lista (productos[currentIndex])
                MostrarRegistro(productos[currentIndex]);
                txtNombreP.Enabled = false; //Deshabilitar la edición 
            }
            else
            {
                MessageBox.Show("No hay más registros."); //Si se acabaron los registros 
            }
        }

        private void btnRetroceder_Click(object sender, EventArgs e)
        {
            //Verificar si el índice es mayor que cero
            if (currentIndex > 0) // Si no estamos en el primer registro
            {
                currentIndex--; //Disminuir el índice 
                //Llamar al método MostrarRegistro y pasar el producto correspondiente en la lista (productos[currentIndex])
                MostrarRegistro(productos[currentIndex]);
                txtNombreP.Enabled = false; //Deshabilitar la edición 
            }
            else
            {
                MessageBox.Show("Ya estás en el primer registro."); //Si es el primer registro 
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Confirmación antes de eliminar
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este producto?",
                                                  "Confirmar eliminación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) //Si se confirmo la eliminación 
            {
                try
                {
                    // Obtener el nombre del producto que se va a eliminar
                    string idProducto = txtNombreP.Text;
                    // SQL para eliminar el producto
                    string query = "DELETE FROM Producto WHERE Nombre_Perfume = @Nombre_Perfume";
                    using (SqlCommand comando = new SqlCommand(query, conex))
                    {
                        comando.Parameters.AddWithValue("@Nombre_Perfume", idProducto);//La consulta utiliza el parametro
                        conex.Open();//Abrir conexión 
                        //Ejecuta las consultas y devuelve el número de filas afectadas 
                        int filasAfectadas = comando.ExecuteNonQuery();
                        if (filasAfectadas > 0)//Si la consulta afecta por lo menos una fila 
                        {
                            txtNombreP.Enabled = false; //Se deshabilita la edición 
                            MessageBox.Show("Producto eliminado correctamente.");
                            // Actualizar la lista de productos
                            productos.RemoveAt(currentIndex);
                            // Verificar si hay más productos para mostrar
                            if (productos.Count > 0)
                            {
                                // Si hay más productos, mostrar el siguiente
                                if (currentIndex >= productos.Count) // Si estamos al final, retroceder
                                {
                                    currentIndex = productos.Count - 1; 
                                }
                                MostrarRegistro(productos[currentIndex]); 
                            }
                            else
                            {
                                MessageBox.Show("No hay más productos."); //Si no quedan productos, limpiar los campos
                                LimpiarCampos(); //Llamar el método para limpiar las cajas de texto
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el producto."); //Error al eliminar producto
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el producto: " + ex.Message);
                }
                finally
                {
                    conex.Close(); //Cerrar conexión con la base de datos 
                }
              }
         }
        private void LimpiarCampos() // Método para limpiar los campos en el formulario
        {
            //Limpiar cada caja de texto
            txtIDProducto.Clear();
            txtClasificacion.Clear();
            txtNombreP.Clear();
            txtMarca.Clear();
            txtPrecio.Clear();
            txtTamaño.Clear();
            txtAroma.Clear();
            txtEmbalaje.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtNombreP.Enabled = true; //Habilitar edición 
            // Verificar si el campo de búsqueda (txtIDProducto) tiene un valor
            if (string.IsNullOrWhiteSpace(txtNombreP.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre de un producto para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Llamar a la función para realizar la búsqueda
            BuscarProducto(txtNombreP.Text);
        }
        private void BuscarProducto(string idProducto)
        {
            try
            {
                // Crear la consulta SQL para buscar el producto por ID
                string query = "SELECT Id_Producto, Clasificacion, Nombre_Perfume, Marca, Precio, Id_Tamaño, Id_Aroma, Id_Envase " +
                               "FROM Producto WHERE Nombre_Perfume = @Nombre_Perfume";
                using (SqlCommand cmd = new SqlCommand(query, conex))
                {
                    cmd.Parameters.AddWithValue("@Nombre_Perfume", idProducto);// Agregar parámetro para ID del producto
                    conex.Open();  // Abrir conexión
                    SqlDataReader registro = cmd.ExecuteReader();
                    if (registro.Read()) // Si encontramos un producto
                    {
                        // Crear un nuevo objeto Producto y cargar la información
                        Producto producto = new Producto
                        {
                            Id_Producto = registro["Id_Producto"].ToString(),
                            Clasificacion = registro["Clasificacion"].ToString(),
                            Nombre_Perfume = registro["Nombre_Perfume"].ToString(),
                            Marca = registro["Marca"].ToString(),
                            Precio = registro["Precio"].ToString(),
                            Id_Tamaño = registro["Id_Tamaño"].ToString(),
                            Id_Aroma = registro["Id_Aroma"].ToString(),
                            Id_Envase = registro["Id_Envase"].ToString()
                        };
                        MostrarRegistro(producto); // Mostrar el producto en los controles
                    }
                    else
                    {
                        // Si no se encuentra el producto
                        MessageBox.Show("No se encontró el producto con el nombre proporcionado.", "Producto No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    conex.Close();  // Cerrar conexión
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el producto: " + ex.Message);
            }
        }
    }
}
