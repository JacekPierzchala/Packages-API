namespace Zadanie2.Application
{
    public interface IRecipientCommands
    {
        Task AddRecipientCommand(AddRecipientDTO addRecipientDTO);
        Task EditRecipientCommand(EditRecipientDTO editRecipientDTO);
    }
}