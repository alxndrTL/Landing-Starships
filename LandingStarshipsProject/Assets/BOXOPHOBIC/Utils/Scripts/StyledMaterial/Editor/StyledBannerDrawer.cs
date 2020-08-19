// Cristian Pop - https://boxophobic.com/

using UnityEngine;
using UnityEditor;
using Boxophobic.Constants;

namespace Boxophobic.StyledGUI
{
    public class StyledBannerDrawer : MaterialPropertyDrawer
    {
        public string title;
        public string subtitle;

        public StyledBannerDrawer(string title, string subtitle)
        {
            this.title = title;
            this.subtitle = subtitle;
        }

        public StyledBannerDrawer(string title)
        {
            this.title = title;
            this.subtitle = "";
        }

        public override void OnGUI(Rect position, MaterialProperty prop, string label, MaterialEditor materialEditor)
        {
            //EditorGUI.DrawRect(position, new Color(0, 1, 0, 0.05f));

            Material material = materialEditor.target as Material;

            DrawBanner(material.shader);
        }

        public override float GetPropertyHeight(MaterialProperty prop, string label, MaterialEditor editor)
        {
            return -2;
        }

        void DrawBanner(Shader shader)
        {
            GUILayout.Space(10);

            var bannerFullRect = GUILayoutUtility.GetRect(0, 0, 40, 0);
            var bannerBeginRect = new Rect(bannerFullRect.position.x, bannerFullRect.position.y, 20, 40);
            var bannerMiddleRect = new Rect(bannerFullRect.position.x + 20, bannerFullRect.position.y, bannerFullRect.xMax - 54, 40);
            var bannerEndRect = new Rect(bannerFullRect.xMax - 20, bannerFullRect.position.y, 20, 40);
            var iconRect = new Rect(bannerFullRect.xMax - 36, bannerFullRect.position.y + 5, 30, 30);

            Color bannerColor;
            Color guiColor;

            if (EditorGUIUtility.isProSkin)
            {
                bannerColor = CONSTANT.ColorDarkGray;
                guiColor = CONSTANT.ColorLightGray;
            }
            else
            {
                bannerColor = CONSTANT.ColorLightGray;
                guiColor = CONSTANT.ColorDarkGray;
            }

            GUI.color = bannerColor;

            GUI.DrawTexture(bannerBeginRect, CONSTANT.BannerImageBegin, ScaleMode.StretchToFill, true);
            GUI.DrawTexture(bannerMiddleRect, CONSTANT.BannerImageMiddle, ScaleMode.StretchToFill, true);
            GUI.DrawTexture(bannerEndRect, CONSTANT.BannerImageEnd, ScaleMode.StretchToFill, true);

#if UNITY_2019_3_OR_NEWER
            GUI.Label(bannerFullRect, "<size=16><color=#" + ColorUtility.ToHtmlStringRGB(guiColor) + ">" + title + subtitle + "</color></size>", CONSTANT.TitleStyle);
#else
            GUI.Label(bannerFullRect, "<size=14><color=#" + ColorUtility.ToHtmlStringRGB(guiColor) + "><b>" + title + "</b> " + subtitle + "</color></size>", CONSTANT.TitleStyle);
#endif

            GUI.color = guiColor;

#if AMPLIFY_SHADER_EDITOR
            if (GUI.Button(iconRect, CONSTANT.IconEdit, new GUIStyle { alignment = TextAnchor.MiddleCenter }))
            {
                AmplifyShaderEditor.AmplifyShaderEditorWindow.ConvertShaderToASE(Shader.Find(shader.name));
            }
#else
            if (GUI.Button(iconRect, CONSTANT.IconEdit, new GUIStyle { alignment = TextAnchor.MiddleCenter }))
            {     
                AssetDatabase.OpenAsset(Shader.Find(shader.name), 1);
            }
#endif


            GUI.color = Color.white;

            GUILayout.Space(10);
        }
    }
}
