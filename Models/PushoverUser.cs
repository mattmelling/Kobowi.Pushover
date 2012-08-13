using System;

namespace Kobowi.Pushover.Models {
    public class PushoverUser {

        private Func<string> _display;

        public string DisplayText { get { return _display(); } }
        public string UserKey { get; private set; }

        public PushoverUser DisplayedAs(Func<string> display) {
            _display = display;
            return this;
        }

        public PushoverUser WithUserKey(string key) {
            UserKey = key;
            return this;
        }
    }
}