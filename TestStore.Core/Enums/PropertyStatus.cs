
using System.ComponentModel;

namespace TestStore.Core.Enums
{
    public enum PropertyStatus
    {
        Live = 1,
        [Description("Not live")]
        NotLive
    }
}