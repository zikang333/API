using API.Models;
using API.Repositories;

namespace API.Services
{
    public class CustService : ICustService
    {
        private readonly ICustRepository _cust;

        public CustService(ICustRepository cust)
        {
            _cust = cust;
        }

        public IEnumerable<CustPhone> GetCustPhoneByCustId(string custId)
        {
            return _cust.GetAll().Where(x => x.CustId == custId).ToList();
        }

        public IEnumerable<CustPhone> GetAllCustPhone()
        {
            try
            {
                return _cust.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AddPhone(CustPhone custPhone)
        {
            await _cust.Create(custPhone);
            return true;
        }

        public bool DeletePhone(CustPhone custPhone)
        {

            try
            {
                var dataList = _cust.GetAll().Where(x => x.CustId == custPhone.CustId && x.PhoneNo == custPhone.PhoneNo).ToList();

                if (dataList.Count == 0)
                    return false;

                foreach (var item in dataList)
                {
                    _cust.Delete(item);
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool UpdatePhoneStatus(CustPhone custPhone)
        {
            try
            {
                var dataList = _cust.GetAll().Where(x => x.CustId == custPhone.CustId && x.PhoneNo == custPhone.PhoneNo).ToList();

                if (dataList.Count == 0)
                    return false;

                foreach (var item in dataList)
                {
                    item.Status = custPhone.Status;
                    _cust.Update(item);
                }
                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool TogglePhoneStatus(CustPhone custPhone)
        {
            try
            {
                var dataList = _cust.GetAll().Where(x => x.CustId == custPhone.CustId && x.PhoneNo == custPhone.PhoneNo).ToList();

                if (dataList.Count == 0)
                    return false;

                foreach (var item in dataList)
                {
                    item.Status = !custPhone.Status;
                    _cust.Update(item);
                }
                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public IEnumerable<CustPhone> GetCustPhoneByStatus(bool status)
        {
            try
            {
                return _cust.GetAll().Where(x => x.Status == status).ToList();
            }

            catch (Exception)
            {
                throw;
            }
        }

        public bool CheckExists(CustPhone custPhone)
        {
            try
            {
                return _cust.GetAll().Where(x => x.CustId == custPhone.CustId && x.PhoneNo == custPhone.PhoneNo).Any();
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
