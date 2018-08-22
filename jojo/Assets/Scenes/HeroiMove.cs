using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroiMove : MonoBehaviour {


    public bool face = true;
    public Transform HeroiT;
    public float vel = 2.5f;
    public float force = 6.5f;
    public Rigidbody2D heroiRB;
    public bool liberapulo = false;
    public Animator anim;
    public bool vivo = true;


    void Start () {
        HeroiT = GetComponent<Transform> ();
        heroiRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

		
	}
	
	// Update is called once per frame
	void Update () {

        if (vivo) 
      {
            if (Input.GetKey(KeyCode.RightArrow) && !face)
            {
                Flip();
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && face)
            {
                Flip();
            }

        }

      
       if(vivo == true)
        {

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(new Vector2(vel * Time.deltaTime, 0));
                anim.SetBool("indle", false);
                anim.SetBool("andar", true);
            }

           else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(new Vector2(-vel * Time.deltaTime, 0));
                anim.SetBool("indle", false);
                anim.SetBool("andar", true);
            }
            else
            { 
                anim.SetBool("indle", true);
                anim.SetBool("andar", false);
            }

            if(vivo == true)
            {

                if (Input.GetKeyDown(KeyCode.Space) && liberapulo == true)
                {
                    heroiRB.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
                }
            }
            
        }


        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate (new Vector2 (vel * Time.deltaTime,0));
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate (new Vector2 (-vel * Time.deltaTime,0));
        }
        if(Input.GetKeyDown(KeyCode.Space) && liberapulo == true )
        {
            heroiRB.AddForce (new Vector2(0, force), ForceMode2D.Impulse);
        }



    }

     void Flip()
    {
        face = !face;

        Vector3 scala = HeroiT.localScale;
        scala.x *= -1;
        HeroiT.localScale = scala;

    }
    void OnCollisionEnter2D(Collision2D outro)
    {
        if(outro.gameObject.CompareTag("chao"))
        {
            liberapulo = true;
        }
    }

    void OnCollisionExit2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("chao"))
        {
            liberapulo = false;
        }
    }
}
