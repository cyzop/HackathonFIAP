using System.ComponentModel;
using System.Reflection;

namespace MedicalConsultation.Entity
{
    public enum ConsultationStatus
    {
        [Description("Agendada")]
        Agendada,
        [Description("Reagendada")]
        Reagendada,
        [Description("Cancelada")]
        Cancelada
    }

    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }

}
