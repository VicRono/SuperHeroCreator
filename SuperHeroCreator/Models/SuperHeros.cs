using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperHeroCreator.Models
{
    public class SuperHeros
    {
       [Key]
        public int SuperheroId{ get; set; }
        public string SuperheroName { get; set; }
        public string HerosAlterEgo { get; set; }
        public string PrimaryAbility { get; set; }
        public string SecondaryAbility { get; set; }
        public string CatchPhrase { get; set; }

    }
}