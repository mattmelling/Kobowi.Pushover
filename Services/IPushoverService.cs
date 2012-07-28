using Orchard;
using Pushover;

namespace Kobowi.Pushover.Services {
    public interface IPushoverService : IDependency {
        void Push(IPushoverMessage message);
    }
}