using System.Collections.Generic;
using Kobowi.Pushover.Models;
using Orchard;
using Pushover;

namespace Kobowi.Pushover.Services {
    public interface IPushoverService : IDependency {
        void Push(IPushoverMessage message);

        IEnumerable<PushoverUser> GetPushoverUsers();
    }
}