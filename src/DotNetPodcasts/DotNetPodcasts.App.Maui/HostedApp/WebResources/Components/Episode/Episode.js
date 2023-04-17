var n=a=>new t(a),t=class{constructor(e){this.context=e}async play(){await this.context.namedCommands.Play(),dotvvm.webView.notifyMauiPage("Play")}};export{n as default};
