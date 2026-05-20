using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Elementos del Puntaje")]
    public int puntaje;
    public int mejorPuntaje;
    public Text textoPuntaje;
    public Text textoMejorPuntaje;

    [Header("Elementos Panel GameOver")]
    public GameObject panelGameOver;
    public Text textoPuntajePanel;
    public Text textoMejorPuntajePanel;

    private void Awake()
    {
        panelGameOver.SetActive(false);
        PonerMejorPuntaje();
    }

    private void PonerMejorPuntaje()
    {
        mejorPuntaje = PlayerPrefs.GetInt("MejorPuntaje");
        textoMejorPuntaje.text = "Mejor: " + mejorPuntaje.ToString();
    }

    public void AumentarPuntaje()
    {
        puntaje += 2;
        textoPuntaje.text = puntaje.ToString();

        if(puntaje > mejorPuntaje)
        {
            PlayerPrefs.SetInt("MejorPuntaje", puntaje);
            textoMejorPuntaje.text = "Mejor: " + puntaje.ToString();
            mejorPuntaje = puntaje;
        }   
    }

    public void AlTocarBomba()
    {
        panelGameOver.SetActive(true);
        textoPuntajePanel.text = "Puntaje Final: " + puntaje.ToString();
        textoMejorPuntajePanel.text = "Mejor puntaje: " + mejorPuntaje.ToString();
        Time.timeScale = 0;
    }

    public void Reiniciar()
    {
        puntaje = 0;
        textoPuntaje.text = puntaje.ToString();
        Time.timeScale = 1;
        panelGameOver.SetActive(false);

        // Eliminar todas las frutas y bombas que estén en la escena
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Interactivo"))
        {
            Destroy(obj);
        }
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
