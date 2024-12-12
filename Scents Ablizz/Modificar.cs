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
    public partial class Modificar : Form
    {
        public Modificar()
        {
            InitializeComponent();
            CargarTamaño(); //Carga de los datos de tamaño
            CargarAromas(); // Carga de los datos de aromas
            CargarEmbalaje(); //Carga de los datos de embalaje o envase 
        }
        //Variables Globales 
        private List<Producto> productos = new List<Producto>(); // Lista para almacenar los registros
        private int currentIndex = 0; // Índice para navegar entre los productos
        private bool isEditing = false; // Variable para controlar si se esta en modo de edición

        // Conexion inicializada de la base de datos 
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
            this.Close(); //Imagen que cierra la aplicación 
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            //Mostrar la página de inicio 
            this.Hide();
            Inicio inicio = new Inicio();
            inicio.Show();
        }

        private void txtIDProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e); //Excepción que permite solo números 
        }

        private void txtClasificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e); //Excepción que permite solo letras 
        }

        private void txtNombreP_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e); //Excepción que permite solo letras 
        }

        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e); //Excepción que permite solo letras 
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e); //Excepción que permite solo números 
        }

        private void txtTamaño_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txtAroma_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txtEmbalaje_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        private void CargarRegistros()//Metodo para cargar los registros de productos 
        {
            try
            {
                //Comando SQL para ejecutar la consulta de las distintas columnas de la tabla producto
                using (SqlCommand comando = new SqlCommand("SELECT Id_Producto, Clasificacion, Nombre_Perfume, Marca, Precio, Id_Tamaño, Id_Aroma, Id_Envase FROM Producto", conex))
                {
                    conex.Open(); // Abrir conexión
                    using (SqlDataReader registro = comando.ExecuteReader()) //Ejecutar consulta y leer los resultados 
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
                //Se asegura de que la conexión se cierre correctamente
                if (conex.State == ConnectionState.Open)
                {
                    conex.Close();
                }
            }
        }
        private void MostrarRegistro(Producto producto) //Metodo para mostrar todos los registros 
        {
            //Asignaciones de los valores obtenidos a las cajas de texto 
            txtIDProducto.Text = producto.Id_Producto;
            txtClasificacion.Text = producto.Clasificacion;
            txtNombreP.Text = producto.Nombre_Perfume;
            txtMarca.Text = producto.Marca;
            txtPrecio.Text = producto.Precio;
            //Asignaciones de los valores obtenidos a los comboBox
            cbxTamaño.SelectedValue = producto.Id_Tamaño;
            cbxAroma.SelectedValue = producto.Id_Aroma;
            cbxEmbalaje.SelectedValue = producto.Id_Envase;
        }
        private void btnAvanzar_Click(object sender, EventArgs e)
        {
            //Verificar si el índice actual es menor que el número total de productos -1 
            if (currentIndex < productos.Count - 1)
            {
                currentIndex++; //Incremento al índice 
                //Llamar al método MostrarRegistro y pasar el producto correspondiente en la lista (productos[currentIndex])
                MostrarRegistro(productos[currentIndex]); 
                txtNombreP.Enabled = false; //Deshabilitar la edición 
            }
            else
            {
                MessageBox.Show("No hay más registros.");//Mostrar cuando la condición ya no se cumpla 
            }
        }
        private void btnRetroceder_Click(object sender, EventArgs e)
        {
            //Verificar si el índice es mayor que cero 
            if (currentIndex > 0)
            {
                currentIndex--; //Disminuir el índice 
                //Llamar al método MostrarRegistro y pasar el producto correspondiente en la lista (productos[currentIndex])
                MostrarRegistro(productos[currentIndex]);
                txtNombreP.Enabled = false; //Deshabilitar la edición 
            }
            else
            {
                MessageBox.Show("Ya estás en el primer registro.");//Mostrar cuando la condición ya no se cumpla 
            }
        }
        private void Modificar_Load(object sender, EventArgs e)
        {
            CargarRegistros(); // Carga el primer registro
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!isEditing)//Verificar si la variable de edición es falsa 
            {
                // Habilitar edición de los campos 
                txtNombreP.Enabled = false;
                txtClasificacion.Enabled = true;
                txtIDProducto.Enabled = true;
                txtMarca.Enabled = true;
                txtPrecio.Enabled = true;
                cbxTamaño.Enabled = true;
                cbxAroma.Enabled = true;
                cbxEmbalaje.Enabled = true;
                //Cambiar el texto del boton 
                btnModificar.Text = "Guardar";
                isEditing = true; //Habilitar el modo de edición 
            }
            else
            {
                // Mostrar el cuadro de mensaje para confirmar la edición 
                DialogResult result = MessageBox.Show("¿Está seguro de que desea guardar los cambios?", "Confirmar Modificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) //Si la respuesta es si se guardan los cambios 
                {
                    try
                    {
                        //Consulta SQL para actualizar los datos modificados 
                        string query = "UPDATE Producto SET Clasificacion = @Clasificacion, Nombre_Perfume = @Nombre_Perfume, Marca = @Marca, Precio = @Precio, Id_Tamaño = @Id_Tamaño, Id_Aroma = @Id_Aroma, Id_Envase = @Id_Envase WHERE Nombre_Perfume = @Nombre_Perfume";
                        using (SqlCommand cmd = new SqlCommand(query, conex))
                        {
                            //Se asignan los valores de los controles a los parametros de la consulta SQL 
                            cmd.Parameters.AddWithValue("@Clasificacion", txtClasificacion.Text);
                            cmd.Parameters.AddWithValue("@Nombre_Perfume", txtNombreP.Text);
                            cmd.Parameters.AddWithValue("@Marca", txtMarca.Text);
                            cmd.Parameters.AddWithValue("@Precio", txtPrecio.Text);
                            cmd.Parameters.AddWithValue("@Id_Tamaño", cbxTamaño.SelectedValue);
                            cmd.Parameters.AddWithValue("@Id_Aroma", cbxAroma.SelectedValue);
                            cmd.Parameters.AddWithValue("@Id_Envase", cbxEmbalaje.SelectedValue);
                            cmd.Parameters.AddWithValue("@Id_Producto", txtIDProducto.Text);
                            conex.Open(); //Se abre la conexión 
                            //Ejecutar la consulta que devuelve el número de filas afectadas o productos actualizados 
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0) //Si se actualizo el producto 
                            {
                                conex.Close(); //Se cierra la conexión 
                                MessageBox.Show("Producto modificado con éxito."); //Mostrar mensaje de modificación exitosa 
                                CargarRegistros(); // Llamar al método para actualizar la lista 
                            }
                            else
                            {
                                MessageBox.Show("No se pudo modificar el producto."); //Error en la actualización 
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //Error en la modificación mientras se realiza la consulta
                        MessageBox.Show("Error al modificar el producto: " + ex.Message); 
                    }
                    finally
                    {
                        conex.Close(); //Cerrar la conexión con la base de datos 
                    }
                }

                // Deshabilitar edición
                txtNombreP.Enabled = false;
                txtClasificacion.Enabled = false;
                txtIDProducto.Enabled = false;
                txtMarca.Enabled = false;
                txtPrecio.Enabled = false;
                cbxTamaño.Enabled = false;
                cbxAroma.Enabled = false;
                cbxEmbalaje.Enabled = false;
                //Cambiar el texto del boton 
                btnModificar.Text = "Modificar";
                isEditing = false; //Deshabilitar el modo de edición 
            }
        }
        private void CargarTamaño() //Método para cargar los datos de la tabla Tamaño
        {
            try
            {
                conex.Open(); //Abrir conexión con la base de datos 
                //Prepara la consulta en SQL 
                SqlCommand comando = new SqlCommand("SELECT Id_Tamaño, Tamaño_ml FROM Tamaño", conex);
                //Ejecuta la consulta y llena los datos obtenidos en un objeto DataTable => tabla 
                SqlDataAdapter adaptador = new SqlDataAdapter(comando); 
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                //Agregar una fila Predeterminada en el DataTable 
                DataRow fila = tabla.NewRow(); //Crear fila 
                fila["Id_Tamaño"] = DBNull.Value; //Se asigna valor nulo 
                fila["Tamaño_ml"] = "Seleccione el tamaño"; //Mostrar texto en el ComboBox 
                tabla.Rows.InsertAt(fila, 0); //Se inserta en la primera posición 
                //Configurar el ComboBox 
                cbxTamaño.ValueMember = "Id_Tamaño"; //Valor asociado a cada Item 
                cbxTamaño.DisplayMember = "Tamaño_ml"; //Texto que se muestra en el ComboBox 
                cbxTamaño.DataSource = tabla; //Asignación como fuente de datos del ComboBox 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tamaños: " + ex.Message); //Error mediante la ejecución 
            }
            finally
            {
                // Cerrar la conexión después de la operación
                if (conex.State == ConnectionState.Open)
                {
                    conex.Close();
                }
            }
        }
        private void CargarAromas()//Método para cargar los datos de la tabla Aroma 
        {
            try
            {
                conex.Open(); //Abrir conexión 
                SqlCommand comando = new SqlCommand("SELECT Id_Aroma, Aroma FROM Aroma", conex);//Prepara la consulta en SQL 
                //Ejecuta la consulta y llena los datos obtenidos en un objeto DataTable => tabla 
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                //Agregar una fila Predeterminada en el DataTable 
                DataRow fila = tabla.NewRow();//Crear tabla
                fila["Id_Aroma"] = DBNull.Value; //Asignar valor nulo
                fila["Aroma"] = "Seleccione el aroma";//Mostrar texto en el ComboBox 
                tabla.Rows.InsertAt(fila, 0);//Se inserta en la primera posición 
                //Configurar el ComboBox 
                cbxAroma.ValueMember = "Id_Aroma"; //Valor asociado a cada Item 
                cbxAroma.DisplayMember = "Aroma"; //Texto que se muestra en el ComboBox 
                cbxAroma.DataSource = tabla; //Asignación como fuente de datos del ComboBox 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar aromas: " + ex.Message); //Error mediante la ejecución 
            }
            finally
            {
                // Cerrar la conexión después de la operación
                if (conex.State == ConnectionState.Open)
                {
                    conex.Close();
                }
            }
        }
        private void CargarEmbalaje() //Método para cargar los datos de la tabla Envase 
        {
            try
            {
                conex.Open();//Abrir conexión 
                SqlCommand comando = new SqlCommand("SELECT Id_Envase, Tipo_Envase FROM Envase", conex);//Prepara la consulta en SQL 
                //Ejecuta la consulta y llena los datos obtenidos en un objeto DataTable => tabla 
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                //Agregar una fila Predeterminada en el DataTable 
                DataRow fila = tabla.NewRow(); //Crear tabla
                fila["Id_Envase"] = DBNull.Value; //Asignar valor nulo
                fila["Tipo_Envase"] = "Seleccione el envase"; //Mostrar texto en el ComboBox 
                tabla.Rows.InsertAt(fila, 0); //Se inserta en la primera posición
                //Configurar el ComboBox 
                cbxEmbalaje.ValueMember = "Id_Envase"; //Valor asociado a cada Item 
                cbxEmbalaje.DisplayMember = "Tipo_Envase"; //Texto que se muestra en el ComboBox 
                cbxEmbalaje.DataSource = tabla; //Asignación como fuente de datos del ComboBox 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar embalajes: " + ex.Message); //Error mediante la ejecución 
            }
            finally
            {
                // Cerrar la conexión después de la operación
                if (conex.State == ConnectionState.Open)
                {
                    conex.Close();
                }
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtNombreP.Enabled = true; //Habilitar la edición 
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
                    cmd.Parameters.AddWithValue("@Nombre_Perfume", idProducto);  // Agregar parámetro para ID del producto
                    conex.Open();  // Abrir conexión
                    SqlDataReader registro = cmd.ExecuteReader();
                    // Si se encuentra un producto
                    if (registro.Read())
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
                        // Mostrar el producto en los controles
                        MostrarRegistro(producto);
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
