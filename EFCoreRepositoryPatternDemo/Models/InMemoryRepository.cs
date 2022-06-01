using System.Collections.Generic;
using System.Linq;

namespace EFCoreRepositoryPatternDemo.Models
{

    //Business Analyst
    //Developer
    //Infrastructure
    //IT Helpdesk
    //Network
    //PMO
    //Project Lead
    public class InMemoryRepository : IEmployeeRepository
    {
        private static List<ClsEmployee> _employeeList = new List<ClsEmployee>()
            {
              new ClsEmployee(){EmpID=1,FirstName="Aaron",LastName="Hawkins",Password="arron@123",CellNumber="(660) 663-4518",Email="aron.hawkins@aol.com" },
              new ClsEmployee(){EmpID=2,FirstName="Hedy",LastName="Greene",Password="hedy@123",CellNumber="(608) 265-2215",Email="hedy.greene@aol.com" },
              new ClsEmployee(){EmpID=3,FirstName="Melvin",LastName="Porter",Password="melvin@123",CellNumber="(959) 119-8364",Email="melvin.porter@aol.com"}
            };

        private static List<ClsSkill> _skillList = new List<ClsSkill>()
            {
            new ClsSkill(){SkillId=1,EmpID=1,SkillName="Microsoft Office Suite",Role="Business Analyst",ExperienceInYears=2},
            new ClsSkill(){SkillId=2,EmpID=1,SkillName="Testing",Role="Developer",ExperienceInYears=3},
            new ClsSkill(){SkillId=3,EmpID=1,SkillName="Stakeholder Management",Role="Project Lead",ExperienceInYears=4}
           };


        public ClsEmployee Add(ClsEmployee employee)
        {
            if (_employeeList.Count == 0)
            {
                employee.EmpID = 1;
            }
            else
            {
                employee.EmpID = _employeeList.Max(e => e.EmpID) + 1;

            }

            _employeeList.Add(employee);
            return employee;
        }


        public ClsEmployee Delete(int id)
        {
            ClsEmployee employee = _employeeList.FirstOrDefault(e => e.EmpID == id);
            if (employee != null)
            {
                _employeeList.Remove(employee);

            }
            return employee;
        }


        public IEnumerable<ClsEmployee> GetAllEmployee()
        {
            return _employeeList;
        }

        public ClsEmployee GetEmployeeByID(int id)
        {
            return _employeeList.FirstOrDefault(e => e.EmpID == id);
        }
        public ClsEmployee GetEmployee(ClsEmployee employee)
        {
            return _employeeList.FirstOrDefault(e => e.Email == employee.Email && e.Password == employee.Password);
        }
        public ClsEmployee Update(ClsEmployee employeeChanges)
        {
            ClsEmployee employee = _employeeList.FirstOrDefault(e => e.EmpID == employeeChanges.EmpID);
            if (employee != null)
            {
                employee.FirstName = employeeChanges.FirstName;
                employee.LastName = employeeChanges.LastName;
                employee.Password = employeeChanges.Password;
                employee.CellNumber = employeeChanges.CellNumber;
                employee.Email = employeeChanges.Email;

            }
            return employee;
        }
        public ClsSkill GetSkill(int Id)
        {

            return _skillList.FirstOrDefault(s => s.SkillId == Id);
        }

        public IEnumerable<ClsSkill> GetAllSkill(int Id)
        {
            return _skillList.Where(s => s.EmpID == Id).ToList<ClsSkill>();
        }

        public void AddSkill(ClsSkill skill)
        {
            if (_skillList.Count == 0)
            {
                skill.SkillId = 1;

            }
            else
            {
                skill.SkillId = _skillList.Max(e => e.SkillId) + 1;

            }

            _skillList.Add(skill);

        }

        public void DeleteSkill(int id)
        {
            ClsSkill skill = _skillList.FirstOrDefault(s => s.SkillId == id);
            if (skill != null)
            {
                _skillList.Remove(skill);

            }

        }

       
    }
}
