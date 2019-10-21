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

namespace Proyecto_Cine.Forms
{
    public partial class Precios : Form
    {
        const int NULL = 0;
        const int NUEVO = 1;        //CONSTANTES
        const int MODIFICAR = 2;

        Conexion BD = new Conexion();
        DataTable DTTiposDeEntradas = new DataTable();
        DataTable DTTiposDeEntradas2 = new DataTable();
        DataTable DTTiposDeSalas = new DataTable();
        DataTable DTPrecios = new DataTable();
        DataTable DTCines = new DataTable();
        SqlDataAdapter adaptador;
        SqlCommand comando;

        int OperacionTiposDeEntradas = 0; //INDICADOR DE OPERACION ACTUAL EN TIPOS DE ENTRADAS
        int OperacionPrecios = 0; //INDICADOR DE OPERACION ACTUAL EN PRECIOS

        public Precios()
        {
            InitializeComponent();

            if (BD.abrir()) //SI LA CONEXION CON LA BASE DE DATOS SE PUEDE ABRIR...
            {
                dgvTDE.DataSource = DTTiposDeEntradas; //INDICARLE AL DATAGRID TIPOS DE ENTRADAS QUE SU FUENTE DE DATOS SERA EL DATATABLE TIPOS DE ENTRADAS
                BoxCines.DataSource = DTCines; //INDICARLE AL BOX CINES QUE SU FUENTE DE DATOS SERA EL DATATABLE CINES
                BoxTDS.DataSource = DTTiposDeSalas; //INDICARLE AL BOX TIPOS DE SALAS QUE SU FUENTE DE DATOS SERA EL DATATABLE TIPOS DE SALAS
                dgvPrecios.DataSource = DTPrecios; //INDICARLE AL DATAGRID PRECIOS QUE SU FUENTE DE DATOS SERA EL DATATABLE PRECIOS
                boxTDE.DataSource = DTTiposDeEntradas2; //INDICARLE AL BOX TIPOS DE ENTRADAS QUE SU FUENTE DE DATOS ERA EL DATATABLE TIPOS DE ENTRADAS 2

                ActualizarDvgTiposDeEntradas(); //ACTUALIZAR EL DATAGRID DE TIPOS DE ENTRADAS
                ActualizarBoxCines(); //ACTUALIZAR EL BOX DE CINES
                ActualizarBoxTDS(); //ACTUALIZAR EL BOX DE TIPOS DE SALAS
                ActualizarDgvPrecios(); //ACTUALIZAR EL DATAGRID DE PRECIOS
                ActualizarBoxTDE(); //ACTUALIZAR EL BOX DE TIPOS DE ENTRADAS
                
            }

            ConfigurarGrids(); //CONFIGURACION RELACIONADA CON LA APARIENCIA DE LOS DATAGRIDS
        }

        private void RemoverElementosBoxTDE()
        {
            for (int i = 0; i < dgvPrecios.RowCount; i++) //RECORRER EL DATAGRID DE PRECIOS
            {
                for (int j = 0; j < DTTiposDeEntradas2.Rows.Count; j++) //RECORRER EL DATATABLE DE TIPOS DE ENTRADAS 2
                {
                    if (DTTiposDeEntradas2.Rows[j][0].ToString() == dgvPrecios.Rows[i].Cells[0].Value.ToString()) //SI EL TIPO DE ENTRADA DEL BOX TIPOS DE ENTRADAS, APARECE ACTUALMENTE EN EL DATAGRID DE PRECIOS...
                    {
                        DTTiposDeEntradas2.Rows.RemoveAt(j); //ELIMINAR ESE ELEMENTO DEL BOX
                    }
                }
            }
        }

