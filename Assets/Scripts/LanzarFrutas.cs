using System.Collections;
using UnityEngine;

public class LanzarFrutas : MonoBehaviour
{

    public GameObject[] frutasParaLanzar;
    public GameObject bomba;
    public float esperaMinima = 0.3f;
    public float esperaMaxima = 1f;
    public float fuerzaMinima = 13;
    public float fuerzaMaxima = 16;
    public Transform[] lugaresLanzamiento;

    [Range(0f, 100f)]
    public float probabilidadBomba = 15f; // Probabilidad de lanzar una bomba en porcentaje (0-100)D

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Lanzador());
    }
     
    private IEnumerator Lanzador()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(esperaMinima, esperaMaxima)); // Espera un tiempo aleatorio entre cada lanzamiento

            Transform tr = lugaresLanzamiento[Random.Range(0, lugaresLanzamiento.Length)]; // Selecciona un lugar de lanzamiento aleatorio

            GameObject fruta = null;
            
            float IndiceFruta = Random.Range(0, frutasParaLanzar.Length); // Selecciona una fruta aleatoria del array
            float PorcentajeBomba = Random.Range(0, 100); // Genera un número aleatorio para determinar si se lanza una bomba o una fruta

            if (PorcentajeBomba < probabilidadBomba) // Si el porcentaje es menor que 20, lanza una bomba
            {
                fruta = Instantiate(bomba, tr.position, bomba.transform.rotation); // Crea la bomba en el lugar de lanzamiento seleccionado
            }
            else // Si el porcentaje es mayor o igual a 20, lanza una fruta
            {
                fruta = Instantiate(frutasParaLanzar[(int)IndiceFruta], tr.position, tr.rotation); // Crea la fruta en el lugar de lanzamiento seleccionado
            }

            Rigidbody2D rb = fruta.GetComponent<Rigidbody2D>();
            rb.AddForce(tr.up * Random.Range(fuerzaMinima, fuerzaMaxima), ForceMode2D.Impulse);
            // Rotación random sin afectar la trayectoria
            rb.angularVelocity = Random.Range(-360f, 360f);

            Destroy(fruta, 5f);

            //print("Fruta arrojada");
        }
    }
}
