//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PersonelMVCUI2.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class Personel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Personel()
        {
            this.Works = new HashSet<Works>();
        }
    
        public int Id { get; set; }
        public Nullable<int> DepartmanId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public Nullable<double> Maas { get; set; }
        public Nullable<System.DateTime> DogumTarihi { get; set; }
        public Nullable<bool> Cinsiyet { get; set; }
        public Nullable<bool> EvliMİ { get; set; }
    
        public virtual Departman Departman { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Works> Works { get; set; }
    }
}
