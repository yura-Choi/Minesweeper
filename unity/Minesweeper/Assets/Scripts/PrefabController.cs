using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabController : MonoBehaviour {

    public GameObject prefeb_block_text;

    public int[,] array_map;

    private void Start()
    {
        this.array_map = CreateMap();

    }

    private int WhereAreYou(int[,] map, int index) {
        if (index == map.Length) return 6;
        else if (index == map.GetLength(0)) return 1;
        else return 3;
    }

    private int CalculateMinesCount(int[,] map, int i, int j) {
        int count = 0;

        switch (WhereAreYou(map, i) + WhereAreYou(map, j)) {
            case 12: // both indexes are MAX index.
                break;
            case 9:  // one is MAX, the other is rest number.
                break;
            case 7:  // one is zero, the other is MAX.
                break;
            case 6:  // both indexes are rest number.
                break;
            case 4:  // one is zero, the other is rest number.
                break;
            case 2:  // both indexes are zero.
                break;
        }

        return count;
    }

    private int[,] CreateMap() {
		int width = 0, height = 0, minesweeper = 0;
		int count_assigned = 0;

		switch (PlayerPrefs.GetString("level").ToLower())
		{
			case "easy":
				width = 5; height = 8;
				minesweeper = 10;
				break;
			case "normal":
				width = 6; height = 9;
				minesweeper = 20;
				break;
			case "hard":
				width = 7; height = 10;
				minesweeper = 30;
				break;
			default:
				Debug.Log("InGame: undefined stage level");
				break;
		}

		int[,] mineMap = new int[width, height];
		System.Random r = new System.Random();

		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {
                // All mines were assigned to the 'mineMap'.
				if (count_assigned == minesweeper) break;
                // The mine is assigned when the random value is even number.
                if (r.Next(1, 5) % 2 == 1) break;

                mineMap[i, j] = 9;
                count_assigned++;
			}

            if (i == (width - 1) && count_assigned != minesweeper) i = 0;
		}

        return array_map;
    }

    public void Map_block_open()
	{
		prefeb_block_text.SetActive(true);
	}
}
