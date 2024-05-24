
async function getMessage() {
    let input = document.getElementById("input").value;
    console.log(input);
    let messages = await sendGetRequest(`https://localhost:7179/api/GetMessagesByDate/Date?dateTime=${input}`);
    if (messages.length == 0) {
        renderMessageOnPage();
        let empty = document.createElement("a");
        empty.append("Date not find!");
        document.getElementById("mainInput").append(empty);
    }
    else {
        let t = document.getElementById("mainInput");
        t.innerHTML = "";
    }
    for (let i = 0; i < messages.length; i++) {
        let message = messages[i];
        ViewMessageOnThePage(message);
    }
}

function ViewMessageOnThePage(message) {
    let messageElement = document.createElement("li");
    let resultMessage = "MESSAGE=" + message.messageText + "  ";//"MESSAGE=${message.messageText}" + "   ";
    let date = "DATE=" + message.date + "  ";//"DATE=message.date" + "   ";
    messageElement.className = "messgae";
    messageElement.id = "messageElementId"
    messageElement.append(resultMessage);
    messageElement.append(date);
    document.getElementById("mainInput").append(messageElement);
    return messageElement;
}

function sendGetRequest(uri) {
    const myHeaders = new Headers()
    myHeaders.append('Content-Type', 'application/json')
    const request = new Request(uri, {
        method: 'GET',
        headers: myHeaders
    });

    let search_result = fetch(request)
        .then((response) => {
            return response.json();
        })

    return search_result;
}

function renderMessageOnPage() {
    let blogsHolder = document.getElementById("mainInput");
    blogsHolder.innerHTML = "";

    //getMessage();
}