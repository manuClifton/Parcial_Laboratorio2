﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivoException : Exception
    {
        public ArchivoException(string message, Exception innerException)
        {

        }

        public ArchivoException(string message) : base(message)
        {

        }

    }//
}//
