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
using System.Windows.Shapes;
using WpfGestionContra.Elementos;
using WpfGestionContra.logica;

namespace WpfGestionContra
{
    /// <summary>
    /// Lógica de interacción para Registro.xaml
    /// </summary>
    public partial class Registro : Window
    {
        public Usuario usuarioModelo;
        private int errores;
        Logica logica;
        public Registro(Logica paselogica)
        {
            InitializeComponent();
            logica = paselogica;
            usuarioModelo = new Usuario();
            //Datacontext del modelo inicializado para poder aplicar validaciones
            this.DataContext = usuarioModelo;
        }

        //Accion del boton para cerrar la ventana
        private void btSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Accion para validar y agregar al usuario
        private void btRegistrar_Click(object sender, RoutedEventArgs e)
        {
            
            if (logica.getUsuarios().ContainsKey(tbUsuario.Text))
            {
                // ya existe el usuario
                MessageBox.Show("El usuario ya existe", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else if (tbContrasenna.Text.Equals(tbContrasennaConf.Text))
            {
                Usuario user = new Usuario(tbUsuario.Text, tbContrasenna.Text, tbCorreo.Text);
                logica.aggUsuario(user);
                this.Close();
            }
            else
            {
                //ventana de que contraseñas no coinciden
                MessageBox.Show("La contraseñas no coinciden", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            } 
        }

        //Enlace que habilita o deshabilita el boton si hay o no errores
        public void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                errores++;
            else
                errores--;

            if (errores == 0)
                btRegistrar.IsEnabled = true;
            else
                btRegistrar.IsEnabled = false;
        }
    }
}
