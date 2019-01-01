using UnityEngine;
using System.Collections;

public class Player2Controller : MonoBehaviour {

    private int move = 0;

    private float speed = 10.0f;


    // Update is called once per frame
    void Update()
    {

        switch (move)
        {
            case 1:
                this.transform.position = new Vector3(transform.position.x, transform.position.y + speed, 0);
                break;

            case 2:
                this.transform.position = new Vector3(transform.position.x, transform.position.y - speed, 0);
                break;
        }

        if(this.transform.localPosition.y >= 185)
        {
            this.transform.localPosition = new Vector3(transform.localPosition.x, 180, 0);
        }
        else if (this.transform.localPosition.y <= -185)
        {
            this.transform.localPosition = new Vector3(transform.localPosition.x, -180, 0);
        }
    }

    public void UpMove2()
    {
        move = 1;
    }

    public void DownMove2()
    {
        move = 2;
    }
    public void ZeroMove2()
    {
        move = 0;
    }
}
