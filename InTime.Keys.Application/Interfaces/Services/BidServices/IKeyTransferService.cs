﻿using InTime.Keys.Application.DTOs.KeyTransferDTOs;

namespace InTime.Keys.Application.Interfaces.Services.BidServices;

public interface IKeyTransferService
{
    Task TransferKey(Guid senderId, Guid receiverId, Guid keyId, int timeSlot, DateTime date);
    Task ApporveTransfer(string hash);
    Task<List<KeyTransferDto>> GetUserTransfers(Guid userId);
}
