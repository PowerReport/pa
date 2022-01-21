namespace PowerAdmin.Blazor.Models.Base
{
    public class BaseUser<TUserId>
    {
        public TUserId Id { get; set; } = default!;
    }
}
