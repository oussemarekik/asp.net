using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        readonly StudentContext _studentContext;



        public GroupRepository(StudentContext _studentContext)
        {
            this._studentContext = _studentContext;
        }
        public void Add(Group s)
        {

            this._studentContext.Groups.Add(s);
            this._studentContext.SaveChanges();
        }

        public void Delete(Group s)
        {
            Group school = this._studentContext.Groups.Find(s.Id);
            if (school != null)
            {
                this._studentContext.Groups.Remove(school);
                this._studentContext.SaveChanges();
            }
        }

        public void Edit(Group s)
        {
            Group s1 = this._studentContext.Groups.Find(s.Id);
            if (s1 != null)
            {
                s1.Name = s.Name;
                s1.SchoolID = s.SchoolID;
                this._studentContext.SaveChanges();
            }
            throw new NotImplementedException();
        }

        public IList<Group> GetAll()
        {
            return this._studentContext.Groups.Include(g => g.School).ToList();
            throw new NotImplementedException();
        }

        public Group getByid(int id)
        {
            return this._studentContext.Groups.Where(x=>x.Id==id).Include(x => x.School).SingleOrDefault();

        }

        public IList<Group> GetGrroupsBySchoolID(int? schoolId)
        {
            IList<Group> groups = (IList<Group>)this._studentContext.Groups.Where(g => g.SchoolID == schoolId).OrderBy(s => s.Name).Include(std => std.School) .ToList(); 
            return groups;
            throw new NotImplementedException();
        }

        public double StudentAgeAverage(int GroupId)
        {
            
            throw new NotImplementedException();
        }

        public int StudentCount(int schoolId)
        {
            throw new NotImplementedException();
        }
    }
}
