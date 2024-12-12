using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scents_Ablizz
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            //Abrir la ventana de insertar 
            this.Hide();
            Insertar insertar = new Insertar();
            insertar.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Abrir la ventana de modificar
            this.Hide();
            Modificar modificar = new Modificar();
            modificar.Show();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            //Abrir la ventana de consultar
            this.Hide();
            Consultar consultar = new Consultar();
            consultar.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Abrir la ventana de eliminar
            this.Hide();
            Eliminar eliminar = new Eliminar();
            eliminar.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();//Imagen que cierra el programa 
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
        }
    }
}
