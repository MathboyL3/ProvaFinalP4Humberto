using MongoDB.Bson;
using Revisao.Data.Mongo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao.Data.Mongo
{
    public class Document : IDocument
    {
        public ObjectId id { get; set; }
        public DateTime CreationDate => id.CreationTime;
    }
}
