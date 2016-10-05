using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using MySql.Data.MySqlClient;
using System.Configuration;
using MedidoresJCAS.Classes;

namespace MedidoresJCAS
{
    public partial class frmMedidores : Form
    {
        List<double> lLongitud;
        List<double> lLatidud;
        TreeNode nodoRaiz;
        String strRuta;
        String strMarcadores;

        public frmMedidores()
        {
            InitializeComponent();
            try
            {
                Configuration configManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                KeyValueConfigurationCollection confCollection = configManager.AppSettings.Settings;

                String host = confCollection["host"].Value.ToString();
                String usuario = confCollection["usuario"].Value.ToString();
                String password = confCollection["password"].Value.ToString();
                String instacia = confCollection["instancia"].Value.ToString();
                strRuta = "'" + confCollection["rutaFotografias"].Value.ToString() + "'";

                string constring = "server=" + host + ";user=" + usuario + ";pwd=" + password + ";database=" + instacia + "; pooling=false; convert zero datetime=True;";
                using (MySqlConnection connPeriodo = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmdPeriodo = new MySqlCommand())
                    {
                        
                        cmdPeriodo.Connection = connPeriodo;
                        cmdPeriodo.CommandText = "select DISTINCT peri_le from lecturas where peri_le>201506";
                        connPeriodo.Open();
                        MySqlDataReader rdrPeriodo = cmdPeriodo.ExecuteReader();
                        while (rdrPeriodo.Read())
                        {
                            cbPeriodo.Items.Add(rdrPeriodo.GetString("peri_le"));
                        }

                        cbPeriodo.SelectedIndex = cbPeriodo.Items.Count-1;
                        rdrPeriodo.Close();                                               
                    }

                    using(MySqlCommand cmdRutas =new MySqlCommand())
                    {
                        cmdRutas.Connection=connPeriodo;
                        cmdRutas.CommandText="select DISTINCT rutl_us from usuarios";
                        MySqlDataReader rdrRutas=cmdRutas.ExecuteReader();
                        while (rdrRutas.Read())
                        {
                            cbRutas.Items.Add(Convert.ToString(rdrRutas.GetInt32("rutl_us")));
                        }
                        cbRutas.SelectedIndex = 0;
                        rdrRutas.Close();
                    }


                    connPeriodo.Close();
                }


                
                //GenerarMapa();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
             
        }

