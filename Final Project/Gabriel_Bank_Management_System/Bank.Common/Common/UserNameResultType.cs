using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Common.Common
{
    public enum UserNameResultType
    {
        /// <summary>
        /// 
        /// </summary>
        DuplicateUser,
        /// <summary>
        /// 
        /// </summary>
        UserNameLengthIncorrect,
        /// <summary>
        /// 
        /// </summary>
        UserNameContainsSpace,
        /// <summary>
        /// 
        /// </summary>
        UserNameDataAccessError,
        /// <summary>
        /// 
        /// </summary>
        UnhandledUserError,
        /// <summary>
        /// 
        /// </summary>
        None
    }
}
