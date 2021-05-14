using MySqlConnector;
using ProyectoZ;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FolderMedia_tools
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_button_Click(object sender, EventArgs e)
        {

            login_info.Text = "Intentando conectar.................";

            MySqlConnection con = new MySqlConnection(
                "Server=ds.hack3.cat; Port=33066; User ID=proyectoz_tools; Password=08139724; Database=desktop_apps");

            try
            {
                con.Open();

                Console.WriteLine($"MySQL version : {con.ServerVersion}");

                var stm = "SELECT actiu, id, nom from myapps_users where nom='"+user.Text+"' and pwd='"+pwd.Text+"'";
                var cmd = new MySqlCommand(stm, con);
                //"myapps_users"
                var sc = cmd.ExecuteScalar();
                con.Close();
                if (sc==null)
                {
                    login_info.Text = "Login incorrecto.";
                    MessageBox.Show("El usuario o password introducido no es correcto.");
                    return;
                } else if (!"1".Equals(sc.ToString()))
                {
                    login_info.Text = "Usuario deshabilitado.";
                    MessageBox.Show("Login correcto pero usuario deshabilitado. Por favor, contacte con el administrador.");
                    return;
                }
                login_info.Text = "CORRECTO"; 
                this.Hide();
                
            } catch (Exception ex) {
                login_info.Text = "Error intentando conectar al servidor.";
                MessageBox.Show("Ha ocurrido un error haciendo login. Asegurese que está conectado a internet. Motivo: "+ex);
            }
        }
    }
}
