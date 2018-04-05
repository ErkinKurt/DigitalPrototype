using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject SendBeeUI;
    public GameObject WorkerBeeUI;
    public GameObject SoldierBeeUI;

    public List<GameObject> gameObjects;

    public void ShowSendBeeUI(Transform _transform, bool isResource ,bool isCP) {
        if (SendBeeUI.activeInHierarchy)
        {
            SendBeeUI.SetActive(false);
            WorkerBeeUI.SetActive(false);
            SoldierBeeUI.SetActive(false);
        }
        else
        {
            if (isResource)
            {
                WorkerBeeUI.SetActive(true);
                SoldierBeeUI.SetActive(false);
            }
            else if(isCP)
            {
                WorkerBeeUI.SetActive(false);
                SoldierBeeUI.SetActive(true);
            }
            else
            {
                WorkerBeeUI.SetActive(true);
                SoldierBeeUI.SetActive(true);
            }
            SendBeeUI.SetActive(true);
        }

        SendBeeUI.transform.position = _transform.position;
        SendBeeUI.transform.position += Vector3.up;
    }
    

    public void Highlight( GameObject obje) {
        if (gameObjects.Count == 0)
        {
            gameObjects.Add(obje);
            gameObjects[0].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.5f);
            // Highlight the object
            Debug.Log("Highligted: " + obje.name);
        }
        else if(gameObjects.Count == 1)
        {
            gameObjects.Add(obje);
            obje.GetComponent<GlobalTargetChecker>().isTarget = true;
        }
        else if (gameObjects.Count == 2)
        {
            ShowTargetUI(gameObjects[1]);
            gameObjects[0].GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.5f);
            gameObjects.Clear();
            gameObjects.Add(obje);
            gameObjects[0].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.5f);
            Debug.Log("Highligted: " + obje.name);
        }

    }

    public void ShowTargetUI(GameObject objec) {
        if (objec.CompareTag("Resource"))
        {
            ShowSendBeeUI(objec.transform,true,false);
        }
        else if (objec.CompareTag("ControlPoint"))
        {
            ShowSendBeeUI(objec.transform,false,true);
        }
        else
        {
            ShowSendBeeUI(objec.transform,false,false);
        }

    }
	
}
