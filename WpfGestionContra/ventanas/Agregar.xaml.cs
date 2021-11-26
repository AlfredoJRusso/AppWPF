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
    /// Lógica de interacción para Agregar.xaml
    /// </summary>
    public partial class Agregar : Window
    {
        Logica logica;
        public Agregar(Logica paselogica)
        {
            logica = paselogica;
            InitializeComponent();
            //binding de combobox
            cbSitios.ItemsSource = logica.getSitios();

            /*  Metodo sin binding
            foreach(Sitio sitio in listaSitios)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = sitio;
                cbSitios.Items.Add(cbi);
            }
            */

        }


        private void cbSitios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbSitios.IsEditable = false;
        }

        //metodo para agregar sitios con las validaciones necesarias
        private void btAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (tbSitio.Text.Equals("") && tbContrasenna.Text.Equals(""))
            {
                MessageBox.Show("Los campos de sitio y contraseña deben estar llenos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (tbSitio.Text.Equals("Sugerencia"))
                {
                    if (MessageBox.Show("El \"Sugerencia\" como sitio seleccionado, esta seguro?", "Error", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        agregar();
                    }
                }
                else
                {
                    agregar();
                    MessageBox.Show("El sitio ha sido agregado", "Exito", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    
                }

                this.Close();
            }
            
        }
        //metodo para habilitar el campo de la fecha 
        private void checkbFecha_Checked(object sender, RoutedEventArgs e)
        {
            dpFecha.IsEnabled = true;
        }

        //metodo para deshabilitar el campo de la fecha 
        private void checkbFecha_Unchecked(object sender, RoutedEventArgs e)
        {
            dpFecha.IsEnabled = false;
        }

        //metodos para cerrar la ventana
        private void btVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //metodo que ingresa los datos a la logica de negocio
        private void agregar()
        {
            if (dpFecha.IsEnabled)
            {
                logica.getLista().Add(new Sitio(tbSitio.Text, tbContrasenna.Text, (DateTime)dpFecha.SelectedDate));
            }
            else
            {
                logica.getLista().Add(new Sitio(tbSitio.Text, tbContrasenna.Text));
                //tbContrasenna.Text = lista.getLista().ToString();
            }
 
        }


        /*Metodo sin bonding
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = (ComboBoxItem)cbSitios.SelectedItem;
            Sitio sit = (Sitio)cbi.Content;
            lblSitio.Content = sit.Nombre; //queria cambiar el texto

        }
        */
    }


    }
