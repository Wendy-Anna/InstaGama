using InstaGama.Domain.Entities.ValueObject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace InstaGama.Domain.Core.Interfaces
{
    public interface IStorageHelper
    {
        Task<ImageBlob> Upload(Stream stream, string nameFile);
        bool IsImage(string nameFile);
    }
}
