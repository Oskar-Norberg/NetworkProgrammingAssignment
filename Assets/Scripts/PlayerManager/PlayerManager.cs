using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerManager : NetworkBehaviour
{
    [SerializeField] private NetworkObject playerPrefab;

    private int nrOfPlayers => NetworkManager.Singleton.ConnectedClients.Count;
    
    List<NetworkObject> players = new List<NetworkObject>();

    public override void OnNetworkSpawn()
    {
        print("0");
        if (!IsServer || !IsHost) return;
        print("1");
        NetworkManager.OnClientConnectedCallback += SpawnPlayer;
        print("2");
        SpawnPlayer(this.OwnerClientId);
    }

    public override void OnNetworkDespawn()
    {
        NetworkManager.OnClientConnectedCallback -= SpawnPlayer;
    }

    private void SpawnPlayer(ulong clientId)
    {
        print("spawn player");
        NetworkSpawnManager spawnManager = NetworkManager.Singleton.SpawnManager;
        NetworkObject player = spawnManager.InstantiateAndSpawn(playerPrefab, clientId);
        players.Add(player);
    }
}
