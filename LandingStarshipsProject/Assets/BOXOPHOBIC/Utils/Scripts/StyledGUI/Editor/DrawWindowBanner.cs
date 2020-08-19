// Cristian Pop - https://boxophobic.com/

using UnityEngine;
using UnityEditor;
using Boxophobic.Constants;

namespace Boxophobic.StyledGUI
{
    public partial class StyledGUI
    {
        public static void DrawWindowBanner(Color bannerColor, string bannerText, string helpURL)
        {
            GUILayout.Space(20);

            var bannerFullRect = GUILayoutUtility.GetRect(0, 0, 40, 0);
            var bannerBeginRect = new Rect(bannerFullRect.position.x + 20, bannerFullRect.position.y, 20, 40);
            var bannerMiddleRect = new Rect(bannerFullRect.position.x + 40, bannerFullRect.position.y, bannerFullRect.xMax - 75, 40);
            var bannerEndRect = new Rect(bannerFullRect.xMax - 36, bannerFullRect.position.y, 20, 40);
            var iconRect = new Rect(bannerFullRect.xMax - 53, bannerFullRect.position.y + 5, 30, 30);

            Color guiColor;

            if (EditorGUIUtility.isProSkin)
            {
                bannerColor = new Color(bannerColor.r, bannerColor.g, bannerColor.b, 1f);
            }
            else
            {
                bannerColor = CONSTANT.ColorLightGray;
            }

            if (bannerColor.r + bannerColor.g + bannerColor.b <= 1.5)
            {
                guiColor = CONSTANT.ColorLightGray;
            }
            else
            {
                guiColor = CONSTANT.ColorDarkGray;
            }

            GUI.color = bannerColor;

            GUI.DrawTexture(bannerBeginRect, CONSTANT.BannerImageBegin, ScaleMode.StretchToFill, true);
            GUI.DrawTexture(bannerMiddleRect, CONSTANT.BannerImageMiddle, ScaleMode.StretchToFill, true);
            GUI.DrawTexture(bannerEndRect, CONSTANT.BannerImageEnd, ScaleMode.StretchToFill, true);

            GUI.color = guiColor;

#if UNITY_2019_3_OR_NEWER
            GUI.Label(bannerFullRect, "<size=16><color=#" + ColorUtility.ToHtmlStringRGB(guiColor) + ">" + bannerText + "</color></size>", CONSTANT.TitleStyle);
#else
            GUI.Label(bannerFullRect, "<size=14><color=#" + ColorUtility.ToHtmlStringRGB(guiColor) + "><b>" + bannerText + "</b></color></size>", CONSTANT.TitleStyle);
#endif
            if (GUI.Button(iconRect, CONSTANT.IconHelp, new GUIStyle { alignment = TextAnchor.MiddleCenter }))
            {
                Application.OpenURL(helpURL);
            }

            GUI.color = Color.white;
            GUILayout.Space(20);
        }
    }
}

