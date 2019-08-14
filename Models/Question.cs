using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace acme_backend.Models
{
    public class Question
    {
        public int ID { get; set; }
        public string Chart { get; set; }
        public string TimeSeries { get; set; }
        public string Units { get; set; }
        public int ProjectId { get; set; }
    }
}
