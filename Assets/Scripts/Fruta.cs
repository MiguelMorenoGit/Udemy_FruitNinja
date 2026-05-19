using UnityEngine;

public class Fruta : MonoBehaviour
{
    public GameObject prefabFrutaCortada;

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        CrearFrutaCortada();
    //    }

    //}

    public void CrearFrutaCortada()
    {
        GameObject frutaCortada = Instantiate(prefabFrutaCortada, transform.position, transform.rotation);

        Rigidbody[] rbsFrutaCortada = frutaCortada.GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody rb in rbsFrutaCortada)
        {
            rb.transform.rotation = Random.rotation;
            rb.AddExplosionForce(Random.Range(500, 1000), transform.position, 5f);
            //rb.AddExplosionForce(500f, transform.position, 5f);
        }

        FindAnyObjectByType<GameManager>().AumentarPuntaje();

        Destroy(gameObject);
        Destroy(frutaCortada.gameObject, 5);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Espada espada = collision.GetComponent<Espada>();

        if (espada == false) return;

        CrearFrutaCortada();
    }
}
