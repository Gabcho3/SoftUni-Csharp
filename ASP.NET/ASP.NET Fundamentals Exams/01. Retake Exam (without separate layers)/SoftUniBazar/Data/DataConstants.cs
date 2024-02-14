using SoftUniBazar.Data.Models;

namespace SoftUniBazar.Data
{
    public static class DataConstants
    {
        public static class AdConstants
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 25;
            public const int DescriptionMinLength = 15;
            public const int DescriptionMaxLength = 250;
            public const string DateFormat = "yyyy-MM-dd H:mm";
        }

        public static class CategoryConstants
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 25;
        }
    }
}
