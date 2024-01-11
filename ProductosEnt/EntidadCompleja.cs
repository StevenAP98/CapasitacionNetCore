using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Presupuestos.Entities.General
{
    public class EntidadCompleja<T>
    {
        //public BitacoraErrores Bitacora { get; set; }
        public T Entidad { get; set; }
        //public List<AdjuntosAPI> ListaAdjuntos { get; set; }
        //public List<Adjuntos> ListaAdjuntosBorrar { get; set; }
        //public List<ContactosMiembrosInstancias> ListaContactosMiembros { get; set; }
    }
}
