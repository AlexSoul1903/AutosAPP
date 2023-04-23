using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAlexCrud2000.Core.Aplication.ViewModels.Estatus
{
    public class SaveEstatusViewModel
    {
        public int IdEstatus { get; set; }
        [Required(ErrorMessage = "Debe colocar la descripcion del estatus")]
        public string Descripcion { get; set; }
       


    }
}
