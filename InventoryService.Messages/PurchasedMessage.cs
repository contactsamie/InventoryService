﻿namespace InventoryService.Messages
{
    public class PurchaseCompletedMessage
    {
        public PurchaseCompletedMessage(string productId, int quantity, bool successful)
        {
            ProductId = productId;
            Quantity = quantity;
            Successful = successful;
        }

        public string ProductId { get; private set; }
        public int Quantity { get; private set; }
        public bool Successful { get; private set; }
    }
}