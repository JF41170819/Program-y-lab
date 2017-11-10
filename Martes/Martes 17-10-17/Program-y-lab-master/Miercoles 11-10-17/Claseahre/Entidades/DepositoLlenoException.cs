using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DepositoLlenoException : Exception
    {
        public DepositoLlenoException():base()
        {

        }
        public DepositoLlenoException(string mensaje):base(mensaje)
        {
        }
    }
}
