using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerManager : NetworkBehaviour
{
    [SerializeField] private NetworkObject playerPrefab;

    private int nrOfPlayers => NetworkManager.Singleton.ConnectedClients.Count;
    
    Dictionary<ulong, Player> players = new Dictionary<ulong, Player>();
    
    public static PlayerManager Instance { get; private set; }

    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

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
        
        players[clientId] = player.GetComponent<Player>();
    }

    public Player GetPlayer(ulong clientId)
    {
        return players[clientId];
    }
}
