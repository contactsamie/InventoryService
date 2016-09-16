﻿using Akka.Actor;
using System;
using System.Configuration;
using Akka.Configuration;

namespace InventoryService.ActorSystemFactoryLib
{
    public class ActorSystemFactory
    {
        /// <summary>
        /// Any actor system passed in can be terminated if 'TerminateActorSystem()' is called on a disposable
        /// </summary>
        /// <param name="serverActorSystemName"></param>
        /// <param name="actorSystem"></param>
        /// <param name="actorSystemConfig"></param>
        public static void CreateOrSetUpActorSystem(string serverActorSystemName = null,ActorSystem actorSystem = null, string actorSystemConfig=null )
        {

            var actorSystemName = ConfigurationManager.AppSettings["ServerActorSystemName"];
            if (string.IsNullOrEmpty(actorSystemName))
            {
                actorSystemName = serverActorSystemName;
            }

            if (string.IsNullOrEmpty(actorSystemName))
            {
                InventoryServiceActorSystem = actorSystem;
            }
            else
            {
                InventoryServiceActorSystem = (string.IsNullOrEmpty(actorSystemConfig) ?
                    Akka.Actor.ActorSystem.Create(actorSystemName) : 
                    Akka.Actor.ActorSystem.Create(serverActorSystemName, ConfigurationFactory.ParseString(actorSystemConfig)));
            }

        

            if (InventoryServiceActorSystem != null) return;
            const string message ="Invalid ActorSystemName.Please set up 'ServerActorSystemName' in the config file";
            Console.WriteLine(message);
            throw new Exception(message);
        }

        public static ActorSystem InventoryServiceActorSystem { get; set; }

        public static void TerminateActorSystem()
        {
            InventoryServiceActorSystem.Terminate();
            InventoryServiceActorSystem.Dispose();
        }
    }
}