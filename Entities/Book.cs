using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caso_Di_Studio.Entities
{
    public class Book
    {
      public int Id { get; set; }
      public string? Titolo { get; set; }
      public string? Anno { get; set; }
      public string? Descrizione { get; set; }
    }
}