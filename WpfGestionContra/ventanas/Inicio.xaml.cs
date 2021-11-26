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
using WpfGestionContra.NewFolder;

namespace WpfGestionContra
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Inicio : Window
    {
        Logica logica;
        public Inicio(Logica paselogica)
        {
            logica = paselogica;
            InitializeComponent();
            // dgTabla.ItemsSource = logic.getLista();

            //binding del datagrid
            dgTabla.DataContext = logica;

        }

        private void btAgregar_Click(object sender, RoutedEventArgs e)
        {
            //accion del boton que crea la proxima ventana y pasa el objeto logica
            Agregar agg = new Agregar(paselogica: logica);
            agg.Show();
        }

        //Accion del boton para cerrar la ventana
        private void btSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //metodo que elimina el item seleccionado
        private void btEliminar_Click(object sender, RoutedEventArgs e)
        {
            if(dgTabla.SelectedIndex != -1)
            {
                //se hace un remove mediante la posicion del elemento
                Logica.listaSit.Remove(Logica.listaSit[dgTabla.SelectedIndex]);
            }

        }

        //metodo que habilita la modificacion del campo seleccionado
        private void btModificar_Click(object sender, RoutedEventArgs e)
        {
            if (dgTabla.SelectedIndex != -1)
            {
                //se hace la modificacion mediante la posicion del elemento
                tbModSitio.Text = Logica.listaSit[dgTabla.SelectedIndex].Nombre;
                tbModContra.Text = Logica.listaSit[dgTabla.SelectedIndex].Contrasenna;

                //muestra los campos para modificar
                btModConf.Visibility = Visibility.Visible;
                tbModContra.Visibility = Visibility.Visible;
                tbModSitio.Visibility = Visibility.Visible;
                dpModFecha.Visibility = Visibility.Visible;
            }
        }

        //metodo que modifica el item seleccionado
        private void btModConf_Click(object sender, RoutedEventArgs e)
        {
            /*
            tbModSitio.Text = Logica.listaSit[dgTabla.SelectedIndex].Nombre;
            tbModContra.Text = Logica.listaSit[dgTabla.SelectedIndex].Contrasenna;
            */

            //modifica el objeto de la lista
            Logica.listaSit[dgTabla.SelectedIndex].Nombre = tbModSitio.Text;
            Logica.listaSit[dgTabla.SelectedIndex].Contrasenna = tbModContra.Text;
            Logica.listaSit[dgTabla.SelectedIndex].Fecha = (DateTime)dpModFecha.SelectedDate;

            //esconde los campos para modificar
            btModConf.Visibility = Visibility.Hidden;
            tbModContra.Visibility = Visibility.Hidden;
            tbModSitio.Visibility = Visibility.Hidden;
            dpModFecha.Visibility = Visibility.Hidden;
        }
    }
}
