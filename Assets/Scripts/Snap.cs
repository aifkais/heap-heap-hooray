using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snap : MonoBehaviour
{
    private Transform terminal;

    // Start is called before the first frame update
    void Start()
    {
        terminal = GameObject.Find("Terminal").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = terminal.position;
        float dist = Vector3.Distance(this.transform.position, terminal.transform.position);
        Debug.Log(dist);
        if (dist < 2)
        {
            Debug.DrawLine(this.transform.position, direction, Color.red);
        }
    }
}
