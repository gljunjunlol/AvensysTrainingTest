using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Common.Common
{
    public enum EmailAddressResultType
    {
        /// <summary>
        /// 
        /// </summary>
        DuplicateEmailAddress,
        /// <summary>
        /// 
        /// </summary>
        EmailAddressIncorrect,
        /// <summary>
        /// 
        /// </summary>
        EmailAddressNullError,
        /// <summary>
        /// 
        /// </summary>
        UnhandledEmailAddressError,
        /// <summary>
        /// 
        /// </summary>
        None
    }
}
