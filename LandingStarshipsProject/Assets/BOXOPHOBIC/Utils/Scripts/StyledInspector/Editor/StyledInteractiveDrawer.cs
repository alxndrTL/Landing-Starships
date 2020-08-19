// Cristian Pop - https://boxophobic.com/

using UnityEngine;
using UnityEditor;

namespace Boxophobic.StyledGUI
{
    [CustomPropertyDrawer(typeof(StyledInteractive))]
    public class StyledInteractiveAttributeDrawer : PropertyDrawer
    {
        StyledInteractive a;

        private int Value;
        private string Keywork;
        public int Type;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            a = (StyledInteractive)attribute;

            Value = a.value;
            Keywork = a.keyword;
            Type = a.type;

            if (Type == 0)
            {
                if (property.intValue == Value)
                {
                    GUI.enabled = true;
                }
                else
                {
                    GUI.enabled = false;
                }
            }
            else if (Type == 1)
            {
                if (Keywork == "ON")
                {
                    GUI.enabled = true;
                }
                else if (Keywork == "OFF")
                {
                    GUI.enabled = false;
                }
            }

        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return -2;
        }
    }
}