        private void AbrirPanelPrecio()
        {
            dgvPrecios.Height = 259; //ACHICAR EL DATAGRID DE PRECIOS
            panelPrecio.Visible = true; //HACER VISIBLE EL PANEL
            btnNuevoPrecio.Visible = false; //OCULTAR EL BOTON DE NUEVO PRECIO
            btnModificarPrecio.Visible = false; //OCULTAR EL BOTON DE MODIFICAR PRECIO

            if (OperacionPrecios == NUEVO) //SI SE VA A AGREGAR UN NUEVO REGISTRO...
            {
                boxTDE.Visible = true; //HACER VISIBLE EL BOX DE TIPO DE ENTRADAS
                label2.Visible = true; //HACER VISIBLE LA ETIQUETA "TIPO"
                txtPrecio.Location = new Point(457, 11); //AJUSTAR POSICION DEL TEXTBOX PRECIO
                label3.Location = new Point(404, 14); //AJUSTAR LA ETIQUETA "PRECIO"
            }

            if(OperacionPrecios == MODIFICAR) //SI SE VA A MODIFICAR...
            {
                boxTDE.Visible = false; //OCULTAR EL BOX DE TIPO DE ENTRADAS YA QUE NO ES ALGO MODIFICABLE
                label2.Visible = false; //OCULTAR LA ETIQUETA "TIPO"
                txtPrecio.Location = new Point(267, 13); //AJUSTAR POSICION DEL TEXTBOX DE PRECIO
                label3.Location = new Point(215, 15); //AJUSTAR LA ETIQUETA "PRECIO"
            }

            
        }

        private void CerrarPanelPrecio()
        {
            OperacionPrecios = NULL; //ASIGNAR A OPERACION ACTUAL DE PRECIOS, NULO.
            panelPrecio.Visible = false; //HACER INVISIBLE EL PANEL
            dgvPrecios.Height = 350; //AGRANDAR EL DATAGRID DE PRECIOS
            btnNuevoPrecio.Visible = true; //HACER VISIBLE EL BOTON DE NUEVO PRECIO
            btnModificarPrecio.Visible = true; //HACER VISIBLE EL BOTON DE MODIFICAR PRECIO
            txtPrecio.Clear(); //LIMPIAR LO QUE HAYA QUEDADO EN EL TEXTBOX DEL PANEL
        }

        private void ActualizarBoxTDE()
        {
            adaptador = new SqlDataAdapter("SELECT * FROM TiposDeEntradas", BD.getSqlConnection()); //TRAER TODOS LOS TIPOS DE ENTRADAS
            DTTiposDeEntradas2.Clear(); //LIMPIAR EL DATATABLE DE VIEJOS REGISTROS
            adaptador.Fill(DTTiposDeEntradas2); //LLENAR EL DATATABLE CON NUEVOS REGISTROS

            DTTiposDeEntradas2.DefaultView.Sort = "Descripcion_TDE"; //ORDENAR REGISTROS ALFABETICAMENTE

            boxTDE.DisplayMember = "Descripcion_TDE"; //LO QUE MOSTRARA EL BOX SERA LA DESCRIPCION DE TIPOS DE ENTRADAS
            boxTDE.ValueMember = "CodTipoDeEntrada_TDE"; //ASIGNARA COMO VALOR, EL CODIGO DE LOS TIPOS DE ENTRADAS
        }

        private void ActualizarDgvPrecios()
        {
            adaptador = new SqlDataAdapter("SELECT CodTipoDeEntrada_Prec, Descripcion_TDE, Precio_Prec FROM Precios INNER JOIN TiposDeEntradas ON CodTipoDeEntrada_Prec = CodTipoDeEntrada_TDE WHERE CodCine_Prec = "+BoxCines.SelectedValue+" AND CodTipoDeSala_Prec = "+BoxTDS.SelectedValue, BD.getSqlConnection()); //TRAER LOS DATOS DEL CINE Y SALA SELECCIONADOS
            DTPrecios.Clear(); //LIMPIAR EL DATATABLE DE VIEJOS REGISTROS
            adaptador.Fill(DTPrecios); //LLENAR EL DATATABLE CON LOS NUEVOS REGISTROS
        }

