using ConsoleAppDevart.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDevart.Models;
public class Grupo
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = string.Empty;

    public EnumAtivoInativoBool Status { get; set; } = EnumAtivoInativoBool.Ativo;

    public virtual List<Person>? Persons { get; set; }

    public override string ToString()
    {
        return Name + " " + Status;
    }
}
