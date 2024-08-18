using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float end = -45;
    public LogicScript logic;

    [SerializeField] private AudioSource speedIncreased;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        //when the logic score is divisible by 5, this function runs. Update is called every frame, so the Boolean
        //speedNeedsToBeIncreased ensure this only runs once per time the score is increased by 5
        if (logic.score % 5 == 0 && logic.speedNeedsToBeIncreased)
        {
            //plays whooshing sound
            speedIncreased.Play();

            //pipe move speed is increased by 50%
            logic.pipeMoveSpeed *= 1.5f;

            //all 4 paralax backgrounds are increased in speed by 25%
            logic.background1ScrollSpeed *= 1.25f;
            logic.background2ScrollSpeed *= 1.25f;
            logic.background3ScrollSpeed *= 1.25f;
            logic.background4ScrollSpeed *= 1.25f;

            //The spawnRate of pipes coming is decreased by 25%, ie the time between pipes spawning is decreased,
            //meaning that pipes actually come quicker as the speed increases 
            logic.spawnRate *= 0.75f;

            logic.speedNeedsToBeIncreased = false;
        }

        //part that actually advances the pipes
        transform.position += (Vector3.left * logic.pipeMoveSpeed) * Time.deltaTime;

        //pipes destroyed after leaving the screen
        if (transform.position.x < end)
            Destroy(gameObject);
    }
}
