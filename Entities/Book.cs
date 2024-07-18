using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Caso_Di_Studio.Entities;

namespace Caso_Di_Studio.Entities
{
    public class Book
    {
      public int Id { get; set; }
      public string Titolo { get; set; }
      public string Anno { get; set; }
      public string Descrizione { get; set; }
      public int CategoryId { get; set; }
      [JsonIgnore]
      public Category? Category { get; set; }
    }
}