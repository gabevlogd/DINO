using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DINO
{
    public class Cactus : Obstacle
    {

        //PROVVISORIO
        private void OnBecameInvisible()
        {
            Destroy(this.gameObject);
        }

    }
}