        private void ActualizarBoxTDS()
        {
            adaptador = new SqlDataAdapter("SELECT CodTipoDeSala_TDS, Descripcion_TDS FROM TiposDeSalas", BD.getSqlConnection()); //TRAER TODOS LOS TIPOS DE SALAS
            DTTiposDeSalas.Clear(); //LIMPIAR EL DATATABLE DE VIEJOS REGISTROS
            adaptador.Fill(DTTiposDeSalas); //LLENAR EL DATATABLE CON LOS NUEVOS REGISTROS

            DTTiposDeSalas.DefaultView.Sort = "Descripcion_TDS"; //ORDENAR REGISTROS ALFABETICAMENTE

            BoxTDS.DisplayMember = "Descripcion_TDS"; //LO QUE SE VERA EN EL BOX, SERA LA DESCRIPCION DEL TIPO DE SALA
            BoxTDS.ValueMember = "CodTipoDeSala_TDS"; //ASIGNAR COMO VALOR EL CODIGO DE TIPO DE SALA
        }

        private void ActualizarBoxCines()
        {
            adaptador = new SqlDataAdapter("SELECT CodCine_Cine, Nombre_Cine FROM Cines", BD.getSqlConnection()); //TRAER TODOS LOS CINES
            DTCines.Clear(); //LIMPIAR EL DATATABLE DE CINES DE VIEJOS REGISTROS
            adaptador.Fill(DTCines); //LLENAR EL DATATABLE DE CINES LOS NUEVOS REGISTROS

            DTCines.DefaultView.Sort = "Nombre_Cine"; //ORDENAR REGISTROS ALFABETICAMENTE

            BoxCines.DisplayMember = "Nombre_Cine"; //LO QUE SE VERA EN EL BOX, SERA EL NOMBRE DE LOS CINES
            BoxCines.ValueMember = "CodCine_Cine"; //ASIGNAR COMO VALOR EL CODIGO DE CINE
        }

        private void OcultarPanelTDE()
        {
            OperacionTiposDeEntradas = NULL; //ASIGNAR NULO COMO OPERACION ACTUAL DE TIPOS DE ENTRADAS
            panelTDE.Visible = false; //HACER INVISIBLE EL PANEL
            dgvTDE.Height = 377; //AGRANDAR EL DATAGRID
            btnNuevoTDE.Visible = true; //MOSTRAR EL BOTON DE NUEVO TIPO DE ENTRADA
            btnModificarTDE.Visible = true; //MOSTRAR EL BOTON DE MODIFICAR TIPO DE ENTRADA
            txtDescripcionTDE.Clear(); //LIMPIAR EL TEXTBOX
        }

        private void MostrarPanelTDE()
        {
            btnNuevoTDE.Visible = false; //OCULTAR EL BOTON DE NUEVO TIPO DE ENTRADA
            btnModificarTDE.Visible = false; //OCULTAR EL BOTON DE MODIFICAR TIPO DE ENTRADA
            dgvTDE.Height = 286; //ACHICHAR EL DATAGRID
            panelTDE.Visible = true; //HACER VISIBLE EL PANEL
        }

        private void ConfigurarGrids()
        {
            dgvTDE.Columns[0].HeaderText = "Codigo";
            dgvTDE.Columns[1].HeaderText = "Tipo de Entrada";

            dgvTDE.Height = 377;
            dgvTDE.Columns[0].Visible = false;
            dgvTDE.ReadOnly = true;
            dgvTDE.AllowUserToAddRows = false;
            dgvTDE.RowHeadersVisible = false;
            dgvTDE.AllowUserToResizeColumns = false;
            dgvTDE.AllowUserToResizeRows = false;
            dgvTDE.MultiSelect = false;
            dgvTDE.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTDE.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTDE.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTDE.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTDE.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvTDE.Sort(dgvTDE.Columns[1], ListSortDirection.Ascending);

            dgvPrecios.Columns[0].HeaderText = "Codigo Tipo de Entrada";
            dgvPrecios.Columns[1].HeaderText = "Tipo de Entrada";
            dgvPrecios.Columns[2].HeaderText = "Precio";

            dgvPrecios.Height = 350;
            dgvPrecios.Columns[0].Visible = false;
            dgvPrecios.ReadOnly = true;
            dgvPrecios.AllowUserToAddRows = false;
            dgvPrecios.RowHeadersVisible = false;
            dgvPrecios.AllowUserToResizeColumns = false;
            dgvPrecios.AllowUserToResizeRows = false;
            dgvPrecios.MultiSelect = false;
            dgvPrecios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPrecios.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPrecios.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPrecios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrecios.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvPrecios.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvPrecios.Sort(dgvPrecios.Columns[1], ListSortDirection.Ascending);
        }

