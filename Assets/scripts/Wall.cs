using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wall : MonoBehaviour
{
    
    private Wall[] _walls;

    private void Start()
    {
        _walls = gameObject.GetComponentsInChildren<Wall>();



    }
    public void WallActive()
    {


        gameObject.SetActive(true);
        

    }
}
