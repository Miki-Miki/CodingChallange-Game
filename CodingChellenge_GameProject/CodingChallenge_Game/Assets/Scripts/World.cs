using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : SceneController
{
   public Transform player;
 
    // Use this for initialization
    public override void Start () {
        base.Start();
        player.position = new Vector3(base.player_X, base.player_Y, base.player_Z);
        if (prevScene == "velid-testing-lab 1") {
            player.position = new Vector3(base.player_X, base.player_Y, base.player_Z);
        }
    }
}
