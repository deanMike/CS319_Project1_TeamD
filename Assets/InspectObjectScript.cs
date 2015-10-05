using UnityEngine;
using System.Collections;

public class InspectObjectScript : MonoBehaviour {

    private GameObject FPSCamera;
    private Vector3 cameraPos;
    private bool upClose = false;
    private RaycastHit hit;
    private Transform originalPos;
    public GameObject interact;
    public VariableControl variables;

    // Use this for initialization
    void Start() {
        FPSCamera = GameObject.Find("VariableController");
        cameraPos = FPSCamera.transform.position;
        variables = FPSCamera.GetComponent<VariableControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (upClose)
        {
            transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0), Time.deltaTime * 300);
        }
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
                PutDownObject();
            }
        }
        Debug.Log(gameObject.name);

    }
    void InspectObject()
    {
        upClose = true;
        variables.interacting = true;
        originalPos = transform;
        transform.position = Camera.main.transform.position + Camera.main.transform.forward;
        //gameObject.transform.parent = Camera.main.transform;
    }
    public void PutDownObject() {
        upClose = false;
        variables.interacting = false;
        //gameObject.transform.parent = null;
        transform.Translate(originalPos.position);
        transform.Rotate(originalPos.rotation.eulerAngles);
        
    }
}