        private void txtDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click(this, new EventArgs());
            }
        }

        public void GenerarMapa()
        {
            string arrDirs = string.Empty;
            double[] aLatitud = lLatidud.ToArray();
            double[] aLongitud = lLongitud.ToArray();

            StringBuilder textoHtml = new StringBuilder();
            // Entorno
            textoHtml.AppendLine(GetFromResources("MedidoresJCAS.mapa.html"));
            string TempFolder = Environment.GetEnvironmentVariable("TEMP");
            arrDirs = "[";
            for (int i = 0; i < aLatitud.GetLength(0); i++)
            {
                if (i != 0)
                {
                    arrDirs += ",";
                }
                arrDirs += "[" + aLatitud[i].ToString("g", new System.Globalization.CultureInfo("en-US"))
                    + "," + aLongitud[i].ToString("g", new System.Globalization.CultureInfo("en-US")) + "]";
            }
            arrDirs += "]";
            textoHtml.Replace("[[ADDRESS]]", arrDirs);


            string ficheroTemporalHTML = TempFolder + @"\" + "google.htm";
            bool existeFichero = false;
            try
            {
                existeFichero = CrearFicheroTexto(ficheroTemporalHTML, textoHtml);

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Text, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (existeFichero)
            {
                this.wbMapa.Navigate(ficheroTemporalHTML);

            }
        }

        public string GetFromResources(string resourceName)
        {
            Assembly assem = this.GetType().Assembly;
            using (Stream stream = assem.GetManifestResourceStream(resourceName))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Error de acceso al Recurso: '" + resourceName + "'\r\n" + e.ToString());
                }
            }
        }

        public bool CrearFicheroTexto(string Fichero, StringBuilder Contenido)
        {
            // Validaciones
            string Ruta = Path.GetDirectoryName(Fichero);
            if (!Directory.Exists(Ruta))
            {
                Directory.CreateDirectory(Ruta);
            }
            if (File.Exists(Fichero))
            {
                File.Delete(Fichero);
            }

            StreamWriter sw = File.CreateText(Fichero);
            sw.Write(Contenido.ToString());
            sw.Close();
            return true;
        }

        private void treeRutas_AfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode childNode in e.Node.Nodes)
            {
                childNode.Checked = e.Node.Checked;
            }
        }

        public void GenerarMapaFiltrado(Double[] aLatitud3,Double[] aLongitud3)
        {
            string arrDirs = string.Empty;

            StringBuilder textoHtml = new StringBuilder();
            // Entorno
            textoHtml.AppendLine(GetFromResources("MedidoresJCAS.mapa.html"));
            string TempFolder = Environment.GetEnvironmentVariable("TEMP");
            arrDirs = "[";
            for (int i = 0; i < aLatitud3.GetLength(0); i++)
            {
                if (i != 0)
                {
                    arrDirs += ",";
                }
                arrDirs += "[" + aLatitud3[i].ToString("g", new System.Globalization.CultureInfo("en-US"))
                    + "," + aLongitud3[i].ToString("g", new System.Globalization.CultureInfo("en-US")) + "]";
            }
            arrDirs += "]";
            textoHtml.Replace("[[ADDRESS]]", arrDirs);


            string ficheroTemporalHTML = TempFolder + @"\" + "google.htm";
            bool existeFichero = false;
            try
            {
                existeFichero = CrearFicheroTexto(ficheroTemporalHTML, textoHtml);

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Text, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (existeFichero)
            {
                this.wbMapa.Navigate(ficheroTemporalHTML);

            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            //BotonGenerar();
           // Enrutar();
        }

        public void Enrutar(List<TomaDomiciliaria> lTomas)
        {
            int idMarker = 1;
            string strScript = "[";
            string strBloque = "";
            string strBloques = "";

            foreach (TomaDomiciliaria tomaActual in lTomas)
            {
                strBloque = "{" +
                "title: '" + tomaActual.Cuenta + "'," +
                "lat: '" + tomaActual.Latitud + "'," +
                "lng: '" + tomaActual.Longitud + "'," +
                "img: '" + tomaActual.Cuenta + "_" + tomaActual.Periodo + "'," +
                "description: '" + tomaActual.Cuenta +"-"+tomaActual.NomUsuario+ "'," +
                "animation: google.maps.Animation.DROP," +
                "icon: 'C:/MedidoresJCAS/Marcadores/" + idMarker.ToString() + ".png'" +
                "},";
                strBloques = strBloques + strBloque;
            }

            strScript = strScript + strBloques.Substring(0, strBloques.Length - 1) + "]";

            StringBuilder textoHtml = new StringBuilder();
            // Entorno
            textoHtml.AppendLine(GetFromResources("MedidoresJCAS.mapaRutas.html"));
            string TempFolder = Environment.GetEnvironmentVariable("TEMP");
            textoHtml.Replace("[[ADDRESS]]", strScript);
            // strRuta = "'" + strRuta + "'";
            textoHtml.Replace("IMAGENES", strRuta);
            string ficheroTemporalHTML = TempFolder + @"\" + "google.htm";
            bool existeFichero = false;
            try
            {
                existeFichero = CrearFicheroTexto(ficheroTemporalHTML, textoHtml);

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Text, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (existeFichero)
            {
                this.wbMapa.Navigate(ficheroTemporalHTML);

            }
        }

        private void btnRuta_Click(object sender, EventArgs e)
        {
            //Enrutar();
        }

        private void btnPeriodo_Click(object sender, EventArgs e)
        {
            try
            {
                List<TomaDomiciliaria> lTomas = new List<TomaDomiciliaria>();

                Configuration configManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                KeyValueConfigurationCollection confCollection = configManager.AppSettings.Settings;

                String host = confCollection["host"].Value.ToString();
                String usuario = confCollection["usuario"].Value.ToString();
                String password = confCollection["password"].Value.ToString();
                String instacia = confCollection["instancia"].Value.ToString();
                string constring = "server=" + host + ";user=" + usuario + ";pwd=" + password + ";database=" + instacia + "; pooling=false; convert zero datetime=True;";

                using (MySqlConnection connDirecciones = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmdDirecciones = new MySqlCommand())
                    {
                        cmdDirecciones.Connection = connDirecciones;
                        cmdDirecciones.CommandText = "select lecturas.usua_le AS usua_le,usuarios.rutl_us AS rutl_us,usuarios.secl_us AS secl_us,usuarios.nomb_us AS nomb_us, "
                                + " lecturas.peri_le AS peri_le, lecturas.longitud_le as Longitud, lecturas.latitud_le as Latitud "
                                + " from ((usuarios join lecturas)) "
                                + " where ((usuarios.clav_us = lecturas.usua_le)) "
                                + " and usuarios.rutl_us=@strRuta"
                                + " and lecturas.peri_le=@strPeriodo"
                                + " ORDER BY  usuarios.secl_us";
                        cmdDirecciones.Parameters.AddWithValue("@strRuta", cbRutas.Text);
                        cmdDirecciones.Parameters.AddWithValue("@strPeriodo", cbPeriodo.Text);
                        connDirecciones.Open();
                        MySqlDataReader rdrDirecciones = cmdDirecciones.ExecuteReader();
                        lTomas=new List<TomaDomiciliaria>();
                        while(rdrDirecciones.Read())
                        {
                            TomaDomiciliaria nuevaToma = new TomaDomiciliaria();
                            nuevaToma.Cuenta = rdrDirecciones.GetString("usua_le");
                            nuevaToma.Latitud = rdrDirecciones.GetString("Latitud");
                            nuevaToma.Longitud = rdrDirecciones.GetString("Longitud");
                            nuevaToma.Periodo = rdrDirecciones.GetString("peri_le");
                            nuevaToma.NomUsuario = rdrDirecciones.GetString("nomb_us");

                            double lon = Convert.ToDouble(nuevaToma.Latitud);

                            if (lon!=0)
                            {
                                lTomas.Add(nuevaToma);
                            }
                        }
                        rdrDirecciones.Close();
                    }
                    connDirecciones.Close();
                }
                if (lTomas.Count > 0)
                {
                    Enrutar(lTomas);
                }
                else
                {
                    MessageBox.Show("Atención: No Hay Registros De Geo localización ", "Atención");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR");
            }
        }

        private void revisionDeCuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
