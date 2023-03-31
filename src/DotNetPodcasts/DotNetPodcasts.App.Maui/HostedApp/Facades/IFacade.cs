namespace DotNetPodcasts.App.Maui.HostedApp.Facades;

public interface IFacade<TDetailModel, TListModel>
{
    List<TListModel> GetAll();
    TDetailModel GetById(int id);
    int Save(TDetailModel item);
    int Delete(TDetailModel item);
}