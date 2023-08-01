const API_URL = "http://localhost:3030/jsonstore/tasks/";

const tasksSelector = {
  ToDo: document.querySelector("#todo-section ul"),
  "In Progress": document.querySelector("#in-progress-section ul"),
  "Code Review": document.querySelector("#code-review-section ul"),
  Done: document.querySelector("#done-section ul"),
};

const buttonsContent = {
  ToDo: "Move to In Progress",
  "In Progress": "Move to Code Review",
  "Code Review": "Move to Done",
  Done: "Close",
};

const inputFields = {
  title: document.getElementById("title"),
  description: document.getElementById("description"),
};

const moveStatuses = {
  ToDo: "In Progress",
  "In Progress": "Code Review",
  "Code Review": "Done",
};

let allTasks = [];

function attachEvents() {
  document
    .getElementById("load-board-btn")
    .addEventListener("click", loadTasks);

  document.getElementById("create-task-btn").addEventListener("click", addTask);
}

async function loadTasks() {
  Object.values(tasksSelector).forEach((selector) => {
    selector.innerHTML = "";
  });

  const response = await fetch(API_URL);
  const tasks = await response.json();

  allTasks = [];
  Object.values(tasks).forEach((task) => {
    allTasks.push(task);
    const listItem = createElement(
      "li",
      null,
      ["task"],
      task._id,
      tasksSelector[task.status]
    );
    createElement("h3", task.title, null, null, listItem);
    createElement("p", task.description, null, null, listItem);
    const moveButton = createElement(
      "button",
      buttonsContent[task.status],
      null,
      null,
      listItem
    );

    moveButton.addEventListener("click", moveTask);
  });
}

function createElement(type, textContent, classes, id, parentElement) {
  const element = document.createElement(type);

  if (textContent) {
    element.textContent = textContent;
  }

  if (classes && classes.length > 0) {
    element.classList.add(...classes);
  }

  if (id) {
    element.id = id;
  }

  if (parentElement) {
    parentElement.appendChild(element);
  }

  return element;
}

function addTask() {
  const task = {
    title: inputFields["title"].value,
    description: inputFields["description"].value,
    status: "ToDo",
  };

  fetch(API_URL, {
    method: "POST",
    body: JSON.stringify(task),
  });

  Object.values(inputFields).forEach((input) => {
    input.value = "";
  });

  loadTasks();
}

function moveTask(e) {
  const id = e.target.parentElement.id;
  const task = allTasks.find((task) => task._id === id);
  task.status = moveStatuses[task.status];

  let method = "PATCH";
  let body = JSON.stringify(task);

  if (e.target.textContent === "Close") {
    method = "DELETE";
    body = undefined;
  }

  fetch(API_URL + id, {
    method,
    body,
  });

  loadTasks();
}
attachEvents();
