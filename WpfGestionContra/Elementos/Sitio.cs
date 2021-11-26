using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGestionContra.NewFolder
{
    public class Sitio : INotifyPropertyChanged
    {
        private String nombre;
        public String Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("nombre"));
            }
        }
        private String contrasenna;
        public String Contrasenna
        {
            get
            {
                return this.contrasenna;
            }
            set
            {
                this.contrasenna = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("contrasenna"));
            }
        }
        private DateTime fecha;
        public DateTime Fecha
        {
            get
            {
                return this.fecha;
            }
            set
            {
                this.fecha = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("fecha"));
            }
        }
        //constructor con fecha predeterminada
        public Sitio(String nombre, String contra)
        {
            this.nombre = nombre;
            this.contrasenna = contra;
            this.fecha = DateTime.Now.AddDays(90);
        }
        //constructor con todos los campos
        public Sitio(String nombre, String contra, DateTime fecha)
        {
            this.nombre = nombre;
            this.contrasenna = contra;
            this.fecha = fecha;
        }
        //constructor vacio
        public Sitio()
        {

        }
        //aplicacion de interfaz de cambio de las propiedades
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
