using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class characterCreation : MonoBehaviour {

    public float temps;
    private float decompte;
    private GameObject _gameMaster;
    private Button gold;
    private Button wood;
    private Button sand;
    private Button rock;
    [Header("0 : GOLD; 1 : WOOD; 2 : SAND; 3 : ROCK")]
    [Range(0, 3)]
    public int to;
    public int toCreate;

    // Use this for initialization
    void Start () {
        decompte = 0;
        _gameMaster = GameObject.Find("_gameMaster");

        gold = GameObject.Find("goldMain").GetComponent<Button>();
        gold.onClick.AddListener(TaskOnClick0);

        wood = GameObject.Find("woodMain").GetComponent<Button>();
        wood.onClick.AddListener(TaskOnClick1);

        sand = GameObject.Find("sandMain").GetComponent<Button>();
        sand.onClick.AddListener(TaskOnClick2);

        rock = GameObject.Find("rockMain").GetComponent<Button>();
        rock.onClick.AddListener(TaskOnClick3);

    }

    void TaskOnClick0()
    {
        to = 0;
    }
    void TaskOnClick1()
    {
        to = 1;
    }
    void TaskOnClick2()
    {
        to = 2;
    }
    void TaskOnClick3()
    {
        to = 3;
    }

    // Update is called once per frame
    void Update () {
        decompte += Time.deltaTime;
        if (decompte > temps * 18)
        {
            switch (to)
            {
                case 0:
                default:
                    _gameMaster.transform.GetComponent<ressourcesHandler>().gold += toCreate;
                    break;
                case 1:
                    _gameMaster.transform.GetComponent<ressourcesHandler>().wood += toCreate;
                    break;
                case 2:
                    _gameMaster.transform.GetComponent<ressourcesHandler>().sand += toCreate;
                    break;
                case 3:
                    _gameMaster.transform.GetComponent<ressourcesHandler>().rock += toCreate;
                    break;
            }
            decompte = 0;
        }
    }
}
