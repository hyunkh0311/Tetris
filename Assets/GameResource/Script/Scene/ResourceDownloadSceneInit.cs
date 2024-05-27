using UnityEngine;

public class ResourceDownloadSceneInit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public async void StartDownload()
    {
        // 다운로드 체크


        // 다운로드 완료
        await Managers.Data.LoadScript();
    }

}
