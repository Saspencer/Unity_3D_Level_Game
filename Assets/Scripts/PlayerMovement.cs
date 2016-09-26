using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
    //Public
    public float moveSpeed;
    public GameObject deathParticles;

    //Private
    private float maxSpeed = 5f;
    private Vector3 input;
    private Vector3 spawn;

	// Use this for initialization
	void Start () 
    {
        spawn = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if(GetComponent<Rigidbody>().velocity.magnitude < maxSpeed)
        {
            GetComponent<Rigidbody>().AddForce(input * moveSpeed);
        }  

        //Check if player fell off the map
        if(transform.position.y < -2)
        {
            Die();
        }
	}

    //Check for collisions
    void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Enemy")
        {
            Die();
        }
    }

    //Check if you collide with goal 
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Goal")
        {
            GameManager.CompleteLevel();
        }
    }

    void Die()
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        transform.position = spawn;
    }
}
