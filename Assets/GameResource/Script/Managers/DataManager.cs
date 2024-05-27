using System.Threading.Tasks;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public async Task LoadScript()
    {
        await LoadScriptStep1();
        await LoadScriptStep2();
    }

    private async Task LoadScriptStep1()
    {
        await Task.WhenAll();
    }

    private async Task LoadScriptStep2()
    {
        await Task.WhenAll();
    }
}
