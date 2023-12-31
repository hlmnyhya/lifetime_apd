//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace lifetime_apd
{
    using System;
    using System.Collections.Generic;
    
    public partial class karyawan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public karyawan()
        {
            this.peminjamen = new HashSet<peminjaman>();
            this.penerimaans = new HashSet<penerimaan>();
            this.permintaans = new HashSet<permintaan>();
        }
    
        public int ID { get; set; }
        public Nullable<int> ID_USERS { get; set; }
        public Nullable<int> ID_UNIT { get; set; }
        public string NIP { get; set; }
        public string NAMA { get; set; }
        public string JABATAN { get; set; }
        public string JENIS_KELAMIN { get; set; }
        public Nullable<System.DateTime> TANGGAL_LAHIR { get; set; }
        public string ALAMAT { get; set; }
        public string STATUS_PENERIMAAN { get; set; }
    
        public virtual unit unit { get; set; }
        public virtual user user { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<peminjaman> peminjamen { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<penerimaan> penerimaans { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<permintaan> permintaans { get; set; }
    }
}
