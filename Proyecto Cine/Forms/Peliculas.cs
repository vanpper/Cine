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

            if (BD.Abrir()) //SI LA CONEXION CON LA BASE DE DATOS SE PUEDE ABRIR...
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
            adaptador = new SqlDataAdapter("SELECT * FROM Clasificaciones", BD.conectarBD); //TRAER TODAS LAS CLASIFICACIONES
            DTClasificaciones.Clear(); //LIMPIAR EL DATATABLE DE VIEJOS REGISTROS
            adaptador.Fill(DTClasificaciones); //LLENAR EL DATATABLE CON LOS NUEVOS REGISTROS

            boxClasificacion.DisplayMember = "Descripcion_Clas"; //LO QUE SE VERA SERA LA DESCRIPCION DE CADA CLASIFICACION
            boxClasificacion.ValueMember = "CodClasificacion_Clas"; //CADA MIEMBRO TENDRA COMO VALOR EL CODIGO DE CLASIFICACION CORRESPONDIENTE
        }

        private void ActualizarBoxGeneros()
        {
            adaptador = new SqlDataAdapter("SELECT * FROM Generos", BD.conectarBD); //TRAER TODOS LOS GENEROS
            DTGeneros.Clear(); //LIMPIAR EL DATATABLE DE VIEJOS REGISTROS
            adaptador.Fill(DTGeneros);  //LLENAR EL DATATABLE CON LOS NUEVOS REGISTROS

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
            
            for(int i = 0; i < dgvPeliculas.ColumnCount; i++)
            {
                dgvPeliculas.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void ActualizarDgvPeliculas()
        {
            adaptador = new SqlDataAdapter("SELECT CodPelicula_Peli, Nombre_Peli, Duracion_Peli, Actores_Peli, Director_Peli, CodGenero_Peli, Descripcion_Gene, CodClasificacion_Peli, Descripcion_Clas, Descripcion_Peli, Portada_Peli, Estado_Peli FROM Peliculas INNER JOIN Generos ON CodGenero_Peli = CodGenero_Gene INNER JOIN Clasificaciones ON CodClasificacion_Clas = CodClasificacion_Peli", BD.conectarBD); //TRAER TODAS LAS PELICULAS
            DTPeliculas.Clear(); //LIMPIAR EL DATATBLE DE VIEJOS REGISTROS
            adaptador.Fill(DTPeliculas); //LLENAR EL DATATABLE CON LOS NUEVOS REGISTROS
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            try 
            {
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

            txtNombre.Focus();
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

            txtNombre.ReadOnly = false;
            txtDuracion.ReadOnly = false;
            txtActores.ReadOnly = false;        //HABILITAR LOS CONTENEDORES PARA EL INGRESO DE DATOS
            txtDirectores.ReadOnly = false;
            txtDescripcion.ReadOnly = false;

            btnAgregarImagen.Visible = true;
            btnBorrarImagen.Visible = true;
            btnVolver.Visible = true;           //OCULTAR BOTONES QUE NO SE UTILIZARAN PARA DICHA OPERACION
            btnGuardar.Visible = true;          //MOSTRAR BOTONES QUE SE UTILIZARAN PARA DICHA OPERACION
            btnNuevo.Visible = false;
            btnModificar.Visible = false;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(OperacionActual == MODIFICAR) //SI SE ESTA MODIFICANDO
            {
                if(txtNombre.TextLength != 0) //SI EL TEXTBOX NOMBRE TIENE ALGO ESCRITO 
                {
                    int CurrentIndex = dgvPeliculas.CurrentRow.Index; //GUARDAR EL INDEX DEL REGISTRO SELECIONADO EN EL DATAGRID
                    string consulta; //GUARDAR LA CONSULTA SQL

                    consulta = "UPDATE Peliculas SET Nombre_Peli = '" + txtNombre.Text + "', CodGenero_Peli = " + boxGenero.SelectedValue + ", CodClasificacion_Peli = " + boxClasificacion.SelectedValue + ", Estado_Peli = '" + cbEstado.Checked + "'";

                    //LAS SIGUIENTES CONDICIONES IF SE BASAN EN QUE SI UN TEXTBOX ESTA VACIO, EN LA CONSULTA EL CAMPO TENDRA UN VALOR = NULL.
                    //CASO CONTRARIO EL VALOR SERA IGUAL A LO QUE CONTENGA EL TEXTBOX

                    if (txtDuracion.TextLength != 0)
                    {
                        consulta += ", Duracion_Peli = " + txtDuracion.Text;
                    }
                    else
                    {
                        consulta += ", Duracion_Peli = NULL";
                    }

                    if(txtActores.TextLength != 0)
                    {
                        consulta += ", Actores_Peli = '" + txtActores.Text + "'";
                    }
                    else
                    {
                        consulta += ", Actores_Peli = NULL";
                    }

                    if(txtDirectores.TextLength != 0)
                    {
                        consulta += ", Director_Peli = '" + txtDirectores.Text + "'";
                    }
                    else
                    {
                        consulta += ", Director_Peli = NULL";
                    }

                    if(txtDescripcion.TextLength != 0)
                    {
                        consulta += ", Descripcion_Peli = '" + txtDescripcion.Text + "'";
                    }
                    else
                    {
                        consulta += ", Descripcion_Peli = NULL";
                    }

                    if (pictureBox1.Image != null) //SI EL PICTURE BOX TIENE UNA IMAGEN CARGADA
                    {
                        MemoryStream buffer = new MemoryStream(); //BUFFER EN MEMORIA QUE VA A GUARDAR LA IMAGEN
                        pictureBox1.Image.Save(buffer, System.Drawing.Imaging.ImageFormat.Jpeg); //PASAR LA IMAGEN AL BUFFER 

                        comando = new SqlCommand(consulta + ", Portada_Peli = @imagen WHERE CodPelicula_Peli = " + dgvPeliculas.CurrentRow.Cells[0].Value, BD.conectarBD); //CARGAR CONSULTA
                        comando.Parameters.Add("@imagen", System.Data.SqlDbType.Image); //PARAMETRO QUE REFERENCIA LA IMAGEN
                        comando.Parameters["@imagen"].Value = buffer.GetBuffer(); //ASIGNAR LA IMAGEN AL PARAMETRO A TRAVES DEL BUFFER
                    }
                    else //SI EL PICTURE BOX NO TIENE UNA IMAGEN CARGADA
                    {
                        comando = new SqlCommand(consulta + ", Portada_Peli = NULL WHERE CodPelicula_Peli = " + dgvPeliculas.CurrentRow.Cells[0].Value, BD.conectarBD); //CARGAR CONSULTA
                    }

                    comando.ExecuteNonQuery(); //EJECUTAR CONSULTA
                    ActualizarDgvPeliculas(); //ACTUALIZAR DATAGRID PELICULAS

                    dgvPeliculas.CurrentCell = dgvPeliculas.Rows[CurrentIndex].Cells[1]; //SELECCIONAR EL REGISTRO QUE ESTABA SELECCIONADO
                    dgvPeliculas.Rows[CurrentIndex].Selected = true; //SELECCIONAR EL REGISTRO QUE ESTABA SELECCIONADO

                    ActualizarContenedores(); //ACTUALIZAR LOS CONTENEDORES
                }
            }

            if(OperacionActual == NUEVO)
            {
                if(txtNombre.TextLength != 0)
                {
                    int NuevoCodigo = Int32.Parse(DTPeliculas.Compute("MAX(CodPelicula_Peli)", "").ToString()) + 1; //OBTENER ULTIMO CODIGO REGISTRADO Y SUMARLE 1
                    string consulta; //CONSULTA SQL

                    consulta = "INSERT INTO Peliculas(CodPelicula_Peli, Nombre_Peli, CodGenero_Peli, CodClasificacion_Peli, Estado_Peli, Duracion_Peli, Actores_Peli, Director_Peli, Descripcion_Peli, Portada_Peli) VALUES (" + NuevoCodigo + ", '" + txtNombre.Text + "', " + boxGenero.SelectedValue + ", " + boxClasificacion.SelectedValue + ", '" + cbEstado.Checked + "'";

                    //LAS SIGUIENTES CONDICIONES IF SE BASAN EN QUE SI UN TEXTBOX ESTA VACIO, EN LA CONSULTA EL CAMPO TENDRA UN VALOR = NULL.
                    //CASO CONTRARIO EL VALOR SERA IGUAL A LO QUE CONTENGA EL TEXTBOX

                    if (txtDuracion.TextLength != 0)
                    {
                        consulta += ", " + txtDuracion.Text;
                    }
                    else
                    {
                        consulta += ", NULL";
                    }

                    if (txtActores.TextLength != 0)
                    {
                        consulta += ", '" + txtActores.Text + "'";
                    }
                    else
                    {
                        consulta += ", NULL";
                    }

                    if (txtDirectores.TextLength != 0)
                    {
                        consulta += ", '" + txtDirectores.Text + "'";
                    }
                    else
                    {
                        consulta += ", NULL";
                    }

                    if (txtDescripcion.TextLength != 0)
                    {
                        consulta += ", '" + txtDescripcion.Text + "'";
                    }
                    else
                    {
                        consulta += ", NULL";
                    }

                    if (pictureBox1.Image != null) //SI EL PICTURE BOX TIENE UNA IMAGEN CARGADA
                    {
                        MemoryStream buffer = new MemoryStream(); //BUFFER EN MEMORIA QUE VA A GUARDAR LA IMAGEN
                        pictureBox1.Image.Save(buffer, System.Drawing.Imaging.ImageFormat.Jpeg); //PASAR LA IMAGEN AL BUFFER 

                        comando = new SqlCommand(consulta + ", @imagen)", BD.conectarBD); //CARGAR CONSULTA
                        comando.Parameters.Add("@imagen", System.Data.SqlDbType.Image); //PARAMETRO QUE REFERENCIA LA IMAGEN
                        comando.Parameters["@imagen"].Value = buffer.GetBuffer(); //ASIGNAR LA IMAGEN AL PARAMETRO A TRAVES DEL BUFFER
                    }
                    else //SI EL PICTURE BOX NO TIENE UNA IMAGEN CARGADA
                    {
                        comando = new SqlCommand(consulta + ", NULL)", BD.conectarBD); //CARGAR CONSULTA
                    }

                    comando.ExecuteNonQuery(); //EJECUTAR CONSULTA
                    ActualizarDgvPeliculas(); //ACTUALIZAR DATAGRID PELICULAS

                    dgvPeliculas.CurrentCell = dgvPeliculas.Rows[dgvPeliculas.RowCount - 1].Cells[1]; //SELECCIONAR EL NUEVO REGISTRO
                    dgvPeliculas.Rows[dgvPeliculas.RowCount - 1].Selected = true; //SELECCIONAR EL NUEVO REGISTRO

                    txtNombre.Clear();
                    txtDuracion.Clear();
                    txtActores.Clear();
                    txtDirectores.Clear();      //LIMPIAR CONTENEDORES
                    txtDescripcion.Clear();
                    boxGenero.SelectedIndex = 0;
                    boxClasificacion.SelectedIndex = 0;
                    pictureBox1.Image = null;
                    txtNombre.Focus();
                }
            }
        }

        private void btnBorrarImagen_Click(object sender, EventArgs e)
        {
            if(pictureBox1.Image != null) //SI EL PICTURE BOX TIENE UNA IMAGEN CARGADA
            {
                pictureBox1.Image = null; //LIMPIAR
            }
        }
    }
}
    

