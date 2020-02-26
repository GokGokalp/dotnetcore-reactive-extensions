const connection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:5001/hubs/chat")
    .build();

document.getElementById("sendMessage").addEventListener("click", event => {
    const message = document.getElementById("message").value;
    const sender = document.getElementById("sender").value;

    connection.invoke("SendMessage", sender, message).catch(err => console.error(err.toString()));
    event.preventDefault();
});

connection.on("chat", (sender, message) => {
    const recMessage = sender + ": " + message;
    const li = document.createElement("li");

    li.textContent = recMessage;
    document.getElementById("messageList").appendChild(li);
});

connection.start().catch(err => console.error(err.toString()));