using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField] GameObject key;
    [SerializeField] GameObject door;

    public bool keyObtained = false;
    public bool allowRestart = false;
    Rigidbody2D rb;

    public GameObject restartText;
    public GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        restartText.SetActive(false);
    }
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        rb.linearVelocity = new Vector2(horizontalMovement * speed, verticalMovement * speed);
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Key"))
        {
            keyObtained = true;
            Debug.Log("collision detected");
            Destroy(c.gameObject);
        }

        if (c.CompareTag("Door") && keyObtained)
        {
            allowRestart = true;
            Debug.Log("collision detected");
            restartText.SetActive(true);
        }
    }
}