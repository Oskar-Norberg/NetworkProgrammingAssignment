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
        if (!IsServer || !IsHost) return;
        
        NetworkManager.OnClientConnectedCallback += SpawnPlayer;
        NetworkManager.OnClientDisconnectCallback += DespawnPlayer;
        
        SpawnPlayer(this.OwnerClientId);
    }

    public override void OnNetworkDespawn()
    {
        NetworkManager.OnClientConnectedCallback -= SpawnPlayer;
        NetworkManager.OnClientDisconnectCallback -= DespawnPlayer;
    }

    private void SpawnPlayer(ulong clientId)
    {
        print("spawn player");
        NetworkSpawnManager spawnManager = NetworkManager.Singleton.SpawnManager;
        NetworkObject player = spawnManager.InstantiateAndSpawn(playerPrefab, clientId);
        
        players[clientId] = player.GetComponent<Player>();
    }
    
    private void DespawnPlayer(ulong clientId)
    {
        players[clientId].GetComponent<NetworkObject>().Despawn();
    }

    public Player GetPlayer(ulong clientId)
    {
        return players[clientId];
    }
}
