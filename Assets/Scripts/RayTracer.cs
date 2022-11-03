using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTracer : MonoBehaviour
{
    [SerializeField]
    private Transform _player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = _player.position;
        if (direction.magnitude < 1)
        {
            Debug.DrawLine(this.transform.position, direction, Color.green);
        }
    }
}
