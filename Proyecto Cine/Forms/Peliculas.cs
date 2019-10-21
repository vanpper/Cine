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
using System.IO;

namespace Proyecto_Cine.Forms
{
    public partial class Peliculas : Form
    {
        const int NULL = 0;
        const int NUEVO = 1;        //CONSTANTES
        const int MODIFICAR = 2;

        Conexion BD = new Conexion();
        DataTable DTPeliculas = new DataTable();
        DataTable DTGeneros = new DataTable();
        DataTable DTClasificaciones = new DataTable();
        SqlDataAdapter adaptador;
        SqlCommand comando;

        int OperacionActual = 0; //INDICADOR DE OPERACION ACTUAL

        public Peliculas()
        {
            InitializeComponent();

            dgvPeliculas.DataSource = DTPeliculas; //INDICARLE AL DATAGRID PELICULAS QUE SU FUENTE DE DATOS SERA EL DATATABLE PELICULAS
            boxGenero.DataSource = DTGeneros; //INDICARLE AL BOX GENEROS QUE SU FUENTE DE DATOS SERA EL DATATABLE GENEROS
            boxClasificacion.DataSource = DTClasificaciones; //INDICARLE AL BOX CLASIFICACIONES QUE SU FUENTE DE DATOS SERA EL DATATABLE CLASIFICACIONES

            if (BD.abrir()) //SI LA CONEXION CON LA BASE DE DATOS SE PUEDE ABRIR...
            {
                ActualizarDgvPeliculas(); //ACTUALIZAR EL DATAGRID PELICULAS
                ActualizarBoxGeneros(); //ACTUALIZAR EL BOX DE GENEROS
                ActualizarBoxClasificaciones(); //ACTUALIZAR EL BOX DE CLASIFICAICONES
            }

            ConfigurarGrids(); //CONFIGURACION RELACIONADA CON LA APARIENCIA DEL DATAGRID
        }

        private void ActualizarContenedores()
        {
            try
            {
                //LLENAR CADA ELEMENTO CON LOS DATOS DE LA PELICULA SELECCIONADA EN EL DATAGRID
                txtNombre.Text = dgvPeliculas.CurrentRow.Cells[1].Value.ToString();
                txtDuracion.Text = dgvPeliculas.CurrentRow.Cells[2].Value.ToString();
                txtActores.Text = dgvPeliculas.CurrentRow.Cells[3].Value.ToString();
                txtDirectores.Text = dgvPeliculas.CurrentRow.Cells[4].Value.ToString();
                boxGenero.SelectedValue = dgvPeliculas.CurrentRow.Cells[5].Value;
                boxClasificacion.SelectedValue = dgvPeliculas.CurrentRow.Cells[7].Value;
                cbEstado.Checked = Boolean.Parse(dgvPeliculas.CurrentRow.Cells[11].Value.ToString());
                txtDescripcion.Text = dgvPeliculas.CurrentRow.Cells[9].Value.ToString();

                if(dgvPeliculas.CurrentRow.Cells[10].Value.ToString() != "") //SI LA PELICULA SELECCIONADA TIENE UNA IMAGEN CARGADA...
                {
                    MemoryStream buffer = new MemoryStream((byte[])dgvPeliculas.CurrentRow.Cells[10].Value); //LLENAR EL BUFFER CON LA IMAGEN
                    pictureBox1.Image = Image.FromStream(buffer); //PASAR LA IMAGEN DEL BUFFER AL PICTURE BOX
                }
                else //SI LA PELICULA NO TIENE UNA IMAGEN CARGADA...
                {
                    pictureBox1.Image = null; //VACIAR EL PICTURE BOX
                }
            } catch (Exception ex) { }
        }

        private void ActualizarBoxClasificaciones()
        {
            adaptador = new SqlDataAdapter("SELECT * FROM Clasificaciones", BD.getSqlConnection()); //TRAER TODAS LAS CLASIFICACIONES
            DTClasificaciones.Clear(); //LIMPIAR EL DATATABLE DE VIEJOS REGISTROS
            adaptador.Fill(DTClasificaciones); //LLENAR EL DATATABLE CON LOS NUEVOS REGISTROS

            DTClasificaciones.DefaultView.Sort = "Descripcion_Clas"; //ORDENAR CLASIFICACIONES ALFABETICAMENTE

            boxClasificacion.DisplayMember = "Descripcion_Clas"; //LO QUE SE VERA SERA LA DESCRIPCION DE CADA CLASIFICACION
            boxClasificacion.ValueMember = "CodClasificacion_Clas"; //CADA MIEMBRO TENDRA COMO VALOR EL CODIGO DE CLASIFICACION CORRESPONDIENTE
        }

