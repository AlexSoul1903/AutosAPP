using CarAlexCrud2000.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAlexCrud2000.Core.Domain.Entities
{
    public class Estatus:AuditBaseEntity
    {
        public int IdEstatus { get; set; }
        public string Descripcion { get; set; }


        //Un estatus puede tener muchos carros.

        //Navegation propety
        public ICollection<Autos> Autos { get; set; }

    }
}
