namespace WebApplication3.Models.Repositories
{
    public class SchoolRepository : ISchoolRepository
    {
        readonly StudentContext _studentContext;

       

        public SchoolRepository(StudentContext _studentContext)
        {
            this._studentContext = _studentContext;
        }
        public void Add(School s)
        {
            this._studentContext.Schools.Add(s);
            this._studentContext.SaveChanges();
        }

        public void Delete(School s)
        {
            School school = this._studentContext.Schools.Find(s.SchoolID);
            if (school !=null)
            {
                this._studentContext.Schools.Remove(school);
                this._studentContext.SaveChanges();
            }

        }

        public void Edit(School s)
        {
            School s1 = this._studentContext.Schools.Find(s.SchoolID);
            if (s1 != null)
            {
                s1.SchoolName = s.SchoolName;
                s1.SchoolAdress = s.SchoolAdress;
                this._studentContext.SaveChanges();
            }
            throw new NotImplementedException();
        }

        public IList<School> GetAll()
        {
            return this._studentContext.Schools.OrderBy(s => s.SchoolName).ToList();
        }

        public School GetById(int id)
        {
            return this._studentContext.Schools.Where(x=>x.SchoolID==id).FirstOrDefault();
            throw new NotImplementedException();
        }

        public double StudentAgeAverage(int schoolId)
        {
            if (StudentCount(schoolId) == 0) { return 0; }
            else
            {
                return this._studentContext.Students.Where(x => x.SchoolID == schoolId).Average(e => e.Age);
            }
            throw new NotImplementedException();
        }

        public int StudentCount(int schoolId)
        {
            return this._studentContext.Students.Count(x => x.SchoolID==schoolId);
            throw new NotImplementedException();
        }
    }
}
