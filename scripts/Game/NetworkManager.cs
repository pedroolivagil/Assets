using System;
using System.Collections.Generic;
using Scenes;
using UnityEngine;

namespace Game{
    public class NetworkManager : Photon.MonoBehaviour{
        public string Version;
        public Camera Camera;
        public GameObject GroupInstance;
        public Transform[] Positions;

        [Tooltip("List prefabs name inside dir /Resources/Actors/ for instantiate online")]
        public List<String> PrefabsList;

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
//            GameObject obj = PhotonNetwork.InstantiatePhoton("Actors/Players/PlayerBlue", position.position, Quaternion.identity, 0);
//            obj.transform.parent = GroupInstance.transform;
            foreach (string prefabName in PrefabsList){
                Transform position = Positions[GameManager.RandomBetween(0, Positions.Length - 1)];
                GameManager.InstantiatePhoton("Actors/" + prefabName, position, GroupInstance);
            }
        }
    }
}