        private void ActualizarDvgTiposDeEntradas()
        {
            adaptador = new SqlDataAdapter("SELECT * FROM TiposDeEntradas", BD.getSqlConnection()); // TRAER TODOS LOS TIPOS DE ENTRADAS
            DTTiposDeEntradas.Clear(); //LIMPIAR EL DATATALE DE VIEJOS REGISTROS
            adaptador.Fill(DTTiposDeEntradas); //LLENAR EL DATATABLE CON LOS NUEVOS REGISTROS
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            OperacionTiposDeEntradas = MODIFICAR; //LA OPERACION ACTUAL DE TIPOS DE ENTRADAS ES "MODIFICAR"
            MostrarPanelTDE(); //MOSTRAR EL PANEL
            txtDescripcionTDE.Text = dgvTDE.CurrentRow.Cells[1].Value.ToString(); //LLENAR EL TEXTBOX CON EL REGISTRO SELECCIONADO
            txtDescripcionTDE.Focus(); //DARLE FOCO AL TEXTBOX
            txtDescripcionTDE.SelectAll(); //SELECCIONAR TODO EL TEXTO
        }

        private void btnNuevoTDE_Click(object sender, EventArgs e)
        {
            OperacionTiposDeEntradas = NUEVO; //OPERACION ACTUAL DE TIPO DE ENTRADAS ES "NUEVO"
            MostrarPanelTDE(); //MOSTRAR EL PANEL
            txtDescripcionTDE.Focus(); //DARLE FOCO AL TEXTBOX
        }

        private void btnVolverTDE_Click(object sender, EventArgs e)
        {
            OcultarPanelTDE(); //OCULTAR EL PANEL TIPOS DE ENTRADA
        }

        private void dgvTDE_SelectionChanged(object sender, EventArgs e)
        {
            if(OperacionTiposDeEntradas == MODIFICAR) //SI LA OPERACION ACTUAL DE TIPO DE ENTRADAS ES MODIFICAR...
            {
                try
                {
                    txtDescripcionTDE.Text = dgvTDE.CurrentRow.Cells[1].Value.ToString(); //LLENAR EL TEXTBOX CON EL REGISTRO SELECCIONADO
                    txtDescripcionTDE.Focus(); //DARLE FOCO AL TEXTBOX
                    txtDescripcionTDE.SelectAll(); //SELECCIONAR TODO EL TEXTO
                }
                catch(Exception ex) { }
            }
        }

