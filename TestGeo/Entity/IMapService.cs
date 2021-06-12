using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGeo.Entity
{
    public interface IMapService
    {
         string GetInfo(string findSity);
         void WriteCoordinateToFile(string filePath, string information, int pass);
    }
}
