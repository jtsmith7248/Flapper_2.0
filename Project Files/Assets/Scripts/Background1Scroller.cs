using UnityEngine;

public class Background1Scroller : MonoBehaviour
{
    //this script handles the scrolling of the furthest back trees. 
    public LogicScript logic;

    private float offset1;
    private Material mat;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        //gets the material component, in this case the background trees
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        //offset is determined by change in time and the speed of this given scrolling backgroun
        offset1 += (Time.deltaTime * logic.background1ScrollSpeed) / 10f;
        //moves it by the offset
        mat.SetTextureOffset("_MainTex", new Vector2(offset1, 0));
    }
}
