using Orchard.ContentManagement;

namespace Kobowi.Pushover.Models {
    public class PushoverUserPart : ContentPart<PushoverUserPartRecord> {
        public string UserKey {
            get { return Record.UserKey; }
            set { Record.UserKey = value; }
        }
    }
}