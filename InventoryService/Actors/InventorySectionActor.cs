﻿using System;
using Akka.Actor;

namespace InventoryService
{
	public class InventorySectionActor : ReceiveActor
	{
		private string Id;
		private int Quantity;

		public InventorySectionActor (string id)
		{
			Id = id;
			Quantity = 10;
			Receive<ReserveMessage> (message => {
				var newQuantity = Quantity - message.Quantity;
				if (newQuantity >= 0) {
					Quantity = newQuantity;
					Sender.Tell(new ReservedMessage(Id, Quantity, true));
				} else {
					Sender.Tell(new ReservedMessage(Id, Quantity, false));
				}
			});
		}
	}
}

