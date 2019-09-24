using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Cine.Forms
{
    public partial class Funciones : Form
    {
        const int NULL = 0;
        const int NUEVO = 1;            //CONSTANTES
        const int MODIFICAR = 2;

        Conexion BD = new Conexion();
        SqlDataAdapter adaptador;
        SqlCommand comando;
        SqlDataReader reader;

        DataTable DTCines = new DataTable();
        DataTable DTSalas = new DataTable();
        DataTable DTPeliculas = new DataTable();        //DATATABLES DEL "PANEL1", BUSQUEDA
        DataTable DTFormatos = new DataTable();
        DataTable DTFunciones = new DataTable();
        
        DataTable DTCines2 = new DataTable();
        DataTable DTSalas2 = new DataTable();           //DATATABLES DEL "PANEL2" DE "NUEVO" O "MODIFICAR"
        DataTable DTPeliculas2 = new DataTable();
        DataTable DTFormatos2 = new DataTable();

        int OperacionActual = 0; //VARIABLE QUE GUARDA LA OPERACION ACTUAL

        public Funciones()
        {
            InitializeComponent();

            boxCines.DataSource = DTCines; //LA FUENTE DE DATOS DEL BOX CINES DEL PANEL1, SERA EL DATATABLE CINES
            boxSalas.DataSource = DTSalas; //LA FUENTE DE DATOS DEL BOX SALAS DEL PANEL1, SERA EL DATATABLE SALAS
            boxPeliculas.DataSource = DTPeliculas; //LA FUENTE DE DATOS DEL BOX PELICULAS DEL PANEL1, SERA EL DATATABLE PELICULAS
            boxFormatos.DataSource = DTFormatos; //LA FUENTE DE DATOS DEL BOX FORMATOS DEL PANEL1, SERA EL DATATABLE FORMATOS
            dgvFunciones.DataSource = DTFunciones; //LA FUENTE DE DATOS DEL DATAGRID FUNCIONES SERA EL DATATABLE FUNCIONES

            PboxCines.DataSource = DTCines2; //LA FUENTE DE DATOS DEL BOX CINES DEL PANEL2, SERA EL DATATABLE CINES 2
            PboxSalas.DataSource = DTSalas2; //LA FUENTE DE DATOS DEL BOX SALAS DEL PANEL2, SERA EL DATATABLE SALAS 2
            PboxPeliculas.DataSource = DTPeliculas2; //LA FUENTE DE DATOS DEL BOX PELICULAS DEL PANEL2, SERA EL DATATABLE PELICULAS 2
            PboxFormatos.DataSource = DTFormatos2; //LA FUENTE DE DATOS DEL BOX FORMATOS DEL PANEL2, SERA EL DATATABLE FORMATOS 2

            if (BD.Abrir()) //SI LA CONEXION CON LA BASE DE DATOS SE PUEDE ABRIR...
            {
                ActualizarBoxsCines(); //ACTUALIZA EL BOX CINES DE AMBOS PANELES
                ActualizarBoxSalasBusqueda(); //ACTUALIZA EL BOX SALAS DEL PANEL 1
                ActualizarBoxSalasPanel(); //ACTUALIZA EL BOX SALAS DEL PANEL 2
                ActualizarBoxsPeliculas(); //ACTUALIZA EL BOX PELICULAS DE AMBOS PANELES
                ActualizarBoxFormatosBusqueda(); //ACTUALIZA EL BOX FORMATOS DEL PANEL 1
                ActualizarBoxFormatoPanel(); //ACTUALIZA EL BOX FORMATOS DEL PANEL 2
                ActualizarDgvFunciones(); //ACTUALIZA EL DATAGRIDVIEW DE FUNCIONES
            }

            ConfigurarGrid(); //CONFIGURACION RELACIONADA CON LA APARIENCIA DEL DATAGRID
            
        }

        private void AbrirPanel()
        {
            dgvFunciones.Height = 253; //ACHICAR DATAGRID
            panel2.Visible = true; //HACER VISIBLE EL PANEL
            btnNuevo.Visible = false; //OCULTAR BOTON "NUEVO"
            btnModificar.Visible = false; //OCULTAR BOTON "MODIFICAR"
        }

        private void CerrarPanel()
        {
            OperacionActual = NULL; //SETEAR OPERACION ACTUAL COMO NULO
            panel2.Visible = false; //OCULTAR PANEL
            dgvFunciones.Height = 348; //AGRANDAR DATAGRID
            btnNuevo.Visible = true; //MOSTRAR BOTON "NUEVO"
            btnModificar.Visible = true; //MOSTRAR BOTON "MODIFICAR"
        }

        private void FiltarDatos()
        {
            //TODAS LAS COMBINACIONES POSIBLES DE LOS CHECKBOXS DEL PANEL SUPERIOR DE BUSQUEDA

            if (cbCine.Checked && cbSala.Checked && cbFecha.Checked && cbPelicula.Checked && cbFormato.Checked) { DTFunciones.DefaultView.RowFilter = "CodCine_Func = " + boxCines.SelectedValue + " AND CodSala_Func = " + boxSalas.SelectedValue + " AND Dia_Func = '" + dtpFecha.Text + "' AND CodPelicula_Func = " + boxPeliculas.SelectedValue + " AND CodFormato_Func = " + boxFormatos.SelectedValue; }
            if (cbCine.Checked && cbSala.Checked && cbFecha.Checked && cbPelicula.Checked && !cbFormato.Checked) { DTFunciones.DefaultView.RowFilter = "CodCine_Func = " + boxCines.SelectedValue + " AND CodSala_Func = " + boxSalas.SelectedValue + " AND Dia_Func = '" + dtpFecha.Text + "' AND CodPelicula_Func = " + boxPeliculas.SelectedValue; }
            if (cbCine.Checked && cbSala.Checked && cbFecha.Checked && !cbPelicula.Checked && cbFormato.Checked) { DTFunciones.DefaultView.RowFilter = "CodCine_Func = " + boxCines.SelectedValue + " AND CodSala_Func = " + boxSalas.SelectedValue + " AND Dia_Func = '" + dtpFecha.Text + " AND CodFormato_Func = " + boxFormatos.SelectedValue; }
            if (cbCine.Checked && cbSala.Checked && cbFecha.Checked && !cbPelicula.Checked && !cbFormato.Checked) { DTFunciones.DefaultView.RowFilter = "CodCine_Func = " + boxCines.SelectedValue + " AND CodSala_Func = " + boxSalas.SelectedValue + " AND Dia_Func = '" + dtpFecha.Text + "'"; }
            if (cbCine.Checked && cbSala.Checked && !cbFecha.Checked && cbPelicula.Checked && cbFormato.Checked) { DTFunciones.DefaultView.RowFilter = "CodCine_Func = " + boxCines.SelectedValue + " AND CodSala_Func = " + boxSalas.SelectedValue + " AND CodPelicula_Func = " + boxPeliculas.SelectedValue + " AND CodFormato_Func = " + boxFormatos.SelectedValue; }
            if (cbCine.Checked && cbSala.Checked && !cbFecha.Checked && cbPelicula.Checked && !cbFormato.Checked) { DTFunciones.DefaultView.RowFilter = "CodCine_Func = " + boxCines.SelectedValue + " AND CodSala_Func = " + boxSalas.SelectedValue + " AND CodPelicula_Func = " + boxPeliculas.SelectedValue; }
            if (cbCine.Checked && cbSala.Checked && !cbFecha.Checked && !cbPelicula.Checked && cbFormato.Checked) { DTFunciones.DefaultView.RowFilter = "CodCine_Func = " + boxCines.SelectedValue + " AND CodSala_Func = " + boxSalas.SelectedValue + " AND CodFormato_Func = " + boxFormatos.SelectedValue; }
            if (cbCine.Checked && cbSala.Checked && !cbFecha.Checked && !cbPelicula.Checked && !cbFormato.Checked) { DTFunciones.DefaultView.RowFilter = "CodCine_Func = " + boxCines.SelectedValue + " AND CodSala_Func = " + boxSalas.SelectedValue; }
            if (cbCine.Checked && !cbSala.Checked && cbFecha.Checked && cbPelicula.Checked && cbFormato.Checked) { DTFunciones.DefaultView.RowFilter = "CodCine_Func = " + boxCines.SelectedValue + " AND Dia_Func = '" + dtpFecha.Text + "' AND CodPelicula_Func = " + boxPeliculas.SelectedValue + " AND CodFormato_Func = " + boxFormatos.SelectedValue; }
            if (cbCine.Checked && !cbSala.Checked && cbFecha.Checked && cbPelicula.Checked && !cbFormato.Checked) { DTFunciones.DefaultView.RowFilter = "CodCine_Func = " + boxCines.SelectedValue + " AND Dia_Func = '" + dtpFecha.Text + "' AND CodPelicula_Func = " + boxPeliculas.SelectedValue; }
            if (cbCine.Checked && !cbSala.Checked && cbFecha.Checked && !cbPelicula.Checked && cbFormato.Checked) { DTFunciones.DefaultView.RowFilter = "CodCine_Func = " + boxCines.SelectedValue + " AND Dia_Func = '" + dtpFecha.Text + "' AND CodFormato_Func = " + boxFormatos.SelectedValue; }
            if (cbCine.Checked && !cbSala.Checked && cbFecha.Checked && !cbPelicula.Checked && !cbFormato.Checked) { DTFunciones.DefaultView.RowFilter = "CodCine_Func = " + boxCines.SelectedValue + " AND Dia_Func = '" + dtpFecha.Text + "'"; }
            if (cbCine.Checked && !cbSala.Checked && !cbFecha.Checked && cbPelicula.Checked && cbFormato.Checked) { DTFunciones.DefaultView.RowFilter = "CodCine_Func = " + boxCines.SelectedValue + " AND CodPelicula_Func = " + boxPeliculas.SelectedValue + " AND CodFormato_Func = " + boxFormatos.SelectedValue; }
            if (cbCine.Checked && !cbSala.Checked && !cbFecha.Checked && cbPelicula.Checked && !cbFormato.Checked) { DTFunciones.DefaultView.RowFilter = "CodCine_Func = " + boxCines.SelectedValue + " AND CodPelicula_Func = " + boxPeliculas.SelectedValue; }
            if (cbCine.Checked && !cbSala.Checked && !cbFecha.Checked && !cbPelicula.Checked && cbFormato.Checked) { DTFunciones.DefaultView.RowFilter = "CodCine_Func = " + boxCines.SelectedValue + " AND CodFormato_Func = " + boxFormatos.SelectedValue; }
            if (cbCine.Checked && !cbSala.Checked && !cbFecha.Checked && !cbPelicula.Checked && !cbFormato.Checked) { DTFunciones.DefaultView.RowFilter = "CodCine_Func = " + boxCines.SelectedValue; }

            if (!cbCine.Checked && cbSala.Checked && cbFecha.Checked && cbPelicula.Checked && cbFormato.Checked) { DTFunciones.DefaultView.RowFilter = "CodSala_Func = " + boxSalas.SelectedValue + " AND Dia_Func = '" + dtpFecha.Text + "' AND CodPelicula_Func = " + boxPeliculas.SelectedValue + " AND CodFormato_Func = " + boxFormatos.SelectedValue; }
            if (!cbCine.Checked && cbSala.Checked && cbFecha.Checked && cbPelicula.Checked && !cbFormato.Checked) { DTFunciones.DefaultView.RowFilter = "CodSala_Func = " + boxSalas.SelectedValue + " AND Dia_Func = '" + dtpFecha.Text + "' AND CodPelicula_Func = " + boxPeliculas.SelectedValue; }
            if (!cbCine.Checked && cbSala.Checked && cbFecha.Checked && !cbPelicula.Checked && cbFormato.Checked) { DTFunciones.DefaultView.RowFilter = "CodSala_Func = " + boxSalas.SelectedValue + " AND Dia_Func = '" + dtpFecha.Text + " AND CodFormato_Func = " + boxFormatos.SelectedValue; }
            if (!cbCine.Checked && cbSala.Checked && cbFecha.Checked && !cbPelicula.Checked && !cbFormato.Checked) { DTFunciones.DefaultView.RowFilter = "CodSala_Func = " + boxSalas.SelectedValue + " AND Dia_Func = '" + dtpFecha.Text + "'"; }
            if (!cbCine.Checked && cbSala.Checked && !cbFecha.Checked && cbPelicula.Checked && cbFormato.Checked) { DTFunciones.DefaultView.RowFilter = "CodSala_Func = " + boxSalas.SelectedValue + " AND CodPelicula_Func = " + boxPeliculas.SelectedValue + " AND CodFormato_Func = " + boxFormatos.SelectedValue; }
            if (!cbCine.Checked && cbSala.Checked && !cbFecha.Checked && cbPelicula.Checked && !cbFormato.Checked) { DTFunciones.DefaultView.RowFilter = "CodSala_Func = " + boxSalas.SelectedValue + " AND CodPelicula_Func = " + boxPeliculas.SelectedValue; }
            if (!cbCine.Checked && cbSala.Checked && !cbFecha.Checked && !cbPelicula.Checked && cbFormato.Checked) { DTFunciones.DefaultView.RowFilter = "CodSala_Func = " + boxSalas.SelectedValue + " AND CodFormato_Func = " + boxFormatos.SelectedValue; }
            if (!cbCine.Checked && cbSala.Checked && !cbFecha.Checked && !cbPelicula.Checked && !cbFormato.Checked) { DTFunciones.DefaultView.RowFilter = "CodSala_Func = " + boxSalas.SelectedValue; }
            if (!cbCine.Checked && !cbSala.Checked && cbFecha.Checked && cbPelicula.Checked && cbFormato.Checked) { DTFunciones.DefaultView.RowFilter = "Dia_Func = '" + dtpFecha.Text + "' AND CodPelicula_Func = " + boxPeliculas.SelectedValue + " AND CodFormato_Func = " + boxFormatos.SelectedValue; }
            if (!cbCine.Checked && !cbSala.Checked && cbFecha.Checked && cbPelicula.Checked && !cbFormato.Checked) { DTFunciones.DefaultView.RowFilter = "Dia_Func = '" + dtpFecha.Text + "' AND CodPelicula_Func = " + boxPeliculas.SelectedValue; }
            if (!cbCine.Checked && !cbSala.Checked && cbFecha.Checked && !cbPelicula.Checked && cbFormato.Checked) { DTFunciones.DefaultView.RowFilter = "Dia_Func = '" + dtpFecha.Text + "' AND CodFormato_Func = " + boxFormatos.SelectedValue; }
            if (!cbCine.Checked && !cbSala.Checked && cbFecha.Checked && !cbPelicula.Checked && !cbFormato.Checked) { DTFunciones.DefaultView.RowFilter = "Dia_Func = '" + dtpFecha.Text + "'"; }
            if (!cbCine.Checked && !cbSala.Checked && !cbFecha.Checked && cbPelicula.Checked && cbFormato.Checked) { DTFunciones.DefaultView.RowFilter = "CodPelicula_Func = " + boxPeliculas.SelectedValue + " AND CodFormato_Func = " + boxFormatos.SelectedValue; }
            if (!cbCine.Checked && !cbSala.Checked && !cbFecha.Checked && cbPelicula.Checked && !cbFormato.Checked) { DTFunciones.DefaultView.RowFilter = "CodPelicula_Func = " + boxPeliculas.SelectedValue; }
            if (!cbCine.Checked && !cbSala.Checked && !cbFecha.Checked && !cbPelicula.Checked && cbFormato.Checked) { DTFunciones.DefaultView.RowFilter = "CodFormato_Func = " + boxFormatos.SelectedValue; }
            if (!cbCine.Checked && !cbSala.Checked && !cbFecha.Checked && !cbPelicula.Checked && !cbFormato.Checked) { DTFunciones.DefaultView.RowFilter = null; }
        }

        private void ConfigurarGrid()
        {
            dgvFunciones.Height = 348;

            dgvFunciones.Columns[0].HeaderText = "Codigo Cine";
            dgvFunciones.Columns[1].HeaderText = "Cine";
            dgvFunciones.Columns[2].HeaderText = "Codigo Sala";
            dgvFunciones.Columns[3].HeaderText = "Sala";
            dgvFunciones.Columns[4].HeaderText = "Dia";
            dgvFunciones.Columns[5].HeaderText = "Horario";
            dgvFunciones.Columns[6].HeaderText = "Codigo Pelicula";
            dgvFunciones.Columns[7].HeaderText = "Pelicula";
            dgvFunciones.Columns[8].HeaderText = "Codigo Formato";
            dgvFunciones.Columns[9].HeaderText = "Formato";
            dgvFunciones.Columns[10].HeaderText = "Stock";
            dgvFunciones.Columns[11].HeaderText = "Estado";


            dgvFunciones.Columns[0].Visible = false;
            dgvFunciones.Columns[2].Visible = false;
            dgvFunciones.Columns[6].Visible = false;
            dgvFunciones.Columns[8].Visible = false;

            dgvFunciones.ReadOnly = true;
            dgvFunciones.AllowUserToAddRows = false;
            dgvFunciones.RowHeadersVisible = false;
            dgvFunciones.AllowUserToResizeColumns = false;
            dgvFunciones.AllowUserToResizeRows = false;
            dgvFunciones.MultiSelect = false;
            dgvFunciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFunciones.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFunciones.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFunciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFunciones.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvFunciones.Sort(dgvFunciones.Columns[1], ListSortDirection.Ascending);

        }

        private void ActualizarDgvFunciones()
        {
            adaptador = new SqlDataAdapter("SELECT CodCine_Func, Nombre_Cine, CodSala_Func, Descripcion_SXC, Dia_Func, Horario_Func, CodPelicula_Func, Nombre_Peli, CodFormato_Func, Descripcion_Form, Stock_Func, Estado_Func from funciones inner join Cines on CodCine_Func = CodCine_Cine inner join SalasXCine on CodCine_Func = CodCine_SXC and CodSala_Func = CodSala_SXC inner join Peliculas on CodPelicula_Func = CodPelicula_Peli inner join Formatos on CodFormato_Func = CodFormato_Form", BD.conectarBD); //TRAER TODAS LAS FUNCIONES
            DTFunciones.Clear(); //LIMPIAR EL DATATABLE DE VIEJOS REGISTROS
            adaptador.Fill(DTFunciones); //LLENAR EL DATATABLE CON LOS NUEVOS REGISTROS
        }

        private void ActualizarBoxFormatosBusqueda()
        {
            adaptador = new SqlDataAdapter("SELECT * FROM Formatos", BD.conectarBD); //TRAER TODOS LOS FORMATOS
            DTFormatos.Clear(); //LIMPIAR EL DATATABLE DE VIEJOS REGISTROS
            adaptador.Fill(DTFormatos); //LLENAR EL DATATABLE CON LOS NUEVOS REGISTROS

            DTFormatos.DefaultView.Sort = "Descripcion_Form"; //ORDENAR ALFABETICAMENTE

            boxFormatos.DisplayMember = "Descripcion_Form"; //EN EL BOX SE VERAN LAS DESCRIPCIONES DE LOS FORMATOS
            boxFormatos.ValueMember = "CodFormato_Form"; //CADA ITEM TENDRA COMO VALOR EL CODIGO FORMATO
        }

        private void ActualizarBoxFormatoPanel()
        {
            adaptador = new SqlDataAdapter("SELECT CodFormato_PXF, Descripcion_Form FROM PeliculasXFormato INNER JOIN Formatos ON CodFormato_PXF = CodFormato_Form WHERE CodPelicula_PXF = " + PboxPeliculas.SelectedValue + " AND Estado_PXF = 'True'", BD.conectarBD); //TRAER SOLAMENTE LOS FORMATOS QUE POSEA LA PELICULA SELECCIONADA EN EL PANEL 2. Y SI ESTA ESTA HABILITADA.
            DTFormatos2.Clear(); //LIMPIAR EL DATATABLE DE VIEJOS REGISTROS
            adaptador.Fill(DTFormatos2); //LLENAR EL DATATABLE CON LOS NUEVOS REGISTROS

            DTFormatos2.DefaultView.Sort = "Descripcion_Form"; //ORDENAR ALFABETICAMENTE

            PboxFormatos.DisplayMember = "Descripcion_Form"; //EN EL BOX SE VERAN LAS DESCRIPCIONES DE LOS FORMATOS
            PboxFormatos.ValueMember = "CodFormato_PXF"; //CADA ITEMA TENDRA COMO VALOR EL CODIGO FORMATO
        }

        private void ActualizarBoxsPeliculas()
        {
            adaptador = new SqlDataAdapter("SELECT CodPelicula_Peli, Nombre_Peli FROM Peliculas", BD.conectarBD); //TRAER TODAS LAS PELICULAS

            //PARA EL BOX PELICULAS DEL PANEL SUPERIOR
            DTPeliculas.Clear(); //LIMPIAR EL DATATBLE DE VIEJOS REGISTROS
            adaptador.Fill(DTPeliculas); //LLENAR EL DATATABLE CON LOS NUEVOS REGISTROS
            DTPeliculas.DefaultView.Sort = "Nombre_Peli"; //ORDENAR ALFABETICAMENTE
            boxPeliculas.DisplayMember = "Nombre_Peli"; //EN EL BOX SE VERAN LOS NOMBRES DE LAS PELICULAS
            boxPeliculas.ValueMember = "CodPelicula_Peli"; //CADA ITEM TENDRA COMO VALOR EL CODIGO PELICULA

            //PARA EL BOX PELICULAS DEL PANEL INFERIOR
            DTPeliculas2.Clear(); //LIMPIAR EL DATATABLE DE VIEJOS REGISTROS
            adaptador.Fill(DTPeliculas2); //LLENAR EL DATATABLE CON LOS NUEVOS REGISTROS
            DTPeliculas2.DefaultView.Sort = "Nombre_Peli"; //ORDENAR ALFABETICAMENTE
            PboxPeliculas.DisplayMember = "Nombre_Peli"; //EN EL BOX SE VERAN LOS NOMBRES DE LAS PELICULAS
            PboxPeliculas.ValueMember = "CodPelicula_Peli"; //CADA ITEM TENDRA COMO VALOR EL CODIGO PELICULA
        }

        private void ActualizarBoxSalasBusqueda()
        {
            adaptador = new SqlDataAdapter("SELECT CodSala_SXC, Descripcion_SXC FROM SalasXCine WHERE CodCine_SXC = " + boxCines.SelectedValue, BD.conectarBD); //TRAER TODAS LAS SALAS DEL CINE SELECCIONADO EN EL PANEL SUPERIOR

            DTSalas.Clear(); //LIMPIAR EL DATATABLE DE VIEJOS REGISTROS
            adaptador.Fill(DTSalas); //LLENAR EL DATATABLE CON LOS NUEVOS REGISTROS
            DTSalas.DefaultView.Sort = "Descripcion_SXC"; //ORDENAR ALFABETICAMENTE
            boxSalas.DisplayMember = "Descripcion_SXC"; //EN EL BOX SE VERAN LOS NOMBRES DE LAS SALAS
            boxSalas.ValueMember = "CodSala_SXC"; //CADA ITEM TENDRA COMO VALOR EL CODIGO SALA
        }

        private void ActualizarBoxSalasPanel()
        {
            adaptador = new SqlDataAdapter("SELECT CodSala_SXC, Descripcion_SXC FROM SalasXCine WHERE CodCine_SXC = " + PboxCines.SelectedValue, BD.conectarBD); //TRAER TODAS LAS SALAS DEL CINE SELECCIONADO EN EL PANEL INFERIOR

            DTSalas2.Clear(); //LIMPIAR EL DATATABLE DE VIEJOS REGISTROS
            adaptador.Fill(DTSalas2); //LLENAR EL DATATABLE CON LOS NUEVOS REGISTROS
            DTSalas2.DefaultView.Sort = "Descripcion_SXC"; //ORDENAR ALFABETICAMENTE
            PboxSalas.DisplayMember = "Descripcion_SXC"; //EN EL BOX SE VERNA LOS NOMBRES DE LAS SALAS
            PboxSalas.ValueMember = "CodSala_SXC"; //CADA ITEM TENDRA COMO VALOR EL CODIGO SALA
        }

        private void ActualizarBoxsCines()
        {
            adaptador = new SqlDataAdapter("SELECT CodCine_Cine, Nombre_Cine FROM Cines", BD.conectarBD); //TRAER TODOS LOS CINES

            //PARA EL BOX CINES DEL PANEL SUPERIOR
            DTCines.Clear(); //LIMPIAR EL DATATABLE DE VIEJOS REGISTROS
            adaptador.Fill(DTCines); //LLENAR EL DATATABLE CON LOS NUEVOS REGISTROS
            DTCines.DefaultView.Sort = "Nombre_Cine"; //ORDENAR ALFABETICAMENTE
            boxCines.DisplayMember = "Nombre_Cine"; //EN EL BOX SE VERAN LOS NOMBRES DE LOS CINES
            boxCines.ValueMember = "CodCine_Cine"; //CADA ITEM TENDRA COMO VALOR EL CODIGO CINE

            //PARA EL BOX CINES DEL PANEL INFERIOR
            DTCines2.Clear(); //LIMPIAR EL DATATABLE DE VIEJOS REGISTROS
            adaptador.Fill(DTCines2); //LLENAR EL DATATABLE CON LOS NUEVOS REGISTROS
            DTCines2.DefaultView.Sort = "Nombre_Cine"; //ORDENAR ALFABETICAMENTE
            PboxCines.DisplayMember = "Nombre_Cine"; //EN EL BOX SE VERAN LOS NOMBRES DE LOS CINES
            PboxCines.ValueMember = "CodCine_Cine"; //CADA ITEM TENDRA COMO VALOR EL CODIGO CINE
        }

        private void boxCines_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarBoxSalasBusqueda(); //ACTUALIZAR EL BOX SALAS DEL PANEL SUPERIOR

            if (cbCine.Checked) //SI EL CHECKBOX DEL BOX CINE ESTA HABILITADO, AL CAMBIAR EL INDEX, TAMBIEN...
            {
                FiltarDatos(); //FILTRAR LOS DATOS EN EL DATAGRID DE ACUERDO A LOS CHECKBOXS SELECCIONADOS

                if(OperacionActual == MODIFICAR && dgvFunciones.RowCount == 0) //SI EL PANEL INFERIOR ESTA ABIERTO Y EL RESULTADO DE LA BUSQUEDA NO ARROJA ALGUN RESULTADO...
                {
                    CerrarPanel(); //CERRAR EL PANEL DE MODIFICACION
                }
            }
        }

        private void cbCine_CheckedChanged(object sender, EventArgs e)
        {
            FiltarDatos(); //FILTRAR LOS DATOS EN EL DATAGRID DE ACUERDO A LOS CHECKBOXS SELECCIONADOS

            if (OperacionActual == MODIFICAR && dgvFunciones.RowCount == 0) //SI EL PANEL INFERIOR ESTA ABIERTO Y EL RESULTADO DE LA BUSQUEDA NO ARROJA ALGUN RESULTADO...
            {
                CerrarPanel(); //CERRAR EL PANEL DE MODIFICACION
            }
        }

        private void cbSala_CheckedChanged(object sender, EventArgs e)
        {
            FiltarDatos(); //FILTRAR LOS DATOS EN EL DATAGRID DE ACUERDO A LOS CHECKBOXS SELECCIONADOS

            if (OperacionActual == MODIFICAR && dgvFunciones.RowCount == 0) //SI EL PANEL INFERIOR ESTA ABIERTO Y EL RESULTADO DE LA BUSQUEDA NO ARROJA ALGUN RESULTADO...
            {
                CerrarPanel(); //CERRAR EL PANEL DE MODIFICACION
            }
        }

        private void cbFecha_CheckedChanged(object sender, EventArgs e)
        {
            FiltarDatos(); //FILTRAR LOS DATOS EN EL DATAGRID DE ACUERDO A LOS CHECKBOXS SELECCIONADOS

            if (OperacionActual == MODIFICAR && dgvFunciones.RowCount == 0) //SI EL PANEL INFERIOR ESTA ABIERTO Y EL RESULTADO DE LA BUSQUEDA NO ARROJA ALGUN RESULTADO...
            {
                CerrarPanel(); //CERRAR EL PANEL DE MODIFICACION
            }
        }

        private void cbPelicula_CheckedChanged(object sender, EventArgs e)
        {
            FiltarDatos(); //FILTRAR LOS DATOS EN EL DATAGRID DE ACUERDO A LOS CHECKBOXS SELECCIONADOS

            if (OperacionActual == MODIFICAR && dgvFunciones.RowCount == 0) //SI EL PANEL INFERIOR ESTA ABIERTO Y EL RESULTADO DE LA BUSQUEDA NO ARROJA ALGUN RESULTADO...
            {
                CerrarPanel(); //CERRAR EL PANEL DE MODIFICACION
            }
        }

        private void cbFormato_CheckedChanged(object sender, EventArgs e)
        {
            FiltarDatos(); //FILTRAR LOS DATOS EN EL DATAGRID DE ACUERDO A LOS CHECKBOXS SELECCIONADOS

            if (OperacionActual == MODIFICAR && dgvFunciones.RowCount == 0) //SI EL PANEL INFERIOR ESTA ABIERTO Y EL RESULTADO DE LA BUSQUEDA NO ARROJA ALGUN RESULTADO...
            {
                CerrarPanel(); //CERRAR EL PANEL DE MODIFICACION
            }
        }

        private void boxSalas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSala.Checked) //SI EL CHECKBOX DEL BOX SALAS ESTA HABILITADO, AL CAMBIAR EL INDEX, TAMBIEN...
            {
                FiltarDatos(); //FILTRAR LOS DATOS EN EL DATAGRID DE ACUERDO A LOS CHECKBOXS SELECCIONADOS

                if (OperacionActual == MODIFICAR && dgvFunciones.RowCount == 0) //SI EL PANEL INFERIOR ESTA ABIERTO Y EL RESULTADO DE LA BUSQUEDA NO ARROJA ALGUN RESULTADO...
                {
                    CerrarPanel(); //CERRAR EL PANEL DE MODIFICACION
                }
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (cbFecha.Checked) //SI EL CHECKBOX DEL DATE TIME PICKER ESTA HABILITADO, AL CAMBIAR LA FECHA, TAMBIEN...
            {
                FiltarDatos(); //FILTRAR LOS DATOS EN EL DATAGRID DE ACUERDO A LOS CHECKBOXS SELECCIONADOS

                if (OperacionActual == MODIFICAR && dgvFunciones.RowCount == 0) //SI EL PANEL INFERIOR ESTA ABIERTO Y EL RESULTADO DE LA BUSQUEDA NO ARROJA ALGUN RESULTADO...
                {
                    CerrarPanel(); //CERRAR EL PANEL DE MODIFICACION
                }
            }
        }

        private void boxPeliculas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPelicula.Checked) //SI EL CHECKBOX DEL BOX PELICULAS ESTA HABILITADO, AL CAMBIAR EL INDEX, TAMBIEN...
            {
                FiltarDatos(); //FILTRAR LOS DATOS EN EL DATAGRID DE ACUERDO A LOS CHECKBOXS SELECCIONADOS

                if (OperacionActual == MODIFICAR && dgvFunciones.RowCount == 0) //SI EL PANEL INFERIOR ESTA ABIERTO Y EL RESULTADO DE LA BUSQUEDA NO ARROJA ALGUN RESULTADO...
                {
                    CerrarPanel(); //CERRAR EL PANEL DE MODIFICACION
                }
            }
        }

        private void boxFormatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFormato.Checked)
            {
                FiltarDatos(); //FILTRAR LOS DATOS EN EL DATAGRID DE ACUERDO A LOS CHECKBOXS SELECCIONADOS

                if (OperacionActual == MODIFICAR && dgvFunciones.RowCount == 0) //SI EL PANEL INFERIOR ESTA ABIERTO Y EL RESULTADO DE LA BUSQUEDA NO ARROJA ALGUN RESULTADO...
                {
                    CerrarPanel(); //CERRAR EL PANEL DE MODIFICACION
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            OperacionActual = NUEVO; //SETEAR OPERACION ACTUAL COMO "NUEVO"
            AbrirPanel(); //ABRIR EL PANEL INFERIOR
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(dgvFunciones.RowCount > 0) //SI EL DATAGRID TIENE ALGUN REGISTRO
            {
                OperacionActual = MODIFICAR; //SETEAR OPERACION ACTUAL COMO "MODIFICAR"
                AbrirPanel(); //ABRIR EL PANEL INFERIOR
                ActualizarContenedores();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            CerrarPanel(); //CERRAR EL PANEL INFERIOR
        }

        private void PboxCines_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarBoxSalasPanel(); //ACTUALIZAR EL BOX SALAS DEL PANEL INFERIOR
        }

        private void PboxPeliculas_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarBoxFormatoPanel(); //ACTUALIZAR EL BOX FORMATOS DEL PANEL INFERIOR
        }

        private bool VerificarExistenciaDeRegistro()
        {
            string FechaPanel = PdtpFecha.Value.ToShortDateString(); //FECHA SELECCIONADA EN EL PANEL INFERIOR
            string[] partesFechaPanel = FechaPanel.Split('/'); //DIVIDIR LA FECHA EN DIA, MES, AÑO

            comando = new SqlCommand("SELECT * FROM Funciones WHERE CodCine_Func = " + PboxCines.SelectedValue + " AND CodSala_Func = " + PboxSalas.SelectedValue + " AND Dia_Func = '" + partesFechaPanel[1]+"/"+ partesFechaPanel[0]+"/"+ partesFechaPanel[2] + "' AND Horario_Func = '" + PtxtHora.Text + ":" + PtxtMinutos.Text + "'", BD.conectarBD); //SELECCIONAR EL SUPUESTO REGISTRO EXISTENTE
            reader = comando.ExecuteReader(); //EJECUTAR COMANDO

            if (reader.Read()) //SI EN EL CINE, SALA, DIA Y HORARIO SELECCIONADO YA EXISTE UNA FUNCION
            {
                reader.Close(); //CERRAR READER
                return true; //RETORNAR VERDADERO
            }

            reader.Close(); //CERRAR READER
            return false; //RETORNAR FALSO
        }

        private void ActualizarContenedores()
        {   
            //ACTUALIZAR CADA CONTENEDOR CON LOS DATOS DEL REGISTRO SELECCIONADO EN EL DATAGRIDVIEW

            try
            {
                PboxCines.SelectedValue = dgvFunciones.CurrentRow.Cells[0].Value;
                PboxSalas.SelectedValue = dgvFunciones.CurrentRow.Cells[2].Value;
                PboxPeliculas.SelectedValue = dgvFunciones.CurrentRow.Cells[6].Value;
                PboxFormatos.SelectedValue = dgvFunciones.CurrentRow.Cells[8].Value;
                PdtpFecha.Value = DateTime.Parse(dgvFunciones.CurrentRow.Cells[4].Value.ToString());

                string Horario = dgvFunciones.CurrentRow.Cells[5].Value.ToString(); //GUARDAR EL HORARIO "HH:MM" EN LA VARIABLE
                string[] partes = Horario.Split(':'); //DIVIDIR EL HORARIO EN HORAS Y MINUTOS
                PtxtHora.Text = partes[0]; //PASAR LAS HORAS AL TEXTBOX HORA
                PtxtMinutos.Text = partes[1]; //PASAR LOS MINUTOS AL TEXTBOX MINUTOS

                PtxtStock.Text = dgvFunciones.CurrentRow.Cells[10].Value.ToString();
                PcbEstado.Checked = bool.Parse(dgvFunciones.CurrentRow.Cells[11].Value.ToString());
            }
            catch (Exception ex) { }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(PboxSalas.SelectedItem != null) //SI EL BOX DE SALAS NO ESTA VACIO
            {
                if(PboxFormatos.SelectedItem != null) //SI EL BOX DE FORMATOS NO ESTA VACIO
                {
                    if (PtxtHora.TextLength != 0) //SI EL TEXTBOX HORA NO ESTA VACIO
                    {
                        if (PtxtMinutos.TextLength != 0) //SI EL TEXTBOX MINUTOS NO ESTA VACIO
                        {
                            if (PtxtStock.TextLength != 0) //SI EL TEXTBOX STOCK NO ESTA VACIO
                            {
                                if (VerificarExistenciaDeRegistro() != true) //CORROBORAR QUE LOS DATOS ELEGIDOS NO EXISTAN EN LA BASE DE DATOS
                                {
                                    if (OperacionActual == NUEVO) //SI SE ESTA AGREGANDO UNA NUEVA FUNCION
                                    {
                                        string FechaPanel = PdtpFecha.Value.ToShortDateString(); //FECHA SELECCIONADA EN EL PANEL INFERIOR
                                        string[] partesFechaPanel = FechaPanel.Split('/'); //DIVIDIR LA FECHA EN DIA, MES, AÑO

                                        comando = new SqlCommand("INSERT INTO Funciones VALUES(" + PboxCines.SelectedValue + ", " + PboxSalas.SelectedValue + ", '" + partesFechaPanel[1] + "/" + partesFechaPanel[0] + "/" + partesFechaPanel[2] + "', '" + PtxtHora.Text + ":" + PtxtMinutos.Text + "', " + PboxPeliculas.SelectedValue + ", " + PboxFormatos.SelectedValue + ", " + PtxtStock.Text + ", '" + PcbEstado.Checked + "')", BD.conectarBD); //INSERTAR NUEVA FUNCION
                                        comando.ExecuteNonQuery(); //EJECUTAR COMANDO

                                        ActualizarDgvFunciones(); //ACTUALIZAR DATAGRID 
                                        PtxtHora.Clear();
                                        PtxtMinutos.Clear();      //LIMPIAR CONTENEDORES
                                        PtxtStock.Clear();
                                        PcbEstado.Checked = true;
                                    }

                                    if (OperacionActual == MODIFICAR)
                                    {
                                        int SelectedIndex = dgvFunciones.CurrentRow.Index; //INDICE DEL REGISTRO SELECCIONADO EN EL DATAGRID
                                        int CantidadFilas = dgvFunciones.RowCount; //CANTIDAD DE FILAS EN EL DATAGRID

                                        string FechaDgv = DateTime.Parse(dgvFunciones.CurrentRow.Cells[4].Value.ToString()).ToShortDateString(); //FECHA DEL ELEMENTO SELECCIONADO EN EL DATAGRID
                                        string[] partesFechaDgv = FechaDgv.Split('/'); //DIVIDIR LA FECHA EN DIA, MES, AÑO

                                        string FechaPanel = PdtpFecha.Value.ToShortDateString(); //FECHA SELECCIONADA EN EL PANEL INFERIOR
                                        string[] partesFechaPanel = FechaPanel.Split('/'); //DIVIDIR LA FECHA EN DIA, MES, AÑO

                                        comando = new SqlCommand("UPDATE Funciones SET CodCine_Func = " + PboxCines.SelectedValue + ", CodSala_Func = " + PboxSalas.SelectedValue + ", Dia_Func = '" + partesFechaPanel[1] + "/" + partesFechaPanel[0] + "/" + partesFechaPanel[2] + "', Horario_Func = '" + PtxtHora.Text + ":" + PtxtMinutos.Text + "', CodPelicula_Func = " + PboxPeliculas.SelectedValue + ", CodFormato_Func = " + PboxFormatos.SelectedValue + ", Stock_Func = " + PtxtStock.Text + ", Estado_Func = '" + PcbEstado.Checked + "' WHERE CodCine_Func = " + dgvFunciones.CurrentRow.Cells[0].Value + " AND CodSala_Func = " + dgvFunciones.CurrentRow.Cells[2].Value + " AND Dia_Func = '" + partesFechaDgv[1] + "/" + partesFechaDgv[0] + "/" + partesFechaDgv[2] + "' AND Horario_Func = '" + dgvFunciones.CurrentRow.Cells[5].Value + "'", BD.conectarBD); //MODIFICAR FUNCION
                                        comando.ExecuteNonQuery(); //EJECUTAR CONSULTA

                                        ActualizarDgvFunciones(); //ACTUALIZAR DATAGRID

                                        if (dgvFunciones.RowCount == 0) //SI AL MODIFICAR EL DATAGRID QUEDO VACIO...
                                        {
                                            CerrarPanel(); //CERRAR EL PANEL
                                        }
                                        else //SI AUN CONTIENE DATOS...
                                        {
                                            if (dgvFunciones.RowCount == CantidadFilas) //SI QUEDO LA MISMA CANTIDAD DE FILAS
                                            {
                                                dgvFunciones.CurrentCell = dgvFunciones.Rows[SelectedIndex].Cells[1]; //SELECCIONAR EL REGISTRO QUE ESTABA SELECCIONADO
                                                dgvFunciones.Rows[SelectedIndex].Selected = true; //SELECCIONAR EL REGISTRO QUE ESTABA SELECCIONADO
                                            }

                                            if (dgvFunciones.RowCount < CantidadFilas && SelectedIndex != 0) //SI HAY MENOS CANTIDAD DE FILAS Y LA QUE ESTABA SELECCIONADA NO ERA LA PRIMERA
                                            {
                                                dgvFunciones.CurrentCell = dgvFunciones.Rows[SelectedIndex - 1].Cells[1]; //SELECCIONAR EL REGISTRO ANTERIOR
                                                dgvFunciones.Rows[SelectedIndex - 1].Selected = true; //SELECCIONAR EL REGISTRO ANTERIOR
                                            }

                                            ActualizarContenedores(); //ACTUALIZAR LOS CONTENEDORES CON LOS DATOS DEL DATAGRID
                                        }
                                    }
                                }
                                else //SI YA EXISTE UNA PELICULA EN LOS DATOS ELEGIDOS
                                {
                                    MessageBox.Show("En el cine elegido, sala, dia y horario, ya existe una funcion programada.", "Funcion existente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else //SI EL STOCK ESTA VACIO
                            {
                                MessageBox.Show("Por favor indique la cantidad de entradas en stock.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                PtxtStock.Focus();
                            }
                        }
                        else //SI LOS MINUTOS ESTAN VACIOS
                        {
                            MessageBox.Show("Faltó completar los minutos.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            PtxtMinutos.Focus();
                        }
                    }
                    else //SI LA HORA ESTA VACIA
                    {
                        MessageBox.Show("Faltó completar la hora.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        PtxtHora.Focus();
                    }
                }
                else //SI LA PELICULA TODAVIA NO TIENE FORMATOS
                {
                    MessageBox.Show("La pelicula seleccionada aun no posee formatos.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else //SI EL BOX DE SALAS ESTA VACIO
            {
                MessageBox.Show("El cine seleccionado aun no posee salas registradas.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvFunciones_SelectionChanged(object sender, EventArgs e)
        {
            if(OperacionActual == MODIFICAR) //SI SE ESTA MODIFICANDO
            {
                ActualizarContenedores(); //ACTUALIZAR LOS CONTENEDORES CON LOS DATOS DEL DATAGRID
            }
        }

        private void PtxtHora_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); //ACEPTAR SOLO NUMEROS
        }

        private void PtxtMinutos_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); //ACEPTAR SOLO NUMEROS
        }

        private void PtxtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); //ACEPTAR SOLO NUMEROS
        }

        private void PtxtHora_Enter(object sender, EventArgs e)
        {
            if (PtxtHora.BackColor != Color.White) PtxtHora.BackColor = Color.White; //SI EL TEXTBOX NO ES DE COLOR BLANCO. PONER COLOR BLANCO
        }

        private void PtxtMinutos_Enter(object sender, EventArgs e)
        {
            if (PtxtMinutos.BackColor != Color.White) PtxtMinutos.BackColor = Color.White; //SI EL TEXTBOX NO ES DE COLOR BLANCO. PONER COLOR BLANCO
        }

        private void PtxtStock_Enter(object sender, EventArgs e)
        {
            if (PtxtStock.BackColor != Color.White) PtxtStock.BackColor = Color.White; //SI EL TEXTBOX NO ES DE COLOR BLANCO. PONER COLOR BLANCO
        }
    }
}
