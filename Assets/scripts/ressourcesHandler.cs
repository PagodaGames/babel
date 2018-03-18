using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ressourcesHandler : MonoBehaviour {

    public int wood;
    public int gold;
    public int rock;
    public int sand;

    public Text woodText;
    public Text goldText;
    public Text rockText;
    public Text sandText;
	
	// Update is called once per frame
	void Update () {
        woodText.text = "" + wood;
        goldText.text = "" + gold;
        rockText.text = "" + rock;
        sandText.text = "" + sand;
	}
}
