using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStore.Core.DTO;

namespace TestStore.BLL.Interface
{
    public interface IDescriptionService
    {
        DescriptionDTO GetDescriptionByIdRealEstate(int id);
        ICollection<PhotoForGalleryDTO> GetPhotoForGalleryById(int idRealEstate);
        void AddDescriptionDto(int id);
        void AddPhotoForGallery(PhotoForGalleryDTO photoDto);
        void UpdateDescriptionDto(DescriptionDTO descriptionDto);
        void DeletePhoto(string path);
        void Save();
    }
}
