using UnityEngine;
using System.Collections;

public class ControlScript : MonoBehaviour
{
    private Texture screen;
    // Use this for initialization
    void Start()
    {
		screen = gameObject.GetComponent<Texture> ();
		Debug.Log (screen.ToString ());
    }
}
	

