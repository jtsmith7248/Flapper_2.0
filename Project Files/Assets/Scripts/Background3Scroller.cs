using UnityEngine;

public class Background3Scroller : MonoBehaviour
{
    //this script handles the scrolling of the middle trees, layer 3 
    public LogicScript logic;
    private float offset3;
    private Material mat;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        offset3 += (Time.deltaTime * logic.background3ScrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset3, 0));
    }
}
