using UnityEngine;

public class Managers : MonoBehaviour
{
    private static readonly Managers instance; // ���ϼ��� ����ȴ�

    public static Managers Instance
    {
        get
        {
            Init();
            return instance;
        }
    } // ������ �Ŵ����� ����´�

    #region Managers

    SceneManagerT scene = new SceneManagerT();
    DataManager data = new DataManager();

    #endregion


    public static SceneManagerT Scene => instance.scene;
    public static DataManager Data => instance.data;


    private static void Init()
    {
        GameObject go = GameObject.Find("@Managers");
        if (go == null)
        {
            go = new GameObject { name = "@Managers" };
            go.AddComponent<Managers>();
        }
        DontDestroyOnLoad(go);
    }
}
