using UnityEngine;
using System.Collections;

public class TitleScreenScript : MonoBehaviour {

    private GameObject Title;
    private GameObject StartButton;
    private GameObject MusicText;
    public GameObject audioManager;
    

	// Use this for initialization
	void Start () {
        if (!GameObject.Find("AudioManager"))
        {
            Instantiate(audioManager);
            GameObject.Find("AudioManager(Clone)").name = "AudioManager";
        }
        MusicText = GameObject.Find("MusicText");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartGame()
    {
        Application.LoadLevel("Gameplay1");
    }
    public void ChangeMusicButtonText()
    {

    }
}
