namespace InTime.Keys.Application.DTOs.KeyTransferDTOs;

public class KeyTransferDto
{
    public Guid SenderId { get; set; }
    public Guid RecieverId { get; set; }
    public string SenderName { get; set; }
    public string RecieverName { get; set; }
    public KeyTransferDto(Guid senderId, Guid recieverId, string senderName = "", string recieverName = "")
    {
        SenderId = senderId;
        RecieverId = recieverId;
        SenderName = senderName;
        RecieverName = recieverName;
    }
}