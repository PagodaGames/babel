using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgColor : MonoBehaviour {

    public int ftw;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // y = 36   =>   9CC2FF00
        float fact = Mathf.Pow(36 / transform.position.y, ftw);
        gameObject.GetComponent<Camera>().backgroundColor = new Color(0.6f * fact, 0.75f * fact, fact, 0);
        
    }
}
