using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float jumpforce = 10.0f;
    public Rigidbody2D rb;
    public GameObject ChangeColor;
    
    public string currentColor;

    public SpriteRenderer sr;
    
    public Color colorYellow;//later on [SerializeField]
    public Color colorPurple;
    public Color colorBlue;
    public Color colorPink;

    void Start()
    {
        SetRandomColor();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*Color color = ChangeColor.GetComponent<SpriteRenderer>().color;
            changeColor to the ChangeColor GameObject! And for now I setToRandColor
            Debug.Log(color);
            sr.color = color;
        */
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            rb.velocity = Vector2.up * jumpforce;
        }

    }
    private void SetRandomColor()
    {
        
        Color[] colors = { colorYellow, colorPink, colorBlue, colorPurple };
        string[] ColorStr = { "Yellow", "Pink", "Blue", "Purple" };
        int index = Random.Range(0, 4);//0~3 randint
        sr.color = colors[index];
        string nextColor = ColorStr[index];
        
        if (currentColor == nextColor)
        {
            SetRandomColor();
        }
        else
        {
            currentColor = nextColor;
            return;
        }
        return;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "ChangeColor")
        {
            SetRandomColor();
            Destroy(collision.gameObject);
            return;
        }
        if (collision.tag != currentColor)
        {
            //not thing happening
            //currentColor = collision.tag;
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//重製關卡
        }
        
        
    }
}
