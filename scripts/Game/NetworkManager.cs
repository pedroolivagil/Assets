using Scenes;
using UnityEngine;

namespace Game{
    public class NetworkManager : Photon.MonoBehaviour{
        public string Version;
        public Camera Camera;
        public Transform[] Positions;

        void Start(){
            DontDestroyOnLoad(gameObject);
            NewConnectionPhoton();
        }

        void NewConnectionPhoton(){
            PhotonNetwork.ConnectUsingSettings(Version);
        }

        void OnConnectedToMaster(){
            string room = (StaticClass.InfoObject != null) ? StaticClass.InfoObject.ToString() : "Marnintong-52";
            PhotonNetwork.JoinOrCreateRoom(room, new RoomOptions{MaxPlayers = 10}, null);
        }

        void OnJoinedRoom(){
            Transform position = Positions[GameManager.RandomBetween(0, Positions.Length - 1)];
            PhotonNetwork.Instantiate("Actors/Player", position.position, Quaternion.identity, 0);
        }
    }
}