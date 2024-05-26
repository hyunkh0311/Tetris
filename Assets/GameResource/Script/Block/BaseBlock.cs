using UnityEngine;
using System.Linq;
using UniRx;

public class BaseBlock : MonoBehaviour
{
    //[LabelText("블럭 낙하 시간")]
    public float blockFallTime = 1.0f;
    private float deltaTime = 0f;

    public static int height = 20;
    public static int width = 10;

    public void Update()
    {
        deltaTime += Time.deltaTime;
        if(deltaTime > blockFallTime || (Input.GetKeyDown(KeyCode.DownArrow)))
        {
            transform.position += new Vector3(0, -1, 0);
            if (!CanMove())
            {
                transform.position += new Vector3(0, 1, 0);
            }
            deltaTime = 0f;
        }
           
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (!CanMove())
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!CanMove())
            {
                transform.position += new Vector3(-1, 0, 0);
            }
        }
    }

    public bool CanMove()
    {
        var list = transform.GetComponent<Transform>();
        foreach(Transform tile in list)
        {
            int roundX = Mathf.RoundToInt(tile.transform.position.x);
            int roundY = Mathf.RoundToInt(tile.transform.position.y);

            if(roundX < 0 || roundX >= width || roundY < 0 || roundY >= height)
            {
                return false;
            }
        }

        return true;
    }
}
