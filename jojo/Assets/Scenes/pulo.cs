using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pulo : MonoBehaviour {

    public float force = 500f;
    public Rigidbody2D Pato;
    public bool liberapulo = false;
    public int duplo = 2;
    public AudioClip puloSom;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update() {  
        if(duplo > 0)
        { 
            if (Input.GetKeyDown(KeyCode.Space))
                {
                    Pato.AddForce(new Vector2(0, force * Time.deltaTime), ForceMode2D.Impulse);
                Gerenciador.inst.PlayAudio(puloSom);
                    duplo--;
                }
           }
       }

        void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("chao"));
        {
            duplo = 2;
            liberapulo = true; 
        }


    } 
    
        void OnCollisionExit2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("chao"));
        {
            liberapulo = false;
        }

    }
}

