using ConsoleAppDevart.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConsoleAppDevart.Converters;

public class EnumAttivoInattivoToStringConverter : ValueConverter<EnumAtivoInativoBool?, string>
{
    public EnumAttivoInattivoToStringConverter() : base(
        status => Converti(status),
        stringa => Converti(stringa)
        )
    {
    }

    private static string Converti(EnumAtivoInativoBool? enumpmr)
    {
        if (enumpmr == null) return "I";
        switch (enumpmr)
        {
            case EnumAtivoInativoBool.Ativo: return "A";
            case EnumAtivoInativoBool.Inativo: return "I";

        }
        return "I";
    }

    private static EnumAtivoInativoBool Converti(string? stringa)
    {
        if (stringa == null) return EnumAtivoInativoBool.Inativo;
        switch (stringa.ToUpper())
        {
            case "A": return EnumAtivoInativoBool.Ativo;
            case "I": return EnumAtivoInativoBool.Inativo;
        }
        return EnumAtivoInativoBool.Inativo;
    }
}
