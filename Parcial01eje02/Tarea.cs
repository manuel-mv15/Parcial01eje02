using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial01eje02
{
    internal class Tarea
    {
        private string nombre;
        private string dia;
        private string priodidad;

        public Tarea()
        {

        }

        public Tarea(string nombre, string dia, string priodidad)
        {
            this.Setnombre(nombre);
            this.Setdia(dia);
            this.SetPriodidad(priodidad);
        }

        private string Getnombre()
        {
            return nombre;
        }

        private void Setnombre(string value)
        {
            nombre = value;
        }


        public string Getdia()
        {
            return dia;
        }

        public void Setdia(string value)
        {
            dia = value;
        }


        public string GetPriodidad()
        {
            return priodidad;
        }

        public void SetPriodidad(string value)
        {
            priodidad = value;
        }

       

        public override string ToString()
        {
            return $"Nombre: {Getnombre()}, Dia: {Getdia()}, Prioridad: {GetPriodidad()}";
        }


        
    }
}
