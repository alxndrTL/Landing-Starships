// Cristian Pop - https://boxophobic.com/

using UnityEngine;

namespace Boxophobic.StyledGUI
{
    public class StyledPopupArray : PropertyAttribute
    {
        public string array;

        public StyledPopupArray(string array)
        {
            this.array = array;
        }
    }
}

