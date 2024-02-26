using API.Models;

namespace API.Services
{
    public interface ICustService
    {
        IEnumerable<CustPhone> GetCustPhoneByCustId(string custId);
        IEnumerable<CustPhone> GetAllCustPhone();
        Task<bool> AddPhone(CustPhone custPhone);
        bool DeletePhone(CustPhone custPhone);
        bool UpdatePhoneStatus(CustPhone custPhone);
        IEnumerable<CustPhone> GetCustPhoneByStatus(bool status);
        bool TogglePhoneStatus(CustPhone custPhone);
        bool CheckExists(CustPhone custPhone);
    }
}
