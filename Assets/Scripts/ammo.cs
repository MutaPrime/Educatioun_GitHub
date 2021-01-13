using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo : MonoBehaviour
{
    // Start is called before the first frame update
    public float remain;
    public float timer;
    void Start()
    {
        remain = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (remain < 0)
        {
            GameObject.Destroy(this.gameObject, 2 );
        }
        else 
        {
            remain -= Time.deltaTime;
        }
    }
}
