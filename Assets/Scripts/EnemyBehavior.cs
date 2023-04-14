/*
    EnemyBehavior.cs controls the killers movement and player tracking
*/
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemyBehavior : MonoBehaviour
{
    private NavMeshAgent Killer;
    public GameObject Player;

    public Camera cam;
    public NavMeshAgent agent;
    public ThirdPersonCharacter character;
    public Animator animator;

    // On start of scene find necessary game objects and components
    void Start(){
        agent.updateRotation = false;
        Killer = GetComponent<NavMeshAgent>();
        Player = GameObject.Find("Player");
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Every frame ensure killer is moving correctly and displaying
    // proper animations.
    void Update(){
        if (agent.remainingDistance > agent.stoppingDistance){
            character.Move(agent.desiredVelocity, false, false);
        }
        else{
        character.Move(Vector3.zero, false, false);
        }
    }

    // If the player collides with the killer's invisible 
    // vision hitboxes then play a noise and track the player's
    // location until they are outside the hitbox.
    void OnTriggerEnter(Collider col){
        if (col.tag == "Player"){
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            Killer.SetDestination(Player.transform.position);
        }
    }

}
