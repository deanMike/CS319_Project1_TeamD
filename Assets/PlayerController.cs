using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.gameObject.transform.position = new Vector3(150, 15, 100);
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey("w")) {
            transform.Translate(0, 0, 3);
        }
        if (Input.GetKey("s")) {
            transform.Translate(0, 0, -3);
        }
        if (Input.GetKey("a")) {
            transform.Translate(-3, 0, 0);
        }
        if (Input.GetKey("d")) {
            transform.Translate(3, 0, 0);
        }
	}
}
