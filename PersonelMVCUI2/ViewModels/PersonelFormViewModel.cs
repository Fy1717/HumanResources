using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonelMVCUI2.Models.EntityFramework;

namespace PersonelMVCUI2.ViewModels
{
    public class PersonelFormViewModel
    {
        
        public IEnumerable<Departman> Departmanlar { get; set; }
        public Personel Personel { get; set; }
    }
}