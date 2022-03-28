using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IImageDAL 
    {
        uspGetImageByProductIdResult Get(int id);

        IEnumerable<uspGetImagesResult> GetImages();

        void Create(Image image);

        uspGetImageByIdResult GetImageById(int id);
    }
}
