﻿using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

namespace Networking
{
	public class Launcher : MonoBehaviourPunCallbacks
	{
		#region Private Serializable Fields

		/// <summary>
		/// The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created.
		/// </summary>
		[Tooltip("The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created")]
		[SerializeField]
		private byte maxPlayersPerRoom = 2;


		public string levelToLoad;
		[Tooltip("The Ui Panel to let the user enter name, connect and play")]
		[SerializeField]
		private GameObject controlPanel;
		[Tooltip("The UI Label to inform the user that the connection is in progress")]
		[SerializeField]
		private GameObject progressPanel;

		#endregion


		#region Private Fields


		/// <summary>
		/// This client's version number. Users are separated from each other by gameVersion (which allows you to make breaking changes).
		/// </summary>
		string gameVersion = "1";


		#endregion


		#region MonoBehaviour CallBacks


		
		/// <summary>
		/// MonoBehaviour method called on GameObject by Unity during early initialization phase.
		/// </summary>
		void Awake()
		{
			// #Critical
			// this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
			PhotonNetwork.AutomaticallySyncScene = true;
		}


		/// <summary>
		/// MonoBehaviour method called on GameObject by Unity during initialization phase.
		/// </summary>
		void Start()
		{
			progressPanel.SetActive(false);
			controlPanel.SetActive(true);
			
		
		}


		#endregion


		public GameObject levelSelectDropdown;
		 

		bool isConnecting;

		/// <summary>
		/// Start the connection process.
		/// - If already connected, we attempt joining a random room
		/// - if not yet connected, Connect this application instance to Photon Cloud Network
		/// </summary>
		public void Connect(string playmode)
		{
			isConnecting = true;
			progressPanel.SetActive(true);

			// we check if we are connected or not, we join if we are , else we initiate the connection to the server.
			if (PhotonNetwork.IsConnected)
			{
				// #Critical we need at this point to attempt joining a Random Room. If it fails, we'll get notified in OnJoinRandomFailed() and we'll create one.
				PhotonNetwork.JoinRandomRoom();
			}
			else
			{
				// #Critical, we must first and foremost connect to Photon Online Server.
				PhotonNetwork.GameVersion = gameVersion;
				PhotonNetwork.ConnectUsingSettings();
			}

			PhotonNetwork.NickName = playmode;
			Debug.Log(PhotonNetwork.NickName);
		}

	
		public override void OnDisconnected(DisconnectCause cause)
		{
			progressPanel.SetActive(false);
			Debug.LogWarningFormat("OnDisconnected() was called by PUN with reason {0}", cause);
		}

		public override void OnConnectedToMaster()
		{
			Debug.Log("OnConnectedToMaster() was called by PUN");
			if (isConnecting)
			{
				// #Critical: The first we try to do is to join a potential existing room. If there is, good, else, we'll be called back with OnJoinRandomFailed()
				PhotonNetwork.JoinRandomRoom();
				isConnecting = false;
			}
		}

		public override void OnJoinRandomFailed(short returnCode, string message)
		{
			Debug.Log("OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");

			// #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
			PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
		}

		public override void OnJoinedRoom()
		{
			Debug.Log("OnJoinedRoom() called by PUN. Now this client is in a room.");

			if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
			{
				
				Text dropdownText = levelSelectDropdown.GetComponent<Text>();
				string dropdownValue = dropdownText.text;
				Debug.Log("Dropdown Text is: "+dropdownValue);

				Debug.Log(dropdownValue+" is loading");

				PlayerPrefs.SetInt("level",1);
				// #Critical
				// Load the Room Level.
				PhotonNetwork.LoadLevel(dropdownValue);
				
			}

		}

	}
}
