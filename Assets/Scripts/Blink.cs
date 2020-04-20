using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public Renderer target;

    public float changeTime;

    private float nextChangeTime;

    private bool isOn;

    private void Start()
    {
        nextChangeTime = Time.time + nextChangeTime;
        isOn = false;
    }

    private void Update()
    {
        if (Time.time >= nextChangeTime)
        {
            nextChangeTime = Time.time + changeTime;
            isOn = !isOn;
            if (isOn)
            {
                target.material.color = Color.white;
            }
            else
            {
                target.material.color = Color.gray;
            }
        }
    }
}
