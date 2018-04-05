using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private GameObject _initialPosition;
    private GameObject _targetPosition;

    public TextManager _workerBtn;
    public TextManager _soldierBtn;

    [SerializeField]
    private InputField _inputFieldWorker;
    private InputField _inputFieldSoldier;

    //Erkin Deneme...
    //Need to add quota to player controller to count every single bee in the game.
    public UIManager _uiManager;

    public GameObject beePref;

    public int _sentBeeNumber;
    
    public void SendWorkerBee()
    {
        //Actual sending bees....
        _initialPosition = _uiManager.gameObjects[0];
        _targetPosition = _uiManager.gameObjects[1];

        _sentBeeNumber = _initialPosition.GetComponent<Bee>().GetWorkerBeeNumber();
        if (_sentBeeNumber > 0)
        {
            Bee _targetBee = _targetPosition.GetComponent<Bee>();
            Bee _initialBee = _initialPosition.GetComponent<Bee>();
            if (_initialPosition.GetComponent<Bee>().prefabObject == null)
            {
                Debug.Log("pref is null sent ok");
            }
            else
            {
                Destroy(_initialPosition.GetComponent<Bee>().prefabObject);
            }

            GameObject _bee = Instantiate(beePref);
            _bee.GetComponent<PrefBee>().Move(_initialPosition.transform, _targetPosition.transform);
            _initialBee.SetWorkerBeeNumber(_initialBee.GetWorkerBeeNumber() - _sentBeeNumber);
            _targetBee.SetWorkerBeeNumber(_targetBee.GetWorkerBeeNumber() + _sentBeeNumber);
            Debug.Log("sent bees: " + _sentBeeNumber);
        }
    }



    public void SendSoldierBee()
    {
        //Actual sending bees....
        _initialPosition = _uiManager.gameObjects[0];
        _targetPosition = _uiManager.gameObjects[1];

        _sentBeeNumber = _initialPosition.GetComponent<Bee>().GetSoldierBeeNumber();
        if (_sentBeeNumber > 0)
        {
            Bee _targetBee = _targetPosition.GetComponent<Bee>();
            Bee _initialBee = _initialPosition.GetComponent<Bee>();
            if (_initialPosition.GetComponent<Bee>().prefabObject == null)
            {
                Debug.Log("pref is null sent ok");
            }
            else
            {
                Destroy(_initialPosition.GetComponent<Bee>().prefabObject);
            }

            GameObject _bee = Instantiate(beePref);
            _bee.GetComponent<PrefBee>().Move(_initialPosition.transform, _targetPosition.transform);
            _initialBee.SetSoldierBeeNumber(_initialBee.GetSoldierBeeNumber() - _sentBeeNumber);
            _targetBee.SetSoldierBeeNumber(_targetBee.GetSoldierBeeNumber() + _sentBeeNumber);
            Debug.Log("sent bees: " + _sentBeeNumber);
        }
    }

    private void Awake()
    {
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
