async function connect() {
    let connectionUrl = "wss://localhost:7179/api/SendMessageToClientBySockets/ws";
    const webSocket = new WebSocket(connectionUrl);
    console.log(webSocket.readyState);
    let input = document.getElementById("input");
    webSocket.onmessage = (event) => {
        console.log(event.data);
        input.innerHTML += `<li><a>${event.data}</a></li>`;
    };

    let succsessLabel = document.getElementById("success");
    let errorLabel = document.getElementById("error");
    let closedLabel = document.getElementById("closed");

    switch (webSocket.readyState) {
        case WebSocket.CLOSED:
            closedLabel.hidden = false;
            break;
        case WebSocket.CONNECTING:
            succsessLabel.hidden = false;
            break;
        default:
            errorLabel.hidden = false;
            break;
    };
}