using System;
using System.Linq;
using System.Threading.Tasks;

namespace lifetime_apd.Models
{
    public class DashboardModels
    {
        public int PeminjamanCount { get; set; }
        public int PenerimaanCount { get; set; }
        public int PengadaanCount { get; set; }
        public int PermintaanCount { get; set; }

        // Constructor to initialize properties or perform any setup logic
        public DashboardModels()
        {
            // You can initialize properties or perform any setup logic here if needed
        }

        // Method to get the count of records from the database
        public int GetPeminjamanCount()
        {
            try
            {
                using (var db = new lifetime_apdEntities())
                {
                    return db.peminjamen.Count();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log the error)
                return 0; // Return a default value or handle the error accordingly
            }
        }

        public int GetPenerimaanCount()
        {
            try
            {
                using (var db = new lifetime_apdEntities())
                {
                    return db.penerimaans.Count();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log the error)
                return 0; // Return a default value or handle the error accordingly
            }
        }

        public int GetPengadaanCount()
        {
            try
            {
                using (var db = new lifetime_apdEntities())
                {
                    return db.pengadaans.Count();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log the error)
                return 0; // Return a default value or handle the error accordingly
            }
        }

        public int GetPermintaanCount()
        {
            try
            {
                using (var db = new lifetime_apdEntities())
                {
                    return db.permintaans.Count();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log the error)
                return 0; // Return a default value or handle the error accordingly
            }
        }
    }
}
