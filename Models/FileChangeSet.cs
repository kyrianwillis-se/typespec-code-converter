using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeSpecCodeConverter.Models
{
    public class FileChangeSet
    {
        public bool HaveChangedFiles { get { return NewFiles.Any() && UpdatedFiles.Any(); } }

        public IEnumerable<string> NewFiles { get; set; }
        public IEnumerable<string> UpdatedFiles { get; set; }
    }
}
