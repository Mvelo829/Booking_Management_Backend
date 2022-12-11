using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Booking_Management_Backend.Localization
{
    public static class Booking_Management_BackendLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(Booking_Management_BackendConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(Booking_Management_BackendLocalizationConfigurer).GetAssembly(),
                        "Booking_Management_Backend.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
