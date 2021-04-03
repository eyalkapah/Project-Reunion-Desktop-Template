using System.ComponentModel;

namespace ProjectReunionTemplate.Core.Utils
{
    public class PropertyChangingEventArgs<T> : PropertyChangingEventArgs
    {
        public PropertyChangingEventArgs(string propertyName, T newValue) : base(propertyName)
        {
            NewValue = newValue;
        }

        public bool Cancel { get; set; }
        public T NewValue { get; set; }
    }
}
