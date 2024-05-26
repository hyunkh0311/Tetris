using UnityEngine;
using System.Linq;
using UniRx;

public class BaseBlock : MonoBehaviour
{
    public float blockFallTime = 1.0f;
    private float deltaTime = 0f;

    public static int height = 20;
    public static int width = 10;

    private Vector3 blockRotate;
    private void Awake()
    {
        blockRotate = transform.rotation.eulerAngles;
    }

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
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.RotateAround(transform.TransformPoint(blockRotate), new Vector3(0, 0, 1), 90);
            if (!CanMove())
            {
                transform.RotateAround(transform.TransformPoint(blockRotate), new Vector3(0, 0, 1), -90);
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

            if(roundX < 0 || roundX >= width || roundY < 0 )//|| roundY >= height)
            {
                return false;
            }
        }

        return true;
    }
}
