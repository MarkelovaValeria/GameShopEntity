using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApi.DataAccessLayer.Entities
{
    public class UserAuthToken
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; }  
        public DateTime IssuedAt { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
