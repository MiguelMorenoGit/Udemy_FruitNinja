using UnityEngine;

public class Espada : MonoBehaviour
{
    [Header("Corte")]
    [SerializeField] private float desplazamientoMinimoParaCortar = 0.1f; // Velocidad mínima para que la espada corte las frutas

    private Camera camaraPrincipal;
    private Rigidbody2D rb;
    private Collider2D col;

    private Vector2 posicionObjetivo;
    private Vector2 posicionMouseAnterior;

    private float distanciaACamara;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        camaraPrincipal = Camera.main;

        distanciaACamara = Mathf.Abs(camaraPrincipal.transform.position.z - transform.position.z);

        posicionObjetivo = transform.position;
        posicionMouseAnterior = posicionObjetivo;

        ActivarCorte(false);
    }

    // Update is called once per frame
    void Update()
    {
        posicionObjetivo = ObtenerPosicionMouseEnElMundo();
        ActualizarEstadoDelCorte();
        posicionMouseAnterior = posicionObjetivo;
    }

    private void FixedUpdate()
    {
        MoverEspada();
    }

    private Vector2 ObtenerPosicionMouseEnElMundo()
    {
        Vector3 posicionMousePantalla = Input.mousePosition;
        posicionMousePantalla.z = distanciaACamara;

        Vector3 posicionMouseMundo = camaraPrincipal.ScreenToWorldPoint(posicionMousePantalla);
        
        return posicionMouseMundo;
    }

    private void ActualizarEstadoDelCorte()
    {
        float desplazamiento = Vector2.Distance(posicionMouseAnterior, posicionObjetivo);

        if (desplazamiento > desplazamientoMinimoParaCortar) ActivarCorte(true);
        else ActivarCorte(false);
    }

    private void MoverEspada()
    {
        rb.MovePosition(posicionObjetivo);
    }

    private void ActivarCorte(bool activar)
    {
        col.enabled = activar;
    }




    //private void AsociarEspadaAlMouse()
    //{
    //    // Obtener la posición del mouse en la pantalla
    //    Vector3 mousePosicion = Input.mousePosition; 

    //    // Esto asegura que la espada se mueva en el plano correcto
    //    float distancia = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
    //    mousePosicion.z = distancia;

    //    // Convertir la posición del mouse a coordenadas del mundo
    //    Vector3 posicionMundo = Camera.main.ScreenToWorldPoint(mousePosicion); 
    //    posicionMundo.z = transform.position.z; // Mantener la espada en el mismo plano z

    //    // Mover la espada a la posición del mouse
    //    rb.position = posicionMundo;
    //}



    //private bool SeMueveElMouse()
    //{
    //    // La posición actual de la espada es la posición del mouse en el mundo
    //    Vector3 posicionMouseActual = transform.position;
    //    // Calcular la distancia entre la última posición del mouse y la posición actual
    //    float desplazamiento = (ultimaPosicionMouse - posicionMouseActual).magnitude;

    //    // Actualizar la última posición del mouse para la próxima comparación
    //    ultimaPosicionMouse = posicionMouseActual;

    //    // Si el desplazamiento es mayor que la velocidad mínima, la espada se considera en movimiento
    //    if (desplazamiento > velocidadMinima) return true;
    //    else return false;
    //}

    /*
    NOTA IMPORTANTE SOBRE UPDATE, FIXEDUPDATE Y RIGIDBODY2D

    Este script separa dos responsabilidades distintas:

    1. Update()
       Se usa para leer el input del jugador, como la posición del ratón.
       Update se ejecuta una vez por frame visual, por eso es el sitio adecuado
       para leer Input.mousePosition y decidir si el jugador está moviendo la espada.

    2. FixedUpdate()
       Se usa para mover el Rigidbody2D.
       FixedUpdate pertenece al ciclo de físicas de Unity, por eso es el sitio
       adecuado para usar rb.MovePosition(), fuerzas, velocidad o cualquier cosa
       relacionada con Rigidbody2D y colisiones.

    El bug original venía de mezclar estas responsabilidades:
    - se movía la espada con Rigidbody2D dentro de Update;
    - después se medía el movimiento usando transform.position;
    - y luego se activaba/desactivaba el Collider2D en ese mismo ciclo.

    Eso podía provocar resultados inconsistentes, porque Transform, Rigidbody2D
    y el sistema de físicas no siempre se sincronizan exactamente en el mismo
    momento del frame.

    Además, el bug era más confuso porque al seleccionar la espada en la Hierarchy
    parecía funcionar. Eso no significaba que el código estuviera bien, sino que
    el editor de Unity estaba inspeccionando activamente el objeto, refrescando
    valores, gizmos, colliders o el Transform de una forma que podía ocultar el
    problema real.

    Regla mental:
    - El input se lee en Update.
    - La física se aplica en FixedUpdate.
    - Los Rigidbody2D se mueven como Rigidbody2D, no mezclando Transform.
    - La lógica debe medir la causa real del movimiento.

    En este juego, la causa real del movimiento es el ratón.
    La espada solo sigue al ratón.

    Por eso el corte se decide comparando:
        posición anterior del ratón en mundo
        vs
        posición actual del ratón en mundo

    y no comparando:
        posición anterior de la espada
        vs
        posición actual de la espada después de moverla.

    Así evitamos depender de sincronizaciones internas entre Transform,
    Rigidbody2D, Collider2D, Update, FixedUpdate y el refresco visual del editor.
*/
}
