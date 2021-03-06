﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using FuncionesNavegador;
using System.Data.Odbc;

namespace ModuloAdminHotel
{
    public partial class Frm_Evento : Form
    {
        conexionmanipulacion con = new conexionmanipulacion();
        DataGridView datagridantes;
        CapaNegocio fn = new CapaNegocio();
        int costototal;
        int costopaquete;
        int costosalon;
        public string[] codigo;
        public Frm_Evento()
        {
            InitializeComponent();
        }
        public Frm_Evento(DataGridView datagrid)
        {
            InitializeComponent();
            datagridantes = datagrid;
        }
        String Codigo;
        Boolean editar;
        String atributo;

        private void ComboxDPI()
        {
            try
            {

                con.Conectar();
                //se inicia un DataSet
                DataSet ds = new DataSet();
                //se indica la consulta en sql
                String Query = "select id_cliente_pk,dpi,nit,nombre from cliente;";
                OdbcDataAdapter dad = new OdbcDataAdapter(Query, con.rutaconectada());
                //se indica con quu tabla se llena
                dad.Fill(ds, "cliente");
                cbxcliente.DataSource = ds.Tables[0].DefaultView;
                //indicamos el valor de los miembros
                cbxcliente.ValueMember = ("id_cliente_pk");
               
                //se indica el valor a desplegar en el combobox
                cbxcliente.DisplayMember = ("dpi");

                //  String nit = "SELECT `nit` FROM `cliente` WHERE `id_cliente_pk`= '" + cbxcliente.Text + "'";
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Los datos no cargaron de forma correcta" + ex, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //------------------------------------------------------------------------------------------
        private void comboboxcomparar()
        {
            txtFechaInicio.Text = datFechaInicio.Value.ToString("yyyy-MM-dd");

            txtFechaFinal.Text = datFechaFinal.Value.ToString("yyyy-MM-dd");


            try
            {

                con.Conectar();
                //se inicia un DataSet
                DataSet ds = new DataSet();
                //se indica la consulta en sql
                String Query = "select evento.`id_salon_pk`,salon.`nombre` from `salon`,`evento` where  (evento.`fecha_entrada`>='" + txtFechaInicio.Text + "' and evento.`fecha_salida` <='" + txtFechaFinal.Text + "' and evento.`estado` = 'reservado') and evento.`id_salon_pk`= salon.`id_salon_pk`";

                //String Query = "select id_salon_pk,nombre from salon;";
                OdbcDataAdapter dad = new OdbcDataAdapter(Query, con.rutaconectada());
                //se indica con quu tabla se llena
                dad.Fill(ds, "salon");
                cbxcompararsalon.DataSource = ds.Tables[0].DefaultView;
                //indicamos el valor de los miembros
                cbxcompararsalon.ValueMember = ("id_salon_pk");
                //se indica el valor a desplegar en el combobox
                cbxcompararsalon.DisplayMember = ("nombre");
                con.Desconectar();
                //para ingresar el combobox
                // string combosalon = cbxSalon.SelectedValue.ToString();
                /*  foreach (DataRowView item in cbxcompararsalon.Items)
                  {
                      if (item.Row[0].ToString() == "something")
                      {
                          //do something
                      }
                  }*/
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Los datos no cargaron de forma correcta" + ex, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //------------------------------------------------------------------------------------------
        private void ComboxSanlon()
        {
           // String comparar = cbxcompararsalon.Text;
              try
            {

                con.Conectar();
                //se inicia un DataSet
                DataSet ds = new DataSet();
                //se indica la consulta en sql
                //String Query = "select evento.`id_salon_pk`,salon.`nombre` from `salon`,`evento` where not (evento.`fecha_entrada`>='" + txtFechaInicio.Text + "' and evento.`fecha_salida` <='" + txtFechaFinal.Text + "' and evento.`estado` = 'reservado') and evento.`id_salon_pk`= salon.`id_salon_pk`";

                //  String Query = "select id_salon_pk,nombre from salon where salon.nombre != '" + cbxcompararsalon.DisplayMember + "' and salon.id_salon_pk <> '" + cbxcompararsalon.ValueMember + "'";
                String Query = "select id_salon_pk,nombre from salon where nombre != '" + cbxcompararsalon.Text + "'";
                OdbcDataAdapter dad = new OdbcDataAdapter(Query, con.rutaconectada());
                //se indica con quu tabla se llena
                dad.Fill(ds, "salon");
                cbxSalon.DataSource = ds.Tables[0].DefaultView;
                //indicamos el valor de los miembros
                cbxSalon.ValueMember = ("id_salon_pk");
                //se indica el valor a desplegar en el combobox
                cbxSalon.DisplayMember = ("nombre");
                con.Desconectar();
                //para ingresar el combobox
               

            }
            catch (Exception ex)
            {
                MessageBox.Show("Los datos no cargaron de forma correcta" + ex, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //---------------------------------------_________________________Combobox_Promosiones_______________________________--------------------------
        private void cb7()
        {
            try
            {
                con.Conectar();
                //se inicia un DataSet
                DataSet ds = new DataSet();
                //se indica la consulta en sql
                String Query = "select id_promocion_pk,nombre from promocion;";
                OdbcDataAdapter dad = new OdbcDataAdapter(Query, con.rutaconectada());
                //se indica con quu tabla se llena
                dad.Fill(ds, "promocion");
                cbxpaquete.DataSource = ds.Tables[0].DefaultView;
                //indicamos el valor de los miembros
                cbxpaquete.ValueMember = ("id_promocion_pk");
                //se indica el valor a desplegar en el combobox
                cbxpaquete.DisplayMember = ("nombre");
                con.Desconectar();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Los datos no cargaron de forma correcta" + ex, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //-------------------------------------------------Llenar Datagrid-----------------------------------------------------------
        private void llenarGrid()
        {
            try
            {
                con.Conectar();
                //se inicia un DataSet
                DataSet ds = new DataSet();
                //se indica la consulta en sql
                String Query = "select * from evento;";
                OdbcDataAdapter dad = new OdbcDataAdapter(Query, con.rutaconectada());
                //se indica con quu tabla se llena
                dad.Fill(ds, "evento");
                dataGridView3.DataSource = ds.Tables[0].DefaultView;
          
        
                con.Desconectar();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Los datos no cargaron de forma correcta" + ex, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
       
        private void Frm_Evento_Load(object sender, EventArgs e)
        {
            ComboxDPI();
            comboboxcomparar();
            cb7();
           ComboxSanlon();
            llenarGrid();
            cbxcliente.Text = "";
            cbxHoraFinal.Text = "";
            cbxHoraInicio.Text = "";
            cbxpaquete.Text = "";
            txtCosto.Text = "";
            txtdescripcion.Text = "";
            txtevento.Text = "";
            txtFechaInicio.Text = "";
            txtFechaFinal.Text = "";
            txtHoraFinal.Text = "";
            txtHoraInicio.Text = "";
            txtdpi.Text = "";
            txtsalon.Text = "";
            txtNit.Text = "";
            txtnombrecliente.Text = "";

            datFechaInicio.Text = "";

            datFechaFinal.Text = "";
            cbxSalon.Text = "";
           /* string NO_form = "Frm_Evento";
            DataTable seg = seguridad.ObtenerPermisos.Permisos(seguridad.Conexion.User, NO_form);
            if (seg.Rows.Count > 0)
            {
                fn.desactivarPermiso(seg, btn_guardar, btn_eliminar, btn_editar, btn_nuevo, btn_cancelar, btn_actualizar, btn_buscar, btn_anterior, btn_siguiente, btn_primero, btn_ultimo);
            }*/
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                cbxpaquete.Enabled = true;
         
            }
            else
            {
                costopaquete = 0;
                cbxpaquete.Enabled = false;
            
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
    

          //----------------------------  Verifica que la fecha inicial se menor a la Final:-------------------------
        
            if (datFechaInicio.Value < datFechaFinal.Value)
            {
              

                    txtFechaInicio.Text = datFechaInicio.Value.ToString("yyyy-MM-dd");

                    txtFechaFinal.Text = datFechaFinal.Value.ToString("yyyy-MM-dd");


                    txtHoraFinal.Text = cbxHoraInicio.Text;
                    txtHoraInicio.Text = cbxHoraFinal.Text;
                    txtsalon.Text = cbxSalon.SelectedValue.ToString();
                    txtdpi.Text = cbxcliente.SelectedValue.ToString();
                 //   txtpromosion.Text = cbxpaquete.SelectedValue.ToString();




                    TextBox[] textbox = { txtevento, txtFechaInicio, txtFechaFinal,txtestado, txtHoraFinal, txtHoraInicio, txtdpi , txtsalon,txtCosto};
                    DataTable datos = fn.construirDataTable(textbox);
                    if (datos.Rows.Count == 0)
                    {
                        MessageBox.Show("Hay campos vacios", "Favor Verificar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string tabla = "evento";
                        if (editar)
                        {
                            fn.modificar(datos, tabla, atributo, Codigo);
                        }
                        else
                        {
                            fn.insertar(datos, tabla);
                        }
                    cbxcliente.Text = "";
                    cbxHoraFinal.Text = "";
                    cbxHoraInicio.Text = "";
                    cbxpaquete.Text = "";
                    txtCosto.Text = "";
                    txtdescripcion.Text = "";
                    txtevento.Text = "";
                    txtFechaInicio.Text = "";
                    txtFechaFinal.Text = "";
                    txtHoraFinal.Text = "";
                    txtHoraInicio.Text = "";
                    txtdpi.Text = "";
                    txtsalon.Text = "";
                    txtNit.Text = "";
                    txtnombrecliente.Text = "";

                    datFechaInicio.Text = "";

                    datFechaFinal.Text = "";
                    cbxSalon.Text = "";
                }
                }


         
            
            else
            {
                MessageBox.Show("verifique la fecha por favor");
            }
        
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string tabla = "evento";
          
            fn.ActualizarGrid(datagridantes, "Select * from evento",tabla);
        }

        private void datFechaFinal_ValueChanged(object sender, EventArgs e)
        {

            txtFechaInicio.Text = datFechaInicio.Value.ToString("yyyy-MM-dd");

            txtFechaFinal.Text = datFechaFinal.Value.ToString("yyyy-MM-dd");
            try
            {

                con.Conectar();
                //se inicia un DataSet
                DataSet ds = new DataSet();
                //se indica la consulta en sql
                String Query = "select evento.`id_salon_pk`,salon.`nombre` from `salon`,`evento` where  (evento.`fecha_entrada`>='" + txtFechaInicio.Text + "' and evento.`fecha_salida` <='" + txtFechaFinal.Text + "' and evento.`estado` = 'reservado') and evento.`id_salon_pk`= salon.`id_salon_pk`";

                //String Query = "select id_salon_pk,nombre from salon;";
                OdbcDataAdapter dad = new OdbcDataAdapter(Query, con.rutaconectada());


                //se indica con quu tabla se llena
                dad.Fill(ds, "salon");
                cbxcompararsalon.DataSource = ds.Tables[0].DefaultView;
                //indicamos el valor de los miembros
                cbxcompararsalon.ValueMember = ("id_salon_pk");
                //se indica el valor a desplegar en el combobox
                cbxcompararsalon.DisplayMember = ("nombre");
                con.Desconectar();
                //para ingresar el combobox
                // string combosalon = cbxSalon.SelectedValue.ToString();
                ComboxSanlon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Los datos no cargaron de forma correcta" + ex, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbxcliente_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cbxcliente_TextChanged(object sender, EventArgs e)
        {
            OdbcCommand comando = new OdbcCommand();
            String Query2 = "select dpi,nit,nombre from cliente where dpi= '" + cbxcliente.Text + "'";

            comando.Connection = con.rutaconectada();

            comando.CommandText = Query2;

            OdbcDataReader leer = comando.ExecuteReader();

            if (leer.HasRows)
            {
                while (leer.Read())
                {
                  //leer.Read();

                  txtNit.Text = leer["nit"].ToString();
                    
                    txtnombrecliente.Text = leer["nombre"].ToString();

                }
                con.Desconectar();
            }


            }
        //---------------------------------------busqueda y descripcion de promociones---------------------------------------------
        private void cbxpaquete_TextChanged(object sender, EventArgs e)
        {
            costopaquete = 0;
           OdbcCommand comando = new OdbcCommand();
            String Query2 = "select detalle,costo from promocion where nombre= '" + cbxpaquete.Text + "'";

            comando.Connection = con.rutaconectada();

            comando.CommandText = Query2;

            OdbcDataReader leer = comando.ExecuteReader();

            if (leer.HasRows)
            {
                while (leer.Read())
                {
                    //leer.Read();

                    txtdescripcion.Text = leer["detalle"].ToString();

                  string  Costopaquete = leer["costo"].ToString();
                  costopaquete = int.Parse(Costopaquete);
                    costototal = costototal + costopaquete;
                    txtCosto.Text = costototal.ToString();

                   // int costopaquete = int.Parse(txtCosto.Text);
                }
               
                con.Desconectar();
            }

        }

        private void cbxpaquete_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxSalon_TextChanged(object sender, EventArgs e)
        {
           costosalon = 0;
           OdbcCommand comando = new OdbcCommand();
            String Query2 = "select costo from salon where nombre= '" + cbxSalon.Text + "'";

            comando.Connection = con.rutaconectada();

            comando.CommandText = Query2;

            OdbcDataReader leer = comando.ExecuteReader();

            if (leer.HasRows)
            {
                while (leer.Read())
                {
                    

           

                    string CostoSalon = leer["costo"].ToString();
                    costosalon = int.Parse(CostoSalon);
                    costototal = costototal + costosalon;
                    txtCosto.Text = costototal.ToString();

                    // int costopaquete = int.Parse(txtCosto.Text);
                }

                con.Desconectar();
            }


        }

        private void datFechaInicio_ValueChanged(object sender, EventArgs e)
        {

            txtFechaInicio.Text = datFechaInicio.Value.ToString("yyyy-MM-dd");

            txtFechaFinal.Text = datFechaFinal.Value.ToString("yyyy-MM-dd");
            try
            {

                con.Conectar();
               // se inicia un DataSet
                DataSet ds = new DataSet();
              //  se indica la consulta en sql
                String Query = "select evento.`id_salon_pk`,salon.`nombre` from `salon`,`evento` where  (evento.`fecha_entrada`>='" + txtFechaInicio.Text + "' and evento.`fecha_salida` <='" + txtFechaFinal.Text + "' and evento.`estado` = 'reservado') and evento.`id_salon_pk`= salon.`id_salon_pk`";

               // String Query = "select id_salon_pk,nombre from salon;";
                OdbcDataAdapter dad = new OdbcDataAdapter(Query, con.rutaconectada());


               // se indica con quu tabla se llena
                dad.Fill(ds, "salon");
                cbxcompararsalon.DataSource = ds.Tables[0].DefaultView;
               // indicamos el valor de los miembros
                cbxcompararsalon.ValueMember = ("id_salon_pk");
               // se indica el valor a desplegar en el combobox
                cbxcompararsalon.DisplayMember = ("nombre");
                con.Desconectar();
               // para ingresar el combobox
                 string combosalon = cbxSalon.SelectedValue.ToString();
                ComboxSanlon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Los datos no cargaron de forma correcta" + ex, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            cbxcliente.Text = "";
            cbxSalon.Text = "";
            cbxpaquete.Text = "";

            editar = false;
         
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
            groupBox4.Enabled = true;
            txtevento.Enabled = true;
            fn.LimpiarComponentes(this);
           // fn.LimpiarComponentes(groupBox1);
           // fn.LimpiarComponentes(groupBox2);
           // fn.LimpiarComponentes(groupBox3);
           // fn.LimpiarComponentes(groupBox4);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                //                String codigo2 = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                String codigo2 = datagridantes.CurrentRow.Cells[0].Value.ToString();
                String atributo2 = "id_evento_pk";
                var resultado = MessageBox.Show("Desea borrar el registro", "Confirme su accion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
               
                    string tabla = "evento";
                    fn.eliminar(tabla, atributo2, codigo2);
                }
            }
            catch
            {
                MessageBox.Show("No ha seleccionado ningun registro a editar");
            }


        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            OdbcDataAdapter da;
            da = new OdbcDataAdapter("Select * from evento where evento.`fecha_entrada`>='" + dat_inicio.Text + "' and evento.`fecha_salida` <='" + dat_final.Text + "'", con.rutaconectada());
            da.Fill(ds);
            dataGridView3.DataSource = ds;

            /*  string tabla = "evento";
            operaciones op = new operaciones();
            op.ejecutar(datagridantes, tabla);*/
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            editar = false;
            cbxcliente.Text = "";
            cbxSalon.Text = "";
            cbxpaquete.Text = "";
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            fn.LimpiarComponentes(this);
            fn.LimpiarComponentes(groupBox1);
            fn.LimpiarComponentes(groupBox2);
            fn.LimpiarComponentes(groupBox3);
            fn.LimpiarComponentes(groupBox4);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            
            fn.Siguiente(datagridantes);
            TextBox[] textbox = { txtevento, txtFechaInicio, txtFechaFinal, txtHoraFinal, txtHoraInicio, txtdpi, txtsalon, txtCosto };
            fn.llenartextbox(textbox, datagridantes);
            cbxSalon.Text = txtsalon.Text;
         
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {

            fn.Anterior(datagridantes);
            TextBox[] textbox = { txtevento, txtFechaInicio, txtFechaFinal, txtHoraFinal, txtHoraInicio, txtdpi, txtsalon, txtCosto };
            fn.llenartextbox(textbox, datagridantes);
            cbxSalon.Text = txtsalon.Text;
      
        }

        private void btnFinal_Click(object sender, EventArgs e)
        {

            fn.Ultimo(datagridantes);
            TextBox[] textbox = { txtevento, txtFechaInicio, txtFechaFinal, txtHoraFinal, txtHoraInicio, txtdpi, txtsalon, txtCosto };
            fn.llenartextbox(textbox, datagridantes);
            cbxSalon.Text = txtsalon.Text;
         
            
        }

        private void btnPrincio_Click(object sender, EventArgs e)
        {

            fn.Primero(datagridantes);
            TextBox[] textbox = { txtevento, txtFechaInicio, txtFechaFinal, txtHoraFinal, txtHoraInicio, txtdpi, txtsalon, txtCosto };
            fn.llenartextbox(textbox, datagridantes);
            cbxSalon.Text = txtsalon.Text;
         
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void cbxSalon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
           Codigo = datagridantes.CurrentRow.Cells[0].Value.ToString();
            TextBox[] textbox = { txtevento, txtFechaInicio, txtFechaFinal, txtHoraFinal, txtHoraInicio, txtdpi, txtsalon, txtCosto };
            fn.llenartextbox(textbox, datagridantes);
            cbxSalon.Text = txtsalon.Text;
            cbxHoraFinal.Text = txtHoraFinal.Text;
            cbxHoraInicio.Text = txtHoraInicio.Text;
            cbxcliente.Text = txtdpi.Text;
        }

        private void txtpromosion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtdpi_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbxcompararsalon_TextChanged(object sender, EventArgs e)
        {
            comboboxcomparar();
        }
    }
}
