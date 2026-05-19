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
        var mousePosicion = Input.mousePosition;
        mousePosicion.z = 10; // Asegúrate de que la posición z sea adecuada para tu escena
        rb.position = Camera.main.ScreenToWorldPoint(mousePosicion);
    }

    // Update is called once per frame
    void Update()
    {
        AsociarEspadaAlMouse();
    }
}
