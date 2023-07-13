using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cactus : Obstacle
{

    private bool scoreUpdated;

    private void OnEnable() => scoreUpdated = false;

    //PROVVISORIO
    private void Update()
    {
        if (!scoreUpdated && transform.position.x <= -1)
        {
            scoreUpdated = true;
            GameManager.EventManager.TriggerEvent(Enumerators.Event.UpdateScore);
        }
    }


}