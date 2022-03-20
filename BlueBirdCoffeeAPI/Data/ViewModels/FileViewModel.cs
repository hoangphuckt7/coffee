using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class FileViewModel
    {
        public Guid Id { get; set; }
        public string? FileType { get; set; } = "image/jpeg";
        public byte[]? Data { get; set; }
    }
}
