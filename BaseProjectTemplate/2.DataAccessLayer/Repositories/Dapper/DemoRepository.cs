using BaseProjectTemplate._1.EntityLayer.Concreate;
using BaseProjectTemplate._2.DataAccessLayer.Abstract;

namespace BaseProjectTemplate._2.DataAccessLayer.Repositories.Dapper
{
    public class DemoRepository : DapperGenericRepository<DemoClass>, IDemoDal
    {
        public DemoRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
