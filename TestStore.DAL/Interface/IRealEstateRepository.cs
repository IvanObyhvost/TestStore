using System;
using System.Collections.Generic;
using TestStore.BLL.DTO;

namespace TestStore.Core.DTO
{
    public interface IRealEstateRepository
    {
        IEnumerable<RealEstateDTO> GetAllRealEstate();
        RealEstateDTO GetRealEstateById(int id);
        RealEstateDTO GetLastAddRealEstate();
        void AddImage(int id, string imagePath, string imageMimeType);
        void DeleteImage(int id);
        void AddRealEstate(RealEstateDTO item);
        void UpdateRealEstate(RealEstateDTO item);
        void DeleteRealEstate(int id); 
        void Save();
    }
}