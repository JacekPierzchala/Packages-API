using System.ComponentModel.DataAnnotations;

namespace Zadanie2.Application
{
    public class EditPackageDTO: AddPackageDTO
    {
        [Required]
        public int Id { get; set; }
    }
}
