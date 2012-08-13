using System.Collections.Generic;
using System.Linq;
using Kobowi.Pushover.Models;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Users.Models;
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

        public IEnumerable<PushoverUser> GetPushoverUsers() {
            var users = _orchard.ContentManager.Query<PushoverUserPart>()
                .Join<PushoverUserPartRecord>().Where(u => u.UserKey != null && u.UserKey != "")
                .List();
            return users.Select(u => new PushoverUser().WithUserKey(u.UserKey)
                                         .DisplayedAs(() => u.Is<UserPart>()
                                                                ? u.As<UserPart>().UserName
                                                                : _orchard.ContentManager
                                                                      .GetItemMetadata(u.ContentItem)
                                                                      .DisplayText));
        }

        #endregion
    }
}