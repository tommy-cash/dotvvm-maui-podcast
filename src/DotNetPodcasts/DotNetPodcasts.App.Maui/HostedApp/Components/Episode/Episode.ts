
export default context => new Episode(context);

class Episode {

    constructor(context) {
        this.context = context;
    }

    async play() {
        await this.context.namedCommands["Play"]();
        dotvvm.webView.notifyMauiPage("Play");
    }
}