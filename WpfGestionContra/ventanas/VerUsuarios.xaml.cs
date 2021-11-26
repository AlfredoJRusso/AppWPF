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

namespace WpfGestionContra.ventanas
{
    /// <summary>
    /// Lógica de interacción para VerUsuarios.xaml
    /// </summary>
    public partial class VerUsuarios : Window
    {

        Usuario Seleccionado;
        Usuario clon;
        public VerUsuarios(Logica paselogica)
        {
            InitializeComponent();
            //Datacontext para el binding del data grid
            dgUsuarios.DataContext = paselogica;            
        }

        //Accion del boton para salir de la ventana
        private void btSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Coge los datos para modificar el usuario seleccionado
        private void dgUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //copia los objetos, crea un clon y asigna el data context a los datos
            Seleccionado = (Usuario)dgUsuarios.SelectedItem;
            clon = (Usuario)Seleccionado.Clone();
            tbCorreo.DataContext = clon;
            tbUsuario.DataContext = clon;
        }

        //Cambia los datos del objeto al pulsar el boton
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Reasigna el Datacontex para el binding e ingresa los datos del clon
            tbCorreo.DataContext = Seleccionado;
            tbUsuario.DataContext = Seleccionado;
            Seleccionado.Correo = clon.Correo;
            Seleccionado.Nombre = clon.Nombre;
        }
    }
}
