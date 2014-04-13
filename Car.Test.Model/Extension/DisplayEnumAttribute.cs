using System;

namespace Car.Test.Model.Extension
{
    public class DisplayEnumAttribute : Attribute
    {
        private string _displayName;

        public DisplayEnumAttribute(string displayName)
        {
            this._displayName = displayName;
        }

        public string DisplayName
        {
            get { return _displayName; }
        }
    }
}