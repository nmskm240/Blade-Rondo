namespace FieldShowIf.Enum
{
    using System;
    using UnityEngine;

    [System.AttributeUsage(System.AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    public class ShowChangeAttribute : PropertyAttribute
    {
        public string Criteria { get; private set; }
        public string Condition { get; private set; }

        public ShowChangeAttribute(string criteria, string condition)
        {
            Criteria = criteria;
            Condition = condition;
        }
    }
}