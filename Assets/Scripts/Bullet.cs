using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{

    public float speed = 10f;
    public float maxLifeTime = 3f;
    public float lifeTimer;
    public Vector3 targetVector;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject asteroidePequeñoPrefab;
    
    void OnEnable()
    {
        lifeTimer = maxLifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * targetVector * Time.deltaTime);

        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0f)
        {
            gameObject.SetActive(false);
        }   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("AsteroideGrande"))
        {
            IncreaseScore();
            Destroy(collision.gameObject);
            divideAsteroide();
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("AsteroidePequeño"))
        {
            IncreaseScore();
            Destroy(collision.gameObject);
            gameObject.SetActive(false);
        }   
    }

    private void divideAsteroide()
    {
        GameObject asteroidePequeño1 = Instantiate(asteroidePequeñoPrefab, transform.position, Quaternion.identity);
        GameObject asteroidePequeño2 = Instantiate(asteroidePequeñoPrefab, transform.position, Quaternion.identity);

        Rigidbody rb1 = asteroidePequeño1.GetComponent<Rigidbody>();
        Rigidbody rb2 = asteroidePequeño2.GetComponent<Rigidbody>();

        Vector3 dirSalida = targetVector.normalized;

        float angle = 30f; 
        Vector3 dir1 = Quaternion.AngleAxis(angle, Vector3.forward) * dirSalida;
        Vector3 dir2 = Quaternion.AngleAxis(-angle, Vector3.forward) * dirSalida;

        float force = 5f;
        rb1.AddForce(dir1 * force, ForceMode.Impulse);
        rb2.AddForce(dir2 * force, ForceMode.Impulse);
    }

    private void IncreaseScore()
    {
        Player.SCORE++;
        Debug.Log(Player.SCORE);
        UpdateScoreText();
    }   

    private void UpdateScoreText()
    {
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<Text>().text = "Puntos : " + Player.SCORE;
    }
}
