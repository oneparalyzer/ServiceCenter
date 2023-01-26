using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oneparalyzer.ServiceCenter.UseCases.DTOs.Client
{
    public class UpdateClientDTO : AddClientDTO
    {
        public int Id { get; set; }
    }
}
