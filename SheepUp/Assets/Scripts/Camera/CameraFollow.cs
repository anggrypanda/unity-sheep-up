using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;

    private float damping = 2f;
    private float height = 10f;

    private Vector3 startPosition;

    private bool canFollowVar;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        startPosition = transform.position;
        canFollowVar = true;
    }

    void Update()
    {
        Follow();
    }

    void Follow()
    {
        if (canFollowVar)
        {
            transform.position = Vector3.Lerp(transform.position,                                                                           // From which pos we are going to lerp
                                             new Vector3(player.position.x + 10f, player.position.y + height, player.position.z - 10f),     // To which pos we are going to lerp
                                             Time.deltaTime * damping);                                                                     // How long it will take
        }
    }

    public bool CanFollow
    {
        get
        {
            return canFollowVar;
        }
        set
        {
            canFollowVar = value;
        }
    }
}
