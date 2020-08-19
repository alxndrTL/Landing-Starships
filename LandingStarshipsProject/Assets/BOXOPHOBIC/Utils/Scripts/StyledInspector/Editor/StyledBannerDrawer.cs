// Cristian Pop - https://boxophobic.com/

using UnityEngine;
using UnityEditor;
using Boxophobic.Constants;

namespace Boxophobic.StyledGUI
{
    [CustomPropertyDrawer(typeof(StyledBanner))]
    public class StyledBannerAttributeDrawer : PropertyDrawer
    {
        StyledBanner a;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            a = (StyledBanner)attribute;

            DrawBanner();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return -2;
        }

        void DrawBanner()
        {
            GUILayout.Space(a.spaceTop);

            var bannerFullRect = GUILayoutUtility.GetRect(0, 0, 40, 0);
            var bannerBeginRect = new Rect(bannerFullRect.position.x, bannerFullRect.position.y, 20, 40);
            var bannerMiddleRect = new Rect(bannerFullRect.position.x + 20, bannerFullRect.position.y, bannerFullRect.xMax - 54, 40);
            var bannerEndRect = new Rect(bannerFullRect.xMax - 20, bannerFullRect.position.y, 20, 40);
            var iconRect = new Rect(bannerFullRect.xMax - 36, bannerFullRect.position.y + 5, 30, 30);

            Color bannerColor;
            Color guiColor;

            if (EditorGUIUtility.isProSkin)
            {
                if (a.colorR < 0)
                {
                    bannerColor = CONSTANT.ColorDarkGray;
                    guiColor = CONSTANT.ColorLightGray;

                }
                else
                {
                    bannerColor = new Color(a.colorR, a.colorG, a.colorB, 1f);
                    guiColor = CONSTANT.ColorDarkGray;
                }                
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
            GUI.Label(bannerFullRect, "<size=16><color=#" + ColorUtility.ToHtmlStringRGB(guiColor) + ">" + a.title + " " + a.subtitle + "</color></size>", CONSTANT.TitleStyle);
#else
            GUI.Label(bannerFullRect, "<size=14><color=#" + ColorUtility.ToHtmlStringRGB(guiColor) + "><b>" + a.title + "</b> " + a.subtitle + "</color></size>", CONSTANT.TitleStyle);
#endif
            GUI.color = guiColor;

            if (GUI.Button(iconRect, CONSTANT.IconHelp, new GUIStyle { alignment = TextAnchor.MiddleCenter }))
            {
                Application.OpenURL(a.helpURL);
            }

            GUI.color = Color.white;

            GUILayout.Space(a.spaceBottom);
        }
    }

}
