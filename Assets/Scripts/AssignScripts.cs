using UnityEngine;
using System.Collections;

public class AssignScripts : MonoBehaviour {
    GameObject Chair;
    // Use this for initialization
    void Start()
    {
        // Add highlighter to all interactable objects.
        foreach (Transform obj in gameObject.GetComponentsInChildren<Transform>())
        {
            if (obj.gameObject.GetComponent<Collider>())
            {
                obj.gameObject.AddComponent<HighlightScript>();
            }
        }

        // Add chairscript to chair.
        Chair = GameObject.Find("upperChair");
        Chair.AddComponent<ChairSpin>();
    }

    // Update is called once per frame
    void Update () {
	
	}
}
