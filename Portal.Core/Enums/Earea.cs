using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Core.Enums
{

    public enum Earea
    {
        [Display(Name = "Direitos e Vulnerabilidades")]
        DireitosEVulnerabilidades,

        [Display(Name = "Maternidade Solo")]
        MaternidadeSolo,

        [Display(Name = "Ambulantes no Carnaval")]
        AmbulantesNoCarnaval,

        [Display(Name = "Racismo Ambiental")]
        RacismoAmbiental,

        [Display(Name = "Saúde Pública")]
        SaudePublica,

        [Display(Name = "Violência e Gênero")]
        ViolenciaEGenero,

        [Display(Name = "Pessoas com Deficiência")]
        PessoasComDeficiencia
    }

}
