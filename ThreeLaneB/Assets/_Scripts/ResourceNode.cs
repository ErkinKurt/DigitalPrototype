using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceNode : MonoBehaviour {
    public UIManager _uiManager;

    // honey rate per worker bee
    public int _rate;
    public Vector2 _location;
    public int _workerBeeNumberP1;
    public int _workerBeeNumberP2;



    private void OnMouseDown()
    {
        _uiManager.Highlight(gameObject);
    }

    private void Awake()
    {
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }
}
