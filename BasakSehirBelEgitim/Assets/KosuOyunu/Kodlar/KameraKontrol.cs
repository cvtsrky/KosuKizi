using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraKontrol : MonoBehaviour
{

    public GameObject TakipEdilecekObje;
    public float KameraHizi = 1f;

    public Vector3 Mesafe = new Vector3(0f, 0f, -1f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, 
            new Vector3(TakipEdilecekObje.transform.position.x, TakipEdilecekObje.transform.position.y, transform.position.z)
            + Mesafe, Time.deltaTime * KameraHizi);

        
    }
}
