using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorizePlane : MonoBehaviour
{
    public bool isOn;
    private Renderer rendererComponent;

    void Start()
    {
        rendererComponent = GetComponent<Renderer>();
    }

    public void Colorize(Color color)
    {
        if(isOn)
        {
            rendererComponent.material.color = color;
        }
    }
}
