using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireworks : MonoBehaviour
{
    public ParticleSystem fireworks;
    public float timer = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        fireworks.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (fireworks.isPlaying)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                fireworks.Stop();
            }
        }
    }
}
