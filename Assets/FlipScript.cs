using UnityEngine;
using System.Collections;

public class FlipScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionEnter(Collision collision) {
        if (Input.GetKey("space")) {
            transform.Translate(new Vector3(25, 0, 25));
        }
    }
}
