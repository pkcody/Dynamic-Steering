using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    
    public void PickRandom()
    {
        float xrand = Random.Range(-40f, -5.5f);
        float zrand = Random.Range(-25f, -13f);
        print(xrand + ", " + zrand);
        gameObject.transform.position = new Vector3(xrand, gameObject.transform.position.y, zrand);

        Invoke("PickRandom", 5f);

    }

    // Update is called once per frame
    void Start()
    {
        Invoke("PickRandom", 5f);
    }
}
