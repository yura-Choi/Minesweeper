using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameController : MonoBehaviour {

    public GameObject panel_SelectLevel;
    public GameObject panel_GameScreen;

    public GameObject prefeb_block_text;

    private string level = "";

	void Start () {
        panel_SelectLevel.SetActive(true);
        panel_GameScreen.SetActive(false);
	}
	
	void Update () {
		
	}

    // select level menu
	public void level_EASY() {
		this.level = "easy";
        panel_SelectLevel.SetActive(false);
        panel_GameScreen.SetActive(true);
	}
    public void level_NORMAL() {
        this.level = "normal";
        panel_SelectLevel.SetActive(false);
        panel_GameScreen.SetActive(true);
    }
    public void level_HARD() {
        this.level = "hard";
        panel_SelectLevel.SetActive(false);
        panel_GameScreen.SetActive(true);
    }

    public void back_TITLE() {
        SceneManager.LoadScene("Title");
    }

    public void map_block_open() {
        prefeb_block_text.SetActive(true);
    }

}
