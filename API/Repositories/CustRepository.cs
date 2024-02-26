using API.Data;
using API.Models;
using static API.Repositories.CustRepository;

namespace API.Repositories
{
    public class CustRepository : ICustRepository
    {
        ApplicationDbContext _dbContext;
        public CustRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<CustPhone> Create(CustPhone custPhone)
        {
            var obj = await _dbContext.CustPhones.AddAsync(custPhone);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(CustPhone custPhone)
        {
            _dbContext.Remove(custPhone);
            _dbContext.SaveChanges();
        }

        public IEnumerable<CustPhone> GetAll()
        {
            try
            {
                return _dbContext.CustPhones.ToList();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public CustPhone GetByCustId(string custId)
        {
            return _dbContext.CustPhones.Where(x => x.CustId == custId).First();
        }

        public void Update(CustPhone custPhone)
        {
            _dbContext.CustPhones.Update(custPhone);
            _dbContext.SaveChanges();
        }
    }
}
