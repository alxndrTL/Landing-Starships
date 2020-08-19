using UnityEngine;

public class EngineRCSAudioController : MonoBehaviour
{
    float cutoffOn = 500;
    public float cutoffOff = 1;

    public bool isEngineOn;

    System.Random rand = new System.Random();
    AudioLowPassFilter lowPassFilter;

    void Awake()
    {
        lowPassFilter = GetComponent<AudioLowPassFilter>();
        Update();
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = (float)(rand.NextDouble() * 2.0 - 1.0);
        }
    }

    void Update()
    {
        lowPassFilter.cutoffFrequency = isEngineOn ? cutoffOn : cutoffOff;
    }
}
