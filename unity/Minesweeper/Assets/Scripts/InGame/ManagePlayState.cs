using UnityEngine;
using UnityEngine.UI;

public class ManagePlayState : MonoBehaviour {

	public Text text_Flag;
	public Text text_LandMine;

	private GlobalState script_Global;

	void Start () {
        script_Global = GameObject.Find("InGameController").GetComponent<GlobalState>();
	}
	
	void Update () {
        text_LandMine.text = "LandMine  " + script_Global.GetLandMineLeft();
        text_Flag.text = "Flag  " + script_Global.GetFlag();
	}
}
