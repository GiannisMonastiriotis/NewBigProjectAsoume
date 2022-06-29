using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

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