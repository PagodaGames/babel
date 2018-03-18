using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addWood : MonoBehaviour {

    public float temps;
    private float decompte;
    private GameObject ressourcesHandler;

    // Use this for initialization
    void Start () {
        decompte = 0;
        ressourcesHandler = GameObject.Find("ressourcesHandler");
    }
	
	// Update is called once per frame
	void Update () {
        decompte += Time.deltaTime;
        if(decompte > temps * 18)
        {
            ressourcesHandler.transform.GetComponent<ressourcesHandler>().gold += (ressourcesHandler.transform.GetComponent<ressourcesHandler>().wood <= 0) ? 0 : 2;
            ressourcesHandler.transform.GetComponent<ressourcesHandler>().wood -= (ressourcesHandler.transform.GetComponent<ressourcesHandler>().wood <= 0) ? 0 : 1;
            decompte = 0;
        }
	}
}
