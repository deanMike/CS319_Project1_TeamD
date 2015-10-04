using UnityEngine;
using System.Collections;

public class AudioManagerScript : MonoBehaviour {
    public AudioClip[] audioClipArray;
    public float[] volumeArray; 
    private AudioSource music;
    // Use this for initialization

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        
    }

	void Start () {
            music = gameObject.GetComponent<AudioSource>();
        if (Application.loadedLevelName == "TitleScreen")
        {
            music.clip = audioClipArray[0];
            music.volume = volumeArray[0];
            music.loop = true;
            music.Play();
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
