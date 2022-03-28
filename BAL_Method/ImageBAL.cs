using Entities.Entity;
using IBAL;
using IDAL;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewModel;

namespace BAL
{
    public class ImageBAL : IImageBAL
    {

        private readonly IImageDAL _imageDAL;

        private readonly IOptions<PathModelForBAL> _imageURL;

        public ImageBAL(IImageDAL imageDAL, IOptions<PathModelForBAL> imageURL)
        {
            _imageDAL = imageDAL;
            this._imageURL = imageURL;
        }

        public void Create(ImageViewModel image)
        {
            try
            {
                if (image != null)
                {
                    Image newImage = new Image()
                    {
                        FileName = image.FileName,
                        OriginalFileName = image.OriginalFileName
                    };

                    _imageDAL.Create(newImage);
                }
                else
                {
                    throw new Exception("Image model cannot be null.");
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error: "+ e);
            }

            
            
        }

        public ImageViewModel Get(int id)
        {

            try
            {
                if (id != 0)
                {
                    uspGetImageByProductIdResult image = _imageDAL.Get(id);

                    ImageViewModel newImage = new ImageViewModel()
                    {
                        FileName = image.FileName,
                        OriginalFileName = image.OriginalFileName,
                        ProductId = image.ProductId
                    };
                    return newImage;
                }
                else
                {
                    throw new Exception("Id cannot be null");
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error: "+ e);
            }


        }

        public ImageViewModel GetImageById(int id)
        {
            try
            {
                if (id != 0)
                {
                    uspGetImageByIdResult images = _imageDAL.GetImageById(id);

                    ImageViewModel image = new ImageViewModel()
                    {
                        FileName = images.FileName,
                        OriginalFileName = images.OriginalFileName
                    };

                    return image;
                }
                else
                {
                    throw new Exception("Id cannot be 0");
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error: " + e);
            }
        }

        public IEnumerable<ImageViewModel> GetImages()
        {
            try
            {
                List<uspGetImagesResult> images = _imageDAL.GetImages().ToList();

                List<ImageViewModel> list = new List<ImageViewModel>();

                for (int i = 0; i < images.Count; i++)
                {
                    ImageViewModel newImage = new ImageViewModel()
                    {
                        FileName = images[i].FileName,
                        OriginalFileName = _imageURL.Value.ImageURL + images[i].Id
                    };
                    list.Add(newImage);
                }
                return list;
            }
            catch (Exception e)
            {

                throw new Exception("Error: " + e);
            }
        }

        public IEnumerable<ImageViewModel> GetCarousel()
        {
            try
            {
                List<uspGetImagesResult> images = _imageDAL.GetImages().ToList();

                List<ImageViewModel> list = new List<ImageViewModel>();

                for (int i = 0; i < images.Count; i++)
                {
                    ImageViewModel newImage = new ImageViewModel()
                    {
                        FileName = images[i].FileName,
                        OriginalFileName = images[i].OriginalFileName
                    };
                    list.Add(newImage);
                }
                return list;
            }
            catch (Exception e)
            {

                throw new Exception("Error: " + e);
            }
        }
    }
}
