using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using SmogBot.Bot.DatabaseAccessLayer;
using SmogBot.Bot.Helpers;
using Tomaszkiewicz.BotFramework.Dialogs;

namespace SmogBot.Bot.Dialogs
{
    [Serializable]
    public class SelectCityDialog : IDialog<string>
    {
        [NonSerialized]
        private readonly BotAccessor _accessor;

        public SelectCityDialog(BotAccessor accessor)
        {
            _accessor = accessor;
        }

        public Task StartAsync(IDialogContext context)
        {
            context.Call(new SearchDialog(
                SearchFunc,
                "Wygl�da na to, �e jeste� tutaj pierwszy raz i nie wybra�e� jeszcze swojego miasta. Wpisz miasto, dla kt�rego dane chcesz otrzymywa�:",
                "Niestety, nie mamy danych dla tego miasta, spr�buj wpisa� jakie� inne w okolicy:",
                "Czy mo�esz doprecyzowa�, o jakie miasto Ci chodzi?",
                "Nie uda�o si� znale�� miasta."
                ), OnCitySelected);

            return Task.CompletedTask;
        }

        private Task<IEnumerable<string>> SearchFunc(string query)
        {
            return _accessor.SearchCity(query);
        }

        private static async Task OnCitySelected(IDialogContext context, IAwaitable<string> result)
        {
            var city = await result;

            context.PrivateConversationData.SetValue(ConversationDataKeys.City, city);

            await context.PostAsync("Ok, Twoje miasto zosta�o zapami�tane :)\r\nW przysz�o�ci automatycznie poka�� dane dla Twojego miasta.");

            context.Done(city);
        }
    }
}