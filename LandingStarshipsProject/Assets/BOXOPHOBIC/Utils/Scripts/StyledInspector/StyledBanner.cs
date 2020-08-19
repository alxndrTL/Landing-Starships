using UnityEngine;

namespace Boxophobic.StyledGUI
{
    public class StyledBanner : PropertyAttribute
    {
        public float colorR;
        public float colorG;
        public float colorB;
        public string title;
        public string subtitle;
        public int spaceTop;
        public int spaceBottom;
        public string helpURL;

        public StyledBanner(string title, string subtitle, string helpURL)
        {
            this.spaceTop = 10;
            this.spaceBottom = 10;
            this.colorR = -1;
            this.title = title;
            this.subtitle = subtitle;
            this.helpURL = helpURL;
        }

        public StyledBanner(float colorR, float colorG, float colorB, string title, string subtitle, string helpURL)
        {
            this.spaceTop = 10;
            this.spaceBottom = 10;
            this.colorR = colorR;
            this.colorG = colorG;
            this.colorB = colorB;
            this.title = title;
            this.subtitle = subtitle;
            this.helpURL = helpURL;
        }

        public StyledBanner(float colorR, float colorG, float colorB, string title, string subtitle, int spaceTop, int spaceBottom, string helpURL)
        {
            this.colorR = colorR;
            this.colorG = colorG;
            this.colorB = colorB;
            this.title = title;
            this.subtitle = subtitle;
            this.spaceTop = spaceTop;
            this.spaceBottom = spaceBottom;
            this.helpURL = helpURL;
        }
    }
}

