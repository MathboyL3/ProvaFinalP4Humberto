using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao.Data.Mongo.Interfaces
{
    public interface IDocument
    {
        ObjectId id { get; }
        DateTime CreationDate => id.CreationTime;
    }
}
