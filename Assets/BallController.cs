using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

    public Rigidbody2D rb ;
    public int a = 1;
    public float xR;
    public float yR;
    // Use this for initialization
    GameObject generator;
    GameObject startButton;

    //GameObject generator = GameObject.Find("PlayGenerator");
    void Start()
    {

        this.generator = GameObject.Find("PlayGenerator");
        this.startButton = GameObject.Find("StartPanel");

        this.startButton.transform.localPosition = new Vector3(0, 0, 0);
    }


    public void gameStart()
    {

        this.transform.localPosition = new Vector3(0, 0, 0);
        xR = Random.Range(-8, 8);
        yR = Random.Range(-8, 8);
        
        //  rb = GetComponent<Rigidbody2D>();
        //    rb.AddForce((transform.up + transform.right)*10000.0f);
        if (-2 < xR && xR< 2){
            gameStart();
        }
        else if(-2 < xR && xR < 2)
        {
            gameStart();
        }
        this.startButton.transform.localPosition = new Vector3(0, 450, 0);

    }
    void Update(){
        this.transform.Translate(xR,yR,0);
        if(yR == 0)
        {
            yR += 3;
        }
    }
	

    void OnTriggerEnter2D(Collider2D other) {
        
        if (other.gameObject.tag == "Player1")
        {
            //x軸に方向の反転
            xR = xR *-1 + 2.0f;
            if(this.transform.localPosition.y > 0)
            {
                yR += 1;
            }else if (this.transform.localPosition.y < 0)
            {
                yR -= 1;
            }
        }
        else if (other.gameObject.tag == "Player2")
        {
            //x軸に方向の反転
            xR = xR * -1 - 2.0f;
            if (this.transform.localPosition.y > 0)
            {
                yR += 1;
            }
            else if (this.transform.localPosition.y < 0)
            {
                yR -= 1;
            }
        }
        else if (other.gameObject.tag == "Wall")
        {//y軸の方向の反転
         //rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y );
            yR *= -1;
        }
        else if(other.gameObject.tag == "Goal1")
        {
           // GameObject generator = GameObject.Find("PlayGenerator");
            generator.GetComponent<PlayGenerator>().addScore_p2();
            //Destroy(this.gameObject);
            gameStart();
        }
        else if (other.gameObject.tag == "Goal2")
        {
          //  GameObject generator = GameObject.Find("PlayGenerator");
            generator.GetComponent<PlayGenerator>().addScore_p1();
            // Destroy(this.gameObject);
            gameStart();
        }
    }
}
