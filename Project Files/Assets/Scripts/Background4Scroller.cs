using UnityEngine;

public class Background4Scroller : MonoBehaviour
{
    //this script handles the scrolling of the frontmost trees, layer 4. 
    public LogicScript logic;
    private float offset4;
    private Material mat;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        offset4 += (Time.deltaTime * logic.background4ScrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset4, 0));
    }
}
