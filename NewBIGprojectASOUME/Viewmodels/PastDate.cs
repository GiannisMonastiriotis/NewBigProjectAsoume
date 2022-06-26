using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace NewBIGprojectASOUME.Viewmodels
{
    public class PastDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;

            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                "dd MM yyyy tt",
                DateTimeFormatInfo.InvariantInfo,
                DateTimeStyles.None,
                out dateTime);

            return (isValid && dateTime > DateTime.Now);

        }
    }
}