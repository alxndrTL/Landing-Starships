// Cristian Pop - https://boxophobic.com/

using UnityEngine;
using UnityEditor;

namespace Boxophobic.StyledGUI
{
    public class StyledSpaceDrawer : MaterialPropertyDrawer
    {
        public float space;

        public StyledSpaceDrawer(float space)
        {
            this.space = space;
        }

        public override void OnGUI(Rect position, MaterialProperty prop, string label, MaterialEditor materialEditor)
        {
            //EditorGUI.DrawRect(position, new Color(0, 1, 0, 0.05f));

            //Material material = materialEditor.target as Material;

            GUILayout.Space(space);
        }

        public override float GetPropertyHeight(MaterialProperty prop, string label, MaterialEditor editor)
        {
            return -2;
        }
    }
}
