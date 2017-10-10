using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public Text _phaseText;
    public Text _houseNameText;
    public Text _selectedItemName;
    public Text _playerHousePowerValue;

    public RawImage _playerHouseBanner;
    public RawImage _selectionArt;

    public UIPrefabs _prefabs;
    public UIElements _elements;
    public GameObject _selectedItem;
    
    GameController gameController;

    [System.Serializable]
    public class UIPrefabs
    {
        public GameObject _supplyImage;
        public GameObject _powerImage;
    }

    [System.Serializable]
    public class UIElements
    {
        public GameObject _selectionPanel;
        public GameObject _actionsPanel;
        public GameObject _actionsPanelTitle;
        public GameObject _regionResources;
        public GameObject _ordersListContainer;
    }

    public void DisplayItemInfo(GameObject item)
    {
        _selectedItem = item;
        _elements._selectionPanel.SetActive(true);
        if (_selectedItem) {
            _selectedItemName.text = _selectedItem.name;

            // Region
            if (_selectedItem.CompareTag("Region")) {
                RegionController regionController = _selectedItem.GetComponent<RegionController>();

                _selectionArt.texture = regionController._art;

                foreach (Transform child in _elements._regionResources.transform) {
                    GameObject.Destroy(child.gameObject);
                }

                ShowRegionResourceCount(regionController._supply, _prefabs._supplyImage, _elements._regionResources);
                ShowRegionResourceCount(regionController._power, _prefabs._powerImage, _elements._regionResources);

                if (gameController._phase == "Planning" && regionController._troops.Count != 0) {
                    _elements._actionsPanel.SetActive(true);
                } else {
                    _elements._actionsPanel.SetActive(false);
                }
            }
        }
    }

    void Awake ()
    {
        gameController = gameObject.GetComponent<GameController>();
        _elements._selectionPanel.SetActive(false);

    }

    void Start ()
    {
        SetPhaseText();
        if (gameController._playerHouse) {
            _playerHouseBanner.texture = gameController._playerHouse.GetComponent<HouseController>()._largeBanner;
            _houseNameText.text = gameController._playerHouse.name;
        }
    }

    void SetPhaseText()
    {
        _phaseText.text = "Turn " + gameController._turn + " - " + gameController._phase + " Phase";
    }

    void FixedUpdate()
    {
        SetPhaseText();

        if (gameController._playerHouse) {
            _playerHousePowerValue.text = gameController._playerHouse.GetComponent<HouseController>()._power.ToString();
        }
    }

    void ShowRegionResourceCount(int resource, GameObject prefab, GameObject holder)
    {
        if (resource > 0) {
            for(int i = 0; i < resource; i++)
            {
                GameObject image = Instantiate(prefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
                image.transform.SetParent(holder.transform);
            }
        }
    }
}
