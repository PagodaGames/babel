using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectClickOnTile : MonoBehaviour {

    RaycastHit hit;
    Ray ray;
    bool click;
    bool touched;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        click = Input.GetMouseButtonDown(0);
        if (click)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            touched = Physics.Raycast(ray, out hit);
            /*Debug.DrawRay(hit.point, hit.point + new Vector3(0, 10, 0), Color.white, 5);
            Debug.DrawRay(hit.point, hit.point + new Vector3(10, 0, 0), Color.red, 5);*/
            if (touched)
            {
                if (hit.transform.gameObject.tag == "carre") { hit.transform.gameObject.GetComponent<groundColor>().clicked = true; }
                //else hit.transform.gameObject.GetComponent<groundColor>().clicked = false;
            }
        }

    }
}
