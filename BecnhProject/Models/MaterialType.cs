using System.ComponentModel;

namespace BecnhProject.Models
{
    public enum MaterialType
    {
        [Description("Сталь")]
        Steel,
        [Description("Нелегированная сталь")]
        NonAlloySteel,
        [Description("Низколегированная сталь")]
        AlloySteel,
        [Description("Высоколегированная сталь")]
        HighAlloySteel,
        [Description("Нержавеющая сталь")]
        StainlessSteel,
        [Description("Прутки\nПоковки")]
        StainlessSteelBar,
        [Description("Отливки")]
        StainlessSteelCast,
        [Description("Жаропрочные материалы")]
        HeatResistance,
        [Description("Титановые сплавы")]
        HeatResistanceTitan,
        [Description("Жаропрочные сплавы")]
        HeatResistanceChecked,
        [Description("Ковкий чугун")]
        CastIron,
        [Description("Сверхтвердая сталь")]
        SuperHardSteel,
        [Description("Алюминиевые сплавы")]
        Aluminium
    }
}