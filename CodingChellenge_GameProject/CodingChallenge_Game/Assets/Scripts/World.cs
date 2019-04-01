using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : SceneController
{
   public Transform player;
 
    // Use this for initialization
    public override void Start () {
        base.Start();
      
        if (prevScene == "Parallel1") {
            player.position = new Vector3(base.player_X, base.player_Y, base.player_Z);
        }
    }
}
