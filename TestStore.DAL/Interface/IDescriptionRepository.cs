using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStore.Core.DTO;

namespace TestStore.DAL.Interface
{
    public interface IDescriptionRepository
    {
        DescriptionDTO GetDescriptionByIdRealEstate(int id);
        ICollection<PhotoForGalleryDTO> GetPhotoForGalleryById(int idRealEstate); 
        void AddDescription(int id);
        void AddPhotoForGallery(PhotoForGalleryDTO photoDto);
        void UpdateDescription(DescriptionDTO item);
        void DeletePhoto(string path);
        void Save();
    }
}
