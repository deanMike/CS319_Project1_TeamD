using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MusicButtonScript : MonoBehaviour {
    private Text musicText;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        musicText = GetComponentInChildren<Text>();
    }
    
    public void stopMusic()
    {
        if (GameObject.Find("AudioManager").GetComponent<AudioSource>().isPlaying)
        {
            GameObject.Find("AudioManager").GetComponent<AudioSource>().Stop();
        }
        else
        {
            GameObject.Find("AudioManager").GetComponent<AudioSource>().Play();
        }

    }


    public void ChangeText()
    {
        if(musicText.text == "Turn Music Off")
        {
            musicText.text = "Turn Music On";
        } else
        {
            musicText.text = "Turn Music Off";
        }
    }
	
}
