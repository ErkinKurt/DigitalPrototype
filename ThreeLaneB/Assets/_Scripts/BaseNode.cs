using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseNode : MonoBehaviour {
    public UIManager _uiManager;
    private Bee _bee;
    public int _health; //kralice ari icin gecici sanirim(test)
    
    //public int maxQuota;
    //private int soldierBeeCost;
    //private int workerBeeCost;
    private List<GameObject> _resourceList;

    public GameManagger GameManagger;
    
    //Arda: usttekki prop.ler eski alttakiler yeni 06:43AM

    private PlayerManager playerManager; //player manager class ref

    public int currentBaseResource; //how many resource this base have
    Player baseOwner; //enum P1 P2

    //bee prefabs
    public GameObject soldierBeePrefab;
    public GameObject workerBeePrefab;

    //costs and quotas
    private int _soldierBeeResourceCost;
    private int _workerBeeResourceCost;
    private int _soldierBeeQuotaCost;
    private int _workerBeeQuotaCost;
    private int _maxBeeQuota;

    private List<Transform> spawnPositions = new List<Transform>(); //bee spawn positions (you cant create empty transform! use vector3)

    enum Player
    {
        P1,
        P2,
    }

    private void Awake()
    {
        _bee = GetComponent<Bee>();
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();

        //set player manager ref
        playerManager = GameManagger.GetComponent<PlayerManager>();

        //set base owner
        if (playerManager.base_P1 == this.gameObject)
        {
            baseOwner = Player.P1;
        }
        else if (playerManager.base_P2 == this.gameObject)
        {
            baseOwner = Player.P2;
        }

        //set Costs
        _soldierBeeResourceCost = GameManagger.soldierBeeResourceCost;
        _workerBeeResourceCost = GameManagger.workerBeeResourceCost;
        _soldierBeeQuotaCost = GameManagger.soldierBeeQuotaCost;
        _workerBeeQuotaCost = GameManagger.workerBeeQuotaCost;

        //set max bee quota
        _maxBeeQuota = GameManagger.maxBeeQuota;

    }

    void Start()
    {
        //Increasing _honeyStock 5 per second.
        InvokeRepeating("AddHoneyStock", 1, 1);

        //add all spawn pos transforms to spawnPos list
        var tempTransformOfChildren = gameObject.GetComponentsInChildren<Transform>();
        foreach (var child in tempTransformOfChildren)
        {
            if (child.CompareTag("BeeSpawnPos") == true)
            {
                spawnPositions.Add(child);
            }
        }
    }

    void Update()
    {
        //update iste falan fistik
    }

    public void CreateSoldierBee()
    {
        
        if (baseOwner == Player.P1)
        {
            Debug.Log("in p1" );
            if (currentBaseResource >= _soldierBeeResourceCost && playerManager.concurrentBee_P1 < _maxBeeQuota)
            {
                currentBaseResource = currentBaseResource - _soldierBeeResourceCost; //decrease resource cost from total
                playerManager.concurrentBee_P1 = playerManager.concurrentBee_P1 + 1; //update p1 concurrent bee
                _bee.SetSoldierBeeNumber(_bee.GetSoldierBeeNumber()+1);

                if (_bee.prefabObject == null)
                {
                    _bee.prefabObject = Instantiate(soldierBeePrefab,spawnPositions[0].position,Quaternion.identity);
                    _bee.prefabObject.GetComponent<PrefBee>().beeNO = _bee.GetSoldierBeeNumber();
                    //_bee.prefabObject.GetComponent<PrefBee>().beeNoText.text = _bee.GetSoldierBeeNumber().ToString();
                }
                else
                {
                    _bee.prefabObject.GetComponent<PrefBee>().beeNO = _bee.GetSoldierBeeNumber();
                    //_bee.prefabObject.GetComponent<PrefBee>().beeNoText.text = _bee.GetSoldierBeeNumber().ToString();
                }
       }
            else
            {
                Debug.Log("CantCreateSoldier P1-> " + "CurrRes=" + currentBaseResource + ">" + "soldierCost= " + _soldierBeeResourceCost + "&&" + " " + "P1concurrBee= " + playerManager.concurrentBee_P1 + "<" + "MaxBeeQuota= " + _maxBeeQuota);
            }
        }
        else if (baseOwner == Player.P2)
        {
            Debug.Log("in p2" );
            if (currentBaseResource >= _soldierBeeResourceCost && playerManager.concurrentBee_P2 < _maxBeeQuota)
            {
                currentBaseResource = currentBaseResource - _soldierBeeResourceCost; //decrease resource cost from total
                playerManager.concurrentBee_P1 = playerManager.concurrentBee_P2 + 1; //update p1 concurrent bee
                _bee.SetSoldierBeeNumber(_bee.GetSoldierBeeNumber()+1);

                if (_bee.prefabObject == null)
                {
                    _bee.prefabObject = Instantiate(soldierBeePrefab,spawnPositions[0].position,Quaternion.identity);
                    _bee.prefabObject.GetComponent<PrefBee>().beeNO = _bee.GetSoldierBeeNumber();
                    //_bee.prefabObject.GetComponent<PrefBee>().beeNoText.text = _bee.GetSoldierBeeNumber().ToString();
                }
                else
                {
                    _bee.prefabObject.GetComponent<PrefBee>().beeNO = _bee.GetSoldierBeeNumber();
                    //_bee.prefabObject.GetComponent<PrefBee>().beeNoText.text = _bee.GetSoldierBeeNumber().ToString();
                }
            }
            else
            {
                Debug.Log("CantCreateSoldier P2-> " + "CurrRes=" + currentBaseResource + ">" + "soldierCost= " + _soldierBeeResourceCost + "&&" + " " + "P1concurrBee= " + playerManager.concurrentBee_P2 + "<" + "MaxBeeQuota= " + _maxBeeQuota);
            }
        }
        else
        {
            Debug.LogWarning("Player settings may wrong. Check P1 and P2 settings or mailto: ardazeytin@outlook.com or Call 911");
        }

    }

    public void CreateWorkerBee()
    {
        //asker ari fonk. bakarak doldur
    }


    //standart resource gathering without using resource additional nodes
    private void AddHoneyStock()
    {
        Debug.Log("Base " + baseOwner +" resource= "+ currentBaseResource);
        currentBaseResource += 5;
    }

    //Arda: alttaki parcalar ne ise yariyor tam bir fikrim yok

    //Need to now who has how many bees in a particular resource.
    //Worker and Soldier bees need to be an object with an attribute to keep track of the owner of them...
    private void AddHoneyStockWithWorkerBee()
    {
        _resourceList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Resource"));
        foreach(var go in _resourceList)
        {
            Debug.Log("Working forEach");
            //go.GetComponent<>
        }
    }

    private void OnMouseDown()
    {
        _uiManager.Highlight(gameObject);
    }


}
