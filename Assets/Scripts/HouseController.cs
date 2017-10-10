using UnityEngine;
using System.Collections.Generic;

public class HouseController : MonoBehaviour {
    public bool _isInPlay = true;
    public int _power = 5;
    public Color _color;
    public Color _secondaryColor;
    public GameObject _homeRegion;
    public GameObject[] _initialRegions;
    public List<GameObject> _orders;
    public Texture _largeBanner;
    public Texture _banner;

    GameController gameController;

    void Start ()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();

        if (_isInPlay) {
            gameController._housesInPlay.Add(gameObject);
            // establish initial control
            InitControl(_homeRegion);

            for(int i = 0; i < _initialRegions.Length; i++)
            {
                InitControl(_initialRegions[i]);
            }
        }

        
    }

    void InitControl (GameObject region)
    {
        RegionController controller = region.GetComponent<RegionController>();
        
        controller._controllingHouse = gameObject;
        Vector3 center = region.GetComponent<Collider>().bounds.center;
        Vector3 origin = new Vector3(center.x, 0.2f, center.z);
        RaycastHit hit;

        if (Physics.Raycast(origin, Vector3.down, out hit)) {
            Debug.Log(hit.collider.name);
        }

        // foreach(GameObject unit in controller._initialTroops)
        // {

        //     Vector3 spawn;
        //     if (controller._unitSpawnPoints.Length != 0) {
        //         spawn = controller._unitSpawnPoints[0].transform.position;
        //     } else {
        //         spawn = region.GetComponent<Collider>().bounds.center;
        //     }

        //     unit.GetComponent<UnitController>()._house = gameObject;
        //     Instantiate(unit, new Vector3(spawn.x, 0.2f, spawn.z), unit.transform.rotation);
        // }
    }
}
