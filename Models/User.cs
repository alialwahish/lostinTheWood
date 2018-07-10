using System.ComponentModel.DataAnnotations;

namespace dapperTest.Models
{
    public abstract class BaseEntity{}
    public class User : BaseEntity
    {
        [Key]
        public long Id {get ; set;}

        [Required]
        [MinLength(10)]
        public string Name {get;set;}
        
        [Required]
        public string Description {get;set;}

        public int Trail_Length {get;set;}

        public int Elevation {get;set;}

        public int Longitude {get;set;}
        public int Latitude {get;set;}


    }
}