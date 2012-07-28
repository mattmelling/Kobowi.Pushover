using Orchard.ContentManagement.Records;

namespace Kobowi.Pushover.Models {
    public class PushoverSettingsPartRecord : ContentPartRecord {
        public virtual string ApiKey { get; set; }
    }
}