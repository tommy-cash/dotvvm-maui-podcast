using DotVVM.Framework.Hosting;
using DotVVM.Framework.Routing;
using static DotNetPodcasts.App.Maui.HostedApp.Routing.Routes;

namespace DotNetPodcasts.App.Maui.HostedApp.Routing;

public class RouteTableProvider
{
    public void ConfigureRoutes(DotvvmRouteTable routeTable)
    {
        routeTable.AddGroup(nameof(Public), "", "Pages", opt =>
        {
            opt.Add(nameof(Public.Default), "{Lang:length(2)}", "Default/Default.dothtml", new { Lang = "en" }, presenterFactory: LocalizablePresenter.BasedOnParameter("Lang"));
            opt.Add(nameof(Public.PodcastDetail), "{Lang:length(2)}/podcast/{Id:int}", "PodcastDetail/PodcastDetail.dothtml", new { Lang = "en" }, presenterFactory: LocalizablePresenter.BasedOnParameter("Lang"));
            opt.Add(nameof(Public.SubscribedPodcasts), "{Lang:length(2)}/subscribed-podcasts", "SubscribedPodcasts/SubscribedPodcasts.dothtml", new { Lang = "en" }, presenterFactory: LocalizablePresenter.BasedOnParameter("Lang"));
            opt.Add(nameof(Public.ListenLater), "{Lang:length(2)}/listen-later", "ListenLater/ListenLater.dothtml", new { Lang = "en" }, presenterFactory: LocalizablePresenter.BasedOnParameter("Lang"));
        });
    }
}