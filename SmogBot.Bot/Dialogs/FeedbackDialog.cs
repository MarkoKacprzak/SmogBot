using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace SmogBot.Bot.Dialogs
{
    [Serializable]
    public class FeedbackDialog : IDialog<string>
    {
        private string _feedback = "";

        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Napisz swoj� opini�, gdy sko�czysz wpisz 'koniec' w osobnej wiadomo�ci.");

            context.Wait(MessageReceivedAsync);
        }

        public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;

            if (message != null && message.Text.ToLower() == "koniec")
            {
                _feedback = _feedback.Trim();

                await context.PostAsync($"Twoja opinia:\r\n{_feedback}");

                PromptDialog.Confirm(context, SendFeedback, "Wys�a� opini�?");

                return;
            }

            if (message?.Text != null)
                _feedback += message.Text + "\r\n";

            context.Wait(MessageReceivedAsync);
        }

        private async Task SendFeedback(IDialogContext context, IAwaitable<bool> result)
        {
            var send = await result;

            if (send)
                await context.PostAsync("Opinia wys�ana. Dzi�kuj� :)");

            context.Done(_feedback);
        }
    }
}