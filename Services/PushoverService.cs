using Kobowi.Pushover.Models;
using Orchard;
using Orchard.ContentManagement;
using Pushover;

namespace Kobowi.Pushover.Services {
    public class PushoverService : IPushoverService {
        private readonly IOrchardServices _orchard;

        public PushoverService(IOrchardServices orchard) {
            _orchard = orchard;
        }

        #region IPushoverService Members

        public void Push(IPushoverMessage message) {
            var apiKey = _orchard.WorkContext.CurrentSite.As<PushoverSettingsPart>().ApiKey;
            var client = new PushoverClient(apiKey);
            client.Push(message);
        }

        #endregion
    }
}