using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDevart.Converters;
public class EnumToString1CharConverter<T> : ValueConverter<T?, string> where T : Enum
{
    public EnumToString1CharConverter(T defaultT, string defaultString = "") : base(
        status => Converti(status, defaultString),
        stringa => ConvertiT(stringa, defaultT)
        )
    { }

    private static string Converti(T? enumvalue, string valoredefalt)
    {
        if (enumvalue == null) return valoredefalt;
        char status = Convert.ToChar(enumvalue);
        return status.ToString();
    }

    private static T ConvertiT(string? stringa, T valoredefaul)
    {
        if (string.IsNullOrWhiteSpace(stringa)) return valoredefaul;
        char carattere = stringa.ToUpper().ToCharArray(0, 1)[0];
        return (T)Enum.ToObject(typeof(T), carattere);
    }
}
