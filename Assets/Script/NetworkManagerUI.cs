using Unity.Netcode;
using UnityEngine;

public class NetworkManagerUI : MonoBehaviour
{
    public void OnHostButtonClicked()
    {
        NetworkManager.Singleton.StartHost();
    }

    public void OnServerButtonClicked()
    {
        NetworkManager.Singleton.StartServer();
    }

    public void OnClientButtonClicked()
    {
        NetworkManager.Singleton.StartClient();
    }
}
