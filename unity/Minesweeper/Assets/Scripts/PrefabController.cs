using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabController : MonoBehaviour {

    public GameObject prefeb_block_text;

    public int[,] array_map;

    private void Start() {
        this.array_map = CreateMap();
    }

    private int WhereAreYou(int[,] map, int index) {
        if (index == (map.Length - 1)) return 6;
        else if (index == 0) return 1;
        else return 3;
    }

    private int CountMines(int[,] map, int i, int i_state, int i_end, int j, int j_state, int j_end) {
        int count = 0;

        for (int k = i_state; k < i_end; k++) {
            for (int l = j_state; l < j_end; l++) {
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
		int width = 0, height = 0, count_mines = 0;
		int count_assigned = 0;

		switch (PlayerPrefs.GetString("level").ToLower())
		{
			case "easy":
				width = 5; height = 8;
				count_mines = 10;
				break;
			case "normal":
				width = 6; height = 9;
				count_mines = 20;
				break;
			case "hard":
				width = 7; height = 10;
				count_mines = 30;
				break;
			default:
				Debug.Log("InGame: undefined stage level");
				break;
		}

		int[,] mineMap = new int[width, height];
		System.Random r = new System.Random();

        // Assign mines.
		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {
                // All mines were assigned to the 'mineMap'.
				if (count_assigned == count_mines) break;

                // If current index has a mine, skip to next index.
                if (mineMap[i, j] == 9) continue;

                // The mine is assigned when the random value is even number.
                if (r.Next(1, 5) % 2 == 1) continue;

                mineMap[i, j] = 9;
                count_assigned++;
			}

            if (i == (width - 1) && count_assigned != count_mines) i = 0;
		}

        // Create map to find mines.
        for (int i = 0; i < width; i++) {
            for (int j = 0; j < height; j++) {
                mineMap[i, j] = CalculateSurroundingMines(mineMap, i, j);
            }
        }

        return mineMap;
    }

    public void Map_block_open() {
		prefeb_block_text.SetActive(true);
	}
}
