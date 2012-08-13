using Kobowi.Pushover.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;

namespace Kobowi.Pushover.Handlers {
    public class PushoverUserPartHandler : ContentHandler {
        public PushoverUserPartHandler(IRepository<PushoverUserPartRecord> repository) {
            Filters.Add(StorageFilter.For(repository));

            // todo: Finish PushoverUserPart, create new feature for Kobowi.Pushover.Users
            // add address book style functionality to form.
        }
    }
}