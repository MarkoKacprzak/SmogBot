using System;
using SmogBot.Bot.Tools;

namespace SmogBot.Bot.Dialogs
{
    [Serializable]
    public class MainMenuDialog : MenuDialogDispatcher
    {
        public MainMenuDialog(Func<MeasurementsDialog> measurementsDialogFactory, Func<NewManageNotificationsDialog> manageNotificationsDialogFactory, Func<FeedbackDialog> feedbackDialogFactory, Func<HelpDialog> helpDialogFactory)
        {
            RegisterMenuItem("Sprawd� przekroczenia norm", measurementsDialogFactory);
            RegisterMenuItem("Zarz�dzaj notyfikacjami", manageNotificationsDialogFactory);
            RegisterMenuItem("Wy�lij opini� o tym bocie", feedbackDialogFactory);
            RegisterMenuItem("Pomoc", helpDialogFactory);
        }
    }
}