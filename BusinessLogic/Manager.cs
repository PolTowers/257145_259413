﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace BusinessLogic
{
    public class Manager
    {
        public Client logged { get; set; }
        public List<Client> clients;

        public Manager() 
        {
            this.clients = new List<Client>();
        }

        public void add(Client client1)
        {
            foreach (Client client in clients)
            {
                if (client.name == client1.name)
                {
                    return;
                }
            }
            this.clients.Add(client1);
        }

        public Client logIn(string name, string password)
        {
            foreach (Client client in clients)
            {
                if (client.MatchingUsername(name) && client.MatchingPassword(password))
                {
                    this.logged = client;
                    return client;
                }
            }
            return null;
        }

        public bool Verify()
        {
            if(clients.Count == 0)
            {
                return false;
            }
            if(clients.Count == 1)
            {
                return true;
            }
            for(int i= 0; i < clients.Count; i++)
            {
                for(int j = i+1; j < clients.Count; j++)
                {
                    if (clients[i].name == clients[j].name)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public Client SignUp(string name, string password)
        {
            Client client= new Client();
            if (!client.VerifyName(name) || !client.VerifyPassword(password) || Exists(name))
            {
                return client;
            }
            client.name = name;
            client.password = password;
            return client;
        }

        private bool Exists(string name)
        {
            foreach(Client client in clients)
            {
                if (client.MatchingUsername(name))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
