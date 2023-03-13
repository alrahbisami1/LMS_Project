using BOL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileLMS = BOL.Data.File;

namespace BOL
{
    public interface IFileData
    {

        void Add(FileLMS file);
        void Update(FileLMS file);
        void Delete(FileLMS file);
       
        FileLMS GetFileById(int id);

        List<FileLMS> GetAllFiles();
    }
}
