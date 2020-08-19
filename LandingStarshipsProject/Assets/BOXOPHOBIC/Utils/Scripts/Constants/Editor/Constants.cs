//  Cristian Pop - https://boxophobic.com/

using UnityEngine;
using UnityEditor;

namespace Boxophobic.Constants
{
    public static class CONSTANT
    {
        public static Texture2D LogoImage
        {
            get
            {
                if (EditorGUIUtility.isProSkin)
                {
                    return Resources.Load("Boxophobic - LogoDark") as Texture2D;
                }
                else
                {
                    return Resources.Load("Boxophobic - LogoLight") as Texture2D;
                }
            }
        }

        public static Texture2D BannerImageBegin
        {
            get
            {
                return Resources.Load("Boxophobic - BannerBegin") as Texture2D;
            }
        }

        public static Texture2D BannerImageMiddle
        {
            get
            {
                return Resources.Load("Boxophobic - BannerMiddle") as Texture2D;
            }
        }

        public static Texture2D BannerImageEnd
        {
            get
            {
                return Resources.Load("Boxophobic - BannerEnd") as Texture2D;
            }
        }

        public static Texture2D CategoryImageBegin
        {
            get
            {
                return Resources.Load("Boxophobic - CategoryBegin") as Texture2D;
            }
        }

        public static Texture2D CategoryImageMiddle
        {
            get
            {
                return Resources.Load("Boxophobic - CategoryMiddle") as Texture2D;
            }
        }

        public static Texture2D CategoryImageEnd
        {
            get
            {
                return Resources.Load("Boxophobic - CategoryEnd") as Texture2D;
            }
        }

        public static Texture2D IconEdit
        {
            get
            {
                return Resources.Load("Boxophobic - IconEdit") as Texture2D;
            }
        }

        public static Texture2D IconFile
        {
            get
            {
                return Resources.Load("Boxophobic - IconFile") as Texture2D;
            }
        }

        public static Texture2D IconHelp
        {
            get
            {
                return Resources.Load("Boxophobic - IconHelp") as Texture2D;
            }
        }

        public static Color ColorDarkGray
        {
            get
            {
                return new Color(0.27f, 0.27f, 0.27f);
            }
        }

        public static Color ColorLightGray
        {
            get
            {
                return new Color(0.83f, 0.83f, 0.83f);
            }
        }

        public static GUIStyle TitleStyle
        {
            get
            {
                GUIStyle guiStyle = new GUIStyle
                {
                    richText = true,
                    alignment = TextAnchor.MiddleCenter
                };

                return guiStyle;
            }
        }

        public static GUIStyle BoldTextStyle
        {
            get
            {
                GUIStyle guiStyle = new GUIStyle();

                Color color;

                if (EditorGUIUtility.isProSkin)
                {
                    color = new Color(0.87f, 0.87f, 0.87f);
                }
                else
                {
                    color = new Color(0.27f, 0.27f, 0.27f);
                }

                guiStyle.normal.textColor = color;
                guiStyle.alignment = TextAnchor.MiddleCenter;
                guiStyle.fontStyle = FontStyle.Bold;

                return guiStyle;
            }
        }
    }
}

