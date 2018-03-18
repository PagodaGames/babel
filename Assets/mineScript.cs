using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mineScript : MonoBehaviour {

    public float temps;
    private float decompte;
    private GameObject ressourcesHandler;
    [Header("0 : GOLD; 1 : WOOD; 2 : SAND; 3 : ROCK")]
    [Range(0, 3)]
    public int to;
    public int toCreate;
    public int size = 100;

    // Use this for initialization
    void Start () {
        decompte = 0;
        ressourcesHandler = GameObject.Find("ressourcesHandler");
    }
	
	// Update is called once per frame
	void Update () {

        decompte += Time.deltaTime;
        if (decompte > temps * 18)
        {
            decompte = 0;
            if (size != 0)
            {

                switch (to)
                {
                    case 0:
                        ressourcesHandler.transform.GetComponent<ressourcesHandler>().gold += toCreate;
                        break;
                    case 1:
                        ressourcesHandler.transform.GetComponent<ressourcesHandler>().wood += toCreate;
                        break;
                    case 2:
                        ressourcesHandler.transform.GetComponent<ressourcesHandler>().sand += toCreate;
                        break;
                    case 3:
                    default:
                        ressourcesHandler.transform.GetComponent<ressourcesHandler>().rock += toCreate;
                        break;
                }
                // size -= toCreate;
                
            } else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
