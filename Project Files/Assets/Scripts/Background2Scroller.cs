using UnityEngine;

public class Background2Scroller : MonoBehaviour
{
    //this script handles the scrolling of the light, the second furthest back layer
    public LogicScript logic;

    private float offset2;
    private Material mat;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        offset2 += (Time.deltaTime * logic.background2ScrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset2, 0));
    }
}
