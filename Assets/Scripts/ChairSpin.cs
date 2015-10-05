using UnityEngine;
using System.Collections;
using System;

public class ChairSpin : MonoBehaviour {
    private bool isRotating = false;
    private float spinTime = 2.0f;
    private AudioClip[] chairSounds;
    void Start()
    {
        chairSounds = new AudioClip[7];
        for (int i = 0; i < chairSounds.Length; i++)
        {
            chairSounds[i] = GameObject.Find("AudioManager").GetComponent<AudioManagerScript>().audioClipArray[i + 3];
        }
    }

    void OnMouseDown()
    {
        GetComponent<AudioSource>().clip = chairSounds[new System.Random().Next(1,6)];
        GetComponent<AudioSource>().Play();
        isRotating = true;
    }

    void Update()
    {
        if (isRotating)
        {
            spinChair();
            spinTime -= Time.deltaTime;
        }
    }

    void spinChair()
    {
        transform.Rotate(Vector3.down, Time.deltaTime * 180, Space.World);
        //Debug.Log(transform.rotation.y.ToString());
        if (spinTime <= 0)
        {
            isRotating = false;
            spinTime = 2.0f;
        }
    }
}
