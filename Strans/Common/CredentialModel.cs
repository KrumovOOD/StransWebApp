using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Strans.Common
{
    public class CredentialModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Nullable<bool> IsValid { get; set; }
    }
}