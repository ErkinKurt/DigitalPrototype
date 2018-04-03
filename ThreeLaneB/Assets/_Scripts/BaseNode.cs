using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseNode : MonoBehaviour {
    public UIManager _uiManager;
    private Bee _bee;

    
    public int _health;
    public int _quota;
    public int _honeyStock;

    public int _maxQuota;
    public int _soldierBeeCost;
    public int _workerBeeCost;




    public void createSoldierBee()
    {
        if(_honeyStock>= _soldierBeeCost && _quota < _maxQuota)
        {
            _honeyStock -= _soldierBeeCost;
            _bee.SetSoldierBeeNumber(_bee.GetSoldierBeeNumber() + 1);
        }
        else { Debug.Log("Soldier creation error;");}
    }

    public void createWorkerBee()
    {
        if (_honeyStock >= _workerBeeCost && _quota < _maxQuota)
        {
            _honeyStock -= _workerBeeCost;
            _bee.SetWorkerBeeNumber(_bee.GetWorkerBeeNumber() + 1);
        }
        else { Debug.Log("Worker creation error;"); }

    }

    private void OnMouseDown()
    {
        _uiManager.Highlight(gameObject);
    }

    private void Awake()
    {
        _bee = GetComponent<Bee>();
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        _quota = _bee.GetSoldierBeeNumber() + _bee.GetWorkerBeeNumber();
	}
}
