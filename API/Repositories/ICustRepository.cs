using API.Models;

namespace API.Repositories
{
    public interface ICustRepository
    {
        Task<CustPhone> Create(CustPhone _object);
        void Delete(CustPhone _object);
        IEnumerable<CustPhone> GetAll();
        CustPhone GetByCustId(string custId);
        void Update(CustPhone _object);
    }
}
