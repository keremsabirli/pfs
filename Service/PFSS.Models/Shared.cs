﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFSS.Models
{
    public abstract class Shared
    {
        [BsonId]
        public string BsonId { get; set; } = new BsonObjectId(ObjectId.GenerateNewId()).ToString();
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
    }
}
