using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    [SerializeField] Vector3 offset = new Vector3(0, 5, -10);

    // Update is called once per frame
    void LateUpdate()
    {
        // Position camera above and behind 
        transform.position = (player.transform.position + offset);
    }
}
