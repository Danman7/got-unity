using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
    public int _turn = 0;
    public int _maxTurns = 10;
    public string _phase = "Planning";
    public GameObject _playerHouse;
    public List<GameObject> _housesInPlay;

    void Start()
    {
        InitPlanningPhase();
    }

    void InitPlanningPhase()
    {
        _turn += 1;
    }
}
