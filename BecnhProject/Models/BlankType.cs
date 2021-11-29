using System.ComponentModel;

namespace BecnhProject.Models
{
    public enum BlankType
    {
        [Description("Прокат")]
        RollMetal,
        [Description("Штамповка")]
        Stamping,
        [Description("Отливка")]
        Casting,
        [Description("Лист")]
        List
    }
}