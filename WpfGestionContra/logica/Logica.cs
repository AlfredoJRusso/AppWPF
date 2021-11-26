using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfGestionContra.Elementos;
using WpfGestionContra.NewFolder;

namespace WpfGestionContra.logica
{
    public class Logica
    {
        //Distintas listas utilizadas en el programa
        public static ObservableCollection<Sitio> listaSit { get; set; }
        static Dictionary<String, Usuario> DicUsuarios { get; set; }
        public static ObservableCollection<Usuario> colUsuarios { get; set; }
        static Boolean prim = true;
        public Logica()
        {
            if (prim)
            {
                DicUsuarios = new Dictionary<string, Usuario>();
                Usuario User1 = new Usuario("Admin", "123456", "alfredorusso08@gamil.com");
                Usuario User2 = new Usuario("Alfredo", "asdqwe", "alfredorusso08@gamil.com");
                DicUsuarios.Add("Admin", User1);
                DicUsuarios.Add("Alfredo", User2);

                colUsuarios = new ObservableCollection<Usuario>();
                colUsuarios.Add(User1);
                colUsuarios.Add(User2);
            }

            listaSit = new ObservableCollection<Sitio>();

            listaSit.Add(new Sitio("Facebook", "asdqwe123"));
            listaSit.Add(new Sitio("Instragram", "asdqwe123"));
            listaSit.Add(new Sitio("Twitter", "asdqwe123"));
        }
        public void aggUsuario(Usuario user)
        {
            DicUsuarios.Add(user.Nombre, user);
        }

        public Dictionary<String, Usuario> getUsuarios()
        {
            return DicUsuarios;
        }
        public ObservableCollection<Sitio> getLista()
        {
            return listaSit;
        }

        public List<String> getSitios()
        {
            List<String> lista = new List<string>();
            foreach (Sitio sit in listaSit)
            {
                lista.Add(sit.Nombre);
            }
            return lista;
        }

    }
}
