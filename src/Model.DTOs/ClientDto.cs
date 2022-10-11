using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DTOs
{
    public class ClientCreateDto
    {
        public string Name { get; set; }
    }

    public class ClientDto
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
    }
}
