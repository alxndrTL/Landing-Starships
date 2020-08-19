using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorizePlane : MonoBehaviour
{
    private Renderer rendererComponent;

    void Start()
    {
        rendererComponent = GetComponent<Renderer>();
    }

    public void Colorize(Color color)
    {
        rendererComponent.material.color = color;
    }
}
