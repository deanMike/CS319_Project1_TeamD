using UnityEngine;
using System.Collections;

public class InspectObjectScript : MonoBehaviour {

    private GameObject FPSCamera;
    private Vector3 cameraPos;
    private bool upClose = false;
    private RaycastHit hit;
    private Vector3 originalPos;
    private Quaternion originalRot;
    public GameObject interact;
    public VariableControl variables;
    private Rigidbody rb;

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
            transform.Rotate(new Vector3(0 - Input.GetAxis("Mouse Y"), 0 - Input.GetAxis("Mouse X"), 0), Time.deltaTime * 360);
            transform.localPosition += (new Vector3(0, 0, Time.deltaTime * Input.GetAxis("Mouse ScrollWheel")));
        }
    }
    
    void OnMouseOver()
    {
        if (Input.GetKeyDown("e"))
        {
            if (gameObject.GetComponent<Rigidbody>())
            {
                Destroy(gameObject.GetComponent<Rigidbody>());
            }
            if (!upClose)
            {
                Debug.Log("UP");
                InspectObject();
            } else  
            {
                PutDownObject();
            }
        }
        if (Input.GetKeyDown("r") && upClose)
        {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.useGravity = true;
            upClose = false;
            variables.interacting = false;
            rb.velocity = Vector3.back * 10;
            
        }
        Debug.Log(transform.localPosition.ToString());

    }
    void InspectObject()
    {
        upClose = true;
        variables.interacting = true;
        originalPos = transform.position;
        originalRot = transform.rotation;
        Debug.Log(originalPos.ToString());
        transform.position = Camera.main.transform.position + Camera.main.transform.forward;
        

        //gameObject.transform.parent = Camera.main.transform;
    }
    public void PutDownObject(Vector3 pos, Quaternion rot) {
        
        upClose = false;
        variables.interacting = false;
        //gameObject.transform.parent = null;
        transform.position = pos;
        transform.rotation = rot;
        //transform.Rotate(originalPos.rotation.eulerAngles);

        
    }
    public void PutDownObject()
    {
        PutDownObject(originalPos, originalRot);
    }
}
