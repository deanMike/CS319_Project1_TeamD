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
    public int up;
    public int mid;
    public int down;

    // Use this for initialization
    void Start() {
        FPSCamera = GameObject.Find("VariableController");
        cameraPos = FPSCamera.transform.position;
        variables = FPSCamera.GetComponent<VariableControl>();
        AssignSounds();
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
            if (!upClose && !variables.interacting)
            {
                Debug.Log(variables.interacting);
                InspectObject();
            } else if (upClose)
            {
                PutDownObject();
            }
        }
        if (Input.GetKeyDown("r") && upClose)
        {
            ThrowObject();
        }
        Debug.Log(transform.localPosition.ToString());

    }
    void ThrowObject()
    {

        rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = true;
        upClose = false;
        variables.interacting = false;
        rb.velocity = Vector3.back * 10;
        GameObject.Find("AudioManager2").GetComponent<AudioSource>().Stop();
        if (!GameObject.Find("AudioManager2").GetComponent<AudioSource>().isPlaying && down > 0)
        {
            GameObject.Find("AudioManager2").GetComponent<AudioSource>().clip = GameObject.Find("AudioManager2").GetComponent<AudioManagerScript>().audioClipArray[down];
            GameObject.Find("AudioManager2").GetComponent<AudioSource>().Play();

        }
    }
    void InspectObject()
    {
        upClose = true;
        variables.interacting = true;
        originalPos = transform.position;
        originalRot = transform.rotation;
        Debug.Log(originalPos.ToString());
        transform.position = Camera.main.transform.position + (Camera.main.transform.forward / 1.1f);
        StartCoroutine(PlaySounds());

        //gameObject.transform.parent = Camera.main.transform;
    }
    public void PutDownObject(Vector3 pos, Quaternion rot) {
        
        upClose = false;
        variables.interacting = false;
        //gameObject.transform.parent = null;
        transform.position = pos;
        transform.rotation = rot;
        //transform.Rotate(originalPos.rotation.eulerAngles);
        GameObject.Find("AudioManager2").GetComponent<AudioSource>().Stop();
        if (!GameObject.Find("AudioManager2").GetComponent<AudioSource>().isPlaying && down > 0)
        {
            GameObject.Find("AudioManager2").GetComponent<AudioSource>().clip = GameObject.Find("AudioManager2").GetComponent<AudioManagerScript>().audioClipArray[down];
            GameObject.Find("AudioManager2").GetComponent<AudioSource>().Play();

        }


    }
    public void PutDownObject()
    {
        PutDownObject(originalPos, originalRot);
    }

    public void AssignSounds()
    {
        switch (gameObject.tag)
        {
            case "printer":
                up = 22;
                break;
            case "mug":
                down = 19;
                break;
            case "frame":
                down = 18;
                break;
            case "paper":
                up = 20;
                down = 21;
                break;
            case "drawer":
                up = new System.Random().Next(12, 14);
                down = new System.Random().Next(10, 12);
                break;
            case "phone":
                up = 15;
                down = 14;
                mid = new System.Random().Next(16, 18);
                break;
            default:
                break;

        }
    }
    IEnumerator PlaySounds()
    {
        if (up > 0)
        {
            GameObject.Find("AudioManager2").GetComponent<AudioSource>().clip = GameObject.Find("AudioManager2").GetComponent<AudioManagerScript>().audioClipArray[up];
            GameObject.Find("AudioManager2").GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(GameObject.Find("AudioManager2").GetComponent<AudioSource>().clip.length);

        }
        if (mid > 0)
        {
            GameObject.Find("AudioManager2").GetComponent<AudioSource>().clip = GameObject.Find("AudioManager2").GetComponent<AudioManagerScript>().audioClipArray[mid];
            GameObject.Find("AudioManager2").GetComponent<AudioSource>().Play();

        }
    }
}
