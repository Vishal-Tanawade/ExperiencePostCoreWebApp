using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExperiencePostCoreWebApp.Models
{
    public class WEBAPIRepository : IEmployeeRepository
    {
        public Employee Add(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void AddSkill(Skill skill)
        {
            throw new NotImplementedException();
        }

        public Employee Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteSkill(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Skill> GetAllSkill(int Id)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeByID(int id)
        {
            throw new NotImplementedException();
        }

        public Skill GetSkill(int Id)
        {
            throw new NotImplementedException();
        }

        public Employee Update(Employee employeeChanges)
        {
            throw new NotImplementedException();
        }
    }
}
