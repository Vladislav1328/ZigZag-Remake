using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PointScript : MonoBehaviour
{
    public float speed = 30;

    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 5, Space.Self);
    }
    private void OnTriggerEnter()
    {
        Vibration.Vibrate(20);
        Destroy(gameObject);
    }
}
