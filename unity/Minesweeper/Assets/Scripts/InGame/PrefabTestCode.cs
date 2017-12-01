using UnityEngine;

public class PrefabTestCode : MonoBehaviour {

    public GameObject prefab_map;
    public GameObject prefab_parent;

    GameObject[,] map_instant = new GameObject[5, 1];

	// Use this for initialization
	void Start () {
        Debug.Log("PrefabTestCode: start");

        for (int i = 0; i < 5;i++){
            int width = 70 * i;
            map_instant[i, 0] = (GameObject)Instantiate(
                prefab_map,
                new Vector3(prefab_map.transform.position.x + width, prefab_map.transform.position.y, 0),
                Quaternion.identity
            );
            map_instant[i, 0].transform.SetParent(prefab_parent.transform);
        }

        Debug.Log("PrefabTestCode: Were my Prefabs created?");
	}
}
