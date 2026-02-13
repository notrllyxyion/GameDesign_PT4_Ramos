using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private SaveSystem saveSystem;

    private int score = 0;

    void Start()
    {
        // Load position/rotation is done inside SaveSystem.Load()
        // We just get the loaded score back.
        score = saveSystem.Load();
        Debug.Log("current score is: " + score);
    }

    void Update()
    {
        // Your movement style
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 move = new Vector2(x, y);

        transform.Translate(move * Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectible"))
        {
            score++;
            Debug.Log("current score is: " + score); // shows every pickup

            Destroy(other.gameObject);

            saveSystem.Save(transform.position, transform.rotation, score);
        }
    }

    void OnApplicationQuit()
    {
        saveSystem.Save(transform.position, transform.rotation, score);
    }
}

