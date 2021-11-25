using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Common.Common
{
    [Flags]
    public enum ForPasswordResultType
    {
        /// <summary>
        /// 
        /// </summary>
        IncorrectPasswordLength = 1,
        /// <summary>
        /// 
        /// </summary>
        PasswordNoUpperCaseLetter = 2,
        /// <summary>
        /// 
        /// </summary>
        PasswordNoLowerCaseLetter = 4,
        /// <summary>
        /// 
        /// </summary>
        PasswordNoDigits = 8,
        /// <summary>
        /// 
        /// </summary>
        PasswordNoSpecialCharacter = 16,
        /// <summary>
        /// 
        /// </summary>
        PasswordThreeRepeatedCharacters = 32,
        /// <summary>
        /// 
        /// </summary>
        UnhandledPasswordError = 64,
        /// <summary>
        /// 
        /// </summary>
        PasswordNullError = 128,
        /// <summary>
        /// 
        /// </summary>
        None = 256
    }
}
