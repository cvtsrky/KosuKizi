using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KlonOlusturma : MonoBehaviour
{

    public GameObject Altin, Kutuk, Miknatis, Tas, Alev, Araba;
    Oyuncu oyuncu;

    public float SilmeZamani = 20f, OlusturmaMesafesi = 50f, OlusturmaSuresi = 1f;


    void NesneKlonla()
    {

        int RastSayi = Random.Range(1, 100);

        if (RastSayi < 50)
            Klonla(Altin, 1.5f);
        else if (RastSayi < 80)
            Klonla(Miknatis, 2f);
        else if (RastSayi < 100)
            Klonla(Araba, 0.99f);

    }

    void Klonla(GameObject Nesne, float Yukseklik)
    {

        int RastSayi = Random.Range(1, 100);

        GameObject YeniObje = Instantiate(Nesne);

        if (RastSayi < 33)
            YeniObje.transform.position = new Vector3(oyuncu.transform.position.x + OlusturmaMesafesi, Yukseklik, oyuncu.SagKord);
        else if (RastSayi < 66)
            YeniObje.transform.position = new Vector3(oyuncu.transform.position.x + OlusturmaMesafesi, Yukseklik, oyuncu.SolKord);
        else if (RastSayi < 100)
            YeniObje.transform.position = new Vector3(oyuncu.transform.position.x + OlusturmaMesafesi, Yukseklik, oyuncu.OrtKord);


        Destroy(YeniObje, SilmeZamani);

    }

    

    // Start is called before the first frame update
    void Start()
    {
        oyuncu = GameObject.Find("KosuKizi").GetComponent<Oyuncu>();
        InvokeRepeating("NesneKlonla", 0f, OlusturmaSuresi);
    }

    // Update is called once per frame
  
    void Update()
    {
       
            



    }
}
