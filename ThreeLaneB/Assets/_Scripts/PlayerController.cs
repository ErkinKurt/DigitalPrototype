using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private Transform _initialPosition;
    private Transform _targetPosition;

    public TextManager _workerBtn;
    public TextManager _soldierBtn;

    [SerializeField]
    private InputField _inputFieldWorker;
    private InputField _inputFieldSoldier;

    //Erkin Deneme...
    //Need to add quota to player controller to count every single bee in the game.
    public UIManager _uiManager;

    public GameObject beePref;

    public void SendWorkerBee()
    {
        //Actual sending bees....
    Debug.Log("AAAAAAAAAA");
        _initialPosition = _uiManager.gameObjects[0].transform;
        _targetPosition = _uiManager.gameObjects[1].transform;

         GameObject _bee =   Instantiate(beePref);
         _bee.GetComponent<PrefBee>().Move(_initialPosition,_targetPosition);
       
        /*
        Bee _targetBee = _targetPosition.GetComponent<Bee>();
        Bee _initialBee = _initialPosition.GetComponent<Bee>();
        if (_sentBeeNumber <= _initialBee.GetWorkerBeeNumber())
        {
            _initialBee.SetWorkerBeeNumber(_initialBee.GetWorkerBeeNumber() - _sentBeeNumber);
            _targetBee.SetWorkerBeeNumber(_targetBee.GetWorkerBeeNumber() + _sentBeeNumber);
            Debug.Log("sent bees: " + _sentBeeNumber);
        }
        else
            Debug.Log("Worker bee sent error:" + _sentBeeNumber);
*/


    }



    public void SendSoldierBee()
    {
        //Actual sending bees....

        _initialPosition = _uiManager.gameObjects[0].transform;
        _targetPosition = _uiManager.gameObjects[1].transform;
        Bee _targetBee = _targetPosition.GetComponent<Bee>();
        Bee _initialBee = _initialPosition.GetComponent<Bee>();
        
        /*
        if (_targetPosition.tag == "Resource")
        {
            Debug.Log("Soldiers can't be sent to the resource.");
            return;
        }
        else if (_sentBeeNumber <= _initialBee.GetSoldierBeeNumber())
        {

            _initialBee.SetSoldierBeeNumber(_initialBee.GetSoldierBeeNumber() - _sentBeeNumber);
            Debug.Log("Sent Bee number:" + _sentBeeNumber);

            _targetBee.SetSoldierBeeNumber(_targetBee.GetSoldierBeeNumber() + _sentBeeNumber);


            Debug.Log("sent bees: " + _sentBeeNumber);
        }
        else
            Debug.Log("Soldier bee sent error:" + _sentBeeNumber);
*/
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
