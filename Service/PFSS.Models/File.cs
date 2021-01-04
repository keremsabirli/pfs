using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace PFSS.Models
{
    public class File : Shared
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public string PhysicalFileId { get; set; }
    }
}
