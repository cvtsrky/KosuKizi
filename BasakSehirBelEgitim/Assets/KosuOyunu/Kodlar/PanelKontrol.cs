using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelKontrol : MonoBehaviour
{

    public Text PuanTxt;
    public Text MiknatisText;
    public GameObject BittiPanel;


    public void Restart()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("KosuOyunu");

    }

    public void Cikis()
    {
        Application.Quit();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