        private void ActualizarBoxGeneros()
        {
            adaptador = new SqlDataAdapter("SELECT * FROM Generos", BD.getSqlConnection()); //TRAER TODOS LOS GENEROS
            DTGeneros.Clear(); //LIMPIAR EL DATATABLE DE VIEJOS REGISTROS
            adaptador.Fill(DTGeneros);  //LLENAR EL DATATABLE CON LOS NUEVOS REGISTROS

            DTGeneros.DefaultView.Sort = "Descripcion_Gene"; //ORDENAR GENEROS ALFABETICAMENTE

            boxGenero.DisplayMember = "Descripcion_Gene"; //LO QUE SE VERA SERA LA DESCRIPCION DE CADA GENERO
            boxGenero.ValueMember = "CodGenero_Gene"; //CADA MIEMBRO TENDRA COMO VALOR EL CODIGO DE GENERO CORRESPONDIENTE
        }

        private void ConfigurarGrids()
        {
            dgvPeliculas.Columns[0].HeaderText = "Codigo";
            dgvPeliculas.Columns[1].HeaderText = "Peliculas";
            dgvPeliculas.Columns[2].HeaderText = "Duracion";
            dgvPeliculas.Columns[3].HeaderText = "Actores";
            dgvPeliculas.Columns[4].HeaderText = "Directores";
            dgvPeliculas.Columns[5].HeaderText = "Codigo Genero";
            dgvPeliculas.Columns[6].HeaderText = "Genero";
            dgvPeliculas.Columns[7].HeaderText = "Codigo Clasificacion";
            dgvPeliculas.Columns[8].HeaderText = "Clasificacion";
            dgvPeliculas.Columns[9].HeaderText = "Descripcion";
            dgvPeliculas.Columns[10].HeaderText = "Portada";
            dgvPeliculas.Columns[11].HeaderText = "Estado";

            for(int i = 0; i < dgvPeliculas.ColumnCount; i++)
            {
                if(i != 1)
                {
                    dgvPeliculas.Columns[i].Visible = false;
                }
            }
            
            dgvPeliculas.ReadOnly = true;
            dgvPeliculas.AllowUserToAddRows = false;
            dgvPeliculas.RowHeadersVisible = false;
            dgvPeliculas.AllowUserToResizeColumns = false;
            dgvPeliculas.AllowUserToResizeRows = false;
            dgvPeliculas.MultiSelect = false;
            dgvPeliculas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPeliculas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPeliculas.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPeliculas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPeliculas.Sort(dgvPeliculas.Columns[1], ListSortDirection.Ascending);

            for (int i = 0; i < dgvPeliculas.ColumnCount; i++)
            {
                dgvPeliculas.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void ActualizarDgvPeliculas()
        {
            adaptador = new SqlDataAdapter("SELECT CodPelicula_Peli, Nombre_Peli, Duracion_Peli, Actores_Peli, Director_Peli, CodGenero_Peli, Descripcion_Gene, CodClasificacion_Peli, Descripcion_Clas, Descripcion_Peli, Portada_Peli, Estado_Peli FROM Peliculas INNER JOIN Generos ON CodGenero_Peli = CodGenero_Gene INNER JOIN Clasificaciones ON CodClasificacion_Clas = CodClasificacion_Peli", BD.getSqlConnection()); //TRAER TODAS LAS PELICULAS
            DTPeliculas.Clear(); //LIMPIAR EL DATATBLE DE VIEJOS REGISTROS
            adaptador.Fill(DTPeliculas); //LLENAR EL DATATABLE CON LOS NUEVOS REGISTROS
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            try 
            {
                openFileDialog1.Title = "Seleccione una imagen";
                openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                openFileDialog1.FileName = "";


                if (openFileDialog1.ShowDialog() == DialogResult.OK) //ABRIR VENTANA PARA SELECCIONAR ARCHIVO. SI SE SELECCIONO UN ARCHIVO...
                {
                    string imagen = openFileDialog1.FileName; //GUARDAR LA RUTA DE LA IMAGEN
                    pictureBox1.Image = Image.FromFile(imagen); //CARGAR ESA IMAGEN A TRAVES DE LA RUTA AL PICTURE BOX
                }
            }
            catch (Exception ex) //SI EL ARCHIVO SELECCIONADO NO ES UNA IMAGEN...
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido");
                pictureBox1.Image = null;
            }
        }

        private void dgvPeliculas_SelectionChanged(object sender, EventArgs e)
        {
            if(OperacionActual != NUEVO) //SI NO SE ESTA AGREGANDO UNA NUEVA PELICULA
            {
                ActualizarContenedores(); //ACTUALIZAR LOS CONTENEDORES DE DATOS CON LA PELICULA SELECCIONADA
            }

            if(OperacionActual == MODIFICAR) placeholderTextbox(); //CONTROL POR SI LOS TEXTBOX ESTAN EN BLANCO. HAY QUE PONER EL TEXTO GUIA
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            OperacionActual = NUEVO; //INDICAR QUE LA OPERACION ACTUAL ES "NUEVO"

            txtNombre.ReadOnly = false;
            txtDuracion.ReadOnly = false;
            txtActores.ReadOnly = false;    //HABILITAR CONTENEDORES PARA INGRESAR DATOS
            txtDirectores.ReadOnly = false;
            txtDescripcion.ReadOnly = false;
            cbEstado.Checked = true;

            txtNombre.Clear();
            txtDuracion.Clear();
            txtActores.Clear();
            txtDirectores.Clear();      //LIMPIAR CONTENEDORES
            txtDescripcion.Clear();
            boxGenero.SelectedIndex = 0;
            boxClasificacion.SelectedIndex = 0;
            pictureBox1.Image = null;

            txtNombre.Text = "Nombre";
            txtDuracion.Text = "Duracion";
            txtActores.Text = "Actores";            //TEXTO QUE DESCRIBE QUE ES CADA TEXTBOX
            txtDirectores.Text = "Directores";
            txtDescripcion.Text = "Descripcion";

            txtNombre.ForeColor = Color.Gray;
            txtDuracion.ForeColor = Color.Gray;
            txtActores.ForeColor = Color.Gray;      //COLOR PARA LOS TEXTBOXS
            txtDirectores.ForeColor = Color.Gray;
            txtDescripcion.ForeColor = Color.Gray;
            this.ActiveControl = null;

            btnAgregarImagen.Visible = true;
            btnBorrarImagen.Visible = true;
            btnGuardar.Visible = true;          //OCULTAR BOTONES QUE NO SE UTILIZARAN PARA DICHA OPERACION
            btnVolver.Visible = true;           //MOSTRAR BOTONES QUE SE UTILIZARAN PARA DICHA OPERACION
            btnNuevo.Visible = false;
            btnModificar.Visible = false;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            OperacionActual = NULL; //INDICAR QUE LA OPERACION ACTUAL ES "NULO"
            ActualizarContenedores(); //ACTUALIZAR LOS CONTENEDORES CON LA PELICULA SELECCIONADA

            txtNombre.ReadOnly = true;
            txtDuracion.ReadOnly = true;
            txtActores.ReadOnly = true;     //INHABILITAR LOS CONTENEDORES PARA EL INGRESO DE DATOS
            txtDirectores.ReadOnly = true;
            txtDescripcion.ReadOnly = true;

            btnAgregarImagen.Visible = false;
            btnBorrarImagen.Visible = false;
            btnNuevo.Visible = true;            //OCULTAR BOTONES QUE NO SE UTILIZARAN PARA DICHA OPERACION
            btnModificar.Visible = true;        //MOSTRAR BOTONES QUE SE UTILIZARAN PARA DICHA OPERACION
            btnVolver.Visible = false;
            btnGuardar.Visible = false;
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            OperacionActual = MODIFICAR; //INDICAR QUE LA OPERACION ACTUAL ES "MODIFICAR"

            txtNombre.Focus();
            txtNombre.ReadOnly = false;
            txtDuracion.ReadOnly = false;
            txtActores.ReadOnly = false;        //HABILITAR LOS CONTENEDORES PARA EL INGRESO DE DATOS
            txtDirectores.ReadOnly = false;
            txtDescripcion.ReadOnly = false;

            placeholderTextbox(); //CONTROL POR SI LOS TEXTBOX ESTAN EN BLANCO. HAY QUE PONER EL TEXTO GUIA
            txtNombre.ForeColor = Color.Black; //COLOR NEGRO POR SI QUEDO EN GRIS

            btnAgregarImagen.Visible = true;
            btnBorrarImagen.Visible = true;
            btnVolver.Visible = true;           //OCULTAR BOTONES QUE NO SE UTILIZARAN PARA DICHA OPERACION
            btnGuardar.Visible = true;          //MOSTRAR BOTONES QUE SE UTILIZARAN PARA DICHA OPERACION
            btnNuevo.Visible = false;
            btnModificar.Visible = false;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!(txtNombre.Text == "Nombre" || txtNombre.Text == "")) //SI EL TEXTBOX NOMBRE TIENE ALGO ESCRITO 
            {
                if (OperacionActual == MODIFICAR) //SI SE ESTA MODIFICANDO
                {
                    if(dgvPeliculas.CurrentRow.Cells[11].Value.ToString() == "True" && cbEstado.Checked == false) //SI SE VA A DESHABILITAR LA PELICULA
                    {
                        DialogResult resultado = MessageBox.Show("Al deshabilitar la pelicula, tambien sera deshabilitada en todos sus formatos.\nPara volver a habilitar cada formato debera hacerlo manualmente.\n¿Desea continuar?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if(resultado == DialogResult.Yes) //SI SE ELIGIO "SI"
                        {
                            modificarPelicula(); //MODIFICAR LA PELICULA EN LA BASE DE DATOS
                            deshabilitarPeliculasXFormato(); //DESHABILITAR LA PELICULA EN SUS VARIOS FORMATOS
                        }
                    }
                    else //SI LA MODIFICACION NO TIENE QUE VER CON DESHABILITAR LA PELICULA
                    {
                        modificarPelicula(); //SIMPLEMENTE MODIFICAR
                    }
                }

                if (OperacionActual == NUEVO)
                {
                    agregarPelicula(); //AGREGAR PELICULA A LA BASE DE DATOS
                }
            }
            else
            {
                MessageBox.Show("La pelicula debe contener un nombre.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBorrarImagen_Click(object sender, EventArgs e)
        {
            if(pictureBox1.Image != null) //SI EL PICTURE BOX TIENE UNA IMAGEN CARGADA
            {
                pictureBox1.Image = null; //LIMPIAR
            }
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if(txtNombre.Text == "Nombre") //SI CUANDO SE SELECCIONO EL TEXTBOX, ESTA ESCRITO EL TEXTO GUIA...
            {
                txtNombre.Clear(); //LIMPIAR CAJA PARA PODER INGRESAR TEXTO
                txtNombre.ForeColor = Color.Black; //PONER EL COLOR EN NEGRO
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "") //SI CUANDO SE DEJO EL TEXTBOX, ESTE QUEDO EN BLANCO...
            {
                txtNombre.Text = "Nombre"; //VOLVER A PONER EL TEXTO GUIA
                txtNombre.ForeColor = Color.Gray; //PONER COLOR EN GRIS
            }
        }

        private void txtDuracion_Enter(object sender, EventArgs e)
        {
            if (txtDuracion.Text == "Duracion") //SI CUANDO SE SELECCIONO EL TEXTBOX, ESTA ESCRITO EL TEXTO GUIA...
            {
                txtDuracion.Clear(); //LIMPIAR CAJA PARA PODER INGRESAR TEXTO
                txtDuracion.ForeColor = Color.Black; //PONER EL COLOR EN NEGRO
            }
        }

        private void txtDuracion_Leave(object sender, EventArgs e)
        {
            if (txtDuracion.Text == "") //SI CUANDO SE DEJO EL TEXTBOX, ESTE QUEDO EN BLANCO...
            {
                txtDuracion.Text = "Duracion"; //VOLVER A PONER EL TEXTO GUIA
                txtDuracion.ForeColor = Color.Gray; //PONER COLOR EN GRIS
            }
        }

        private void txtActores_Enter(object sender, EventArgs e)
        {
            if (txtActores.Text == "Actores") //SI CUANDO SE SELECCIONO EL TEXTBOX, ESTA ESCRITO EL TEXTO GUIA...
            {
                txtActores.Clear(); //LIMPIAR CAJA PARA PODER INGRESAR TEXTO
                txtActores.ForeColor = Color.Black; //PONER EL COLOR EN NEGRO
            }
        }

        private void txtActores_Leave(object sender, EventArgs e)
        {
            if (txtActores.Text == "") //SI CUANDO SE DEJO EL TEXTBOX, ESTE QUEDO EN BLANCO...
            {
                txtActores.Text = "Actores"; //VOLVER A PONER EL TEXTO GUIA
                txtActores.ForeColor = Color.Gray; //PONER COLOR EN GRIS
            }
        }

        private void txtDirectores_Enter(object sender, EventArgs e)
        {
            if (txtDirectores.Text == "Directores") //SI CUANDO SE SELECCIONO EL TEXTBOX, ESTA ESCRITO EL TEXTO GUIA...
            {
                txtDirectores.Clear(); //LIMPIAR CAJA PARA PODER INGRESAR TEXTO
                txtDirectores.ForeColor = Color.Black; //PONER EL COLOR EN NEGRO
            }
        }

        private void txtDirectores_Leave(object sender, EventArgs e)
        {
            if (txtDirectores.Text == "") //SI CUANDO SE DEJO EL TEXTBOX, ESTE QUEDO EN BLANCO...
            {
                txtDirectores.Text = "Directores"; //VOLVER A PONER EL TEXTO GUIA
                txtDirectores.ForeColor = Color.Gray; //PONER COLOR EN GRIS
            }
        }

        private void txtDescripcion_Enter(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "Descripcion") //SI CUANDO SE SELECCIONO EL TEXTBOX, ESTA ESCRITO EL TEXTO GUIA...
            {
                txtDescripcion.Clear(); //LIMPIAR CAJA PARA PODER INGRESAR TEXTO
                txtDescripcion.ForeColor = Color.Black; //PONER EL COLOR EN NEGRO
            }
        }

        private void txtDescripcion_Leave(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "") //SI CUANDO SE DEJO EL TEXTBOX, ESTE QUEDO EN BLANCO...
            {
                txtDescripcion.Text = "Descripcion"; //VOLVER A PONER EL TEXTO GUIA
                txtDescripcion.ForeColor = Color.Gray; //PONER COLOR EN GRIS
            }
        }

        private void placeholderTextbox()
        {
            if (txtDuracion.Text == "")
            {
                txtDuracion.Text = "Duracion";
                txtDuracion.ForeColor = Color.Gray;
            }
            else txtDuracion.ForeColor = Color.Black;

            if (txtActores.Text == "")
            {
                txtActores.Text = "Actores";
                txtActores.ForeColor = Color.Gray;
            }
            else txtActores.ForeColor = Color.Black;

            if (txtDirectores.Text == "")
            {
                txtDirectores.Text = "Directores";
                txtDirectores.ForeColor = Color.Gray;
            }
            else txtDirectores.ForeColor = Color.Black;

            if (txtDescripcion.Text == "")
            {
                txtDescripcion.Text = "Descripcion";
                txtDescripcion.ForeColor = Color.Gray;
            }
            else txtDescripcion.ForeColor = Color.Black;
        }

        private void txtDuracion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); //ACEPTAR SOLO NUMEROS
        }

