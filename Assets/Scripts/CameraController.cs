using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float offsetYpos;
    [SerializeField] private float offsetXpos;

    private void Update()
    {
        //you don't have to write get component because transform is used so often it can be accessed like this
        transform.position = new Vector3(player.position.x + offsetXpos, player.position.y + offsetYpos, transform.position.z);

        //always move the camera ahead of the direction the player is running... how?
    }
}
