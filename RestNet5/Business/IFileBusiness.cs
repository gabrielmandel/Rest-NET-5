using Microsoft.AspNetCore.Http;
using RestNet5.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestNet5.Business
{
    public interface IFileBusiness
    {
        public byte[] GetFile(string fileName);

        public Task<FileDetailVO> SaveFileToDisk(IFormFile file);
        public Task<List<FileDetailVO>> SaveMultipleFileToDisk(IList<IFormFile> file);
    }
}
