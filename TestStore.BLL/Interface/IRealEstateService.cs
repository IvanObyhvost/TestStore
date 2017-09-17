using System.Collections.Generic;
using TestStore.BLL.DTO;
using TestStore.Core.DTO;

namespace TestStore.BLL.Interface
{
    public interface IRealEstateService
    {
        IEnumerable<RealEstateDTO> GetRealEstates();
        RealEstateDTO GetRealEstateById(int id);
        RealEstateDTO GetLastAddRealEstate();
        void AddImage(int id, string imagePath, string imageMimeType);
        void DeleteImage(int id);
        void AddRealEstateDto(RealEstateDTO realEstateDto);
        void UpdateRealEstateDto(RealEstateDTO realEstateDto);
        void DeleteRealEstateDto(int id);
        void Save();
    }
}