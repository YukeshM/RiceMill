using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace IBAL
{
    public interface IImageBAL
    {
        ImageViewModel Get(int id);

        IEnumerable<ImageViewModel> GetImages();

        void Create(ImageViewModel image);

        ImageViewModel GetImageById(int id);

        IEnumerable<ImageViewModel> GetCarousel();

    }
}
