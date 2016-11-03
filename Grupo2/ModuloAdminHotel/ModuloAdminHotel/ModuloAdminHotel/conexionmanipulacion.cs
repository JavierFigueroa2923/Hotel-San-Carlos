﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Data.Odbc;

namespace ModuloAdminHotel
{
    class conexionmanipulacion
    {
        String connect = "server=localhost; database=hsc; Uid=root ; pwd=;";
        public void Conectar()
        {
            OdbcConnection  conexion = new OdbcConnection (connect);
            conexion.Open();

        }
        public void Desconectar()
        {
            OdbcConnection  conexion = new OdbcConnection (connect);
            conexion.Close();
        }
        public OdbcConnection  rutaconectada()
        {
            OdbcConnection  conexion1 = new OdbcConnection (connect);
            conexion1.Open();
            return conexion1;

        }
        //llena los combobox
        public void getColumnas(ComboBox cb,String tabla,String parametro)
        {
            
            OdbcCommand cm = new OdbcCommand("SELECT "+parametro+" FROM " + tabla +";" , rutaconectada());
            OdbcDataReader adaptador = cm.ExecuteReader();
            while(adaptador.Read())
            {
                cb.Items.Add(adaptador[parametro].ToString());
               
            }
            adaptador.Close();

        }
        //llena los textos
        public void llenartext(TextBox tx,String Query,String parametro)
        {
            OdbcCommand cm = new OdbcCommand(Query, rutaconectada());
            OdbcDataReader adaptador = cm.ExecuteReader();
            if(adaptador.Read()==true)
            {
               
                tx.Text=(adaptador[parametro].ToString());

            }
            adaptador.Close();
        }
        public void EjecutarQuery(TextBox tx,String Query)
        {
            Conectar();
            OdbcCommand comando = new OdbcCommand(Query, rutaconectada());
            int Ifilasafectadas = comando.ExecuteNonQuery();
           ;
            if (Ifilasafectadas > 0)
                MessageBox.Show("Operacion realizada con exitosamente");
            Desconectar();
        }

    }
}