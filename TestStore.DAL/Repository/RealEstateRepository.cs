using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestStore.BLL.DTO;
using TestStore.Core.DTO;
using TestStore.Core.Entites;
using TestStore.Core.Repository;
using TestStore.DAL.Entites;

namespace TestStore.DAL.Repository
{
    public class RealEstateRepository :  IRealEstateRepository
    {
        private TestStoreContext _testStoreContext;
        public RealEstateRepository(TestStoreContext testStore )
        {
            _testStoreContext = testStore;
        }
        public IEnumerable<RealEstateDTO> GetAllRealEstate()
        {
            var realEstateList = _testStoreContext.RealEstates;
            List<RealEstateDTO> realEstateDtos = new List<RealEstateDTO>();
            foreach(var item in realEstateList)
            {
                realEstateDtos.Add(new RealEstateDTO()
                {
                    Id = item.Id, 
                    RealEstateID = item.RealEstateID, 
                    Price = item.Price, 
                    Postcode = item.Postcode, 
                    Location = item.Location,
                    Bathrooms = item.Bathrooms,
                    Bedrooms = item.Bedrooms,
                    Garden = item.Garden,
                    LivingRooms = item.LivingRooms, 
                    Parking = item.Parking,
                    Shower = item.Shower,
                    SSTC = item.SSTC,
                    Area = item.Area,
                    SalesCorner = item.SalesCorner,
                    Tenure = item.Tenure,
                    PropertyStatus = item.PropertyStatus,
                    ImagePath = item.ImagePath,
                    ImageMimeType = item.ImageMimeType,
                    ShortDescription = item.ShortDescription,
                    LongDescription = item.LongDescription
                   
              });
            }
            return realEstateDtos;
        }

        public RealEstateDTO GetRealEstateById(int id)
        {
            var realEstate = _testStoreContext.RealEstates.Find(id);
            RealEstateDTO realEstateDto = new RealEstateDTO()
            {
                Id = realEstate.Id,
                RealEstateID = realEstate.RealEstateID,
                Price = realEstate.Price,
                Postcode = realEstate.Postcode,
                Location = realEstate.Location,
                Bathrooms = realEstate.Bathrooms,
                Bedrooms = realEstate.Bedrooms,
                Garden = realEstate.Garden,
                LivingRooms = realEstate.LivingRooms,
                Parking = realEstate.Parking,
                Shower = realEstate.Shower,
                Tenure = realEstate.Tenure,
                PropertyStatus = realEstate.PropertyStatus,
                SSTC = realEstate.SSTC,
                Area = realEstate.Area,
                SalesCorner = realEstate.SalesCorner,
                ImagePath = realEstate.ImagePath,
                ImageMimeType = realEstate.ImageMimeType,
                ShortDescription = realEstate.ShortDescription,
                LongDescription = realEstate.LongDescription
            };
            return realEstateDto;
        }

        public void AddRealEstate(RealEstateDTO item)
        {
            RealEstate realEstate = new RealEstate()
            {
                RealEstateID = item.RealEstateID,
                Price = item.Price,
                Postcode = item.Postcode,
                Location = item.Location,
                Bathrooms = item.Bathrooms,
                Bedrooms = item.Bedrooms,
                Garden = item.Garden,
                LivingRooms = item.LivingRooms,
                Parking = item.Parking,
                Shower = item.Shower,
                Tenure = item.Tenure,
                PropertyStatus = item.PropertyStatus,
                SSTC = item.SSTC,
                Area = item.Area,
                SalesCorner = item.SalesCorner,
                ShortDescription = item.ShortDescription,
                LongDescription = item.LongDescription
                
            };
            _testStoreContext.RealEstates.Add(realEstate);
        }

        public void UpdateRealEstate(RealEstateDTO item)
        {
            RealEstate real = new RealEstate()
            {
                Id = item.Id,
                RealEstateID = item.RealEstateID,
                Price = item.Price,
                Postcode = item.Postcode,
                Location = item.Location,
                Bathrooms = item.Bathrooms,
                Bedrooms = item.Bedrooms,
                Garden = item.Garden,
                LivingRooms = item.LivingRooms,
                Parking = item.Parking,
                Shower = item.Shower,
                Tenure = item.Tenure,
                PropertyStatus = item.PropertyStatus,
                SSTC = item.SSTC,
                Area = item.Area,
                SalesCorner = item.SalesCorner,
                ImagePath = item.ImagePath,
                ImageMimeType = item.ImageMimeType,
                ShortDescription = item.ShortDescription,
                LongDescription = item.LongDescription
            };

            _testStoreContext.Entry(real).State = EntityState.Modified;
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


        public void DeleteRealEstate(int id)
        {
            RealEstate real = _testStoreContext.RealEstates.Find(id);
            Description description = _testStoreContext.Descriptions.Find(real.Id);
            if (description != null)
            {
                _testStoreContext.Descriptions.Remove(description);
            }
            if (real != null)
            {
                _testStoreContext.RealEstates.Remove(real);
            }
        }




        public RealEstateDTO GetLastAddRealEstate()
        {
            RealEstate real = (from u in _testStoreContext.RealEstates
                                select u).Last();
            RealEstateDTO realEstateDto = new RealEstateDTO()
            {
                Id = real.Id,
                RealEstateID = real.RealEstateID,
                Price = real.Price,
                Postcode = real.Postcode,
                Location = real.Location,
                Bathrooms = real.Bathrooms,
                Bedrooms = real.Bedrooms,
                Garden = real.Garden,
                LivingRooms = real.LivingRooms,
                Parking = real.Parking,
                Shower = real.Shower,
                Tenure = real.Tenure,
                PropertyStatus = real.PropertyStatus,
                SSTC = real.SSTC,
                Area = real.Area,
                SalesCorner = real.SalesCorner,
                ImagePath = real.ImagePath,
                ImageMimeType = real.ImageMimeType,
                ShortDescription = real.ShortDescription,
                LongDescription = real.LongDescription
            };
            return realEstateDto;
        }


        public void AddImage(int id, string imagePath, string imageMimeType)
        {
            RealEstate real = _testStoreContext.RealEstates.Find(id);
            if (real == null)
            {
               real = new RealEstate();
            }
            real.ImagePath = imagePath;
            real.ImageMimeType = imageMimeType;

            _testStoreContext.Entry(real).State = EntityState.Modified;

        }


        public void DeleteImage(int id)
        {
            RealEstate real = _testStoreContext.RealEstates.Find(id);
            real.ImagePath = null;

            _testStoreContext.Entry(real).State = EntityState.Modified;
        }
    }
}
