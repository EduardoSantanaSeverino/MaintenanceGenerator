namespace MG.Application.Generic
{
    public interface IGenerateControls
    {
        List<IItemToReplace> ItemToReplaces { get; }

        void AddInputControls(IFrmMainApp form);

        void AddOutputControls();
    }
}
