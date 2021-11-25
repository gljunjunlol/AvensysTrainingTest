using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Common.Common
{
    public enum IdResultType
    {
        /// <summary>
        /// 
        /// </summary>
        DuplicateId,
        /// <summary>
        /// 
        /// </summary>
        IdIncorrect,
        /// <summary>
        /// 
        /// </summary>
        IdDataAccessError,
        /// <summary>
        /// 
        /// </summary>
        UnhandledIdError,
        /// <summary>
        /// 
        /// </summary>
        IdNullError,
        /// <summary>
        /// 
        /// </summary>
        None
    }
}
