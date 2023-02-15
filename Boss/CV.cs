using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CV
{
    public class CVc
    {
        public string Qualification { get; set; }
        public string School { get; set; }
        public string UniversityScore { get; set; }
        public  List<string> Skills { get; set; }
        public List<string> Companies { get; set; }
        public string StartTime { get; set; } 
        public string EndTime { get; set; }
        public List<string> Languages { get; set; }
        public bool HasHonorDiplom { get; set; } = false;
        public string GitLink { get; set; } = null;
        public string Linkedin { get; set; } = null;
    }
}
