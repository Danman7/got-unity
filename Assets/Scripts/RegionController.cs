using UnityEngine;
using System.Collections.Generic;
using cakeslice;

public class RegionController : MonoBehaviour {
    public bool _isLandRegion;
    public int _power;
    public int _supply;
    public int _fortLevel;
    public int _garrison;
    public GameObject[] _adjacentRegions;
    public GameObject[] _initialTroops;
    public GameObject[] _unitSpawnPoints;
    public List<GameObject> _troops;
    public GameObject _orderSpawnPoint;
    public GameObject _controllingHouse;
    public bool _isInPlay;
    public Texture _art;

    [HideInInspector][SerializeField] Renderer renderer;
    Color regionColor;
    UIController uiController;

    void Start() {
        uiController = GameObject.Find("GameController").GetComponent<UIController>();
        renderer = GetComponent<Renderer>();
        regionColor = renderer.material.color;
    }

    void FixedUpdate() {
        if (_controllingHouse) {
            regionColor = _controllingHouse.GetComponent<HouseController>()._color;
            regionColor.a = 0.4f;
            renderer.material.color = regionColor;
        } else {
            regionColor.a = 0.0f;
            renderer.material.color = regionColor;
        }
    }

    void OnMouseEnter() {
        gameObject.GetComponent<Outline>().eraseRenderer = false;
    }

    void OnMouseExit() {
        gameObject.GetComponent<Outline>().eraseRenderer = true;
    }

    void OnMouseUpAsButton() {
        uiController.DisplayItemInfo(gameObject);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag ("Unit"))
        {
            _troops.Add(other.gameObject);
        }
    }
}
