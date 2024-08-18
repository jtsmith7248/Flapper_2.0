using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    //3 different pipe prefabs, each has a different sized gap between them corresponding to difficulty in passing through
    public GameObject pipeEasy;
    public GameObject pipeMedium;
    public GameObject pipeHard;
    public LogicScript logic;

    //controls the range at which the center of each pipe object can spawn
    public float heightOffset = 7;

    private float timer = 0;
    private int randPipeType;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        //first pipe to spawn is always easy
        spawnPipe(pipeEasy);
    }

    void Update()
    {
        //timer is updated every frame, and a Rand.Range func is used to determine which type of pipe is spawned 
        //next. Timer is reset every time a pipe spawns, and logic.spawnRate is dynamic and changes over the game
        if (timer < logic.spawnRate)
            timer += Time.deltaTime;
        else
        {
            randPipeType = Random.Range(1, 6);

            if (randPipeType <= 2)
                spawnPipe(pipeEasy);
            else if (randPipeType <= 4)
                spawnPipe(pipeMedium);
            else
                spawnPipe(pipeHard);

            timer = 0;
        }

    }

    //spawns pipes. woah.
    //parameter is sent in because type of pipe (easy, medium, hard) changes
    void spawnPipe(GameObject pipe)
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        //another use of Rand.Range finds a random point between the highest and lowest allowable spots to spawn in the 
        //center of the next pipe.
        float spawnPoint = Random.Range(lowestPoint, highestPoint);

        Instantiate(pipe, new Vector3(transform.position.x, spawnPoint, 0), transform.rotation);
    }
}
