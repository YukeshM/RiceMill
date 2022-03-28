

using Entities.Entity;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class ImageDAL : IImageDAL
    {
        private readonly RicemillContext _ricemillContext;

        public ImageDAL(RicemillContext ricemillContext)
        {
            this._ricemillContext = ricemillContext;
        }

        public void Create(Image image)
        {
            try
            {
                _ricemillContext.Image.Add(image);
                _ricemillContext.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception("error: " + e.Message);
            }
        }

        public uspGetImageByProductIdResult Get(int id)
        {
            try
            {
                if (id != 0)
                {
                    uspGetImageByProductIdResult images = _ricemillContext.Procedures.uspGetImageByProductIdAsync(id).Result.ToList().FirstOrDefault();
                    return images;
                }
                else
                {
                    throw new Exception("Id cannot be 0");
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error: " + e.Message);
            }
        }

        public uspGetImageByIdResult GetImageById(int id)
        {
            try
            {
                if (id != 0)
                {
                    uspGetImageByIdResult image = _ricemillContext.Procedures.uspGetImageByIdAsync(id).Result.ToList().FirstOrDefault();
                    return image;
                }
                else
                {
                    throw new Exception("Id cannot be 0");
                }

            }
            catch (Exception e)
            {

                throw new Exception("Error: " + e.Message);
            }
        }

        public IEnumerable<uspGetImagesResult> GetImages()
        {
            try
            {
                List<uspGetImagesResult> images = _ricemillContext.Procedures.uspGetImagesAsync().Result;
                return images;
            }
            catch (Exception e)
            {

                throw new Exception("Error: " + e.Message);
            }

        }
    }
}
