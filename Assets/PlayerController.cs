using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


    private int move = 0;

    private float speed = 10.0f;


    // Update is called once per frame
    void Update () {

        switch (move)
        {
            case 1:
                this.transform.position = new Vector3(transform.position.x, transform.position.y + speed, 0);
                break;

            case 2:
                this.transform.position = new Vector3(transform.position.x, transform.position.y - speed, 0);
                break;
        }

        if (this.transform.localPosition.y >= 185)
        {
            this.transform.localPosition = new Vector3(transform.localPosition.x, 180, 0);
        }
        else if (this.transform.localPosition.y <= -185)
        {
            this.transform.localPosition = new Vector3(transform.localPosition.x, -180, 0);
        }
    }
    
    public void UpMove() {
        move = 1;
    }

    public void DownMove()
    {
        move = 2;
    }
    public void ZeroMove()
    {
        move = 0;
    }
}
