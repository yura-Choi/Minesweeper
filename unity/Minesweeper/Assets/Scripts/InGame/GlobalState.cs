using UnityEngine;

public class GlobalState : MonoBehaviour {

    private int width;
    private int height;
    private int landmine_count;
    private int flag;

    private void Start() {
        this.flag = 0;
    }

    public void SettingMapInfo(int width, int height, int landmine) {
        this.width = width;
        this.height = height;
        this.landmine_count = landmine;
    }

    public int GetWidth() {
        return width;
    }

    public int GetHeight() {
        return height;
    }

    public int GetLandMineLeft() {
        return landmine_count - flag;
    }

    public int GetFlag() {
        return flag;
    }
}
