namespace MedicalConsultation.WebApp.Services
{
    public static class TimeService
    {
        public static List<string> GerarHorariosConsulta()
        {
            List<string> horas = new List<string>();
            string hora = string.Empty;
            for (int i = 8; i < 20; i++)
            {
                hora = i.ToString("D2");
                horas.Add($"{hora}:00");
                horas.Add($"{hora}:30");
            }
            return horas;
        }
    }
}
