using UnityEngine;
using System.Collections;

public class AutoText : MonoBehaviour {

    public float letterPause = 0.2f;

    string message;
    TextMesh title;

	// Use this for initialization
	void Start () {
        title = gameObject.GetComponent<TextMesh>();
        message = title.text;

        title.text = "";

        StartCoroutine(TypeText());
	    
	}

    IEnumerator TypeText()
    {
        foreach(char letter in message.ToCharArray())
        {
            title.text += letter;
            yield return new WaitForSeconds(letterPause);
        }
    }
}
