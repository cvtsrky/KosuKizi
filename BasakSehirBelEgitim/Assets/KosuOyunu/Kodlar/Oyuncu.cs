using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oyuncu : MonoBehaviour
{

    public bool MiknatisAlindiMi = false;
    public float MikGecSur = 5f, MikKalanSuresi;

    public GameObject Yol1;
    public GameObject Yol2;
    public float Hiz = 10f;
    Animator animator;

    PanelKontrol panelKontrol;
    int Puan;

    bool YerdeMi;

    private void OnCollisionEnter(Collision collision)
    {
        YerdeMi = true;
    }


    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.name == "Yol1Gecis")
        {

            Yol2.transform.position = new Vector3(Yol1.transform.position.x + 200f, Yol1.transform.position.y, Yol1.transform.position.z);

        }
        else if(other.gameObject.name == "Yol2Gecis")
        {

            Yol1.transform.position = new Vector3(Yol2.transform.position.x + 200f, Yol2.transform.position.y, Yol2.transform.position.z);
        }
        else if (other.gameObject.tag == "Toplanabilir")
        {

            Puan++;

            panelKontrol.PuanTxt.text = "Puan : " + Puan;

            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Miknatis")
        {
            panelKontrol.MiknatisText.gameObject.SetActive(true);
            MiknatisAlindiMi = true;

            MikKalanSuresi += MikGecSur;

            Destroy(other.gameObject);

        }
        else if(other.gameObject.tag == "Engel")
        {

            panelKontrol.BittiPanel.SetActive(true);
            Time.timeScale = 0f;

        }

        Debug.Log(other.gameObject.name + " Objesine Temas Ettiniz");
        
    }


    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        panelKontrol = GameObject.Find("OyunYonetim").GetComponent<PanelKontrol>();

    }

    // Update is called once per frame
    void Update()
    {

        if (MiknatisAlindiMi == true)
        {
            MikKalanSuresi -= Time.deltaTime;
            panelKontrol.MiknatisText.text = "Mık Kalan Süresi : " + MikKalanSuresi.ToString("0");
        }
            

        if(MikKalanSuresi < 0f)
        {
            panelKontrol.MiknatisText.gameObject.SetActive(false);
            MiknatisAlindiMi = false;
            MikKalanSuresi = 0;
        }

        Haraket();


    }

    void ZiplaIptal()
    {
        animator.SetBool("Zipla", false);
    }

    int Yol = 1;
    public float SolKord = 32f, SagKord = 25f, OrtKord = 28.5f;
    void Haraket()
    {

        transform.Translate(0f, 0f, Hiz * Time.deltaTime);

        if (SimpleInput.GetKeyDown(KeyCode.UpArrow) && YerdeMi)
        {
            YerdeMi = false;
            transform.Translate(0f, 2f, 0f);
            animator.SetBool("Zipla", true);
            Invoke("ZiplaIptal", 0.5f);
        }

        if (SimpleInput.GetKeyDown(KeyCode.LeftArrow))
        {
            Yol = 1;
        }

        if (SimpleInput.GetKeyDown(KeyCode.RightArrow))
        {
            Yol = 2;
        }

        if (SimpleInput.GetKeyDown(KeyCode.DownArrow))
        {
            Yol = 3;
        }

        if (Yol == 1)
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, SolKord), Time.deltaTime * 2f);
        else if (Yol == 2)
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, SagKord), Time.deltaTime * 2f);
        else if (Yol == 3)
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, OrtKord), Time.deltaTime * 2f);
    }

}
