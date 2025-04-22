using ConsoleAppDevart.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDevart.Models;
public class Person
{
    public string Name { get; set; }

    public EnumAtivoInativo Status { get; set; }
    public string? GrupoName { get; set; }

    public virtual Grupo? Grupo { get; set; }

    public override string ToString()
    {
        return Name + " " + Status;
    }
}
