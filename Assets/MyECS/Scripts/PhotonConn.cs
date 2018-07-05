using UnityEngine;
using MonoBehaviour = Photon.MonoBehaviour;

public class PhotonConn : MonoBehaviour
{
    public string versionName = "0.1";

    private void Start()
    {
        connectToPhoton();
    }

    public void connectToPhoton()
    {
        PhotonNetwork.ConnectUsingSettings(versionName);
        Debug.Log("Connectin to photon...");
    }

    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("We are connected to master");
    }

    private void OnJoinedLobby()
    {
        Debug.Log("On Joined Lobby");
    }

    private void OnDisconnectedFromPhoton(NetworkDisconnection info)
    {
        Debug.Log("Dis from photon services");
    }
}