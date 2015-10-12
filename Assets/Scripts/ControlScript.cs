using UnityEngine;
using System.Collections;

public class ControlScript : MonoBehaviour
{
    private Material screen;
    // Use this for initialization
    void Start()
    {
        screen = gameObject.GetComponents<Material>()[1];
    }
}
	

