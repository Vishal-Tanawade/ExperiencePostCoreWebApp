using System.Collections.Generic;
using System.Linq;

namespace ExperiencePostCoreWebApp.Models
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
        private static List<Employee> _employeeList = new List<Employee>()
            {
              new Employee(){EmpID=1,FirstName="Aaron",LastName="Hawkins",Password="arron@123",CellNumber="(660) 663-4518",Email="aron.hawkins@aol.com",ProfilePicture="no-image" },
              new Employee(){EmpID=2,FirstName="Hedy",LastName="Greene",Password="hedy@123",CellNumber="(608) 265-2215",Email="hedy.greene@aol.com" ,ProfilePicture="no-image"},
              new Employee(){EmpID=3,FirstName="Melvin",LastName="Porter",Password="melvin@123",CellNumber="(959) 119-8364",Email="melvin.porter@aol.com",ProfilePicture="no-image"}
            };

        private static List<Skill> _skillList = new List<Skill>()
            {
            new Skill(){SkillId=1,EmpID=1,SkillName="Microsoft Office Suite",Role="Business Analyst",ExperienceInYears=2},
            new Skill(){SkillId=2,EmpID=1,SkillName="Testing",Role="Developer",ExperienceInYears=3},
            new Skill(){SkillId=3,EmpID=1,SkillName="Stakeholder Management",Role="Project Lead",ExperienceInYears=4}
           };


        public Employee Add(Employee employee)
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


        public Employee Delete(int id)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.EmpID == id);
            if (employee != null)
            {
                _employeeList.Remove(employee);

            }
            return employee;
        }


        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;
        }

        public Employee GetEmployeeByID(int id)
        {
            return _employeeList.FirstOrDefault(e => e.EmpID == id);
        }
        public Employee GetEmployee(Employee employee)
        {
            return _employeeList.FirstOrDefault(e => e.Email == employee.Email && e.Password == employee.Password);
        }
        public Employee Update(Employee employeeChanges)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.EmpID == employeeChanges.EmpID);
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
        public Skill GetSkill(int Id)
        {

            return _skillList.FirstOrDefault(s => s.SkillId == Id);
        }

        public IEnumerable<Skill> GetAllSkill(int Id)
        {
            return _skillList.Where(s => s.EmpID == Id).ToList<Skill>();
        }

        public void AddSkill(Skill skill)
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
            Skill skill = _skillList.FirstOrDefault(s => s.SkillId == id);
            if (skill != null)
            {
                _skillList.Remove(skill);

            }

        }

       
    }
}
