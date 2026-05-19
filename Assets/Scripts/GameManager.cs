using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int puntaje;
    public Text textoPuntaje;

    public void AumentarPuntaje()
    {
        puntaje += 2;
        textoPuntaje.text = puntaje.ToString();
    }

    public void AlTocarBomba()
    {

        Time.timeScale = 0;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
