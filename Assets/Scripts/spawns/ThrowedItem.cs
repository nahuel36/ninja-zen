using UnityEngine;
using System.Collections;

public class ThrowedItem : MonoBehaviour {
    

    private bool setedValues = false;
    private bool skiped = false;

    private Vector3 initPos;
    private Vector3 mediumPos;
    private Vector3 finalPos;
    private Vector3 direction;
    private float velocity;
    public string spawnerDIR;

    public GameObject SpriteObj;
   // public GameObject HurtExplotionObj;


    public int HurtAmount = 1;
    public int Score = 1;

    public void setValues(Vector3 init, Vector3 medium, Vector3 final , float velocityParam, string spawnerIdentifier)
    {
        initPos  = init ;
        finalPos = final;
        mediumPos = medium;
        velocity = velocityParam;

        direction = finalPos - initPos;
        direction.Normalize();

        setedValues  = true ;

        spawnerDIR = spawnerIdentifier;

        skiped = false;
    }




    public void BreakItem()
    {
        if (!setedValues) return;
        if (skiped) return;

        if (Vector3.Distance(transform.position, mediumPos) < 2f)
        {

            setedValues = false;
            SpriteObj.SetActive(false);
            Invoke("DestroyObject", 4);
            LevelManager.Instance.AddScore(Score);
            LevelManager.Instance.KaratekaKickExplode(spawnerDIR);

        }
    }


    public void checkEndTrayectory()
    {
        if (skiped) return;

        if (direction.x > 0 && transform.position.x > finalPos.x ||
            direction.x < 0 && transform.position.x < finalPos.x)
        {
            setedValues = false;
            SpriteObj.SetActive(false);
            //HurtExplotionObj.SetActive(true);
            Invoke("DestroyObject", 4);
            LevelManager.Instance.hurtKarateka(HurtAmount);
        }

    }


    public void DestroyObject() {

        //HurtExplotionObj.SetActive(false);
        SpriteObj.SetActive(true);


        this.gameObject.DestroyAPS();
    }


    public void Skip()
    {
        if ((direction.x > 0 && transform.position.x > (initPos.x + ((finalPos.x - initPos.x) * 0.85f))) ||
            (direction.x < 0 && transform.position.x < (initPos.x - ((initPos.x - finalPos.x) * 0.85f))))
        {
            skiped = true;
        }
    }



    void Update ()
    {
        if (setedValues  == false) return;

        checkEndTrayectory();

        transform.Translate(direction * Time.deltaTime * velocity);
	}


}
