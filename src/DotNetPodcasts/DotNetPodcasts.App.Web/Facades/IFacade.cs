using System.Collections.Generic;

namespace DotNetPodcasts.App.Web.Facades;

public interface IFacade<TDetailModel, TListModel>
{
    List<TListModel> GetAll();
    TDetailModel GetById(int id);
    int Save(TDetailModel item);
    int Delete(TDetailModel item);
}