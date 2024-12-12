namespace Scents_Ablizz
{
    partial class Eliminar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Eliminar));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtEmbalaje = new System.Windows.Forms.TextBox();
            this.lblEmbalaje = new System.Windows.Forms.Label();
            this.txtAroma = new System.Windows.Forms.TextBox();
            this.txtTamaño = new System.Windows.Forms.TextBox();
            this.txtClasificacion = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.txtNombreP = new System.Windows.Forms.TextBox();
            this.lblAroma = new System.Windows.Forms.Label();
            this.lblTamaño = new System.Windows.Forms.Label();
            this.lblClasificacion = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtIDProducto = new System.Windows.Forms.TextBox();
            this.lblIDP = new System.Windows.Forms.Label();
            this.btnRetroceder = new Scents_Ablizz.BotonesR();
            this.btnAvanzar = new Scents_Ablizz.BotonesR();
            this.btnRegresar = new Scents_Ablizz.BotonesR();
            this.btnEliminar = new Scents_Ablizz.BotonesR();
            this.btnBuscar = new Scents_Ablizz.BotonesR();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(814, 46);
            this.panel1.TabIndex = 115;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(767, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 74;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(311, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 32);
            this.label1.TabIndex = 74;
            this.label1.Text = "E l i m i n a r";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(446, 80);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(334, 310);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 112;
            this.pictureBox2.TabStop = false;
            // 
            // txtEmbalaje
            // 
            this.txtEmbalaje.Enabled = false;
            this.txtEmbalaje.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmbalaje.Location = new System.Drawing.Point(121, 379);
            this.txtEmbalaje.Name = "txtEmbalaje";
            this.txtEmbalaje.Size = new System.Drawing.Size(190, 26);
            this.txtEmbalaje.TabIndex = 111;
            // 
            // lblEmbalaje
            // 
            this.lblEmbalaje.AutoSize = true;
            this.lblEmbalaje.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmbalaje.Location = new System.Drawing.Point(46, 383);
            this.lblEmbalaje.Name = "lblEmbalaje";
            this.lblEmbalaje.Size = new System.Drawing.Size(70, 20);
            this.lblEmbalaje.TabIndex = 110;
            this.lblEmbalaje.Text = "Envase: ";
            // 
            // txtAroma
            // 
            this.txtAroma.Enabled = false;
            this.txtAroma.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAroma.Location = new System.Drawing.Point(121, 329);
            this.txtAroma.Name = "txtAroma";
            this.txtAroma.Size = new System.Drawing.Size(190, 26);
            this.txtAroma.TabIndex = 109;
            // 
            // txtTamaño
            // 
            this.txtTamaño.Enabled = false;
            this.txtTamaño.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTamaño.Location = new System.Drawing.Point(121, 287);
            this.txtTamaño.Name = "txtTamaño";
            this.txtTamaño.Size = new System.Drawing.Size(190, 26);
            this.txtTamaño.TabIndex = 108;
            // 
            // txtClasificacion
            // 
            this.txtClasificacion.Enabled = false;
            this.txtClasificacion.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClasificacion.Location = new System.Drawing.Point(158, 154);
            this.txtClasificacion.Name = "txtClasificacion";
            this.txtClasificacion.Size = new System.Drawing.Size(153, 26);
            this.txtClasificacion.TabIndex = 107;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Enabled = false;
            this.txtPrecio.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(121, 242);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(190, 26);
            this.txtPrecio.TabIndex = 106;
            // 
            // txtMarca
            // 
            this.txtMarca.Enabled = false;
            this.txtMarca.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMarca.Location = new System.Drawing.Point(121, 200);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(190, 26);
            this.txtMarca.TabIndex = 105;
            // 
            // txtNombreP
            // 
            this.txtNombreP.Enabled = false;
            this.txtNombreP.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreP.Location = new System.Drawing.Point(202, 69);
            this.txtNombreP.Name = "txtNombreP";
            this.txtNombreP.Size = new System.Drawing.Size(175, 26);
            this.txtNombreP.TabIndex = 104;
            // 
            // lblAroma
            // 
            this.lblAroma.AutoSize = true;
            this.lblAroma.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAroma.Location = new System.Drawing.Point(46, 333);
            this.lblAroma.Name = "lblAroma";
            this.lblAroma.Size = new System.Drawing.Size(66, 20);
            this.lblAroma.TabIndex = 103;
            this.lblAroma.Text = "Aroma: ";
            // 
            // lblTamaño
            // 
            this.lblTamaño.AutoSize = true;
            this.lblTamaño.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTamaño.Location = new System.Drawing.Point(46, 291);
            this.lblTamaño.Name = "lblTamaño";
            this.lblTamaño.Size = new System.Drawing.Size(74, 20);
            this.lblTamaño.TabIndex = 102;
            this.lblTamaño.Text = "Tamaño: ";
            // 
            // lblClasificacion
            // 
            this.lblClasificacion.AutoSize = true;
            this.lblClasificacion.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClasificacion.Location = new System.Drawing.Point(47, 161);
            this.lblClasificacion.Name = "lblClasificacion";
            this.lblClasificacion.Size = new System.Drawing.Size(111, 20);
            this.lblClasificacion.TabIndex = 101;
            this.lblClasificacion.Text = "Clasificación: ";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(48, 249);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(64, 20);
            this.lblPrecio.TabIndex = 100;
            this.lblPrecio.Text = "Precio: ";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarca.Location = new System.Drawing.Point(48, 200);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(67, 20);
            this.lblMarca.TabIndex = 99;
            this.lblMarca.Text = "Marca: ";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(47, 73);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(149, 20);
            this.lblNombre.TabIndex = 98;
            this.lblNombre.Text = "Nombre producto: ";
            // 
            // txtIDProducto
            // 
            this.txtIDProducto.Enabled = false;
            this.txtIDProducto.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDProducto.Location = new System.Drawing.Point(158, 111);
            this.txtIDProducto.Name = "txtIDProducto";
            this.txtIDProducto.Size = new System.Drawing.Size(153, 26);
            this.txtIDProducto.TabIndex = 97;
            this.txtIDProducto.Enter += new System.EventHandler(this.txtIDProducto_Enter);
            // 
            // lblIDP
            // 
            this.lblIDP.AutoSize = true;
            this.lblIDP.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDP.Location = new System.Drawing.Point(47, 118);
            this.lblIDP.Name = "lblIDP";
            this.lblIDP.Size = new System.Drawing.Size(105, 20);
            this.lblIDP.TabIndex = 96;
            this.lblIDP.Text = "ID Producto: ";
            // 
            // btnRetroceder
            // 
            this.btnRetroceder.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnRetroceder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRetroceder.BackgroundImage")));
            this.btnRetroceder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRetroceder.FlatAppearance.BorderSize = 0;
            this.btnRetroceder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetroceder.ForeColor = System.Drawing.Color.White;
            this.btnRetroceder.Location = new System.Drawing.Point(91, 425);
            this.btnRetroceder.Name = "btnRetroceder";
            this.btnRetroceder.Size = new System.Drawing.Size(84, 44);
            this.btnRetroceder.TabIndex = 117;
            this.btnRetroceder.UseVisualStyleBackColor = false;
            this.btnRetroceder.Click += new System.EventHandler(this.btnRetroceder_Click);
            // 
            // btnAvanzar
            // 
            this.btnAvanzar.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnAvanzar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAvanzar.BackgroundImage")));
            this.btnAvanzar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAvanzar.FlatAppearance.BorderSize = 0;
            this.btnAvanzar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAvanzar.ForeColor = System.Drawing.Color.White;
            this.btnAvanzar.Location = new System.Drawing.Point(202, 424);
            this.btnAvanzar.Name = "btnAvanzar";
            this.btnAvanzar.Size = new System.Drawing.Size(84, 44);
            this.btnAvanzar.TabIndex = 116;
            this.btnAvanzar.UseVisualStyleBackColor = false;
            this.btnAvanzar.Click += new System.EventHandler(this.btnAvanzar_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnRegresar.FlatAppearance.BorderSize = 0;
            this.btnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegresar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.ForeColor = System.Drawing.Color.White;
            this.btnRegresar.Location = new System.Drawing.Point(641, 423);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(130, 42);
            this.btnRegresar.TabIndex = 114;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(464, 423);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(130, 42);
            this.btnEliminar.TabIndex = 113;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(405, 63);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 40);
            this.btnBuscar.TabIndex = 118;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // Eliminar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(812, 488);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnRetroceder);
            this.Controls.Add(this.btnAvanzar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txtEmbalaje);
            this.Controls.Add(this.lblEmbalaje);
            this.Controls.Add(this.txtAroma);
            this.Controls.Add(this.txtTamaño);
            this.Controls.Add(this.txtClasificacion);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.txtNombreP);
            this.Controls.Add(this.lblAroma);
            this.Controls.Add(this.lblTamaño);
            this.Controls.Add(this.lblClasificacion);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtIDProducto);
            this.Controls.Add(this.lblIDP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(812, 488);
            this.MinimumSize = new System.Drawing.Size(812, 488);
            this.Name = "Eliminar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eliminar";
            this.Load += new System.EventHandler(this.Eliminar_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BotonesR btnRetroceder;
        private BotonesR btnAvanzar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private BotonesR btnRegresar;
        private BotonesR btnEliminar;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtEmbalaje;
        private System.Windows.Forms.Label lblEmbalaje;
        private System.Windows.Forms.TextBox txtAroma;
        private System.Windows.Forms.TextBox txtTamaño;
        private System.Windows.Forms.TextBox txtClasificacion;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.TextBox txtNombreP;
        private System.Windows.Forms.Label lblAroma;
        private System.Windows.Forms.Label lblTamaño;
        private System.Windows.Forms.Label lblClasificacion;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtIDProducto;
        private System.Windows.Forms.Label lblIDP;
        private BotonesR btnBuscar;
    }
}