        private void btnGuardarTDE_Click(object sender, EventArgs e)
        {
            if(txtDescripcionTDE.TextLength != 0) //SI EL TEXTBOX NO ESTA VACIO...
            {
                if (OperacionTiposDeEntradas == NUEVO) //SI SE ESTA AGREGANDO UN NUEVO TIPO DE ENTRADA...
                {
                    int NuevoCodigo = Int32.Parse(DTTiposDeEntradas.Compute("MAX(CodTipoDeEntrada_TDE)", "").ToString()) + 1; //OBTENER EL ULTIMO CODIGO Y SUMARLE 1

                    comando = new SqlCommand("INSERT INTO TiposDeEntradas (CodTipoDeEntrada_TDE, Descripcion_TDE) VALUES (" + NuevoCodigo + ", '" + txtDescripcionTDE.Text + "')", BD.getSqlConnection()); //INSERTAR EL NUEVO REGISTRO
                    comando.ExecuteNonQuery(); //EJECUTAR CONSULTA
                    ActualizarDvgTiposDeEntradas(); //ACTUALIZAR DATAGIRD TIPOS DE ENTRADAS

                    seleccionarTDE(NuevoCodigo.ToString()); //SELECCIONAR EL NUEVO REGISTRO

                    txtDescripcionTDE.Clear(); //LIMPIAR EL TEXTBOX
                    txtDescripcionTDE.Focus(); //DARLE FOCO AL TEXTBOX
                }

                if (OperacionTiposDeEntradas == MODIFICAR) //SI SE ESTA MODIFICANDO UN TIPO DE ENTRADA...
                {
                    String CurrentCodeTDE = dgvTDE.CurrentRow.Cells[0].Value.ToString(); //GUARDAR EL CODIGO ACTUAL DE TDE
                    String CurrentCodePrecios = dgvPrecios.CurrentRow.Cells[0].Value.ToString(); //GUARDAR EL CODIGO ACTUAL DE PRECIOS

                    comando = new SqlCommand("UPDATE TiposDeEntradas SET Descripcion_TDE = '" + txtDescripcionTDE.Text + "' WHERE CodTipoDeEntrada_TDE = " + CurrentCodeTDE, BD.getSqlConnection()); //MODIFICAR EL REGISTOR SELECCIONADO
                    comando.ExecuteNonQuery(); //EJECUTAR CONSULTA

                    ActualizarDvgTiposDeEntradas(); //ACTUALIZAR DATAGRID TIPO DE ENTRADAS
                    ActualizarDgvPrecios(); //ACTUALIZAR DATAGRID DE PRECIOS

                    seleccionarTDE(CurrentCodeTDE); //SELECCIONAR EL REGISTRO MODIFICADO
                    seleccionarPrecio(CurrentCodePrecios);
                   
                    txtDescripcionTDE.Text = dgvTDE.CurrentRow.Cells[1].Value.ToString(); //LLENAR EL TEXTBOX CON EL REGISTRO SELECCIONADO
                    txtDescripcionTDE.Focus(); //DARLE FOCO AL TEXTBOX
                    txtDescripcionTDE.SelectAll(); //SELECCIONAR TODO EL TEXTO
                }

                ActualizarBoxTDE(); //ACTUALIZAR TAMBIEN EL BOX TIPOS DE ENTRADAS EN EL PANEL DE PRECIOS

                if (OperacionPrecios == NUEVO) //SI LA OPERACION ACTUAL DE PRECIOS ES "NUEVO"...
                {
                    RemoverElementosBoxTDE(); //ELIMINAR DEL BOX LOS ELEMENTOS QUE YA ESTAN EN EL DATAGRID DE PRECIOS
                }
            }
            else //SI EL TEXTBOX ESTA VACIO
            {
                MessageBox.Show("La descripcion no puede quedar vacia", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcionTDE.Focus();
            }
        }

        private void BoxCines_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarDgvPrecios(); //ACTUALIZAR DATAGRID DE PRECIOS CON EL CINE SELECCIONADO
            BoxTDS.SelectedIndex = 0; //SELECCIONAR EL PRIMER ITEM DEL BOX DE TIPO DE SALAS

            if(OperacionPrecios == NUEVO) //SI LA OPERACION ACTUAL DE PRECIOS ES "NUEVO"...
            {
                ActualizarBoxTDE(); //LLENAR EL BOX DE TIPO DE ENTRADAS
                RemoverElementosBoxTDE(); // Y QUITAR LOS ELEMENTOS QUE YA ESTAN EN EL DATAGRID, PARA NO VOLVER A AGREGARLOS

                if (DTTiposDeEntradas2.Rows.Count == 0) //SI EL BOX SE QUEDA VACIO, ES DECIR, YA ESTAN TODOS LOS TIPOS DE ENTRADAS AGREGADOS
                {
                    CerrarPanelPrecio(); //CERRAR EL PANEL
                }
            }

            if(OperacionPrecios == MODIFICAR) //SI SE ESTA MODIFICANDO...
            {
                if(dgvPrecios.RowCount == 0) //Y SI EN EL CINE Y LA SALA NO HAY DATOS...
                {
                    CerrarPanelPrecio(); //CERRAR EL PANEL
                }
            }
        }

