using UnityEngine;

public class PipeMiddlScript : MonoBehaviour
{
    //creates an object of the type logicscript, bringing in a connection from that script to this one
    public LogicScript logic;
    public int passingPipeCheckpointValue = 1;
    void Start()
    {
        //allows each individual pipe, as they are spawned, to connect with the LogicScript so we can update the score as 
        //the player passes through each individual checkpoint between the pipes
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //calls the add to score method when Flapper passes through a pipe
        if (collision.gameObject.layer == 3)
            logic.addToScore(passingPipeCheckpointValue);
    }
}
