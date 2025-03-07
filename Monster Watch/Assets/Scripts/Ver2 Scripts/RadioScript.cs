using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RadioScript : MonoBehaviour
{
    private Rigidbody2D radioRigidBody;
    public AudioClip Click;
    public AudioSource sounds;

    void Start()
    {
        radioRigidBody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        
    }

    private void OnMouseDown ()
    {
        if (!GameManagerScript.inUI) 
        {
            radioRigidBody.AddForce((new Vector2(0, 100 / 4)));
            float rand = Random.Range(0, 4);
            if (rand >= 3)
            {
                radioRigidBody.AddTorque(300 / 4);
            }
            else
            {
                radioRigidBody.AddTorque(-300 / 4);
            }
            sounds.clip = Click;
            sounds.Play();

        }
    }
    
        
}
