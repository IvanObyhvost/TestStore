using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStore.Core.DTO;
using TestStore.DAL.Entites;
using TestStore.DAL.Interface;

namespace TestStore.DAL.Repository
{
    public class DescriptionRepository: IDescriptionRepository
    {
        private TestStoreContext _testStoreContext;
        public DescriptionRepository(TestStoreContext testStore)
        {
            _testStoreContext = testStore;
        }
        public DescriptionDTO GetDescriptionByIdRealEstate(int id)
        {
            try
            {
                var description = (from u in _testStoreContext.Descriptions
                                    where u.RealEstateId == id
                                    select u).FirstOrDefault();
                DescriptionDTO descriptionDto = new DescriptionDTO()
                {
                    Id = description.Id,
                    RealEstateId = description.RealEstateId,
                    ShortDescription = description.ShortDescription,
                    LongDescription = description.LongDescription
                };
                return descriptionDto;
            }
            catch
            {

                return null;
            }
            
        }
        public void AddDescription(int id)
        {
            try
            {
                Description description = new Description()
                {
                    Id = id,
                    RealEstateId = id,
                    ShortDescription = "",
                    LongDescription = ""
                };
                _testStoreContext.Descriptions.Add(description);
            }
            catch
            {
                
            }
            
        }

        public void UpdateDescription(DescriptionDTO item)
        {
            try
            {
                Description description = _testStoreContext.Descriptions.Find(item.Id);
                description.ShortDescription = item.ShortDescription;
                description.LongDescription = item.LongDescription;

                _testStoreContext.Entry(description).State = EntityState.Modified;
            }
            catch
            {
 
            }
           
        }
        public void Save()
        {
            try
            {
                _testStoreContext.SaveChanges();
            }
            catch
            {

            }
        }
        
        public ICollection<PhotoForGalleryDTO> GetPhotoForGalleryById(int idRealEstate)
        {
            var photos = (from u in _testStoreContext.PhotoForGalleries
                where u.RealEstateId == idRealEstate
                select u).ToList();
            
            var photoDtos = new List<PhotoForGalleryDTO>();

            foreach(var item in photos)
            {
                photoDtos.Add(new PhotoForGalleryDTO()
                {
                    Id = item.Id,
                    RealEstateId = item.RealEstateId,
                    UrlImage = item.UrlImage
                });
            }
            return photoDtos;
        }

        public void AddPhotoForGallery(PhotoForGalleryDTO photoDto)
        {
            var photo = new PhotoForGallery()
            {
                RealEstateId = photoDto.RealEstateId,
                UrlImage = photoDto.UrlImage,
            };

            _testStoreContext.PhotoForGalleries.Add(photo);
        }


        public void DeletePhoto(string path)
        {
            PhotoForGallery photo = (from u in _testStoreContext.PhotoForGalleries
                                    where u.UrlImage == path
                                    select u).FirstOrDefault();
            _testStoreContext.PhotoForGalleries.Remove(photo);
        }
    }
}
