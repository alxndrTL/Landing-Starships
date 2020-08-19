// Cristian Pop - https://boxophobic.com/

using UnityEngine;
using UnityEditor;
using System;

namespace Boxophobic.StyledGUI
{
    public class StyledInteractiveDrawer : MaterialPropertyDrawer
    {
        public string keyword;
        public float value1 = -1f;
        public float value2 = -1f;
        public float value3 = -1f;

        protected int type;

        public StyledInteractiveDrawer(string k)
        {
            type = 0;
            keyword = k;
        }

        public StyledInteractiveDrawer(string k, float v1)
        {
            type = 1;
            keyword = k;
            value1 = v1;
        }

        public StyledInteractiveDrawer(string k, float v1, float v2)
        {
            type = 1;
            keyword = k;
            value1 = v1;
            value2 = v2;
        }

        public StyledInteractiveDrawer(string k, float v1, float v2, float v3)
        {
            type = 1;
            keyword = k;
            value1 = v1;
            value2 = v2;
            value3 = v3;
        }

        public override void OnGUI(Rect position, MaterialProperty prop, String label, MaterialEditor materialEditor)
        {
            Material material = materialEditor.target as Material;

            if (type == 1)
            {
                if (material.HasProperty(keyword))
                {
                    if (value1 == material.GetFloat(keyword) || value2 == material.GetFloat(keyword) || value3 == material.GetFloat(keyword))
                    {
                        GUI.enabled = true;
                    }
                    else
                    {
                        GUI.enabled = false;
                    }
                }
            }
            else if (type == 0)
            {
                if (keyword == "ON")
                {
                    GUI.enabled = true;
                }
                else if (keyword == "OFF")
                {
                    GUI.enabled = false;
                }
                else if (material.IsKeywordEnabled(keyword))
                {
                    GUI.enabled = true;
                }
                else
                {
                    GUI.enabled = false;
                }
            }
        }

        public override float GetPropertyHeight(MaterialProperty prop, string label, MaterialEditor editor)
        {
            return -2;
        }
    }
}