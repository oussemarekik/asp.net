using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        readonly StudentContext studentContext;
        public StudentRepository(StudentContext studentContext)
        {
            this.studentContext = studentContext;
        }
        public void Add(Student s)
        {
            studentContext.Students.Add(s);
            studentContext.SaveChanges();
        }

        public void Delete(Student s)
        {
            Student student = studentContext.Students.Find(s.StudentId);
            if (student != null)
            {
                studentContext.Students.Remove(student);
                studentContext.SaveChanges(true);
            }
            throw new NotImplementedException();
        }

        public void Edit(Student s)
        {
            Student student = studentContext.Students.Find(s.StudentId);
            if(student != null)
            {
                student.StudentName = s.StudentName;
                student.School = s.School;
                student.SchoolID = s.SchoolID;
                student.Age = s.Age;
                student.BirthDate = s.BirthDate;
                student.GroupId = s.GroupId;
                studentContext.SaveChanges();
            }
            throw new NotImplementedException();
        }

        public IList<Student> FindByName(string name)
        {
            return studentContext.Students.Where(s=>s.StudentName == name).ToList();
            throw new NotImplementedException();
        }

        public IList<Student> GetAll()
        {
            
            return studentContext.Students.OrderBy(x => x.StudentName).Include(x=> x.School).Include(x=>x.group).ToList();
            throw new NotImplementedException();
        }

        public Student GetById(int id)
        {
            return studentContext.Students.Where(x => x.StudentId == id).Include(x => x.School).SingleOrDefault(); 
        }

        public IList<Student> GetStudentsByGroupID(int? GroupId)
        {
            return studentContext.Students.Where(g=>g.GroupId== GroupId).OrderBy(g=>g.StudentName).Include(g=>g.group).ToList();
            throw new NotImplementedException();
        }

        public IList<Student> GetStudentsBySchoolID(int? schoolId)
        {
            return studentContext.Students.Where(s =>s.SchoolID.Equals(schoolId)).OrderBy(s => s.StudentName).Include(std => std.School).ToList();
        }
    }
}
