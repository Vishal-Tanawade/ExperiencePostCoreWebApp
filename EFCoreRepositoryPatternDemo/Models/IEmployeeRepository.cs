using System.Collections.Generic;

namespace ExperiencePostCoreWebApp.Models
{
    public interface IEmployeeRepository
    {
        public Employee GetEmployee(Employee employee);
        IEnumerable<Employee> GetAllEmployee();
        Employee Add(Employee employee);
        Employee GetEmployeeByID(int id);
        Employee Update(Employee employeeChanges);
        Employee Delete(int id);
        Skill GetSkill(int Id);
        IEnumerable<Skill> GetAllSkill(int Id);
        void AddSkill(Skill skill);
        void DeleteSkill(int id);
    }
}