        private void modificarPelicula()
        {
            String CodPelicula = dgvPeliculas.CurrentRow.Cells[0].Value.ToString();
            int CurrentIndex = dgvPeliculas.CurrentRow.Index; //GUARDAR EL INDEX DEL REGISTRO SELECCIONADO EN EL DATAGRID
            string consulta; //GUARDAR LA CONSULTA SQL

            consulta = "UPDATE Peliculas SET Nombre_Peli = '" + txtNombre.Text + "', CodGenero_Peli = " + boxGenero.SelectedValue + ", CodClasificacion_Peli = " + boxClasificacion.SelectedValue + ", Estado_Peli = '" + cbEstado.Checked + "'";

            //LAS SIGUIENTES CONDICIONES IF SE BASAN EN QUE SI UN TEXTBOX ESTA VACIO, EN LA CONSULTA EL CAMPO TENDRA UN VALOR = NULL.
            //CASO CONTRARIO EL VALOR SERA IGUAL A LO QUE CONTENGA EL TEXTBOX

            if (txtDuracion.Text != "Duracion") //SI ESTA LLENO
            {
                consulta += ", Duracion_Peli = " + txtDuracion.Text;
            }
            else //SI ESTA VACIO
            {
                consulta += ", Duracion_Peli = NULL";
            }

            if (txtActores.Text != "Actores") //SI ESTA LLENO
            {
                consulta += ", Actores_Peli = '" + txtActores.Text + "'";
            }
            else //SI ESTA VACIO
            {
                consulta += ", Actores_Peli = NULL";
            }

            if (txtDirectores.Text != "Directores") //SI ESTA LLENO
            {
                consulta += ", Director_Peli = '" + txtDirectores.Text + "'";
            }
            else //SI ESTA VACIO
            {
                consulta += ", Director_Peli = NULL";
            }

            if (txtDescripcion.Text != "Descripcion") //SI ESTA LLENO
            {
                consulta += ", Descripcion_Peli = '" + txtDescripcion.Text + "'";
            }
            else //SI ESTA VACIO
            {
                consulta += ", Descripcion_Peli = NULL";
            }

            if (pictureBox1.Image != null) //SI EL PICTURE BOX TIENE UNA IMAGEN CARGADA
            {
                MemoryStream buffer = new MemoryStream(); //BUFFER EN MEMORIA QUE VA A GUARDAR LA IMAGEN
                pictureBox1.Image.Save(buffer, System.Drawing.Imaging.ImageFormat.Jpeg); //PASAR LA IMAGEN AL BUFFER 

                comando = new SqlCommand(consulta + ", Portada_Peli = @imagen WHERE CodPelicula_Peli = " + CodPelicula, BD.getSqlConnection()); //CARGAR CONSULTA
                comando.Parameters.Add("@imagen", System.Data.SqlDbType.Image); //PARAMETRO QUE REFERENCIA LA IMAGEN
                comando.Parameters["@imagen"].Value = buffer.GetBuffer(); //ASIGNAR LA IMAGEN AL PARAMETRO A TRAVES DEL BUFFER
            }
            else //SI EL PICTURE BOX NO TIENE UNA IMAGEN CARGADA
            {
                comando = new SqlCommand(consulta + ", Portada_Peli = NULL WHERE CodPelicula_Peli = " + CodPelicula, BD.getSqlConnection()); //CARGAR CONSULTA
            }

            comando.ExecuteNonQuery(); //EJECUTAR CONSULTA
            ActualizarDgvPeliculas(); //ACTUALIZAR DATAGRID PELICULAS

            seleccionarRegistro(CodPelicula); //SELECCIONAR EL REGISTRO QUE ESTABA SELECCIONADO

            ActualizarContenedores(); //ACTUALIZAR LOS CONTENEDORES
            placeholderTextbox(); //CONTROL POR SI LOS TEXTBOX QUEDARON EN BLANCO. HAY QUE PONER EL TEXTO GUIA
        }

