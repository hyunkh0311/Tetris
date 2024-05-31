using Unity.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject spawnObj;

    [SerializeField] private GameObject[] blockObj;

    [SerializeField] private float blockFallTime = 1.0f;
    [SerializeField] private float deltaTime = 0f;
    [SerializeField] private static int height = 20;
    [SerializeField] private static int width = 10;

    [SerializeField] private Vector3 blockRotate;
    [SerializeField] private GameObject cntBlock;
    [SerializeField] private GameObject indicateBlock;

    [SerializeField] private Transform[,] blockMap = new Transform[width, height];

    private void Start()
    {
        Init();
        NewBlock();
    }

    public void Init()
    {

    }

    public void Update()
    {
        KeyMove();
    }

    public void NewBlock()
    {
        cntBlock = spawnObj.Add(blockObj[Random.Range(0, blockObj.Length)]);
        blockRotate = cntBlock.transform.rotation.eulerAngles;
        indicateBlock = spawnObj.Add(cntBlock);
        indicateBlock.transform.rotation = cntBlock.transform.rotation;

        var children = indicateBlock.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer child in children)
        {
            child.color = new Color(child.color.r, child.color.g, child.color.b, 0.1f);
        }
    }

    public void KeyMove()
    {
        if (cntBlock == null)
            return;

        deltaTime += Time.deltaTime;
        if (deltaTime > blockFallTime || (Input.GetKeyDown(KeyCode.DownArrow)))
        {
            cntBlock.transform.position += new Vector3(0, -1, 0);
            if (!CanMove(cntBlock))
            {
                cntBlock.transform.position += new Vector3(0, 1, 0);
                AddBlock();
                CheckForLines();
                Destroy(indicateBlock);
                indicateBlock = null;
                cntBlock = null;
                NewBlock();
            }
            deltaTime = 0f;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            while(CanMove(cntBlock))
            {
                cntBlock.transform.position += new Vector3(0, -1, 0);
            }
            cntBlock.transform.position += new Vector3(0, 1, 0);
            AddBlock();
            CheckForLines();
            Destroy(indicateBlock);
            indicateBlock = null;
            cntBlock = null;
            NewBlock();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            cntBlock.transform.position += new Vector3(-1, 0, 0);
            if (!CanMove(cntBlock))
            {
                cntBlock.transform.position += new Vector3(1, 0, 0);
            }
            IndicateBlock();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            cntBlock.transform.position += new Vector3(1, 0, 0);
            if (!CanMove(cntBlock))
            {
                cntBlock.transform.position += new Vector3(-1, 0, 0);
            }
            IndicateBlock();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            cntBlock.transform.RotateAround(cntBlock.transform.TransformPoint(blockRotate), new Vector3(0, 0, 1), 90);
            if (!CanMove(cntBlock))
            {
                cntBlock.transform.RotateAround(cntBlock.transform.TransformPoint(blockRotate), new Vector3(0, 0, 1), -90);
            }
            IndicateBlock();
        }
    }

    public bool CanMove(GameObject obj)
    {
        var list = obj.transform.GetComponent<Transform>();
        foreach (Transform tile in list)
        {
            int roundX = Mathf.RoundToInt(tile.transform.position.x);
            int roundY = Mathf.RoundToInt(tile.transform.position.y);

            if (roundX < 0 || roundX >= width || roundY < 0)//|| roundY >= height)
            {
                return false;
            }

            if (height > roundY && blockMap[roundX, roundY] != null)
                return false;
        }
        return true;
    }

    private void AddBlock()
    {
        foreach(Transform children in cntBlock.transform)
        {
            int roundX = Mathf.RoundToInt(children.transform.position.x);
            int roundY = Mathf.RoundToInt(children.transform.position.y);

            blockMap[roundX, roundY] = children;
        }
    }

    private void CheckForLines()
    {
        for(int i = height - 1; i >=0; i--)
        {
            if(CompleteLine(i))
            {
                DeleteBlock(i);
                RowDown(i);
            }
        }
    }

    private bool CompleteLine(int line)
    {
        for(int j = 0; j < width; j++)
        {
            if (blockMap[j, line] == null)
                return false;
        }

        return true;
    }

    private void DeleteBlock(int line)
    {
        for(int j = 0; j < width; j++)
        {
            Destroy(blockMap[j, line].gameObject);
            blockMap[j, line] = null;
        }
    }

    private void RowDown(int line)
    {
        for (int i = line; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (blockMap[j, i] != null)
                {
                    blockMap[j, i - 1] = blockMap[j, i];
                    blockMap[j, i] = null;
                    blockMap[j, i - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }

    private void IndicateBlock()
    {
        indicateBlock.transform.SetPositionAndRotation(cntBlock.transform.position, cntBlock.transform.rotation);
        while (CanMove(indicateBlock))
        {
            indicateBlock.transform.position += new Vector3(0, -1, 0);
        }
        indicateBlock.transform.position += new Vector3(0, 1, 0);
    }
}
