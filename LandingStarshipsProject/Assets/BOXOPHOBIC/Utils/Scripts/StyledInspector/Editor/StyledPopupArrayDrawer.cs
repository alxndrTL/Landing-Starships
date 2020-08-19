// Cristian Pop - https://boxophobic.com/

using UnityEngine;
using UnityEditor;

namespace Boxophobic.StyledGUI
{
    [CustomPropertyDrawer(typeof(StyledPopupArray))]
    public class StyledPopupArrayAttributeDrawer : PropertyDrawer
    {
        StyledPopupArray a;
        private int index = 0;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            a = (StyledPopupArray)attribute;

            var arrProp = property.serializedObject.FindProperty(a.array);

            var arr = new string[arrProp.arraySize];

            for (int i = 0; i < arrProp.arraySize; i++)
            {
                arr[i] = arrProp.GetArrayElementAtIndex(i).stringValue;
            }

            index = EditorGUILayout.Popup(property.displayName, index, arr);
            property.intValue = index;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return -2;
        }
    }
}