        private void BoxTDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarDgvPrecios(); //ACTUALIZAR DATAGIRD DE PRECIOS CON LA SALA SELECCIONADA

            if (OperacionPrecios == NUEVO) //SI LA OPERACION ACTUAL DE PRECIOS ES "NUEVO"
            {
                ActualizarBoxTDE(); //LLENAR EL BOX DE TIPOS DE ENTRADAS
                RemoverElementosBoxTDE(); //Y QUITAR LOS ELEMENTOS QUE YA ESTAN EN EL DATAGRID, PARA NO VOLVER A AGREGARLOS

                if (DTTiposDeEntradas2.Rows.Count == 0) //SI EL BOX SE QUEDA VACIO, ES DECIR, YA ESTAN TODOS LOS TIPOS DE ENTRADAS AGREGADOS
                {
                    CerrarPanelPrecio(); //CERRAR EL PANEL
                }
            }

            if (OperacionPrecios == MODIFICAR) //SI SE ESTA MODIFICANDO...
            {
                if (dgvPrecios.RowCount == 0) //Y LA SALA NO CONTIENE DATOS...
                {
                    CerrarPanelPrecio(); //CERRAR EL PANEL
                }
            }
        }

        private void btnNuevoPrecio_Click(object sender, EventArgs e)
        {
            ActualizarBoxTDE(); //LLENAR EL BOX DE TIPOS DE ENTRADAS
            RemoverElementosBoxTDE(); //REMOVER LOS ELEMENTOS QUE YA ESTAN EN EL DATAGIRD, PARA NO VOLVER A AGREGARLOS
            
            if(DTTiposDeEntradas2.Rows.Count > 0) //SI EL BOX NO QUEDA VACIO...
            {
                OperacionPrecios = NUEVO; //OPERACION ACTUAL DE PRECIOS ES "NUEVO"
                AbrirPanelPrecio(); //ABRIR EL PANEL PARA AGREGAR UN NUEVO PRECIO
                txtPrecio.Focus(); //DARLE FOCO AL TEXTBOX DE PRECIO
            }
        }

        private void btnModificarPrecio_Click(object sender, EventArgs e)
        {
            if(dgvPrecios.RowCount != 0) //SI EL DATAGRID POSEE REGISTROS...
            {
                OperacionPrecios = MODIFICAR; //OPERACION ACTUAL DE PRECIOS ES "MODIFICAR"
                AbrirPanelPrecio(); //ABRIR PANEL
                txtPrecio.Text = dgvPrecios.CurrentRow.Cells[2].Value.ToString(); //LLENAR EL TEXTBOX CON EL PRECIO SELECIONADO
                txtPrecio.Focus(); //DARLE FOCO AL TEXTBOX
                txtPrecio.SelectAll(); //SELECCIONAR TODO EL TEXTO
            }

        }

        private void btnVolverPrecio_Click(object sender, EventArgs e)
        {
            CerrarPanelPrecio(); //CERRAR EL PANEL
        }

        private void dgvPrecios_SelectionChanged(object sender, EventArgs e)
        {
            if(OperacionPrecios == MODIFICAR) //SI SE ESTA MODIFICANDO...
            {
                try
                {
                    txtPrecio.Text = dgvPrecios.CurrentRow.Cells[2].Value.ToString(); //LLENAR EL TEXTBOX CON EL PRECIO SELECIONADO
                    txtPrecio.Focus(); //DARLE FOCO AL TEXTBOX
                    txtPrecio.SelectAll(); //SELECCIONAR TODO EL TEXTO
                }
                catch(Exception ex) { }
            }
        }

