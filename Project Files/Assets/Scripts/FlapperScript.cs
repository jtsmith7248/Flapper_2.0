using System.Threading;
using UnityEngine;

public class FlapperScript : MonoBehaviour
{
    public Rigidbody2D body;
    public float birdJump;
    public LogicScript logic;
    public bool flapperAlive = true;
    public bool birdSoundPlayed = false;

    //adds in source for sound when Flapper collides with a pipe
    //SerializeField ensures that AudioSource is accessible in Unity editor
    [SerializeField] private AudioSource birdCollision;

    //logic connects this script with LogicScript on runtime
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        //when Flapper is alive and the spacebar is pressed, this function executes, causing him to move upward and
        //'flap'
        if (Input.GetKeyDown(KeyCode.Space) && flapperAlive == true) 
        {
            body.velocity = Vector2.up * birdJump;
        }
    }

    //finds when Flapper has a collision, ending that round
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ensures that collision sound only plays once per round, not repeadly as the bird continues to fall
        if (!birdSoundPlayed)
        {
            birdCollision.Play();
            birdSoundPlayed = true;
        }

        logic.gameOver();
        flapperAlive = false;
    }
}
