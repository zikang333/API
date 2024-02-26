using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class CustPhone
    {
        public string CustId { get; set; }
        public string PhoneNo { get; set; }
        public bool Status { get; set; }
    }
}
