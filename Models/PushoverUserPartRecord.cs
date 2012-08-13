using Orchard.ContentManagement.Records;

namespace Kobowi.Pushover.Models {
    public class PushoverUserPartRecord : ContentPartRecord {
        public virtual string UserKey { get; set; }
    }
}