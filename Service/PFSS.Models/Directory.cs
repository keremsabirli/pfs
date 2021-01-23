using System;
using System.Collections.Generic;
using System.Text;

namespace PFSS.Models
{
    public class Directory : Shared
    {
        public string Name { get; set; }
        /// <summary>
        /// Id of the User who created this directory.
        /// </summary>
        public string CreatorId { get; set; }
        public string ParentDirectoryId { get; set; }
    }
}
