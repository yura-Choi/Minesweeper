using UnityEngine;

public class PrefabController : MonoBehaviour {

    public GameObject prefeb_block_text;
    public int[,] array_map;

	private GlobalState script_Global;

    private void Start() {
		script_Global = GameObject.Find("InGameController").GetComponent<GlobalState>();
        // this.array_map = CreateMap();
    }

    private int WhereAreYou(int[,] map, int index) {
        if (index == (map.Length - 1)) return 6;
        else if (index == 0) return 1;
        else return 3;
    }

    private int CountMines(int[,] map, int i, int i_start, int i_end, int j, int j_start, int j_end) {
        int count = 0;

        for (int k = i_start; k < i_end; k++) {
            for (int l = j_start; l < j_end; l++) {
                if (k == 0 && l == 0) continue;
                if (map[i + k, j + 1] == 9) count++;
            }
        }

        return count;
    }

    private int CalculateSurroundingMines(int[,] map, int i, int j) {
        int count = 0;

        switch (WhereAreYou(map, i) + WhereAreYou(map, j)) {
            case 12: // both indexes are MAX index.
                count = CountMines(map, i, -1, 1, j, -1, 1);
                break;
            case 9:  // one is MAX, the other is rest number.
                if (i > j) {
                    count = CountMines(map, i, -1, 1, j, -1, 2);
                    break;
                }
                count = CountMines(map, i, -1, 2, j, -1, 1);
                break;
            case 7:  // one is zero, the other is MAX.
                if (i > j) {
                    count = CountMines(map, i, -1, 1, j, 0, 2);
                    break;
                }
                count = CountMines(map, i, 0, 2, j, -1, 1);
                break;
            case 6:  // both indexes are rest number.
                count = CountMines(map, i, -1, 2, j, -1, 2);
                break;
            case 4:  // one is zero, the other is rest number.
                if (i > j) {
                    count = CountMines(map, i, -1, 1, j, 0, 2);
                    break;
                }
                count = CountMines(map, i, -1, 1, j, -1, 2);
                break;
            case 2:  // both indexes are zero.
                count = CountMines(map, i, -1, 1, j, 0, 2);
                break;
            default:
                Debug.Log("InGame: failed to calculate surrounding mines");
                break;
        }

        return count;
    }

    private int[,] CreateMap() {
		int count_assigned = 0;

        switch (PlayerPrefs.GetString("level").ToLower())
        {
            case "easy":
                script_Global.SettingMapInfo(5, 8, 10);
                break;
            case "normal":
                script_Global.SettingMapInfo(6, 9, 20);
                break;
            case "hard":
                script_Global.SettingMapInfo(7, 10, 30);
                break;
            default:
                Debug.Log("InGame: undefined stage level");
                break;
        }

        int[,] mineMap = new int[script_Global.GetWidth(), script_Global.GetHeight()];
		System.Random r = new System.Random();

        // Assign mines.
		for (int i = 0; i < script_Global.GetWidth(); i++) {
			for (int j = 0; j < script_Global.GetHeight(); j++) {
                // All mines were assigned to the 'mineMap'.
				if (count_assigned == script_Global.GetLandMineLeft()) break;

                // If current index has a mine, skip to next index.
                if (mineMap[i, j] == 9) continue;

                // The mine is assigned when the random value is even number.
                if (r.Next(1, 5) % 2 == 1) continue;

                mineMap[i, j] = 9;
                count_assigned++;
			}

            if (i == (script_Global.GetWidth() - 1) && count_assigned != script_Global.GetLandMineLeft()) i = 0;
		}

        // Create map to find mines.
        for (int i = 0; i < script_Global.GetWidth(); i++) {
            for (int j = 0; j < script_Global.GetHeight(); j++) {
                mineMap[i, j] = CalculateSurroundingMines(mineMap, i, j);
            }
        }

        return mineMap;
    }

    public void Map_block_open() {
		prefeb_block_text.SetActive(true);
	}
}
