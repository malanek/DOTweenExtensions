#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace BBExtensions.DOTweenExt
{
    [CustomPropertyDrawer(typeof(DOTweenParams))]
    public class DOTweenParamsDrawer : PropertyDrawer
    {
        private const string customEase = nameof(DOTweenParams.CustomEase);
        private const string animationCurve = nameof(DOTweenParams.AnimationCurve);
        private const string standardEase = nameof(DOTweenParams.StandardEase);
        private const string duration = nameof(DOTweenParams.Duration);
        private const float optionWidth = 15f;
        private const float durationWidth = 50f;
        private const float labelWidth = 125f;
        private const float padding = 2f;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            float remainingWidth = position.width - labelWidth - optionWidth - durationWidth - 6f;
            Rect labelRect = new(position.x, position.y, labelWidth, position.height);
            Rect optionRect = new(position.x + labelWidth, position.y, optionWidth, position.height);
            Rect curveRect = new(position.x + labelWidth + optionWidth + padding, position.y, remainingWidth, position.height);
            Rect durationRect = new(position.x + labelWidth + optionWidth + padding + remainingWidth + padding, position.y, durationWidth, position.height);

            using (new EditorGUI.PropertyScope(position, label, property))
            {
                SerializedProperty customEaseProperty = property.FindPropertyRelative(customEase);
                SerializedProperty durationProperty = property.FindPropertyRelative(duration);
                EditorGUI.LabelField(labelRect, label);
                EditorGUI.PropertyField(optionRect, customEaseProperty, GUIContent.none);
                EditorGUI.PropertyField(durationRect, durationProperty, GUIContent.none);
                if (customEaseProperty.boolValue)
                    EditorGUI.PropertyField(curveRect, property.FindPropertyRelative(animationCurve), GUIContent.none);
                else
                    EditorGUI.PropertyField(curveRect, property.FindPropertyRelative(standardEase), GUIContent.none);
            }
        }

    }
}
#endif
