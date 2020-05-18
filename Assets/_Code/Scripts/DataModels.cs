using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    [System.Serializable]
    public class GameLobby
    {
        public string Id;
        public string Title;
        public string Host;
        public string Guest;
        public string hostId;
        public string guestId;
        public string Password;
    }

    [System.Serializable]
    class ClientInfo : System.Object
    {
        public string name;
        public string localAddress;
        public int localPort;
        public string address;
        public int port;
        public int conType;
    }
    [System.Serializable]
    public class User
    {
        public string id;
        public string name;
        public string email;
        public string password;
    }

    [System.Serializable]
    public class Request : System.Object
    {
        public string Action;
        public string User;
        public string Payload;
    }
    [System.Serializable]
    public class Payload
    {
        public string Username;
        public string password;
        public string keke;
    }
}
