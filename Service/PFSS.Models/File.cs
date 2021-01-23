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
        public Directory ParentDirectory { get; set; }
        public User User { get; set; }
    }
}
