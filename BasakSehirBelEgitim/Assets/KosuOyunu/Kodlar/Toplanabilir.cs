using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toplanabilir : MonoBehaviour
{

    Oyuncu oyuncu;

    public float Mesafe = 10f;
    // Start is called before the first frame update
    void Start()
    {
        oyuncu = GameObject.Find("KosuKizi").GetComponent<Oyuncu>();
    }

    // Update is called once per frame
    float KMesafe;
    void Update()
    {

        if (oyuncu.MiknatisAlindiMi)
        {

            KMesafe = Vector3.Distance(transform.position, oyuncu.transform.position);

            if (KMesafe < Mesafe)
                transform.position = Vector3.MoveTowards(transform.position, oyuncu.transform.position, Time.deltaTime * 20f);


        }


        
    }
}