        private void agregarPelicula()
        {
            int NuevoCodigo = Int32.Parse(DTPeliculas.Compute("MAX(CodPelicula_Peli)", "").ToString()) + 1; //OBTENER ULTIMO CODIGO REGISTRADO Y SUMARLE 1
            string consulta; //CONSULTA SQL

            consulta = "INSERT INTO Peliculas(CodPelicula_Peli, Nombre_Peli, CodGenero_Peli, CodClasificacion_Peli, Estado_Peli, Duracion_Peli, Actores_Peli, Director_Peli, Descripcion_Peli, Portada_Peli) VALUES (" + NuevoCodigo + ", '" + txtNombre.Text + "', " + boxGenero.SelectedValue + ", " + boxClasificacion.SelectedValue + ", '" + cbEstado.Checked + "'";

            //LAS SIGUIENTES CONDICIONES IF SE BASAN EN QUE SI UN TEXTBOX ESTA VACIO, EN LA CONSULTA EL CAMPO TENDRA UN VALOR = NULL.
            //CASO CONTRARIO EL VALOR SERA IGUAL A LO QUE CONTENGA EL TEXTBOX

            if (txtDuracion.Text != "Duracion") //SI ESTA LLENO
            {
                consulta += ", " + txtDuracion.Text;
            }
            else //SI ESTA VACIO
            {
                consulta += ", NULL";
            }

            if (txtActores.Text != "Actores") //SI ESTA LLENO
            {
                consulta += ", '" + txtActores.Text + "'";
            }
            else //SI ESTA VACIO
            {
                consulta += ", NULL";
            }

            if (txtDirectores.Text != "Directores") //SI ESTA LLENO
            {
                consulta += ", '" + txtDirectores.Text + "'";
            }
            else //SI ESTA VACIO
            {
                consulta += ", NULL";
            }

            if (txtDescripcion.Text != "Descripcion") //SI ESTA LLENO
            {
                consulta += ", '" + txtDescripcion.Text + "'";
            }
            else //SI ESTA VACIO
            {
                consulta += ", NULL";
            }

            if (pictureBox1.Image != null) //SI EL PICTURE BOX TIENE UNA IMAGEN CARGADA
            {
                MemoryStream buffer = new MemoryStream(); //BUFFER EN MEMORIA QUE VA A GUARDAR LA IMAGEN
                pictureBox1.Image.Save(buffer, System.Drawing.Imaging.ImageFormat.Jpeg); //PASAR LA IMAGEN AL BUFFER 

                comando = new SqlCommand(consulta + ", @imagen)", BD.getSqlConnection()); //CARGAR CONSULTA
                comando.Parameters.Add("@imagen", System.Data.SqlDbType.Image); //PARAMETRO QUE REFERENCIA LA IMAGEN
                comando.Parameters["@imagen"].Value = buffer.GetBuffer(); //ASIGNAR LA IMAGEN AL PARAMETRO A TRAVES DEL BUFFER
            }
            else //SI EL PICTURE BOX NO TIENE UNA IMAGEN CARGADA
            {
                comando = new SqlCommand(consulta + ", NULL)", BD.getSqlConnection()); //CARGAR CONSULTA
            }

            comando.ExecuteNonQuery(); //EJECUTAR CONSULTA
            ActualizarDgvPeliculas(); //ACTUALIZAR DATAGRID PELICULAS

            seleccionarRegistro(NuevoCodigo.ToString()); //SELECCIONAR EL NUEVO REGISTRO

            txtNombre.Clear();
            txtDuracion.Clear();
            txtActores.Clear();
            txtDirectores.Clear();      //LIMPIAR CONTENEDORES
            txtDescripcion.Clear();
            boxGenero.SelectedIndex = 0;
            boxClasificacion.SelectedIndex = 0;
            pictureBox1.Image = null;
            txtNombre.Focus();

            placeholderTextbox(); //CONTROL POR SI LOS TEXTBOX ESTAN EN BLANCO. HAY QUE PONER EL TEXTO GUIA
        }

        private void deshabilitarPeliculasXFormato()
        {
            comando = new SqlCommand("UPDATE PeliculasXFormato SET Estado_PXF = 'False' WHERE CodPelicula_PXF = " + dgvPeliculas.CurrentRow.Cells[0].Value.ToString(), BD.getSqlConnection());
            comando.ExecuteNonQuery();
        }

        private void seleccionarRegistro(String CodPelicula)
        {
            for(int i=0; i<dgvPeliculas.RowCount; i++) //RECORRER TODO EL DATAGRID DE PELICULAS
            {
                if(dgvPeliculas.Rows[i].Cells[0].Value.ToString() == CodPelicula) //SI EL CODIGO DE LA FILA COINCIDE CON EL CODIGO BUSCADO
                {
                    dgvPeliculas.CurrentCell = dgvPeliculas.Rows[i].Cells[1]; //SELECCIONAR EL REGISTRO
                    dgvPeliculas.Rows[i].Selected = true; //SELECCIONAR EL REGISTRO
                }
            }
        }
    }
}
    

