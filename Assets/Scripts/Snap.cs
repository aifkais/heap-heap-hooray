using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snap : MonoBehaviour
{
    [SerializeField]
    private Transform _plate;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = _plate.position;
        float dist = Vector3.Distance(this.transform.position, _plate.transform.position);
        Debug.Log(dist);
        if (dist < 2)
        {
            Debug.DrawLine(this.transform.position, direction, Color.red);
        }
    }
}
