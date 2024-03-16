using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Asp.net_Core_Web_App_MVC_E_Commerce.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
