using MahApps.Metro.Controls.Dialogs;

namespace ExaminationProgram.Interfaces
{
    public interface IDialogControllerWithContext
    {
        object Context { get; }
        IDialogCoordinator DialogCoordinator { get; }

        void SetDialogCoordinator(IDialogCoordinator dialogCoordinator, object context);
    }
}
