using BaseProjectTemplate._1.EntityLayer.Concreate;
using BaseProjectTemplate._2.DataAccessLayer.Abstract;
using BaseProjectTemplate._3.BusinessLayer.Abstract;

namespace BaseProjectTemplate._3.BusinessLayer.Concreate
{
    public class DemoClassManager : IDemoClassService
    {

        internal readonly IDemoDal _demoClassDal;

        public DemoClassManager(IDemoDal demoClassDal)
        {
            _demoClassDal = demoClassDal;
        }

        public async Task DeleteAsync(Guid id, string UserId)
        {
            await _demoClassDal.DeleteAsync(id, UserId);
        }

        public async Task<IEnumerable<DemoClass>> GetAllAsync()
        {
            return await _demoClassDal.GetAllAsync();
        }

        public async Task<DemoClass?> GetByIdAsync(Guid Id)
        {
           return await _demoClassDal.GetByIdAsync(Id);
        }

        public async Task<DemoClass?> GetByIdAsync(long Id)
        {
            return await _demoClassDal.GetByIdAsync(Id);

        }

        public async Task InsertAsync(DemoClass Entity, string UserId)
        {
            await _demoClassDal.InsertAsync(Entity, UserId);
        }

        public async Task UpdateAsync(DemoClass Entity, string UserId)
        {
            await _demoClassDal.UpdateAsync(Entity, UserId);
        }
    }
}
