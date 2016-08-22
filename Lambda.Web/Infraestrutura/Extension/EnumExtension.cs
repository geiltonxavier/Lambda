using System;
using System.Linq;
using System.Web.Mvc;

namespace Lambda.Web.Infraestrutura.Extension
{
    public static class EnumExtension
    {
        public static SelectList ToSelectList<TEnum>(this TEnum enumObj) where TEnum : struct
        {
            var values = from TEnum e in Enum.GetValues(typeof(TEnum))
                         select new { Id = e, Name = e.ToString() };
            return new SelectList(values, "Id", "Name", enumObj);
        }
    }
}