        private void btnGuardarPrecio_Click(object sender, EventArgs e)
        {
            if(txtPrecio.TextLength != 0) //SI EL TEXTBOX DE PRECIO NO ESTA VACIO...
            {
                if (OperacionPrecios == NUEVO) //SI LA OPERACION ES "NUEVO"
                {
                    comando = new SqlCommand("INSERT INTO Precios (CodCine_Prec, CodTipoDeSala_Prec, CodTipoDeEntrada_Prec, Precio_Prec) VALUES ("+BoxCines.SelectedValue+", "+BoxTDS.SelectedValue+", "+boxTDE.SelectedValue+", "+txtPrecio.Text+")", BD.getSqlConnection()); //INSERTAR EL NUEVO REGISTRO
                    comando.ExecuteNonQuery(); //EJECUTAR CONSULTA

                    ActualizarDgvPrecios(); //ACTUALIZAR EL DATAGRID DE PRECIOS
                    txtPrecio.Clear(); //LIMPIAR EL TEXTBOX
                    txtPrecio.Focus(); //DARLE FOCO AL TEXTBOX

                    seleccionarPrecio(boxTDE.SelectedValue.ToString()); //SELECCIONAR EL NUEVO REGISTRO

                    RemoverElementosBoxTDE(); //REMOVER DEL BOX LOS TIPOS DE ENTRADAS YA AGREGADOS EN LOS PRECIOS. INCLUIDO EL NUEVO REGISTRO

                    if (DTTiposDeEntradas2.Rows.Count == 0) //SI EL BOX QUEDA VACIO PORQUE YA SE AGREGARON TODOS LOS TIPOS DE ENTRADAS...
                    {
                        CerrarPanelPrecio(); //CERRAR EL PANEL
                    }
                }

                if (OperacionPrecios == MODIFICAR) //SI SE VA A MODIFICAR
                {
                    String CurrentCode = dgvPrecios.CurrentRow.Cells[0].Value.ToString();

                    comando = new SqlCommand("UPDATE Precios SET Precio_Prec = " + txtPrecio.Text + " WHERE CodCine_Prec = " + BoxCines.SelectedValue + " AND CodTipoDeSala_Prec = " + BoxTDS.SelectedValue + " AND CodTipoDeEntrada_Prec = " + CurrentCode, BD.getSqlConnection()); //ACTUALIZAR REGISTRO
                    comando.ExecuteNonQuery(); //EJECUTAR CONSULTA

                    ActualizarDgvPrecios(); //ACTUALIZAR DATAGRID DE PRECIO

                    seleccionarPrecio(CurrentCode); //SELECCIONAR EL REGISTRO MODIFICADO

                    txtPrecio.Text = dgvPrecios.CurrentRow.Cells[2].Value.ToString(); //LLENAR EL TEXTBOX CON EL PRECIO SELECCIONADO
                    txtPrecio.Focus(); //DARLE FOCO AL TEXTBOX
                    txtPrecio.SelectAll(); //SELECCIONAR TODO EL TEXTO
                }
            }
            else //SI EL TEXTBOX PRECIO ESTA VACIO
            {
                MessageBox.Show("El precio no puede quedar vacio", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.Focus();
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); //ACEPTAR SOLO NUMEROS
        }

        private void seleccionarPrecio(String codigo)
        {
            for(int i=0; i<dgvPrecios.RowCount; i++) //RECORRER TODOS LOS PRECIOS
            {
                if(dgvPrecios.Rows[i].Cells[0].Value.ToString() == codigo) //SI EL CODIGO DE LA FILA COINCIDE CON EL CODIGO BUSCADO
                {
                    dgvPrecios.CurrentCell = dgvPrecios.Rows[i].Cells[2]; //SELECCIONAR REGISTRO
                    dgvPrecios.Rows[i].Selected = true; //SELECCIONAR REGISTRO
                }
            }
        }

        private void seleccionarTDE(String codigo)
        {
            for (int i=0; i<dgvTDE.RowCount; i++) //RECORRER TODOS LOS TIPOS DE ENTRADAS
            {
                if (dgvTDE.Rows[i].Cells[0].Value.ToString() == codigo) //SI EL CODIGO DE LA FILA COINCIDE CON EL CODIGO BUSCADO
                {
                    dgvTDE.CurrentCell = dgvTDE.Rows[i].Cells[1]; //SELECCIONAR REGISTRO
                    dgvTDE.Rows[i].Selected = true; //SELECCIONAR REGISTRO
                }
            }
        }
    }
}
