﻿using Photon;
using Scenes;

namespace Game{
    public class NetworkManager : MonoBehaviour{
        public string Version;

        void Start(){
            DontDestroyOnLoad(gameObject);
            NewConnectionPhoton();
        }

        void NewConnectionPhoton(){
            PhotonNetwork.ConnectUsingSettings(Version);
        }

        void OnConnectedToMaster(){
            PhotonNetwork.JoinOrCreateRoom(StaticClass.InfoObject.ToString(), new RoomOptions{MaxPlayers = 10}, null);
        }

        void OnJoinedRoom(){
//        PhotonNetwork.Instantiate("Sphere", transform.position, transform.rotation, 0);
        }
    }
}