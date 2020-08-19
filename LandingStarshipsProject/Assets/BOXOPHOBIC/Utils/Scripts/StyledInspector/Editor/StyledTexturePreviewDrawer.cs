// Cristian Pop - https://boxophobic.com/

using UnityEngine;
using UnityEditor;

namespace Boxophobic.StyledGUI
{
    [CustomPropertyDrawer(typeof(StyledTexturePreview))]
    public class StyledTexturePreviewAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var rect = GUILayoutUtility.GetRect(0, 0, Screen.width, 0);
            GUI.DrawTexture(rect, (Texture)property.objectReferenceValue, ScaleMode.StretchToFill, false);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return -2;
        }
    }
}
