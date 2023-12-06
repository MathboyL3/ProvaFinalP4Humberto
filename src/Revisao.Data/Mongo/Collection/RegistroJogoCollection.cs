using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao.Data.Mongo.Collection
{
    [CollectionName("RegistroJogo")]
    public class RegistroJogoCollection : Document
    {
        public int primeiroNumero { get; set; }
        public int segundoNumero { get; set; }
        public int terceiroNumero { get; set; }
        public int quartoNumero { get; set; }
        public int quintoNumero { get; set; }
        public int sextoNumero { get; set; }
    }
}
