using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPulsePro.Builders
{
    public class CreateUpdateBuilderProfileDto
    {
        [Required]
        [StringLength(BuilderProfileConsts.MaxNameLength)]
        public string Name { get; set; } = string.Empty;
    }
}
