using System;

namespace minta_zh
{
    [AttributeUsage(AttributeTargets.Property)]
    class DisplayNameAttribute : Attribute
    {
        public string DisplayName { get; set; }

        /*
         *Attribute feladat:
         *Legyen egy nyilvános tulajdonsága, amelyben a megjelenítési nevet lehet eltárolni. (0,5 pont) Ezt az értéket az attribútum konstruktorában is értékül lehessen adni. 
         *(0,5 pont)
        */
        # region Generalt_Konstruktor
        public DisplayNameAttribute(string displayName)
        {
            DisplayName = displayName;
            
        }
        #endregion 
        public string getName(string display) { return DisplayName; }
 
    }
}
