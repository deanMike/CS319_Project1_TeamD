using UnityEngine;
using System.Collections;

public class TitleScreenScript : MonoBehaviour {

    private GameObject Title;
    private GameObject StartButton;
    private GameObject MusicText;


	// Use this for initialization
	void Start () {
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
