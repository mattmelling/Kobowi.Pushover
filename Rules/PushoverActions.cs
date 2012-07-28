using System;
using Kobowi.Pushover.Services;
using Orchard.Localization;
using Orchard.Logging;
using Orchard.Rules.Models;
using Orchard.Rules.Services;
using Orchard.Tokens;
using Pushover;

namespace Kobowi.Pushover.Rules
{
    public class PushoverActions : IActionProvider {
        private readonly ITokenizer _tokenizer;
        private readonly IPushoverService _pushover;

        public Localizer T { get; set; }
        public ILogger Logger { get; set; }

        public PushoverActions(ITokenizer tokenizer, IPushoverService pushover) {
            _tokenizer = tokenizer;
            _pushover = pushover;
            T = NullLocalizer.Instance;
            Logger = NullLogger.Instance;
        }

        #region IActionProvider Members

        public void Describe(DescribeActionContext describe) {
            describe.For("Pushover", T("Pushover"), T("Pushover"))
                .Element("Push", T("Send Pushover Message"), T("Sends a Pushover message to the selected user"),
                         Push, context => T("Send Pushover Message"), "PushoverMessageSettings");
        }

        #endregion

        private bool Push(ActionContext context) {
            var message = new PushoverMessageBase {
                User = _tokenizer.Replace(context.Properties["PushoverUser"], context.Tokens),
                Title = _tokenizer.Replace(context.Properties["MessageTitle"], context.Tokens),
                Message = _tokenizer.Replace(context.Properties["MessageBody"], context.Tokens),
                Url = _tokenizer.Replace(context.Properties["MessageUrl"], context.Tokens),
                UrlTitle = _tokenizer.Replace(context.Properties["MessageUrlTitle"], context.Tokens)
            };
            try {
                _pushover.Push(message);
            }
            catch (Exception e) {
                Logger.Error(e, "Failed to push message to Pushover");
            }
            return true;
        }
    }
}