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

        [Tooltip("List prefabs name inside dir /Resources/Actors/Players for instantiate online")]
        public String PrefabsPlayerName;

        void Start(){
            DontDestroyOnLoad(gameObject);
            NewConnectionPhoton();
        }

        void NewConnectionPhoton(){
            PhotonNetwork.ConnectUsingSettings(Version);
        }

        void OnConnectedToMaster(){
            string room = (StaticClass.InfoObject != null) ? StaticClass.InfoObject.ToString() : "Marnintong-52";
            PhotonNetwork.JoinOrCreateRoom(room, new RoomOptions{MaxPlayers = 100}, null);
        }

/* Si es posible, mostrar en la parte superior o inferior el nombre de la galaxia a la que está conectado el usuario */
        void OnJoinedRoom(){
            Transform position = Positions[GameManager.RandomBetween(0, Positions.Length - 1)];
            GameManager.InstantiatePhoton("Actors/Players/" + PrefabsPlayerName, position, GroupInstance);
        }
    }
}