using CarAlexCrud2000.Core.Aplication.ViewModels.Estatus;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAlexCrud2000.Core.Aplication.ViewModels.Autos
{
    public class SaveAutoViewModel
    {
        public int IdAuto { get; set; }
        [Required(ErrorMessage = "Debe colocar la marca del carro")]
        public string Marca { get; set; }
        public string ImgRuta { get; set; }
        [Required(ErrorMessage = "Debe colocar el modelo del carro")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "Debe colocar el año del carro")]
        public string Year { get; set; }
        [Range(1,int.MaxValue, ErrorMessage = "Debe colocar el estatus del carro")]
        public int miEstatusId { get; set; }

        public List<EstatusViewModel> EstatusList { get; set; }
    }
}
