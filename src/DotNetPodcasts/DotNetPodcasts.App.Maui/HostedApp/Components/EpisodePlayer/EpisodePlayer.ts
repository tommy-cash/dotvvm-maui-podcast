
export default context => new EpisodePlayer(context);

class EpisodePlayer {

    constructor(context) {
        this.context = context;

        dotvvm.events.initCompleted.subscribe(() => {
            const podcastPlayer = document.querySelector(".player-panel");
            const podcastPlayerPropName = podcastPlayer.getAttribute("data-prop-name");
            const podcastPlayerViewModelPropName = "EpisodePlayerViewModel";

            const elapsedEpisodeTimeBar = document.querySelector(".player-panel__playback-tools__timer > input");
            const elapsedEpisodeTimePropName = elapsedEpisodeTimeBar.getAttribute("data-prop-name");

            elapsedEpisodeTimeBar.addEventListener("change", function (e) {
                const setTime = e.target.value;
                const patchedElapsedEpisodeTime = {
                    [podcastPlayerViewModelPropName]: {
                        [podcastPlayerPropName]: { [elapsedEpisodeTimePropName]: setTime }
                    }
                };
                dotvvm.patchState(patchedElapsedEpisodeTime);
            });

            const volumeBar = document.querySelector(".player-panel__playback-options__volume > input");
            const volumePropName = volumeBar.getAttribute("data-prop-name");

            volumeBar.addEventListener("change", function (e) {
                const volume = e.target.value;

                //await context.namedCommands["VolumeUpdated"](volume);

                const patchedVolume = {
                    [podcastPlayerViewModelPropName]: {
                        [podcastPlayerPropName]: { [volumePropName]: volume }
                    }
                };
                dotvvm.patchState(patchedVolume);
            });

            window.setInterval(function () {
                let refreshBtn = document.getElementById("refresh-button");
                refreshBtn.click();
            }, 1000);
        });
    }
}