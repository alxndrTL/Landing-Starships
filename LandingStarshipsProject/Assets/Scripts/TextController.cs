using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text telemetryText;

    public void SetTelemetryText(float altitude, float speed)
    {
        telemetryText.text = (int)altitude + "m |" + (int)speed + "m/s";
    }
}
