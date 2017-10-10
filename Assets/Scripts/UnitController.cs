using UnityEngine;

public class UnitController : MonoBehaviour {
    public int _cost = 1;
    public int _strength = 1;
    public GameObject _house;

    [HideInInspector][SerializeField] Renderer renderer;

    void Start() {
        renderer = GetComponent<Renderer>();
        if (_house) {
            renderer.material.color  = _house.GetComponent<HouseController>()._color;
        }
    }
}
