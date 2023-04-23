using CarAlexCrud2000.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAlexCrud2000.Core.Domain.Entities
{

    public class Autos: AuditBaseEntity
    {
        public int IdAuto { get; set; }
        public string Marca { get; set; }
        public string ImgRuta { get; set; }
        public string Modelo { get; set; }
        public string Year { get; set; }



        public int miEstatusId { get; set; }
        public int miUserId { get; set; }
        //Navegation Property permite navegar en el estatus que tenga ese carro asociado.
        //permite configurar las relaciones.

        //Un carro puede tener 1 Estatus. 
        public Estatus estatus { get; set; }


        public Users user { get; set; }
    }

}
