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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        restartText.SetActive(false);
    }
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        rb.linearVelocity = new Vector2(horizontalMovement * speed, rb.linearVelocity.y);

  
        rb.gravityScale = 0f;
        rb.linearVelocity = new Vector2(horizontalMovement * speed, verticalMovement * speed); 
   
        rb.gravityScale = 1f;
        rb.linearVelocity = new Vector2(horizontalMovement * speed, rb.linearVelocity.y);
       
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject == key)
        {
            keyObtained = true;
            Destroy(gameObject);
        }

        if (c.gameObject == door && keyObtained)
        {
            allowRestart = true;
            restartText.SetActive(true);
        }
    }
}