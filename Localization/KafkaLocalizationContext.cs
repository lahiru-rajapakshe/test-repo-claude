using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Infrastructure.Localization
{
    public static class KafkaLocalizationContext
    {
        private static readonly AsyncLocal<string> _currentLanguage = new AsyncLocal<string>();

        public static void SetLanguage(string language)
        {
            _currentLanguage.Value = language;
        }

        public static string GetLanguage()
        {
            return _currentLanguage.Value ?? "en-US";
        }
    }
}
