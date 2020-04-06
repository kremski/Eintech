using System.ComponentModel.DataAnnotations;

namespace Eintech.Models
{
    public class GroupViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Group Name")]
        public string Name { get; set; }
    }
}
