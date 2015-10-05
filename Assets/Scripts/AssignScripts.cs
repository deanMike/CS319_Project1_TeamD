using UnityEngine;
using System.Collections;

public class AssignScripts : MonoBehaviour {
    private GameObject Chair;

    // Use this for initialization
    void Start()
    {        // Add highlighter to all interactable objects.
        foreach (Transform obj in gameObject.GetComponentsInChildren<Transform>())
        {
            if (obj.gameObject.GetComponent<Collider>())
            {
                obj.gameObject.AddComponent<HighlightScript>();
                obj.gameObject.AddComponent<InspectObjectScript>();
            }
        }
        
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("NonInteractive"))
        {
            Destroy(obj.GetComponent<HighlightScript>());
            Destroy(obj.GetComponent<InspectObjectScript>());
        }

        // Add chairscript to chair.
        Chair = GameObject.Find("upperChair");
        Chair.AddComponent<ChairSpin>();
        AudioSource sound = Chair.AddComponent<AudioSource>();
        }

    // Update is called once per frame
    void Update () {
	
	}
}
