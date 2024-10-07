#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace BBExtensions.DOTweenExt
{
    [CustomPropertyDrawer(typeof(DOTweenParams))]
    public class DOTweenParamsDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            // Get the element index if it's part of a list
            int index = GetElementIndex(property);

            float labelWidth = EditorGUIUtility.labelWidth;
            float indentLength = EditorGUI.indentLevel * 15f;

            // Display the variable name or list element index
            Rect labelRect = new(position.x + indentLength, position.y, labelWidth - indentLength, position.height);
            if (index != -1)
            {
                EditorGUI.LabelField(labelRect, new GUIContent("Element " + index));
            }
            else
            {
                EditorGUI.LabelField(labelRect, label);
            }

            float optionWidth = 15f; // Fixed width for option field
            float durationWidth = 50f; // Fixed width for duration field

            float remainingWidth = position.width - labelWidth - optionWidth - durationWidth - 4f; // Remaining width for curve field
            float startX = position.x + labelWidth;

            Rect optionRect = new(startX, position.y, optionWidth, position.height);
            Rect curveRect = new(startX + optionWidth + 2f, position.y, remainingWidth, position.height);
            Rect durationRect = new(startX + optionWidth + 2f + remainingWidth + 2f, position.y, durationWidth, position.height);

            SerializedProperty customEaseProperty = property.FindPropertyRelative("CustomEase");

            EditorGUI.PropertyField(optionRect, customEaseProperty, GUIContent.none);
            if (customEaseProperty.boolValue)
                EditorGUI.PropertyField(curveRect, property.FindPropertyRelative("AnimationCurve"), GUIContent.none);
            else
                EditorGUI.PropertyField(curveRect, property.FindPropertyRelative("StandardEase"), GUIContent.none);
            EditorGUI.PropertyField(durationRect, property.FindPropertyRelative("Duration"), GUIContent.none);

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => EditorGUIUtility.singleLineHeight;

        private int GetElementIndex(SerializedProperty property)
        {
            if (property.depth == 0 || !property.propertyPath.Contains("["))
                return -1;

            int startIndex = property.propertyPath.LastIndexOf("[") + 1;
            int endIndex = property.propertyPath.IndexOf("]", startIndex);
            string indexString = property.propertyPath[startIndex..endIndex];

            return int.TryParse(indexString, out int index) ? index : -1;
        }

    }
}
#endif
