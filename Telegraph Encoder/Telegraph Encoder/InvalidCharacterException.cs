using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telegraph_Encoder
{
    class InvalidCharacterException:ApplicationException
    {
        public InvalidCharacterException(char a):base("------ERROR------\r\nInvalid character "+a+" used!")
        { }
    }
}
