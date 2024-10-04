using Microsoft.Extensions.Localization;

namespace ExpensesManager.Shared.Localization
{
    public static class LocalizerService
    {
        private static IStringLocalizerFactory _localizerFactory;

        public static void Configure(IStringLocalizerFactory localizerFactory)
        {
            _localizerFactory = localizerFactory;
        }

        public static IStringLocalizer GetLocalizer<T>()
        {
            if (_localizerFactory == null)
                throw new InvalidOperationException("LocalizationService is not configured.");

            return _localizerFactory.Create(typeof(T));
        }

        public static IStringLocalizer GetLocalizer(string baseName, string location)
        {
            if (_localizerFactory == null)
                throw new InvalidOperationException("LocalizationService is not configured.");

            return _localizerFactory.Create(baseName, location);
        }
    }
}
