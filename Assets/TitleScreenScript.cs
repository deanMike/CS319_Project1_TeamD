using UnityEngine;
using System.Collections;

public class TitleScreenScript : MonoBehaviour {

    private GameObject Title;
    private GameObject StartButton;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartGame()
    {
        Application.LoadLevel("Gameplay1");
    }
}
