// TODO
function attachEvents() {
  const addButton = document.getElementById("add-button");
  const loadButton = document.getElementById("load-button");

  loadButton.addEventListener("click", loadTasks);
  addButton.addEventListener("click", addTask);
}
async function loadTasks() {
  document.getElementById("todo-list").innerHTML = "";

  const tasks = await (
    await fetch("http://localhost:3030/jsonstore/tasks/")
  ).json();

  for (const taskObject of Object.values(tasks)) {
    const listItem = document.createElement("li");
    listItem.id = taskObject["_id"];

    const span = document.createElement("span");
    span.textContent = taskObject.name;
    listItem.appendChild(span);

    const buttonContent = ["Remove", "Edit"];
    for (let i = 0; i < buttonContent.length; i++) {
      const button = document.createElement("button");
      button.textContent = buttonContent[i];
      listItem.appendChild(button);
    }

    document.getElementById("todo-list").appendChild(listItem);
  }

  catchButtonEvent();
}
function catchButtonEvent() {
  const removeButtons = document.querySelectorAll(
    "#todo-list li button:nth-child(even)"
  );

  removeButtons.forEach((button) => {
    button.addEventListener("click", (e) => {
      const id = button.parentElement.id;
      removeTask(id);
    });
  });

  const editButtons = document.querySelectorAll(
    "#todo-list li button:nth-child(odd)"
  );
  editButtons.forEach((button) => {
    button.addEventListener("click", (e) => {
      if (button.textContent === "Edit") {
        const listItem = button.parentElement;
        const span = listItem.querySelector("span");

        const input = document.createElement("input");
        input.value = span.textContent;
        span.replaceWith(input);

        listItem.querySelectorAll(`button`)[1].textContent = "Submit";
      } else {
        const id = button.parentElement.id;
        const name = button.parentElement.querySelector(`input`).value;
        fetch(`http://localhost:3030/jsonstore/tasks/${id}`, {
          method: "put",
          body: JSON.stringify({ name, _id: id }),
        });
        loadTasks();
      }
    });
  });
}
function addTask() {
  const taskName = document.getElementById("title").value;
  fetch("http://localhost:3030/jsonstore/tasks/", {
    method: "post",
    body: JSON.stringify({ name: taskName }),
  });
  loadTasks();
}
function removeTask(id) {
  fetch(`http://localhost:3030/jsonstore/tasks/${id}`, {
    method: "delete",
  });
  loadTasks();
}

attachEvents();
