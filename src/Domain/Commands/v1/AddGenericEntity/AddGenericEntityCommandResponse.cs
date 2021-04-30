namespace LiquidCRUDExample.Domain.Commands.v1.AddGenericEntity
{
    public class AddGenericEntityCommandResponse<TIdentifier>
    {
        public TIdentifier Data { get; set; }

        public AddGenericEntityCommandResponse(TIdentifier data)
        {
            Data = data;
        }
    }
}
