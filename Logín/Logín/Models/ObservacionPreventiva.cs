using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logín.Models
{
    public class ObservacionPreventiva
    {
        public Guid ObPreId { get; set; }
        public String ObPreTipo { get; set; }
        public String ObPreActoSubEsta { get; set; }
        public String ObPreCondicionSubEsta { get; set; }
        public String ObPreDaño { get; set; }
        public String ObPreArea { get; set; }
        public String ObPreLugar { get; set; }
        public String ObPreNombreObservador { get; set; }
        public String ObPreNombreObservadorFecha { get; set; }
        public String ObPreNombreObservada { get; set; }
        public String ObPreNombreObservadaFecha { get; set; }
        public String ObPreJefe { get; set; }
        public String ObPreDescripcion{ get; set; }
        public String ObPreMediCorrectiva { get; set; }
        public String ObPreCompromiso { get; set; }
        public String ObPreFechaLevantamiento { get; set; }

        
    }
    
}
