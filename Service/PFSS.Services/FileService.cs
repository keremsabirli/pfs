using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using PrivateFileStorageService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PFSS.Services
{
    public class FileService : BaseService<Models.File>
    {
        public GridFSBucket Bucket { get; set; }
        public FileService(IDatabaseSettings settings) : base(settings)
        {
            Bucket = new GridFSBucket(database, new GridFSBucketOptions
            {
                BucketName = "filebucket",
                ChunkSizeBytes = 1048576, // 1MB
                WriteConcern = WriteConcern.WMajority,
                ReadPreference = ReadPreference.Secondary
            });
        }
        public async override Task<Models.File> GetById(string id)
        {
            return await base.GetById(id);
        }
        public async Task<bool> Upload(IFormFile formFile)
        {
            var physicalFileId = await Bucket.UploadFromStreamAsync(formFile.FileName, formFile.OpenReadStream());
            var file = new Models.File()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Name = formFile.FileName,
                Extension = formFile.ContentType,
                PhysicalFileId = physicalFileId.ToString()
            };
            await Add(file);
            return true;
        }
        
    }
}
