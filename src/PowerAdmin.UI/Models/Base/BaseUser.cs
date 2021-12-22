namespace PowerAdmin.UI.Models.Base
{
    public class BaseUser<TUserId>
    {
        public TUserId Id { get; set; } = default!;
    }
}
