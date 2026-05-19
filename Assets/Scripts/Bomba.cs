using UnityEngine;

public class Bomba : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Espada espada = collision.GetComponent<Espada>();

        if (espada == false) return;

        FindAnyObjectByType<GameManager>().AlTocarBomba();

        //Espada espada = collision.GetComponent<Espada>();
        //if (espada == false) return;
        //FindAnyObjectByType<GameManager>().puntaje = 0;
        //FindAnyObjectByType<GameManager>().textoPuntaje.text = "0";
        //Destroy(gameObject);
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
