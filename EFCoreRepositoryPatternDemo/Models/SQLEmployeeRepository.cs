using System.Linq;
using System.Collections.Generic;

namespace EFCoreRepositoryPatternDemo.Models
{
    public class SQLEmployeeRepository: IEmployeeRepository
    {

        private readonly AppDBContext context;
        public SQLEmployeeRepository(AppDBContext context)
        {
            this.context = context;

        }
        public ClsEmployee Add(ClsEmployee employee)
        {
            context.coreEmployees.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public void AddSkill(ClsSkill skill)
        {
            context.coreSkill.Add(skill);
            context.SaveChanges();

        }

        public ClsEmployee Delete(int id)
        {
            ClsEmployee employee = context.coreEmployees.Find(id);
            if (employee != null)
            {
                context.coreEmployees.Remove(employee);
                context.SaveChanges();

            }
            return employee;

        }

        public void DeleteSkill(int id)
        {
            ClsSkill skill = context.coreSkill.Find(id);
            if (skill != null)
            {
                context.coreSkill.Remove(skill);
                context.SaveChanges();
            }
        }

        public IEnumerable<ClsEmployee> GetAllEmployee()
        {
            IEnumerable<ClsEmployee> employees = context.coreEmployees;

            return context.coreEmployees;
        }

        public IEnumerable<ClsSkill> GetAllSkill(int Id)
        {
            return context.coreSkill.Where(s => s.EmpID == Id).ToList<ClsSkill>();


        }

        public ClsEmployee GetEmployee(ClsEmployee employee)
        {
            return context.coreEmployees.FirstOrDefault(e => e.Email == employee.Email && e.Password == employee.Password);

        }

        public ClsEmployee GetEmployeeByID(int id)
        {

            return context.coreEmployees.FirstOrDefault(e => e.EmpID == id);
        }

        public ClsSkill GetSkill(int Id)
        {
            return context.coreSkill.FirstOrDefault(s => s.SkillId == Id);
        }

        public ClsEmployee Update(ClsEmployee employeeChanges)
        {
            ClsEmployee employee = context.coreEmployees.FirstOrDefault(e => e.EmpID == employeeChanges.EmpID);
            if (employee != null)
            {
                employee.FirstName = employeeChanges.FirstName;
                employee.LastName = employeeChanges.LastName;
                employee.Password = employeeChanges.Password;
                employee.CellNumber = employeeChanges.CellNumber;
                employee.Email = employeeChanges.Email;

            }
            var emp = context.coreEmployees.Attach(employee);
            emp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return employee;


        }
    }
}
