using System;

namespace DotNetPodcasts.App.Web.Models;

public abstract class ModelBase : IModel
{
    public int Id { get; set; }
}