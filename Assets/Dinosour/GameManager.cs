using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DINO
{
    public class GameManager : MonoBehaviour
    {
        public Player Player;
        public static GameManager Instance;

        private void Awake()
        {
            if (Instance == null) Instance = this;
        }
    }
}
