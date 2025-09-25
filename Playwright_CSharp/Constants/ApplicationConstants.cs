using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_CSharp.Constants
{
    public static class ApplicationConstants
    {
        public const string VALID_USER = "standard_user";
        public const string VALID_PASSWORD = "secret_sauce";
        public const string INVALID_PASSWORD = "secret_123";
        public const string LOCKED_OUT_USER = "locked_out_user";
        public const string USERNAME_PASSWORD_DO_NOT_MATCH_TEXT= "Epic sadface: Username and password do not match any user in this service";
        public const string LOCKED_USER_WARNING_TEXT = "Epic sadface: Sorry, this user has been locked out.";
        public const string PRODUCT_TEXT = "Products";
        public const string POSTALCODE_MANDATORY_TEXT = "Error: Postal Code is required";
        public const string ORDER_SUCCESS_TEXT = "Thank you for your order!";
    }
}
