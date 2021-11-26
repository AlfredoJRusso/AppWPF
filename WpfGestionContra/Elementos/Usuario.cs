using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGestionContra.Elementos
{
    public class Usuario : IDataErrorInfo, ICloneable, INotifyPropertyChanged
    {
        //getters y setters personalizados para evitar excepcion en la llamada de cambio de la propiedad
        private String nombre;
        public String Nombre {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
                if(PropertyChanged != null)
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
                if (PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs("contrasenna"));
            }
        }
        private String correo;
        public String Correo
        {
            get
            {
                return this.correo;
            }
            set
            {
                this.correo = value;
                if (PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs("correo"));
            }
        }
        //constructor con todos los campos
        public Usuario(String nombre, String contra, String correo)
        {
            this.Nombre = nombre;
            this.Contrasenna = contra;
            this.Correo = correo;
        }
        //constructor vacio
        public Usuario()
        {

        }
        //aplicacion de interfaz de cambio de las propiedades
        public event PropertyChangedEventHandler PropertyChanged;

        //Sobrecarga del metodo toString
        public override string ToString()
        {
            return "Nombre usuario: " + Nombre + ", Contraseña: ******, Correo: " + Correo; 
        }

        //implementacion de validacion de errores
        public string Error => throw new NotImplementedException();

        //implementacion de validacion de errores y definicion del error
        public string this[string columnName]
        {
            get
            {
                String Error = "";
                if (columnName == "Nombre")
                {
                    if (string.IsNullOrEmpty(Nombre))
                        Error = "Debe introducir el nombre de usuario";
                }
                if (columnName == "Contrasenna")
                {
                    if (string.IsNullOrEmpty(Contrasenna))
                        Error = "Debe introducir la contraseña de la cuenta";
                }
                if (columnName == "Correo")
                {
                    if (string.IsNullOrEmpty(Correo))
                        Error = "Debe introducir el correo de la cuenta";
                }
                return Error;
            }
        }

        //Implementacion del metodo IClonable
        public Object Clone()
        {
            return this.MemberwiseClone();
        }

    }
}
