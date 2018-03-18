using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class converterBehaviour : MonoBehaviour {

    public float temps;
    private float decompte;
    private GameObject _gameMaster;
    [Header("0 : GOLD; 1 : WOOD; 2 : SAND; 3 : ROCK")]
    [Range(0,3)]
    public int from; // (0GOLD;1WOOD;2SAND;3ROCK)
    [Range(0, 3)]
    public int to;
    public int toTransfer;
    public int toCreate;
    public Color goldColor;
    public Color woodColor;
    public Color rockColor;
    public Color sandColor;

    // Use this for initialization
    void Start () {
        decompte = 0;
        _gameMaster = GameObject.Find("_gameMaster");
        switch(to)
        {
            case 0:
                GetComponentInChildren<Renderer>().material.color = goldColor;
                break;
            case 1:
                GetComponentInChildren<Renderer>().material.color = woodColor;
                break;
            case 2:
                GetComponentInChildren<Renderer>().material.color = sandColor;
                break;
            case 3:
            default:
                GetComponentInChildren<Renderer>().material.color = rockColor;
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {

        switch (to)
        {
            case 0:
                GetComponentInChildren<Renderer>().material.color = goldColor;
                break;
            case 1:
                GetComponentInChildren<Renderer>().material.color = woodColor;
                break;
            case 2:
                GetComponentInChildren<Renderer>().material.color = sandColor;
                break;
            case 3:
            default:
                GetComponentInChildren<Renderer>().material.color = rockColor;
                break;
        }



        decompte += Time.deltaTime;
        if (decompte > temps * 18)
        {
            int toRetire;
            switch(from)
            {
                case 0:
                    _gameMaster.transform.GetComponent<ressourcesHandler>().gold -= toTransfer;
                    toRetire = _gameMaster.transform.GetComponent<ressourcesHandler>().gold;
                    if (_gameMaster.transform.GetComponent<ressourcesHandler>().gold < 0)
                    {
                        _gameMaster.transform.GetComponent<ressourcesHandler>().gold = 0;
                    }
                    break;
                case 1:
                    _gameMaster.transform.GetComponent<ressourcesHandler>().wood -= toTransfer;
                    toRetire = _gameMaster.transform.GetComponent<ressourcesHandler>().wood;
                    if (_gameMaster.transform.GetComponent<ressourcesHandler>().wood < 0)
                    {
                        _gameMaster.transform.GetComponent<ressourcesHandler>().wood = 0;
                    }
                    break;
                case 2:
                    _gameMaster.transform.GetComponent<ressourcesHandler>().sand -= toTransfer;
                    toRetire = _gameMaster.transform.GetComponent<ressourcesHandler>().sand;
                    if (_gameMaster.transform.GetComponent<ressourcesHandler>().sand < 0)
                    {
                        _gameMaster.transform.GetComponent<ressourcesHandler>().sand = 0;
                    }
                    break;
                case 3:
                default:
                    _gameMaster.transform.GetComponent<ressourcesHandler>().rock -= toTransfer;
                    toRetire = _gameMaster.transform.GetComponent<ressourcesHandler>().rock;
                    if (_gameMaster.transform.GetComponent<ressourcesHandler>().rock < 0)
                    {
                        _gameMaster.transform.GetComponent<ressourcesHandler>().rock = 0;
                    }
                    break;
            }

            if (!(toRetire < 0))
            {
                switch (to)
                {
                    case 0:
                        _gameMaster.transform.GetComponent<ressourcesHandler>().gold += toCreate;
                        break;
                    case 1:
                        _gameMaster.transform.GetComponent<ressourcesHandler>().wood += toCreate;
                        break;
                    case 2:
                        _gameMaster.transform.GetComponent<ressourcesHandler>().sand += toCreate;
                        break;
                    case 3:
                    default:
                        _gameMaster.transform.GetComponent<ressourcesHandler>().rock += toCreate;
                        break;
                }
            }

            decompte = 0;
        }
    }
}
