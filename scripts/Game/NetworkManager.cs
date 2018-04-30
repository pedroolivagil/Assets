using Photon;

public class NetworkManager : MonoBehaviour{
    public string Version;

    void Start(){
        PhotonNetwork.ConnectUsingSettings(Version);
    }

    void OnConnectedToMaster(){
        PhotonNetwork.JoinOrCreateRoom("Galaxy 1", new RoomOptions(){MaxPlayers = 10}, null);
    }

    void OnJoinedRoom(){
        PhotonNetwork.Instantiate("Sphere", transform.position, transform.rotation, 0);
    }
}