using System.Linq; ;

namespace minta_zh
{
    public class AttributeHelper
    {
        //Ez itt reflexió 
        public static string GetPropertyDisplayName<T>(string propertyName)
        {
            // Ezzel kérdezem le a típusát a displaynamenek
            var type = typeof(T);
            var propInfo = type.GetProperties().FirstOrDefault(x => x.Name == propertyName);
            if (propInfo != null)
            {
                DisplayNameAttribute displayInfo = (DisplayNameAttribute)System.Attribute.GetCustomAttribute(propInfo, typeof(DisplayNameAttribute));
                return displayInfo?.DisplayName;
            }

            return "";
        }

    }
}
