using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurniTOOLS.Models
{
    public class AdminDatabaseSettings:IAdminDatabaseSettings
    {
        public string AdminsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IAdminDatabaseSettings
    {
        public string AdminsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
