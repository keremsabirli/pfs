using PFSS.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PFSS.ViewModels
{
    public class DirectoryViewModel : BaseViewModel
    {
        public string Name { get; set; }
        /// <summary>
        /// Id of the User who created this directory.
        /// </summary>
        public string CreatorId { get; set; }
        public string ParentDirectoryId { get; set; }
        public List<DirectoryViewModel> ChildDirectories { get; set; }
        public List<string> ChildFileIds { get; set; }
    }
}
