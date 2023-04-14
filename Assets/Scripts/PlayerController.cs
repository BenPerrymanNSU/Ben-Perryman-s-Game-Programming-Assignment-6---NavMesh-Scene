/*
    PlayerController.cs controls the players ability to move and ensures proper animations play

*/
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public ThirdPersonCharacter character;
    public Animator animator;

    // On start of scene do not update rotation
    void Start(){
        agent.updateRotation = false;
    }

    // Every frame check if the player has clicked somewhere and move the character
    // to the location or nearest location. Tracks mouse curser and ensures the player
    // model animates properly.
    void Update(){
        if (Input.GetMouseButtonDown(0)){
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)){
                agent.SetDestination(hit.point);
            }
        }
            
        if (agent.remainingDistance > agent.stoppingDistance){
            character.Move(agent.desiredVelocity, false, false);
        }
        else{
            character.Move(Vector3.zero, false, false);
        }
    }

    // On collision with Collectible prefab play animation then
    // call function
    void OnTriggerEnter(Collider col){
        if (col.tag == "Collectable"){
            animator.Play("Base Layer.Win", 0, 0);
            Invoke("returnToLoco", 1f);
        }
    }

    // Return player's animation back to standard locomotion animation
    void returnToLoco(){
        animator.Play("Base Layer.Locomotion", 0, 0);
    }
}
