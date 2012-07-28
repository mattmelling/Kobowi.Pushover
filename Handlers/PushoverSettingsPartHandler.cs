using Kobowi.Pushover.Models;
using Orchard;
using Orchard.Caching;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;

namespace Kobowi.Pushover.Handlers {
    public class PushoverSettingsPartHandler : ContentHandler {
        public PushoverSettingsPartHandler(IRepository<PushoverSettingsPartRecord> repository, IOrchardServices orchard, ICacheManager cache) {
            Filters.Add(StorageFilter.For(repository));
            Filters.Add(new ActivatingFilter<PushoverSettingsPart>("Site"));
        }
    }
}