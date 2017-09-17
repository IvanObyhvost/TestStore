using System;
using System.Collections.Generic;
using TestStore.BLL.Interface;
using TestStore.Core.DTO;

namespace TestStore.BLL.Services
{
    public class RealEstateService : IRealEstateService
    {
        //IUnitOfWork DataBase { get; set; }
        IRealEstateRepository _realEstateRepository;

        public RealEstateService(IRealEstateRepository repository)
        {
            _realEstateRepository = repository;
        }

        public IEnumerable<RealEstateDTO> GetRealEstates()
        {
            return _realEstateRepository.GetAllRealEstate();
        }

        public RealEstateDTO GetRealEstateById(int id)
        {
            return _realEstateRepository.GetRealEstateById(id);
        }

        public void AddRealEstateDto(RealEstateDTO realEstateDto)
        {
            _realEstateRepository.AddRealEstate(realEstateDto);
        }

        public void UpdateRealEstateDto(RealEstateDTO realEstateDto)
        {
            _realEstateRepository.UpdateRealEstate(realEstateDto);
        }

        public void Save()
        {
            _realEstateRepository.Save();
        }
        public void DeleteRealEstateDto(int id)
        {
            _realEstateRepository.DeleteRealEstate(id);
        }


        public RealEstateDTO GetLastAddRealEstate()
        {
            return _realEstateRepository.GetLastAddRealEstate();
        }


        public void AddImage(int id, string imagePath, string imageMimeType)
        {
            _realEstateRepository.AddImage(id, imagePath, imageMimeType);
            Save();
        }


        public void DeleteImage(int id)
        {
            _realEstateRepository.DeleteImage(id);
        }
    }
}
