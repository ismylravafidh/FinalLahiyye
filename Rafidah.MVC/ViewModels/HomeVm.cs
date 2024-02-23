using Rafidah.Core.Entities;

namespace Rafidah.MVC.ViewModels
{
    public class HomeVm
    {
        public AppUser AppUser { get; set; }
        public List<Education>? Education { get; set; }
        public List<WorkAndExperience>? WorkAndExperience { get; set; }
        public List<Certificate>? Certificate { get; set; }
    }
}
