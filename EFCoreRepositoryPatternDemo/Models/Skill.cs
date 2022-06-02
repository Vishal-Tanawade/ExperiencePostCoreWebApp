using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExperiencePostCoreWebApp.Models
{
    public class Skill
    {

        public Skill()
        {
              
        }
       [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkillId { get; set; }
        //[ForeignKey("Employeee")]
        public int EmpID { get; set; }
        [DisplayName("Skill Name")]
        [Required(ErrorMessage = "Skill name should not be blank")]
        public string SkillName { get; set; }
        [Required(ErrorMessage = "Employee Role should not be blank")]
        [DisplayName("Role")]
        public string Role { get; set; }
        [DisplayName("Experience In Years")]
        [Required(ErrorMessage = "Experience in years should not be blank")]
        public int ExperienceInYears { get; set; }
        public virtual Employee Employeee { get; set; }
    }
}
