function attachEvents() {
  const sendButton = document.getElementById("submit");
  const refreshButton = document.getElementById("refresh");

  sendButton.addEventListener("click", postMessages);
  refreshButton.addEventListener("click", refreshMessages);
}
function postMessages() {
  const authorName = document.querySelector("input[name=author").value;
  const messageToSend = document.querySelector("input[name=content]").value;

  if (!authorName || !messageToSend) {
    document.getElementById("messages").value = "Error!";
    return;
  }

  const obj = {
    author: authorName,
    content: messageToSend,
  };

  fetch("http://localhost:3030/jsonstore/messenger", {
    method: "post",
    headers: { "Content-type": "aplication/json" },
    body: JSON.stringify(obj),
  });
}
function refreshMessages() {
  fetch("http://localhost:3030/jsonstore/messenger")
    .then((res) => res.json())
    .then((messages) => {
      const ouput = [];
      for (const obj of Object.values(messages)) {
        ouput.push(`${obj.author}: ${obj.content}`);
      }
      document.getElementById("messages").value = ouput.join("\n");
    });
}
attachEvents();
