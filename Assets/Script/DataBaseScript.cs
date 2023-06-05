using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Database", menuName = "Db")]
public class DataBaseScript : ScriptableObject
{
    public List<User> users;
}

[System.Serializable]
public class User
{
    public string user, password, tlf, email;
    //constructor
    public User(string user, string password, string tlf, string email)
    {
        this.user = user;
        this.password = password;
        this.tlf = tlf;
        this.email = email;
    }
}