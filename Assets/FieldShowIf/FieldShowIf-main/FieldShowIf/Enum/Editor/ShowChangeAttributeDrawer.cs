namespace FieldShowIf.Enum
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;
    using UnityEditor;
    using UnityEngine;

    [CustomPropertyDrawer(typeof(ShowChangeAttribute), true)]
    public class ShowChangeAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var showChangeAttribute = attribute as ShowChangeAttribute;
            var target = property.serializedObject.targetObject;
            Type conditionType = property.serializedObject.targetObject.GetType();
            FieldInfo conditionField = conditionType.GetField(showChangeAttribute.Condition, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            if (conditionField.GetValue(target).ToString().Contains(showChangeAttribute.Criteria))
            {
                // EditorGUI.BeginDisabledGroup(true);
                EditorGUI.PropertyField(position, property, label, true);
                // EditorGUI.EndDisabledGroup();
            }
        }
    }
}