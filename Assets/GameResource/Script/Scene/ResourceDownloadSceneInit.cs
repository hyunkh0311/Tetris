using UnityEngine;

public class ResourceDownloadSceneInit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public async void StartDownload()
    {
        // �ٿ�ε� üũ


        // �ٿ�ε� �Ϸ�
        await Managers.Data.LoadScript();
    }

}
