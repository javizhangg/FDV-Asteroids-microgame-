using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    private GameObject botonPausa;
    private GameObject menuPausa;

public void Start()
    {
        botonPausa = GameObject.Find("BotonPausa");
        menuPausa = GameObject.Find("MenuPausa");
        menuPausa.SetActive(false);
    }

public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1f)
            {
                Pausa();
            }
            else
            {
                Reanudar();
            }
        }
    }

public void Pausa()
    {
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
    }

public void Reanudar()
    {
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }
}
