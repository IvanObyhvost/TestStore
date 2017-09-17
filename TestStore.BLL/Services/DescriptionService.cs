using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStore.BLL.Interface;
using TestStore.Core.DTO;
using TestStore.DAL.Interface;

namespace TestStore.BLL.Services
{
    public class DescriptionService: IDescriptionService
    {
        private IDescriptionRepository _descriptionRepository;

        public DescriptionService(IDescriptionRepository repository)
        {
            _descriptionRepository = repository;
        }
        public DescriptionDTO GetDescriptionByIdRealEstate(int id)
        {
            return _descriptionRepository.GetDescriptionByIdRealEstate(id); ;
        }
        public void AddDescriptionDto(int id)
        {
            _descriptionRepository.AddDescription(id);
        }

        public void UpdateDescriptionDto(DescriptionDTO descriptionDto)
        {
            _descriptionRepository.UpdateDescription(descriptionDto); 
        }

        public void Save()
        {
            _descriptionRepository.Save();
        }


        public ICollection<PhotoForGalleryDTO> GetPhotoForGalleryById(int idRealEstate)
        {
            return _descriptionRepository.GetPhotoForGalleryById(idRealEstate);
        }

        public void AddPhotoForGallery(PhotoForGalleryDTO photoDto)
        {
            _descriptionRepository.AddPhotoForGallery(photoDto);
        }


        public void DeletePhoto(string path)
        {
            _descriptionRepository.DeletePhoto(path);
        }
    }
}
