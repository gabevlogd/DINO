using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player Player;

    public static EventManager<Enumerators.Event> EventManager;
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        EventManager = new EventManager<Enumerators.Event>();
    }
}
