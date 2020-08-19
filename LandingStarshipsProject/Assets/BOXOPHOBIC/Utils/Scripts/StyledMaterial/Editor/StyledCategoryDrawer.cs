// Cristian Pop - https://boxophobic.com/

using UnityEngine;
using UnityEditor;
using System;

namespace Boxophobic.StyledGUI
{
    public class StyledCategoryDrawer : MaterialPropertyDrawer
    {
        public string category;

        public StyledCategoryDrawer(string category)
        {
            this.category = category;
        }

        public override void OnGUI(Rect position, MaterialProperty prop, String label, MaterialEditor materiaEditor)
        {
            if (prop.floatValue < 0)
            {
                GUI.enabled = true;
            }
            else
            {
                GUI.enabled = true;
                StyledGUI.DrawInspectorCategory(position, category);
            }
        }

        public override float GetPropertyHeight(MaterialProperty prop, string label, MaterialEditor editor)
        {
            if (prop.floatValue < 0)
            {
                return -2;
            }
            else
            {
                return 40;
            }
        }
    }
}
