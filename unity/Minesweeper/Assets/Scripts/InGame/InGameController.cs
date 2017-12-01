using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameController : MonoBehaviour {

    public GameObject panel_SelectLevel;
    public GameObject panel_GameScreen;

	void Start () {
        panel_SelectLevel.SetActive(true);
        panel_GameScreen.SetActive(false);
	}

    // select level menu
    public void level_EASY() {
        PlayerPrefs.SetString("level", "easy");
        panel_SelectLevel.SetActive(false);
        panel_GameScreen.SetActive(true);
	}
	public void level_NORMAL() {
		PlayerPrefs.SetString("level", "normal");
        panel_SelectLevel.SetActive(false);
        panel_GameScreen.SetActive(true);
    }
	public void level_HARD() {
		PlayerPrefs.SetString("level", "hard");
        panel_SelectLevel.SetActive(false);
        panel_GameScreen.SetActive(true);
    }

    public void back_TITLE() {
        SceneManager.LoadScene("Title");
    }

}
