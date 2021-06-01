using System.ComponentModel;

namespace KLoveCoding.Enums
{
    public enum HttpCustomStatusCode
    {
        [Description("Error")]
        ERROR,
        [Description("Success")]
        SUCCESS,
        [Description("Warning")]
        WARNING
    }
}
