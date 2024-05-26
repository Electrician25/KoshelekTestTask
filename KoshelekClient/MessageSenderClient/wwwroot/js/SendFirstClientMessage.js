async function sendPostRequest(json, uri) {
    const myHeaders = new Headers()
    myHeaders.append('Content-Type', 'application/json')
    const request = new Request(uri, {
        method: 'POST',
        body: json,
        headers: myHeaders
    });

    let search_result = await fetch(request)
        .then((response) => {
            if(response.status < 400) {
                document.getElementById("error").hidden = true;
                document.getElementById("success").hidden = false;
            }
            else {
                document.getElementById("success").hidden = true;
                document.getElementById("error").hidden = false;
            }
            return response.json();
        })


    return search_result;
}

const createMessageJSON = async () => {

    let message = document.getElementById("inputMessage").value;
    let json = JSON.stringify({ 
        messageText: message,
        date: null
    });
    
    await sendPostRequest(json, `http://localhost:25545/api/MessageSender/Send`);
}