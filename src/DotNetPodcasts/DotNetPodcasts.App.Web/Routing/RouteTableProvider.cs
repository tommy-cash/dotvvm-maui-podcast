using DotVVM.Framework.Hosting;
using DotVVM.Framework.Routing;
using static DotNetPodcasts.App.Web.Routing.Routes;

namespace DotNetPodcasts.App.Web.Routing;

public class RouteTableProvider
{
    public void ConfigureRoutes(DotvvmRouteTable routeTable)
    {
        routeTable.AddGroup(nameof(Public), "", "Pages", opt =>
        {
            opt.Add(nameof(Public.Default), "{Lang:length(2)}", "Default/Default.dothtml", new { Lang = "en" }, presenterFactory: LocalizablePresenter.BasedOnParameter("Lang"));
            opt.Add(nameof(Public.PodcastDetail), "podcast/{Lang:length(2)}", "PodcastDetail/PodcastDetail.dothtml", new { Lang = "en" }, presenterFactory: LocalizablePresenter.BasedOnParameter("Lang"));
        });
    }
}