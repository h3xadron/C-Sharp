using System;

namespace minta_zh
{
    [AttributeUsage(AttributeTargets.Property)]
    class DisplayNameAttribute : Attribute
    {
        public string DisplayName { get; set; }

        # region Generalt_Konstruktor
        public DisplayNameAttribute(string displayName)
        {
            DisplayName = displayName;
            
        }
        #endregion 
 
    }
}
