using UnityEngine;
using System.Collections;

public class InspectObjectScript : MonoBehaviour {

    private GameObject FPSCamera;
    private Vector3 cameraPos;
    private bool upClose = false;
    private RaycastHit hit;
    private Vector3 originalPos;
    public GameObject interact;

    // Use this for initialization
    void Start() {
        FPSCamera = GameObject.Find("FPSController");
        cameraPos = FPSCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       

    }
    
    void OnMouseOver()
    {
        if (Input.GetKeyDown("e"))
        {
            if (!upClose)
            {
                Debug.Log("UP");
                InspectObject();
            } else
            {
                Debug.Log("Down");
                PutDownObject();
            }
        }
    }
    void InspectObject()
    {
        originalPos = transform.position;
        while (!transform.position.Equals(cameraPos))
        {
            transform.position = (Vector3.MoveTowards(originalPos, cameraPos, Time.deltaTime));
        }
        upClose = true;
    }
    void PutDownObject() {
        transform.Translate(Vector3.MoveTowards(cameraPos, originalPos, 1.0f));
        upClose = false;
    }
}
