using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfGestionContra.Elementos;
using WpfGestionContra.logica;
using WpfGestionContra.ventanas;

namespace WpfGestionContra
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Creacion del objeto logica de negocio
        Logica logica = new Logica();
        public MainWindow()
        {
            InitializeComponent();
        }

        //hace el login del usuario y valida si los campos son correctos
        private void btAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (logica.getUsuarios().ContainsKey(tbUsuario.Text))
            {
                Usuario user;
                logica.getUsuarios().TryGetValue(tbUsuario.Text, out user);
                if (user.Contrasenna.Equals(tbContrasenna.Text))
                {
                    Inicio ini = new Inicio(paselogica: logica);
                    ini.Show();
                }
                else
                {
                    MessageBox.Show("La contraseña es incorrecta", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("El usuario no existe", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
           
        }

        //Creacion de la pagina de registro de usuario
        private void lblRegistro_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Registro reg = new Registro(paselogica: logica);
            reg.Show();
        }

        //accion del boton para limpiar los campos
        private void btLimpiar_Click(object sender, RoutedEventArgs e)
        {
            tbUsuario.Text = "";
            tbContrasenna.Text = "";
        }

        //Creacion de la pagina de visualizacion de usuarios
        private void btVerUser_Click(object sender, RoutedEventArgs e)
        {
            VerUsuarios ver = new VerUsuarios(paselogica: logica);
            ver.Show();
        }
    }
}
