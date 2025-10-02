using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float thrustForce = 150f;
    public float rotationSpeed = 120f;
    public float xBorderLimit = 7f;
    public float yBorderLimit = 6f;
    public GameObject gun, bulletPrefab;


    private Rigidbody _rigid;

    public static int SCORE = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float rotation = Input.GetAxis("Rotate") * Time.deltaTime;
        float thrust = Input.GetAxis("Thrust") * Time.deltaTime;


        Vector3 thrustDirection = transform.right;

        _rigid.AddForce(thrustDirection * thrust * thrustForce);

        transform.Rotate(Vector3.forward, -rotation * rotationSpeed);


        var newPos = transform.position;
        if (newPos.x > xBorderLimit)
        {
            newPos.x = -xBorderLimit+1;
        }
        else if (newPos.x < -xBorderLimit)
        {
            newPos.x = xBorderLimit-1;
        }
        else if (newPos.y > yBorderLimit)
        {
            newPos.y = -yBorderLimit+1;
        }
        else if (newPos.y < -yBorderLimit)
        {
            newPos.y = yBorderLimit-1;
        }   
        transform.position = newPos;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = BulletManager.Instance.GetBullet();
            bullet.transform.position = gun.transform.position;
            bullet.transform.rotation = Quaternion.identity;
            bullet.SetActive(true);

            Bullet balaScript = bullet.GetComponent<Bullet>();
            balaScript.targetVector = transform.right;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "AsteroideGrande" || collision.gameObject.tag == "AsteroidePequeño")
        {
            SCORE = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            Debug.Log("He colisionado con otra cosa...");
        }
        
    }
}
