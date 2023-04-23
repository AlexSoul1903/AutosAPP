using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAlexCrud2000.Core.Aplication.ViewModels.Autos
{
    public class AutoViewModel
    {

        public int IdAuto { get; set; }
        public string Marca { get; set; }
        public string ImgRuta { get; set; }
        public string Modelo { get; set; }
        public string Year { get; set; }
        public int IdEstatus { get; set; }

        public string EstatusDescripcion { get; set; }
    }
}
