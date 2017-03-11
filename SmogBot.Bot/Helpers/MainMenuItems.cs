using System;
using System.Collections.Generic;
using Microsoft.Bot.Builder.Dialogs;
using SmogBot.Bot.Dialogs;

namespace SmogBot.Bot.Helpers
{
    public class MainMenuItems : Dictionary<string, Func<IDialog<object>>>
    {
        public MainMenuItems(Func<MeasurementsDialog> measurementsDialogFactory, Func<NewManageNotificationsDialog> manageNotificationsDialogFactory, Func<FeedbackDialog> feedbackDialogFactory, Func<HelpDialog> helpDialogFactory
            )
        {
            Add("Sprawd� przekroczenia norm", measurementsDialogFactory);
            Add("Zarz�dzaj notyfikacjami", manageNotificationsDialogFactory);
            Add("Wy�lij opini� o tym bocie", feedbackDialogFactory);
            Add("Pomoc", helpDialogFactory);
        }
    }
}