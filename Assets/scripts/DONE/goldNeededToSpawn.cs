using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class goldNeededToSpawn : MonoBehaviour {

    private GameObject _gameMaster;
    public Text onetext;

    // Use this for initialization
    void Start () {
        _gameMaster = GameObject.Find("_gameMaster");
    }
	
	// Update is called once per frame
	void Update () {
        if(_gameMaster.transform.GetComponent<ressourcesHandler>().gold < _gameMaster.transform.GetComponent<prices>().priceFloor)
        {
            // desactiver le bouton
        } else
        {
            // activer le bouton
        }
        onetext.text = _gameMaster.transform.GetComponent<prices>().priceFloor + "";
    }
}
