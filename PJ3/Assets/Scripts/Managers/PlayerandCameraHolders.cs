using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerandCameraHolders : MonoBehaviour
{

    public GameObject Player;
    public GameObject Camera;

    public void PlayerCanMove(bool move){
        Player.GetComponent<Rigidbody>().isKinematic = !move;
    }
}
