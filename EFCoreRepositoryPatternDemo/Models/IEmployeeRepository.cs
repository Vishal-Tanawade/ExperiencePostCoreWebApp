using System.Collections.Generic;

namespace ExperiencePostCoreWebApp.Models
{
    public interface IEmployeeRepository
    {
        public ClsEmployee GetEmployee(ClsEmployee employee);
        IEnumerable<ClsEmployee> GetAllEmployee();
        ClsEmployee Add(ClsEmployee employee);
        ClsEmployee GetEmployeeByID(int id);
        ClsEmployee Update(ClsEmployee employeeChanges);
        ClsEmployee Delete(int id);
        ClsSkill GetSkill(int Id);
        IEnumerable<ClsSkill> GetAllSkill(int Id);
        void AddSkill(ClsSkill skill);
        void DeleteSkill(int id);
    }
}
