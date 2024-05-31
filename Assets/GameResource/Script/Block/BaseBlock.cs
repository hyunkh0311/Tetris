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
        
    }


}
