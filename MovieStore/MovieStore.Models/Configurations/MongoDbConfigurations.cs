using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Models.Configurations
{
    public class MongoDbConfigurations
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
