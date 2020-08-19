// Cristian Pop - https://boxophobic.com/

using UnityEditor;

namespace Boxophobic.Utils
{
    public partial class BoxophobicUtils
    {
        public static string GetBoxophobicFolder()
        {
            string[] folder = AssetDatabase.FindAssets("BOXOPHOBIC");
            string boxFolder = null;

            for (int i = 0; i < folder.Length; i++)
            {
                if (AssetDatabase.GUIDToAssetPath(folder[i]).EndsWith("BOXOPHOBIC"))
                {
                    boxFolder = AssetDatabase.GUIDToAssetPath(folder[i]);
                }
            }

            return boxFolder;
        }
    }
}

