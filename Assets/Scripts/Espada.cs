using UnityEngine;

public class Espada : MonoBehaviour
{
    private Rigidbody2D rb;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void AsociarEspadaAlMouse()
    {
        // Obtener la posición del mouse en la pantalla
        Vector3 mousePosicion = Input.mousePosition; 

        // Esto asegura que la espada se mueva en el plano correcto
        float distancia = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
        mousePosicion.z = distancia;

        // Convertir la posición del mouse a coordenadas del mundo
        Vector3 posicionMundo = Camera.main.ScreenToWorldPoint(mousePosicion); 
        posicionMundo.z = transform.position.z; // Mantener la espada en el mismo plano z

        // Mover la espada a la posición del mouse
        rb.position = posicionMundo;
    }

    // Update is called once per frame
    void Update()
    {
        AsociarEspadaAlMouse();
    }
}
