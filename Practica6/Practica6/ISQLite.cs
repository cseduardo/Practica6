using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;

namespace Practica6
{
    public interface ISQLite
    {
        string GetLocalFilePath(string filename);
    }
}