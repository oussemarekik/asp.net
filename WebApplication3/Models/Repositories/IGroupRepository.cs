namespace WebApplication3.Models.Repositories
{
    public interface IGroupRepository
    {
        IList<Group> GetAll();
        Group getByid(int id);
        void Add(Group s);
        void Edit(Group s);
        void Delete(Group s);
        IList<Group> GetGrroupsBySchoolID(int? schoolId);
        double StudentAgeAverage(int schoolId);
        int StudentCount(int schoolId);
    }
}
