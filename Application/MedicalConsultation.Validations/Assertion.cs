using System.Globalization;

namespace MedicalConsultation.Validations
{
    public static class Assertion
    {
        public static void AssertIfEquals(string? value1, string? value2, string message)
        {
            if(!string.Equals(value1, value2, StringComparison.InvariantCultureIgnoreCase))
                throw new ArgumentException(message);
        }
        public static void AssertIfEquals(int value1, int value2, string message)
        {
            if (value1 != value2)
                throw new ArgumentException(message);
        }
        public static void AssertIsNotNull(object obj, string message)
        {
            if (obj == null) 
                throw new ArgumentException(message);
        }
        public static void AssertIsNull(object obj, string message)
        {
            if (obj != null)
                throw new ArgumentException(message);
        }
        public static void AssertStringIsNotNullOrEmpty(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException(message);
        }

        public static void AssertIfExistInCollection(string value, string[] colletion, string message)
        {
            if (colletion.FirstOrDefault(f =>
                        f.Equals(value, StringComparison.InvariantCultureIgnoreCase)) == null)
                throw new ArgumentException(message);
        }

        public static void AssertIsUniqueInCollection(string value, string[] collection, string message)
        {
            if (collection.FirstOrDefault(f =>
                        f.Equals(value, StringComparison.InvariantCultureIgnoreCase)) != null)
                throw new ArgumentException(message);
        }

        public static void AssertCollectionWithUniqueValues(string[] collection, string message)
        {
            var duplicates = collection.GroupBy(x => x)
                    .Where(g => g.Count() > 1)
                    .Select(g => g.Key);

            if (duplicates?.Count() > 0)
                throw new ArgumentException(message);
        }

        public static void AssertMinValue(int? value, int minValue, string message)
        {
            if (value != null &&
                value < minValue)
                throw new ArgumentException(message);
        }
        public static void AssertMaxValue(int? value, int maxValue, string message)
        {
            if (value != null &&
                value > maxValue)
                throw new ArgumentException(message);
        }

        public static void AssertStringDateInFormat(string value, string format, string message)
        {
            if (!DateTime.TryParseExact(value, format, new CultureInfo("pt-BR"), DateTimeStyles.None, out _))
                throw new ArgumentException(message);
        }

        public static void AssertDataIsNullOrInvalid(DateTime date, string message)
        {
            if(date == DateTime.MinValue)
                throw new ArgumentException(message);
        }
        public static void AssertDataIsNullOrInvalid(DateTime date, DateTime minValue, string message)
        {
            if (date < minValue)
                throw new ArgumentException(message);
        }
             
    }
}
