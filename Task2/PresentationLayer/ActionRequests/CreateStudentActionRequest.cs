using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.ActionRequests
{
    public class CreateStudentActionRequest
    {
        [Required(ErrorMessage ="Name is Required")]
        [StringLength(100,ErrorMessage ="Name Not exceed 100 Charcter")]
        public string Name { get; set; }

        [Range(6,20,ErrorMessage ="Age must between 6 and 20 ")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }

       // public string Image { get; set; }
    }
}
