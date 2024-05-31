using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers instance; // ���ϼ��� ����ȴ�

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
    GameManager game = new GameManager();

    #endregion


    public static SceneManagerT Scene => Instance.scene;
    public static DataManager Data => Instance.data;


    private static void Init()
    {
        if (instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go);

            instance = go.GetComponent<Managers>();
        }
    }
}
